using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Threading;
using System.Net.Sockets;
using SIPLib;


namespace Phone
{
    public partial class MainWindow : Form
    {

        SIPLib.Del DelOutput;
        SIPLib.DelRequest DelRequest1;
        SIPLib.Listener Phone;
        SIPLib.Player player = new Player("127.0.0.1", portplayer);
        DelCloseSession DelClosesession;
        static int portplayer = 4000;
        static int port = 5060;


        public MainWindow()
        {
            InitializeComponent();
            DelOutput += funcOutput;
            DelRequest1 += ReceivedInvite;
            DelClosesession += CloseSession;
        }

        public void funcOutput(string Info, string Caption)
        {
            MessageBox.Show(Info, Caption);
        }

        public bool ReceivedInvite(string a)
        {
            if (DialogResult.Yes == MessageBox.Show("Хотите принять вызов от: " + a, "Входящий вызов", MessageBoxButtons.YesNo))
            {
                player.SetOptions(a.Remove(0, a.IndexOf('@') + 1), portplayer);
                player.Start();
                this.btnMakeDirectCall.Enabled = false;
                this.btnHangUpDirectCall.Enabled = true;
                this.btnPause.Enabled = true;
                this.btnResume.Enabled = false;
                return true;
                
            }
            else
            {
                player.Stop();
                return false;
            }
        }

        public void CloseSession(string Name)
        {
            ListView.ListViewItemCollection items = new ListView.ListViewItemCollection(new ListView());

            
        }

        private void btnMakeDirectCall_Click(object sender, EventArgs e)
        {
            Phone.MakeCall(this.tbTargetIP.Text, this.tbTargetUserNameDirect.Text, tbAccountUser.Text);
            player.SetOptions(this.tbTargetIP.Text, portplayer);
            player.Start();
            this.btnMakeDirectCall.Enabled = false;
            this.btnHangUpDirectCall.Enabled = true;
            this.btnPause.Enabled = true;
            this.btnResume.Enabled = false;
            this.tbTargetIP.Enabled = false;
            this.tbTargetUserNameDirect.Enabled = false;
        }

        private void btnHangUpDirectCall_Click(object sender, EventArgs e)
        {
            this.btnMakeDirectCall.Enabled = true;
            this.btnHangUpDirectCall.Enabled = false;
            this.btnPause.Enabled = false;
            this.btnResume.Enabled = false;
            this.tbTargetIP.Enabled = true;
            this.tbTargetUserNameDirect.Enabled = true;
            Phone.StopPhone();
            player.Stop();
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Phone.StopPhone();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Phone = new SIPLib.Listener(port, DelRequest1, this.tbAccountUser.Text,DelClosesession);  //класс слушателя
            btnMakeDirectCall.Enabled = true;
            btnHangUpDirectCall.Enabled = true;
            btnLogIn.Enabled = false;
            tbAccountUser.Enabled = false;
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Phone != null)
                Phone.StopPhone();
            Application.Exit();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.btnPause.Enabled = false;
            this.btnResume.Enabled = true;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            player.Start();
            this.btnPause.Enabled = true;
            this.btnResume.Enabled = false;
        }

    }
}
