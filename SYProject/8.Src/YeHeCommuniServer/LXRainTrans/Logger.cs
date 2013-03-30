using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms ;

namespace LXRainTrans
{
    public class Logger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="txt"></param>
        public Logger(TextBox txt)
        {
            _txt = txt;
        } private TextBox _txt;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        delegate void LogDelegateDefine (string s );

        /// <summary>
        /// 
        /// </summary>
        private Delegate LogDelegate
        {
            get
            {
                if (_logDelegate == null)
                {
                    _logDelegate = new LogDelegateDefine(this.LogHelper);
                }
                return _logDelegate;
            }
        } Delegate _logDelegate;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public void Log(string s)
        {
            s = DateTime.Now + " " + s + Environment.NewLine;

            LogHelper(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        void LogHelper(string s)
        {
            if (_txt.InvokeRequired)
            {
                _txt.Invoke(this.LogDelegate, s);
            }
            else
            {
                if (_txt.TextLength > 100 * 100)
                {
                    _txt.Clear();
                }
                _txt.AppendText(s);
            }
        }
    }
}
