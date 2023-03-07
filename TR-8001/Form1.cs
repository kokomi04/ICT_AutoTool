using Gma.System.MouseKeyHook;
using KAutoHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TR_8001
{
    public partial class Form1 : Form
    {
        DirectoryInfo Folder;
        FileInfo[] dsfile;
        Process pros;
        //List<string> product = new List<string>
        //{
        //    "953073T00", "953107T00", "J21O002T00"
        //};

        string barcode;
        string SNcheck;
        int counter;
        int counter1 = 0;
        int BarcodeLength = 11;
        string[] LogPath = new string[3];
        string filePath = "";
        string pathcurrentNow = Directory.GetCurrentDirectory();

        SerialPort P = new SerialPort();
        string InputData = String.Empty;
        delegate void SetTextCallback(string text);
        bool isDone = false;
        private bool isFail;
        bool isSaveFailLog;
        bool connect = false;
        private bool received;

        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            checkBox1.Checked = bool.Parse(RegistryHelper.getRegistryKey("isUseCam", "false"));
            checkBox2.Checked = bool.Parse(RegistryHelper.getRegistryKey("isSaveFailLog", "true"));
            textBox4.Text = RegistryHelper.getRegistryKey("ScanPrg", "Scan_Barcode.exe");
            timer1.Enabled = true;
            BarcodeLength = Int32.Parse(RegistryHelper.getRegistryKey("BarcodeLength", "11"));
            numericUpDown1.Value = Decimal.Parse(RegistryHelper.getRegistryKey("BarcodeLength", "11"));

            SNcheck = RegistryHelper.getRegistryKey("SNcheck", "FV");
            FillSNcheck();

            LoadLogPath();
            //comboBox1.DataSource = product;
            comboBox1.SelectedItem = RegistryHelper.getRegistryKey("selected", "J21O002T00");

            LoadFolder();

            LoadSerialPort();

            //LoadEventChange();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox4.Enabled = true;
            else
                textBox4.Enabled=false;


            switch (comboBox1.SelectedItem)
            {
                case "953073T00":
                    {
                        textBox2.Text = LogPath[0];
                    }
                    break;
                case "953107T00":
                    {
                        textBox2.Text = LogPath[1];
                    }
                    break;
                case "J21O002T00":
                    {
                        textBox2.Text = LogPath[2];
                    }
                    break;
            }
            textBox1.Focus();
            //this.Activate();

            if (!connect)
            {
                try
                {
                    connect = true;
                    P.Open();
                    btKetNoi.Text = "Disconnect";
                    btKetNoi.ForeColor = Color.Red;
                    groupBox1.Enabled = false;
                    btSend.Enabled = true;
                    txtSend.Enabled = true;
                    // groupBox3.Enabled = true;
                    statusSend.Visible = true;
                    // status.Text = "Connected with " + cbCom.SelectedItem.ToString();
                    // status.ForeColor = Color.Green;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't connect COM Port.", "Retry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    panel1.BackColor = Color.Brown;
                    textBox1.Visible = label1.Visible = label4.Visible = btnUseCam.Visible = false;
                    lbwarning.Visible = true;
                    lbwarning.Text = "ERROR COM PORT";
                }
            }
            // status.Text = "Choose COM Port!";
            //status.ForeColor = Color.DarkCyan;
        }
        #region Functions
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);
        //static IntPtr FindWindowByIndex(IntPtr hWndParent, int index, string classname)
        //{
        //    if (index == 0)
        //        return hWndParent;
        //    else
        //    {
        //        int ct = 0;
        //        IntPtr result = IntPtr.Zero;
        //        do
        //        {
        //            result = FindWindowEx(hWndParent, result, classname, null); // TPageControl
        //            if (result != IntPtr.Zero)
        //                ++ct;
        //        }
        //        while (ct < index && result != IntPtr.Zero);
        //        return result;
        //    }
        //}
        public void LoadEventChange()
        {
            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                switch (comboBox1.SelectedItem)
                {
                    case "953073T00":
                        {
                            watcher.Path = LogPath[0];
                        }
                        break;
                    case "953107T00":
                        {
                            watcher.Path = LogPath[1];
                        }
                        break;
                    case "J21O002T00":
                        {
                            watcher.Path = LogPath[2];
                        }
                        break;
                }
                /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                // Only watch text files.
                watcher.Filter = "*.csv";

                // Add event handlers.
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                // watcher.Deleted += new FileSystemEventHandler(OnChanged);

                // Begin watching.
                watcher.EnableRaisingEvents = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex.Message, "Warning", "", "");
            }
        }
        public void LoadLogPath()
        {
            LogPath[0] = RegistryHelper.getRegistryKey("LogPath0", "");
            LogPath[1] = RegistryHelper.getRegistryKey("LogPath1", "");
            LogPath[2] = RegistryHelper.getRegistryKey("LogPath2", "");

            for (int i = 0; i < LogPath.Length; i++)
            {
                if (LogPath[i] == "" || String.IsNullOrEmpty(LogPath[i]))
                {
                    MsgBox.ShowException($"Chọn lại LogPath {i}", "Warning", "", "");
                    FolderBrowserDialog f1 = new FolderBrowserDialog();
                    if (f1.ShowDialog() == DialogResult.OK)
                    {
                        LogPath[i] = f1.SelectedPath;
                        RegistryHelper.setRegistryKey($"LogPath{i}", LogPath[i]);
                    }
                }
            }
        }
        public void LoadFolder()
        {
            try
            {
                switch (comboBox1.SelectedItem)
                {
                    case "953073T00":
                        {
                            Folder = new DirectoryInfo(LogPath[0]);
                        }
                        break;
                    case "953107T00":
                        {
                            Folder = new DirectoryInfo(LogPath[1]);
                        }
                        break;
                    case "J21O002T00":
                        {
                            Folder = new DirectoryInfo(LogPath[2]);
                        }
                        break;
                }
                dsfile = Folder.GetFiles();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex.Message, "Error", "OK", "Cancel");
                panel1.BackColor = Color.Brown;
                textBox1.Visible = label1.Visible = label4.Visible = false;
                lbwarning.Visible = true;
                lbwarning.Text = "ERROR LOG PATH";

                LoadFile();

                panel1.BackColor = Color.DarkSeaGreen;
                textBox1.Visible = label1.Visible = label4.Visible = true;
                lbwarning.Visible = false;
            }
        }
        public void LoadSerialPort()
        {
            string[] ports = SerialPort.GetPortNames();

            cbCom.Items.AddRange(ports);
            P.ReadTimeout = 1000;
            P.DataReceived += new SerialDataReceivedEventHandler(DataReceive);

            string[] BaudRate = { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            cbRate.Items.AddRange(BaudRate);

            string[] Databits = { "6", "7", "8" };
            cbBits.Items.AddRange(Databits);

            string[] Parity = { "None", "Odd", "Even" };
            cbParity.Items.AddRange(Parity);

            string[] stopbit = { "1", "1.5", "2" };
            cbBit.Items.AddRange(stopbit);

            //cbCom.SelectedItem = inif.Read("CONFIG", "COM").ToUpper();
            cbCom.SelectedItem = RegistryHelper.getRegistryKey("COM", "COM1").ToUpper();

            if (cbCom.SelectedItem == null)
            {
                MessageBox.Show("Can't connect COM Port.", "Retry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panel1.BackColor = Color.Brown;
                textBox1.Visible = label1.Visible = label4.Visible = false;
                lbwarning.Visible = true;
                lbwarning.Text = "ERROR COM PORT";
            }

            cbRate.SelectedIndex = 3; // 9600
            cbBits.SelectedIndex = 2; // 8
            cbParity.SelectedIndex = 0; // None
            cbBit.SelectedIndex = 0; // None
        }
        public void LoadFile()
        {
            FolderBrowserDialog f1 = new FolderBrowserDialog();
            //f1.SelectedPath = "E:\\";
            //string ResultWrite = null;
            //f1.ShowNewFolderButton = true;
            if (f1.ShowDialog() == DialogResult.OK)
            {
                switch (comboBox1.SelectedItem)
                {
                    case "953073T00":
                        {
                            LogPath[0] = textBox2.Text = f1.SelectedPath;
                            RegistryHelper.setRegistryKey("LogPath0", f1.SelectedPath);
                        }
                        break;
                    case "953107T00":
                        {
                            LogPath[1] = textBox2.Text = f1.SelectedPath;
                            RegistryHelper.setRegistryKey("LogPath1", f1.SelectedPath);
                        }
                        break;
                    case "J21O002T00":
                        {
                            LogPath[2] = textBox2.Text = f1.SelectedPath;
                            RegistryHelper.setRegistryKey("LogPath2", f1.SelectedPath);
                        }
                        break;
                }
            }

            panel1.BackColor = Color.DarkSeaGreen;
            textBox1.Visible = label1.Visible = label4.Visible = true;
            lbwarning.Visible = false;
        }
        public async void handle(string status)
        {
            // isDone = false;
            // this.Hide();
            //IntPtr parentHandle = AutoControl.FindWindowHandle(null, null);


            IntPtr handle = AutoControl.FindWindowHandle(null, "TR-8001");

            if (handle == IntPtr.Zero)
            {
                MessageBox.Show("Hãy bật phần mềm TR-8001");
                return;
            }
            AutoControl.BringToFront(handle);
            await Task.Delay(50);
            AutoControl.SendClickOnPosition(handle, 300, 120, EMouseKey.DOUBLE_LEFT);
            SendKeys.SendWait(barcode);
            //AutoControl.SendKeyPress(KeyCode.F6);
            await Task.Delay(2000);
            //  AutoControl.SendKeyPress(KeyCode.F5);

            if (P.IsOpen)
            {
                P.Write(status + "\r\n");
                txtkq.Text += DateTime.Now.ToString("HH:mm:ss") + "  " + status + Environment.NewLine;
                statusSend.Text = "Waiting for response...";

                counter = 20;
                waitingResponse.Start();
            }
            else
            {
                MessageBox.Show("Check COM");
            }
        }
        public void checkSN()
        {
            Folder.Refresh();
            dsfile = Folder.GetFiles();


            if (!barcode.Contains(SNcheck) || !IsNumber(barcode.Substring(1, barcode.Length - 1)))
            {
                textBox1.Text = "";
                MsgBox.ShowWrong("sxcs", "sdcfd", "OK", "Cancel");
                return;
            }
            else if (dsfile.Where(p => p.Name.Contains(barcode)).FirstOrDefault() != null)
            {
                if (MsgBox.ShowRetest("sxcs", "sdcfd", "OK", "Cancel") == DialogResult.Yes)
                {
                    handle("RETEST");
                }
                else return;
            }
            else
            {
                if (MsgBox.ShowTest("sxcs", "sdcfd", "OK", "Cancel") == DialogResult.Yes)
                {
                    handle("TEST");
                }
                else return;
            }
        }
        public bool IsNumber(string text)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(text);
        }
        public bool checkCam()
        {
            if (File.Exists(pathcurrentNow + "\\Barcode.txt"))
                File.Delete(pathcurrentNow + "\\Barcode.txt");
            try
            {
                ProcessStartInfo info = new ProcessStartInfo(pathcurrentNow + "\\" + textBox4.Text.Trim());
                info.UseShellExecute = true;
                info.Verb = "runas";
                pros = Process.Start(info);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException("Không mở được phần mềm Scan Barcode", "ERROR", "OK", "Cancel");
                return false;
            }

            counter1 = 600;
            waitCam.Start();
            return true;
        }
        public void FillSNcheck()
        {
            textBox3.Text = SNcheck;
            int tmp = SNcheck.Length;
            for (int i = 0; i < BarcodeLength - tmp; i++)
            {
                textBox3.Text += "*";
            }
        }
        #endregion

        #region Events
        private void button2_Click(object sender, EventArgs e)
        {
            LoadFile();
            LoadEventChange();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Length == BarcodeLength)
                {
                    barcode = textBox1.Text.ToUpper().Trim();
                    checkSN();
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "953073T00":
                    {
                        RegistryHelper.setRegistryKey("selected", "953073T00");
                        textBox2.Text = RegistryHelper.getRegistryKey("LogPath0", LogPath[0]);
                    }
                    break;
                case "953107T00":
                    {
                        RegistryHelper.setRegistryKey("selected", "953107T00");
                        textBox2.Text = RegistryHelper.getRegistryKey("LogPath1", LogPath[1]);
                    }
                    break;
                case "J21O002T00":
                    {
                        RegistryHelper.setRegistryKey("selected", "J21O002T00");
                        textBox2.Text = RegistryHelper.getRegistryKey("LogPath2", LogPath[2]);
                    }
                    break;
                default:
                    break;
            }
            LoadEventChange();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > BarcodeLength)
            {
                textBox1.Text = "";
            }
            if (textBox1.Text.Length == numericUpDown1.Value)
            {
                label1.Text = "Correct Length Barcode";

                label1.ForeColor = Color.Green;

                textBox1.SelectAll();
            }
            else if (textBox1.Text.Length == 0)
            {
                label1.Text = "Input Barcode";
                label1.ForeColor = Color.DodgerBlue;
            }
            else
            {
                label1.Text = "Wrong Length Barcode";
                label1.ForeColor = Color.Red;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            BarcodeLength = (int)numericUpDown1.Value;
            RegistryHelper.setRegistryKey("BarcodeLength", BarcodeLength.ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                RegistryHelper.setRegistryKey("isUseCam", "true");
                textBox1.Visible = false;
                textBox4.Enabled = true;
                label1.Visible = false;
                label4.Visible = false;
                btnUseCam.Visible = true;
                btnUseCam.Text = "ENTER";
                this.AcceptButton = btnUseCam;
            }
            else
            {
                RegistryHelper.setRegistryKey("isUseCam", "false");
                textBox1.Visible = true;
                textBox4.Enabled = false;
                label1.Visible = true;
                label4.Visible = true;
                btnUseCam.Visible = false;
                this.AcceptButton = null;
            }
        }
        private void btnUseCam_Click(object sender, EventArgs e)
        {
            checkCam();
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (isDone)
            {
                isDone = false;

                if (isFail == true)
                {
                    isFail = false;

                    if (isSaveFailLog==true)
                    {
                        WriteFailLog write = new WriteFailLog();

                        switch (comboBox1.SelectedItem)
                        {
                            case "953073T00":
                                {
                                    if (!Directory.Exists(LogPath[0] + "\\FAILLOG"))
                                    {
                                        Directory.CreateDirectory(LogPath[0] + "\\FAILLOG");
                                    }

                                    write.Read(filePath, LogPath[0] + "\\FAILLOG");
                                }
                                break;
                            case "953107T00":
                                {
                                    if (!Directory.Exists(LogPath[1] + "\\FAILLOG"))
                                    {
                                        Directory.CreateDirectory(LogPath[1] + "\\FAILLOG");
                                    }

                                    write.Read(filePath, LogPath[1] + "\\FAILLOG");
                                }
                                break;
                            case "J21O002T00":
                                {
                                    if (!Directory.Exists(LogPath[2] + "\\FAILLOG"))
                                    {
                                        Directory.CreateDirectory(LogPath[2] + "\\FAILLOG");
                                    }

                                    write.Read(filePath, LogPath[2] + "\\FAILLOG");
                                }
                                break;
                        }
                    }
                }

                // this.Hide();
                this.Show();
                await Task.Delay(3000);
                // AutoControl.SendMultiKeysFocus(new KeyCode[] { KeyCode.ALT, KeyCode.TAB });
                this.BringToFront();
                this.Focus();
                this.Activate();

                await Task.Delay(1000);
                this.BringToFront();
                this.Focus();
                this.Activate();
            }

        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            isDone = true;
            if (e.Name.Contains("FAIL"))
            {
                filePath = e.FullPath;
                isFail = true;
            }
        }
        private async void waitingResponse_Tick(object sender, EventArgs e)
        {
            counter--;

            if (received == true)
            {
                received = false;
                waitingResponse.Stop();
            }

            if (counter == 0)
            {
                waitingResponse.Stop();

                await Task.Delay(1000);
                this.BringToFront();
                this.Focus();
                this.Activate();
                MsgBox.ShowException("Không nhận đc phản hồi từ mạch điều khiển!", "ERROR", "OK", "Cancel");
            }
        }
        private void waitCam_Tick(object sender, EventArgs e)
        {
            counter1--;
            if (File.Exists(pathcurrentNow + "\\Barcode.txt"))
            {
                if (!pros.HasExited)
                {
                    pros.Kill();
                }

                waitCam.Stop();
                try
                {
                    using (StreamReader str = new StreamReader(pathcurrentNow + "\\Barcode.txt"))
                    {
                        barcode = str.ReadLine();
                        barcode = barcode.Substring(2, barcode.Length - 2);
                        if (!barcode.Contains(SNcheck) || !IsNumber(barcode.Substring(1, barcode.Length - 1)) || barcode.Length != BarcodeLength)
                        {
                            MsgBox.ShowException("Wrong Barcode", "ERROR", "OK", "Cancel");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MsgBox.ShowException(ex.Message, "ERROR", "OK", "Cancel");
                }

                checkSN();
            }
            else
            {
                if (counter1 == 0)
                {
                    if (!pros.HasExited)
                    {
                        pros.Kill();
                    }
                    waitCam.Stop();
                    MsgBox.ShowException("Kiểm tra kết nối Camera!", "ERROR CAM", "OK", "Cancel");
                }
            }
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SNcheck = textBox3.Text.Trim().Replace("*", "");
                FillSNcheck();
                RegistryHelper.setRegistryKey("SNcheck", SNcheck);
            }
        }
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RegistryHelper.setRegistryKey("ScanPrg", textBox4.Text);
            }
        }
        #endregion

        #region Config
        private void cbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            P.PortName = cbCom.SelectedItem.ToString();
            //INIFile inif = new INIFile(Directory.GetCurrentDirectory() + "\\config.ini");
            //inif.Write("CONFIG", "COM", P.PortName);
            RegistryHelper.setRegistryKey("COM", P.PortName);
        }
        private void cbRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            P.BaudRate = Convert.ToInt32(cbRate.Text);
        }
        private void cbBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            P.DataBits = Convert.ToInt32(cbBits.Text);
        }
        private void cbParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            switch (cbParity.SelectedItem.ToString())
            {
                case "Odd":
                    P.Parity = Parity.Odd;
                    break;
                case "None":
                    P.Parity = Parity.None;
                    break;
                case "Even":
                    P.Parity = Parity.Even;
                    break;
            }
        }
        private void cbBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            switch (cbBit.SelectedItem.ToString())
            {
                case "1":
                    P.StopBits = StopBits.One;
                    break;
                case "1.5":
                    P.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    P.StopBits = StopBits.Two;
                    break;
            }
        }
        private void DataReceive(object obj, SerialDataReceivedEventArgs e)
        {
            received = true;
            InputData = P.ReadExisting();
            if (InputData != String.Empty)
            {
                SetText(InputData);
            }
        }
        private void SetText(string text)
        {
            if (this.txtkq.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtkq.Text += text;
                statusSend.Text = "Received response! Enter request";
            }
        }
        private void btSend_Click(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Write(txtSend.Text + "\r\n");
                txtkq.Text += txtSend.Text + Environment.NewLine; //DateTime.Now.ToString("HH:mm:ss") + "  " + txtSend.Text + Environment.NewLine;
                statusSend.Text = "Waiting for response...";
            }

            //txtSend.Clear();
        }
        private void btKetNoi_Click(object sender, EventArgs e)
        {
            if (!connect)
            {
                try
                {
                    connect = true;
                    P.Open();
                    btKetNoi.Text = "Disconnect";
                    btKetNoi.ForeColor = Color.Red;
                    groupBox1.Enabled = false;
                    btSend.Enabled = true;
                    txtSend.Enabled = true;
                    // groupBox3.Enabled = true;
                    statusSend.Visible = true;
                    // status.Text = "Connected with " + cbCom.SelectedItem.ToString();
                    // status.ForeColor = Color.Green;
                    panel1.BackColor = Color.DarkSeaGreen;
                    textBox1.Visible = label1.Visible = label4.Visible = true;
                    lbwarning.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't connect.", "Retry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                connect = false;
                P.Close();
                btKetNoi.Text = "Connect";
                btKetNoi.ForeColor = Color.Green;
                groupBox1.Enabled = true;
                btSend.Enabled = false;
                txtSend.Enabled = false;
                //groupBox3.Enabled = false;
                statusSend.Visible = false;
                // status.Text = "Disconnected";
                //status.ForeColor = Color.Red;
            }
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            txtkq.Text = "";
            //txtSend.Text = "";
        }
        private void txtkq_TextChanged(object sender, EventArgs e)
        {
            txtkq.SelectionStart = txtkq.Text.Length;
            txtkq.ScrollToCaret();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                RegistryHelper.setRegistryKey("isSaveFailLog", "true");
                isSaveFailLog = true;
            }
            else
            {
                RegistryHelper.setRegistryKey("isSaveFailLog", "false");
                isSaveFailLog = false;
            }
        }
        #endregion

        
    }
}