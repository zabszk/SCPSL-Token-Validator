using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Token_Validator_Windows.Utils;
using ZXing;
using ZXing.Common;

namespace Token_Validator_Windows
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            return lpPoint;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        private const string MsgHeader = "SCP:SL Token Validator v. 2.0.3";

        private static DecodingOptions DecOpt;
        private static string ApiToken;
        private static bool Authed;

        private enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            DecOpt = new DecodingOptions
            {
                PossibleFormats = new[] { BarcodeFormat.QR_CODE },
                TryHarder = true
            };

            if (!File.Exists(FileManager.AppFolder + "StaffAPI.txt")) return;
            ApiToken = FileManager.ReadAllLines(FileManager.AppFolder + "StaffAPI.txt")[0];
            Authed = true;
            authedLabel.Text = "Authenticated using staff API token.";
            authedLabel.ForeColor = Color.DeepSkyBlue;

            RegisterHotKey(Handle, 1, (int)KeyModifier.Alt, Keys.F12.GetHashCode());
        }

        private void scanQR_Click(object sender, EventArgs e)
        {
            Visible = false;
            Thread.Sleep(150);
            var screens = Screen.AllScreens;
            foreach (var screen in screens)
            {
                var screenshot = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
                var graphics = Graphics.FromImage(screenshot);
                graphics.CopyFromScreen(screen.Bounds.Left, screen.Bounds.Top, 0, 0, screenshot.Size);

                var bitmap = new Bitmap(screenshot);

                BarcodeReader reader = new BarcodeReader { AutoRotate = false, Options = DecOpt };
                Result result = reader.Decode(bitmap);
                if (result == null) continue;
                string decoded = result.ToString().Trim();

                new Thread(() => Request(decoded)){IsBackground = true, Name = "Token validation", Priority = ThreadPriority.AboveNormal}.Start();
                Visible = true;
                return;
            }

            MessageBox.Show("QR code not found.", MsgHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Visible = true;
        }

        private void FromClipboard_Click(object sender, EventArgs e)
        {
            var token = Clipboard.GetText().Replace("\n\r", "<br>").Replace("\n", "<br>");
            new Thread(() => Request(token)) { IsBackground = true, Name = "Token validation", Priority = ThreadPriority.AboveNormal }.Start();
        }

        private void Request(string auth)
        {
            fromClipboard.Enabled = false;
            scanQR.Enabled = false;
            userIDLabel.Text = "";
            nicknameLabel.Text = "";
            issuanceLabel.Text = "";
            expirationLabel.Text = "";

            statusLabel.Text = "Token validation in progress...";
            statusPanel.BackColor = Color.DarkGray;

            try
            {
                var decoded = JsonConvert.DeserializeObject<Dictionary<string, string>>(HttpQuery.Post(
                    "https://api.scpslgame.com/v5/tools/validatetoken.php",
                    $"auth={WebUtility.UrlEncode(auth)}" + (Authed ? "&token=" + ApiToken : "")));

                if (decoded["success"] == "false")
                {
                    statusLabel.Text = "Error: " + decoded["error"];
                    statusPanel.BackColor = Color.Crimson;

                    fromClipboard.Enabled = true;
                    scanQR.Enabled = true;
                    return;
                }

                if (decoded["verified"] == "false")
                {
                    statusLabel.Text = "Digital signature invalid";
                    statusPanel.BackColor = Color.Crimson;

                    fromClipboard.Enabled = true;
                    scanQR.Enabled = true;
                    return;
                }

                userIDLabel.Text = decoded["UserID"];
                nicknameLabel.Text = Base64Decode(decoded["Nickname"]);
                issuanceLabel.Text = decoded["Issuance time"];
                expirationLabel.Text = decoded["Expiration time"];

                if (!decoded.ContainsKey("clean") || !decoded.ContainsKey("GlobalBan"))
                {
                    if (decoded["newToken"] == "false")
                    {
                        statusLabel.Text = "Signature verification successful, token is old.";
                        statusPanel.BackColor = Color.MediumAquamarine;
                    }
                    else
                    {
                        statusLabel.Text = "Signature verification successful";
                        statusPanel.BackColor = Color.DeepSkyBlue;
                    }

                    fromClipboard.Enabled = true;
                    scanQR.Enabled = true;
                    return;
                }

                if (decoded["clean"] == "true")
                {
                    if (decoded["newToken"] == "false")
                    {
                        statusLabel.Text = "Signature verification successful, token is old.";
                        statusPanel.BackColor = Color.MediumAquamarine;
                    }
                    else
                    {
                        statusLabel.Text = "Signature verification successful, not banned in any game, token is old.";
                        statusPanel.BackColor = Color.Teal;
                    }
                }
                else
                {
                    if (decoded["GlobalBan"] == "true")
                    {
                        if (decoded["newToken"] == "false")
                        {
                            statusLabel.Text = "Signature verification successful, banned in SCP:SL, token is old.";
                            statusPanel.BackColor = Color.OrangeRed;
                        }
                        else
                        {
                            statusLabel.Text = "Signature verification successful, banned in SCP:SL.";
                            statusPanel.BackColor = Color.OrangeRed;
                        }
                    }
                    else
                    {
                        if (decoded["newToken"] == "false")
                        {
                            statusLabel.Text =
                                "Signature verification successful, banned in other games, token is old.";
                            statusPanel.BackColor = Color.DarkOrange;
                        }
                        else
                        {
                            statusLabel.Text = "Signature verification successful, banned in other games.";
                            statusPanel.BackColor = Color.Orange;
                        }
                    }
                }
            }
            catch
            {
                statusLabel.Text = "Token validation failed (exception).";
                statusPanel.BackColor = Color.DarkGray;
            }

            fromClipboard.Enabled = true;
            scanQR.Enabled = true;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == 1)
            {
                var pos = GetCursorPosition();

                var screenshot = new Bitmap(900, 900);
                var graphics = Graphics.FromImage(screenshot);
                graphics.CopyFromScreen(pos.X - 450, pos.Y - 450, 0, 0, screenshot.Size);

                var bitmap = new Bitmap(screenshot);

                BarcodeReader reader = new BarcodeReader { AutoRotate = false, Options = DecOpt };
                Result result = reader.Decode(bitmap);
                if (result == null)
                {
                    MessageBox.Show("QR code not found.", MsgHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string decoded = result.ToString().Trim();

                new Thread(() => Request(decoded)) { IsBackground = true, Name = "Token validation", Priority = ThreadPriority.AboveNormal }.Start();
            }
            base.WndProc(ref m);
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private void CopyUserIDButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(userIDLabel.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(Handle, 1);
        }
    }
}
