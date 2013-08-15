using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChatChatBroadcast
{
    public partial class FmLogin : Form
    {
        public FmLogin()
        {
            InitializeComponent();
        }

        public void ShowThisForm(object sender, FormClosedEventArgs e) { Application.Exit(); }

        public void RunForm(Form ObjForm)
        { this.Hide(); ObjForm.Show(); ObjForm.FormClosed += new FormClosedEventHandler(ShowThisForm); }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtName.Text == "" || TxtPort.Text == "")
            {
                MessageBox.Show("โปรดใส่ข้อมูลทั้งหมดให้ครบ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FmChat FmChat = new FmChat();
            FmChat.UName = TxtName.Text;
            FmChat.Port = Convert.ToInt16(TxtPort.Text);
            RunForm(FmChat);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))) e.Handled = true;
        }
    }
}
