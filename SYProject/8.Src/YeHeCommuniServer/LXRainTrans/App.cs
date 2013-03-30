using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;
using System.Windows.Forms;

namespace LXRainTrans
{
    public class App : AppBase
    {
        static public App Default
        {
            get
            {
                if (App.DefaultInstance == null)
                {

                    App a = new App();
                    a.RunningMessage = "程序已运行";
                    App.DefaultInstance = a;

                }
                return App.DefaultInstance as App;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private App()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public override System.Windows.Forms.Form MainForm
        {
            get
            {
                if (_frmMain == null)
                {
                    _frmMain = new frmMain();
                }
                return _frmMain;
            }
        } private frmMain _frmMain;

        /// <summary>
        /// 
        /// </summary>
        public Logger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Logger(((frmMain)this.MainForm).LogTextBox);
                }
                return _logger;
            }
        } Logger _logger;

        #region Trans
        /// <summary>
        /// 
        /// </summary>
        public Trans Trans
        {
            get
            {
                if (_trans == null)
                {
                    _trans = new Trans();
                }
                return _trans;
            }
        } private Trans _trans;
        #endregion //Trans

        #region Config
        /// <summary>
        /// 
        /// </summary>
        public Config Config
        {
            get
            {
                if (_config == null)
                {
                    _config = new Config();
                }
                return _config;
            }
        } private Config _config;
        #endregion //Config

        #region DB
        /// <summary>
        /// 
        /// </summary>
        public DB DB
        {
            get
            {
                if (_dB == null)
                {
                    _dB = new DB(Config.ConnectionString);
                }
                return _dB;
            }
        } private DB _dB;
        #endregion //DB
    }
}
