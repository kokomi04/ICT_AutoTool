
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TR_8001
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUseCam = new System.Windows.Forms.Button();
            this.lbwarning = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btSend = new System.Windows.Forms.Button();
            this.statusSend = new System.Windows.Forms.Label();
            this.txtkq = new System.Windows.Forms.TextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbBit = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbBits = new System.Windows.Forms.ComboBox();
            this.cbRate = new System.Windows.Forms.ComboBox();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btXoa = new System.Windows.Forms.Button();
            this.btKetNoi = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.waitingResponse = new System.Windows.Forms.Timer(this.components);
            this.waitCam = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.AutoScrollMinSize = new System.Drawing.Size(20, 20);
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(495, 466);
            this.splitContainer1.SplitterDistance = 86;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Tan;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Wide Latin", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(10, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 13, 4, 13);
            this.label3.Size = new System.Drawing.Size(471, 65);
            this.label3.TabIndex = 0;
            this.label3.Text = "ICT AUTO TOOL";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(482, 368);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DarkKhaki;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(474, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TEST";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Info;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "953073T00",
            "953107T00",
            "J21O002T00"});
            this.comboBox1.Location = new System.Drawing.Point(7, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(113, 24);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnUseCam);
            this.panel1.Controls.Add(this.lbwarning);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 262);
            this.panel1.TabIndex = 8;
            // 
            // btnUseCam
            // 
            this.btnUseCam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnUseCam.Font = new System.Drawing.Font("Sitka Small", 60F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(5)));
            this.btnUseCam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUseCam.Location = new System.Drawing.Point(14, 29);
            this.btnUseCam.Margin = new System.Windows.Forms.Padding(4);
            this.btnUseCam.Name = "btnUseCam";
            this.btnUseCam.Size = new System.Drawing.Size(430, 203);
            this.btnUseCam.TabIndex = 11;
            this.btnUseCam.Text = "ENTER";
            this.btnUseCam.UseVisualStyleBackColor = false;
            this.btnUseCam.Visible = false;
            this.btnUseCam.Click += new System.EventHandler(this.btnUseCam_Click);
            // 
            // lbwarning
            // 
            this.lbwarning.AutoSize = true;
            this.lbwarning.BackColor = System.Drawing.Color.Brown;
            this.lbwarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbwarning.ForeColor = System.Drawing.Color.White;
            this.lbwarning.Location = new System.Drawing.Point(90, 113);
            this.lbwarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbwarning.Name = "lbwarning";
            this.lbwarning.Size = new System.Drawing.Size(280, 31);
            this.lbwarning.TabIndex = 10;
            this.lbwarning.Text = "ERROR COM PORT";
            this.lbwarning.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(14, 104);
            this.label4.Margin = new System.Windows.Forms.Padding(50);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.label4.Size = new System.Drawing.Size(147, 41);
            this.label4.TabIndex = 9;
            this.label4.Text = "BARCODE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Maroon;
            this.textBox1.Location = new System.Drawing.Point(178, 104);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(266, 41);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(184, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input Barcode";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(127, 14);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(259, 23);
            this.textBox2.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Chocolate;
            this.button2.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.Location = new System.Drawing.Point(394, 10);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(474, 340);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CONFIG";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(4, 4);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.splitContainer2.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.splitContainer2.Panel1.Controls.Add(this.btSend);
            this.splitContainer2.Panel1.Controls.Add(this.statusSend);
            this.splitContainer2.Panel1.Controls.Add(this.txtkq);
            this.splitContainer2.Panel1.Controls.Add(this.txtSend);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.MistyRose;
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Size = new System.Drawing.Size(466, 332);
            this.splitContainer2.SplitterDistance = 247;
            this.splitContainer2.TabIndex = 30;
            // 
            // btSend
            // 
            this.btSend.Enabled = false;
            this.btSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSend.ForeColor = System.Drawing.Color.Black;
            this.btSend.Location = new System.Drawing.Point(396, 208);
            this.btSend.Margin = new System.Windows.Forms.Padding(4);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(58, 26);
            this.btSend.TabIndex = 28;
            this.btSend.Text = "SEND";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // statusSend
            // 
            this.statusSend.AutoSize = true;
            this.statusSend.BackColor = System.Drawing.SystemColors.Control;
            this.statusSend.ForeColor = System.Drawing.Color.SteelBlue;
            this.statusSend.Location = new System.Drawing.Point(214, 17);
            this.statusSend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusSend.Name = "statusSend";
            this.statusSend.Size = new System.Drawing.Size(92, 15);
            this.statusSend.TabIndex = 29;
            this.statusSend.Text = "Enter request!";
            this.statusSend.Visible = false;
            // 
            // txtkq
            // 
            this.txtkq.BackColor = System.Drawing.SystemColors.Info;
            this.txtkq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtkq.Location = new System.Drawing.Point(214, 34);
            this.txtkq.Margin = new System.Windows.Forms.Padding(4);
            this.txtkq.Multiline = true;
            this.txtkq.Name = "txtkq";
            this.txtkq.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtkq.Size = new System.Drawing.Size(240, 168);
            this.txtkq.TabIndex = 26;
            this.txtkq.TextChanged += new System.EventHandler(this.txtkq_TextChanged);
            // 
            // txtSend
            // 
            this.txtSend.BackColor = System.Drawing.Color.Ivory;
            this.txtSend.Enabled = false;
            this.txtSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSend.Location = new System.Drawing.Point(212, 208);
            this.txtSend.Margin = new System.Windows.Forms.Padding(4);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(176, 26);
            this.txtSend.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbBit);
            this.groupBox1.Controls.Add(this.cbParity);
            this.groupBox1.Controls.Add(this.cbBits);
            this.groupBox1.Controls.Add(this.cbRate);
            this.groupBox1.Controls.Add(this.cbCom);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(14, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(196, 174);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 137);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Stop Bit";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(8, 110);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Parity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(8, 83);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Data Bits";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(8, 56);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Baud Rate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(8, 30);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "COM";
            // 
            // cbBit
            // 
            this.cbBit.ForeColor = System.Drawing.Color.Black;
            this.cbBit.FormattingEnabled = true;
            this.cbBit.Location = new System.Drawing.Point(70, 134);
            this.cbBit.Margin = new System.Windows.Forms.Padding(4);
            this.cbBit.Name = "cbBit";
            this.cbBit.Size = new System.Drawing.Size(100, 23);
            this.cbBit.TabIndex = 4;
            this.cbBit.SelectedIndexChanged += new System.EventHandler(this.cbBit_SelectedIndexChanged);
            // 
            // cbParity
            // 
            this.cbParity.ForeColor = System.Drawing.Color.Black;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(70, 108);
            this.cbParity.Margin = new System.Windows.Forms.Padding(4);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(100, 23);
            this.cbParity.TabIndex = 3;
            this.cbParity.SelectedIndexChanged += new System.EventHandler(this.cbParity_SelectedIndexChanged);
            // 
            // cbBits
            // 
            this.cbBits.ForeColor = System.Drawing.Color.Black;
            this.cbBits.FormattingEnabled = true;
            this.cbBits.Location = new System.Drawing.Point(70, 80);
            this.cbBits.Margin = new System.Windows.Forms.Padding(4);
            this.cbBits.Name = "cbBits";
            this.cbBits.Size = new System.Drawing.Size(100, 23);
            this.cbBits.TabIndex = 2;
            this.cbBits.SelectedIndexChanged += new System.EventHandler(this.cbBits_SelectedIndexChanged);
            // 
            // cbRate
            // 
            this.cbRate.ForeColor = System.Drawing.Color.Black;
            this.cbRate.FormattingEnabled = true;
            this.cbRate.Location = new System.Drawing.Point(70, 53);
            this.cbRate.Margin = new System.Windows.Forms.Padding(4);
            this.cbRate.Name = "cbRate";
            this.cbRate.Size = new System.Drawing.Size(100, 23);
            this.cbRate.TabIndex = 1;
            this.cbRate.SelectedIndexChanged += new System.EventHandler(this.cbRate_SelectedIndexChanged);
            // 
            // cbCom
            // 
            this.cbCom.ForeColor = System.Drawing.Color.Black;
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Location = new System.Drawing.Point(70, 26);
            this.cbCom.Margin = new System.Windows.Forms.Padding(4);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(100, 23);
            this.cbCom.TabIndex = 0;
            this.cbCom.SelectedIndexChanged += new System.EventHandler(this.cbCom_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox2.Controls.Add(this.btXoa);
            this.groupBox2.Controls.Add(this.btKetNoi);
            this.groupBox2.Location = new System.Drawing.Point(14, 180);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(196, 54);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // btXoa
            // 
            this.btXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.ForeColor = System.Drawing.Color.Black;
            this.btXoa.Location = new System.Drawing.Point(96, 17);
            this.btXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(74, 27);
            this.btXoa.TabIndex = 7;
            this.btXoa.Text = "Delete";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btKetNoi
            // 
            this.btKetNoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btKetNoi.ForeColor = System.Drawing.Color.Green;
            this.btKetNoi.Location = new System.Drawing.Point(10, 17);
            this.btKetNoi.Margin = new System.Windows.Forms.Padding(4);
            this.btKetNoi.Name = "btKetNoi";
            this.btKetNoi.Size = new System.Drawing.Size(80, 27);
            this.btKetNoi.TabIndex = 5;
            this.btKetNoi.Text = "Connect";
            this.btKetNoi.UseVisualStyleBackColor = true;
            this.btKetNoi.Click += new System.EventHandler(this.btKetNoi_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.YellowGreen;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 81);
            this.panel2.TabIndex = 12;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(284, 53);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(126, 21);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "Scan_Barcode.exe";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(82, 34);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(75, 21);
            this.textBox3.TabIndex = 13;
            this.textBox3.Text = "FV*********";
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Check SN";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(284, 2);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(107, 23);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Save Fail Log";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(284, 29);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 23);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Use Camera";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(82, 5);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 22);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "SN LENGTH";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // waitingResponse
            // 
            this.waitingResponse.Tick += new System.EventHandler(this.waitingResponse_Tick);
            // 
            // waitCam
            // 
            this.waitCam.Interval = 2;
            this.waitCam.Tick += new System.EventHandler(this.waitCam_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 466);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "TR-8001 Tool";
            this.Activated += new System.EventHandler(this.Form1_Load);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer waitingResponse;
        private System.Windows.Forms.Timer waitCam;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUseCam;
        private System.Windows.Forms.Label lbwarning;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Label statusSend;
        private System.Windows.Forms.TextBox txtkq;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbBit;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbBits;
        private System.Windows.Forms.ComboBox cbRate;
        private System.Windows.Forms.ComboBox cbCom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btKetNoi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox4;
    }
}

