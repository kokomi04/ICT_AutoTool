using Gma.System.MouseKeyHook;
using KAutoHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TR_8001
{
    public partial class Form1 : Form
    {
        DirectoryInfo Folder;
        FileInfo[] dsfile;
        string text;

        int counter;
        int BarcodeLength = 11;
        string LogPath = "";
        string failPath = "";

        bool isDone = false;

        SerialPort P = new SerialPort();
        string InputData = String.Empty;
        delegate void SetTextCallback(string text);
        bool connect = false;
        private bool received;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            ////////LogPath
            timer1.Enabled = true;
            INIFile inif = new INIFile(Directory.GetCurrentDirectory() + "\\config.ini");
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\config.ini"))
            {
                inif.Write("CONFIG", "LogPath", "C:\\Users\\PhamDuy\\Desktop\\LOG");
                inif.Write("CONFIG", "BarcodeLength", "11");
                inif.Write("CONFIG", "COM", "COM1");
            }

            BarcodeLength = Int32.Parse(inif.Read("CONFIG", "BarcodeLength"));
            numericUpDown1.Value = Decimal.Parse(inif.Read("CONFIG", "BarcodeLength"));

            LogPath = inif.Read("CONFIG", "LogPath");

            Folder = new DirectoryInfo(LogPath);
            if (Folder.Exists)
            {
                dsfile = Folder.GetFiles();
            }
            else
            {
                MsgBox.ShowException("Log Path error!", "ERROR", "OK", "Cancel");
                panel1.BackColor = Color.Brown;
                textBox1.Visible = label1.Visible = label4.Visible = false;
                lbwarning.Visible = true;
                lbwarning.Text = "ERROR LOG PATH";
            }

            ///////////Serial
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

            cbCom.SelectedItem = inif.Read("CONFIG", "COM").ToUpper();
            if (cbCom.SelectedItem == null)
            {
                MsgBox.ShowException("Can't connect COM Port", "ERROR", "OK", "Cancel");
                panel1.BackColor = Color.Brown;
                textBox1.Visible = label1.Visible = label4.Visible = false;
                lbwarning.Visible = true;
                lbwarning.Text = "ERROR COM PORT";
            }

            cbRate.SelectedIndex = 3; // 9600
            cbBits.SelectedIndex = 2; // 8
            cbParity.SelectedIndex = 0; // None
            cbBit.SelectedIndex = 0; // None
            Load_EventChangeFile();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = LogPath;
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

                    MsgBox.ShowException("Can't connect COM Port", "ERROR", "OK", "Cancel");
                    panel1.BackColor = Color.Brown;
                    textBox1.Visible = label1.Visible = label4.Visible = false;
                    lbwarning.Visible = true;
                    lbwarning.Text = "ERROR COM PORT";
                }
            }
            // status.Text = "Choose COM Port!";
            //status.ForeColor = Color.DarkCyan;
        }
        private void Load_EventChangeFile()
        {
            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = LogPath;
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher.Filter = "*.csv";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);

            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }

        #region AutoTest

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        static IntPtr FindWindowByIndex(IntPtr hWndParent, int index, string classname)
        {
            if (index == 0)
                return hWndParent;
            else
            {
                int ct = 0;
                IntPtr result = IntPtr.Zero;
                do
                {
                    result = FindWindowEx(hWndParent, result, classname, null); // TPageControl
                    if (result != IntPtr.Zero)
                        ++ct;
                }
                while (ct < index && result != IntPtr.Zero);
                return result;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f1 = new FolderBrowserDialog();
            f1.SelectedPath = "E:\\";
            //string ResultWrite = null;
            //f1.ShowNewFolderButton = true;
            if (f1.ShowDialog() == DialogResult.OK)
            {
                LogPath = textBox2.Text = f1.SelectedPath;
            }
            else if (f1.ShowDialog() == DialogResult.Cancel)
            {
                LogPath = textBox2.Text = f1.SelectedPath;
            }

            INIFile inif = new INIFile(Directory.GetCurrentDirectory() + "\\config.ini");
            inif.Write("CONFIG", "LogPath", LogPath);
            panel1.BackColor = Color.DarkSeaGreen;
            textBox1.Visible = label1.Visible = label4.Visible = true;
            lbwarning.Visible = false;
            Load_EventChangeFile();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Length == BarcodeLength)
                {
                    text = textBox1.Text.ToUpper().Trim();
                    Folder.Refresh();
                    dsfile = Folder.GetFiles();
                    //dsfile.Where(f => f.CreationTime.)

                    //foreach (var item in dsfile)
                    //{
                    if (!text.Contains("FV"))
                    {
                        textBox1.Text = "";
                        MsgBox.ShowWrong("sxcs", "sdcfd", "OK", "Cancel");
                        return;
                    }
                    else if (dsfile.Where(p => p.Name.Contains(text)).FirstOrDefault() != null)
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
                    //}

                }

            }
        }

        public async void handle(string status)
        {
            // isDone = false;
            // this.Hide();
            //IntPtr parentHandle = AutoControl.FindWindowHandle(null, null);


            IntPtr handle = AutoControl.FindWindowHandle(null, "TR-8001");

            if (handle == IntPtr.Zero)
            {
                MsgBox.ShowException("Hãy bật phần mềm TR-8001", "Chú ý", "OK", "Cancel");
                return;
            }
            AutoControl.BringToFront(handle);
            await Task.Delay(50);
            AutoControl.SendClickOnPosition(handle, 300, 120, EMouseKey.DOUBLE_LEFT);
            SendKeys.SendWait(text);
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
                MsgBox.ShowException("Check COM", "ERROR", "OK", "Cancel");
            }
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
            INIFile inif = new INIFile(Directory.GetCurrentDirectory() + "\\config.ini");
            inif.Write("CONFIG", "BarcodeLength", BarcodeLength.ToString());
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (isDone)
            {
                isDone = false;

                //Func<bool> writeLog = () =>
                //                   {
                //                       WriteFailLog write = new WriteFailLog();

                //                       if (!Directory.Exists(LogPath + "\\FAILLOG"))
                //                       {
                //                           Directory.CreateDirectory(LogPath + "\\FAILLOG");
                //                       }
                //                       return write.Read(failPath, LogPath + "\\FAILLOG");
                //                   };
                Task<bool> task = new Task<bool>(() =>
                {
                    WriteFailLog write = new WriteFailLog();

                    if (!Directory.Exists(LogPath + "\\FAILLOG"))
                    {
                        Directory.CreateDirectory(LogPath + "\\FAILLOG");
                    }
                    return write.Read(failPath, LogPath + "\\FAILLOG");
                });
                task.Start();

                if (task.Result == false)
                {
                    MsgBox.ShowException("Create fail log error", "ERROR", "OK", "Cancel");
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
                failPath = e.FullPath;
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
        #endregion


        #region Config
        private void cbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            P.PortName = cbCom.SelectedItem.ToString();
            INIFile inif = new INIFile(Directory.GetCurrentDirectory() + "\\config.ini");
            inif.Write("CONFIG", "COM", P.PortName);
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
                    MsgBox.ShowException("Can't connect.", "ERROR", "OK", "Cancel");
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
        #endregion


    }

}
