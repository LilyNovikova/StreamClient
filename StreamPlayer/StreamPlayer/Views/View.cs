using StreamPlayer.Controllers;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace StreamPlayer.Views
{
    public partial class View : Form
    {
        Controller myController = new Controller();

        public enum Buttons
        {
            Setup,
            Play,
            Pause,
            Teardowm
        }

        public View()
        {
            InitializeComponent();
            connectBtn.Click += myController.Connect;
            setupBtn.Click += myController.Setup;
            playBtn.Click += myController.Play;
            pauseBtn.Click += myController.Pause;
            teardownBtn.Click += myController.Teardown;
            exitBtn.Click += myController.Exit;
        }

        public string ServerPort => serverPortNum.Text;
        public string ClientPort => clientPortNum.Text;

        public IPAddress ServerIP => IPAddress.Parse(this.serverIP.Text);

        //return the video name
        public string VideoName => videoName.Text;

        public void UpdateVideoNamesCmb(string[] files)
        {
            videoName.Items.Clear();
            videoName.Items.AddRange(files.ToArray());
            videoName.SelectedIndex = 0;
        }

        public void EnableFilesCmb() => videoName.Enabled = true;

        public void SetImageBoxBlack()
        {
            this.imageBox.BackColor = Color.Black;
        }

        public void SetImageBox(Image image)
        {
            this.imageBox.Image = image;
        }

        public void DisableConnectBtn()
        {
            this.connectBtn.Enabled = false;
        }

        public void EnableButton(Buttons button)
        {
            switch (button)
            {
                case Buttons.Setup:
                    this.setupBtn.Enabled = true;
                    break;
                case Buttons.Play:
                    this.playBtn.Enabled = true;
                    break;
                case Buttons.Pause:
                    this.pauseBtn.Enabled = true;
                    break;
                case Buttons.Teardowm:
                    this.teardownBtn.Enabled = true;
                    break;
                default:
                    throw new ArgumentException($"Unknow button {button}");
            }
        }

        public void DisableButton(Buttons button)
        {
            switch (button)
            {
                case Buttons.Setup:
                    this.setupBtn.Enabled = false;
                    break;
                case Buttons.Play:
                    this.playBtn.Enabled = false;
                    break;
                case Buttons.Pause:
                    this.pauseBtn.Enabled = false;
                    break;
                case Buttons.Teardowm:
                    this.teardownBtn.Enabled = false;
                    break;
                default:
                    throw new ArgumentException($"Unknow button {button}");
            }
        }

        //delegate to use function as a parameter
        delegate void SetInfoCallback(string info);

        //append text to the server box
        public void SetServerBox(string msg)
        {
            var text = msg;
            var callback = new SetInfoCallback(AddServerText);
            this.Invoke(callback, new object[] { text });
        }

        public void AddServerText(string msg)
        {
            this.serverBox.Text += msg;
        }

        //append text to the client box
        public void SetClientBox(string msg)
        {
            var text = msg;
            var callback = new SetInfoCallback(AddClientText);
            this.Invoke(callback, new object[] { text });
        }

        public void AddClientText(string msg)
        {
            this.clientBox.Text += msg;
        }

        public bool IsPacketReportChecked => packetReportCheck.CheckState == CheckState.Checked;
    }
}
