using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TR_8001
{
    public partial class MsgBox : Form
    {
        public MsgBox()
        {
            InitializeComponent();
        }

        static MsgBox msgBox;
        static DialogResult result = DialogResult.No;

        public static DialogResult ShowTest(string text, string caption, string btnOk, string btnCancel)
        {
            msgBox = new MsgBox();
            msgBox.StartPosition = FormStartPosition.CenterParent;
            msgBox.Text = "ICT TEST";
            // msgBox.label1.Text = text;
            msgBox.button1.Text = btnOk;
            msgBox.button2.Text = btnCancel;
            msgBox.button3.Visible = false;
            msgBox.splitContainer1.Panel1.BackColor = Color.Chartreuse;
            msgBox.label1.Text = "TEST";

            msgBox.label1.Location = new Point(80, 63);
            msgBox.button3.Visible = false;
            msgBox.ShowDialog();
            return result;
        }

        public static DialogResult ShowRetest(string text, string caption, string btnOk, string btnCancel)
        {
            msgBox = new MsgBox();
            msgBox.StartPosition = FormStartPosition.CenterParent;
            msgBox.Text = "ICT TEST";
            // msgBox.label1.Text = text;
            msgBox.button1.Text = btnOk;
            msgBox.button2.Text = btnCancel;
            msgBox.button3.Visible = false;
            msgBox.splitContainer1.Panel1.BackColor = Color.Gold;
            msgBox.label1.Text = "RETEST";
            msgBox.label1.Location = new Point(30, 63);
            msgBox.button3.Visible = false;
            msgBox.ShowDialog();
            return result;
        }

        public static DialogResult ShowWrong(string text, string caption, string btnOk, string btnCancel)
        {
            msgBox = new MsgBox();
            msgBox.StartPosition = FormStartPosition.CenterParent;
            msgBox.Text = "ICT TEST";
            // msgBox.label1.Text = text;
            // msgBox.button1.Enabled = false;
            msgBox.button1.Text = btnOk;
            msgBox.button2.Text = btnCancel;
            msgBox.button3.Visible = false;
            msgBox.splitContainer1.Panel1.BackColor = Color.Red;
            msgBox.label1.Text = "ERROR";
            msgBox.label1.Location = new Point(55, 63);
            msgBox.button3.Visible = false;
            msgBox.ShowDialog();
            return result;
        }

        public static DialogResult ShowException(string text, string caption, string btnOk, string btnCancel)
        {
            msgBox = new MsgBox();
            msgBox.StartPosition = FormStartPosition.CenterParent;
            msgBox.Text = caption;
            // msgBox.label1.Text = text;
            // msgBox.button1.Enabled = false;
            msgBox.button1.Text = btnOk;
            msgBox.button2.Text = btnCancel;
            msgBox.splitContainer1.Panel1.BackColor = Color.Red;
            msgBox.label1.Text = "";
            msgBox.label1.Location = new Point(55, 63);
            msgBox.button3.Text = text;
            msgBox.button1.Select();
            msgBox.ShowDialog();
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            msgBox.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = DialogResult.No;
            msgBox.Close();
        }
    }
}
