using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ChatChatBroadcast
{
    public partial class FmChat : Form
    {
        private Thread ThreadReceiveMessage;

        public string UName;
        public int Port;

        public FmChat()
        {
            InitializeComponent();
        }

        private void FmChat_Load(object sender, EventArgs e)
        {
            this.Text = "Chat On Port " + this.Port;
            CheckForIllegalCrossThreadCalls = false;
            this.ThreadReceiveMessage = new Thread(ReceiveMessage);
            this.ThreadReceiveMessage.Start();
            udpSendMessageOnNetwork(Encoding.Default.GetBytes(string.Format("info|x|{0} | {1} ได้เข้าสู่ระบบ", 
                                                DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy"), this.UName)));
        }

        private void FmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ThreadReceiveMessage.Abort();
            using (UdpClient udpClient = new UdpClient(AddressFamily.InterNetwork))
            { udpClient.Send(Encoding.Default.GetBytes(" "), 1, new IPEndPoint(IPAddress.Parse("127.0.0.1"), this.Port)); }

            udpSendMessageOnNetwork(Encoding.Default.GetBytes(string.Format("info|x|{0} | {1} ออกจากระบบ",
                                                DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy"), this.UName)));
        }

        private void BtnSendMessage_Click(object sender, EventArgs e)
        {
            if (TxtMessage.Text == "") return;
            this.SendMessage(TxtMessage.Text);
            TxtMessage.Text = "";
        }

        private void TxtMessage_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) BtnSendMessage_Click(sender, e); }

        private void BtnClearDisplayMessage_Click(object sender, EventArgs e)
        { TxtDisplayMessage.Clear(); }

        private void RefreshScrollBar()
        {
            TxtDisplayMessage.SelectionStart = TxtDisplayMessage.TextLength;
            TxtDisplayMessage.ScrollToCaret();
            TxtDisplayMessage.Refresh();
        }

        private void udpSendMessageOnNetwork(byte[] MsgSend)
        {
            using (UdpClient udpClient = new UdpClient(AddressFamily.InterNetwork))
            {
                byte[] IpAddr = Dns.GetHostByName(Environment.MachineName).AddressList[0].GetAddressBytes();
                IPAddress address = IPAddress.Parse(string.Format("{0}.{1}.{2}.255", IpAddr[0], IpAddr[1], IpAddr[2]));
                udpClient.Send(MsgSend, MsgSend.Length, new IPEndPoint(address, this.Port));
                udpClient.Close();
            }
        }

        private void ReceiveMessage()
        {
            UdpClient udpClientReceiveMessage = new UdpClient(this.Port);
            IPEndPoint ipEndPointReceiveMessage = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] data = udpClientReceiveMessage.Receive(ref ipEndPointReceiveMessage);
                
                
                if (Dns.GetHostByName(Environment.MachineName).AddressList[0].ToString() != ipEndPointReceiveMessage.Address.ToString())
                {
                    string[] DataIsSplit = Encoding.Default.GetString(data).Split(
                                            new string[] { "|x|" }, 2, StringSplitOptions.None);

                    if (DataIsSplit[0] == "talk") TxtDisplayMessage.Text += DataIsSplit[1] + "\r\n";
                    else if (DataIsSplit[0] == "info")
                    {
                        TxtDisplayMessage.Text += "==================================================\r\n"
                                                + DataIsSplit[1] + "\r\n"
                                                + "==================================================\r\n";
                    }
                }

                //TxtDisplayMessage.Text += Encoding.Default.GetString(data) + "\r\n";
                this.RefreshScrollBar();
            }
        }

        private void SendMessage(string Message)
        {
            TxtDisplayMessage.Text += "[ฉัน] [" + DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy") + "] พูดว่า: " + Message + "\r\n";
            this.RefreshScrollBar();
            byte[] MsgSend = Encoding.Default.GetBytes(string.Format("talk|x|[{0}] [{1}] พูดว่า: {2}", 
                                                        this.UName, DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy"), Message));
            this.udpSendMessageOnNetwork(MsgSend);
        }
    }
}
