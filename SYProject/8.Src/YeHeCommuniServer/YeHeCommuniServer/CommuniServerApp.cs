using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi;
//using Xdgk.Communi.Processor;
using System.Threading;

namespace CommuniServer
{
    /// <summary>
    /// 
    /// </summary>
    public class YeHeCommuniServerApp
    {
        /// <summary>
        /// 
        /// </summary>
        private YeHeCommuniServerApp()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        static public YeHeCommuniServerApp Default
        {
            get
            {
                if (s_default == null)
                {
                    s_default = new YeHeCommuniServerApp();
                }
                return s_default;
            }
        } private static YeHeCommuniServerApp s_default;


        /// <summary>
        /// 
        /// </summary>
        public CommuniSoft CommuniSoft
        {
            get { return _communiSoft; }
            set { _communiSoft = value; }
        } private CommuniSoft _communiSoft;

        /// <summary>
        /// 
        /// </summary>
        public CSDBI CSDBI
        {
            get { return _CSDBI; }
            set { _CSDBI = value; }
        } private CSDBI _CSDBI;

        /// <summary>
        /// 
        /// </summary>
        public ResourceManager ResourceManager
        {
            get
            {
                if (_resourceManager == null)
                {
                    _resourceManager = new ResourceManager();
                }
                return _resourceManager;
            }
        } private ResourceManager _resourceManager;

        /// <summary>
        /// 
        /// </summary>
        public frmMain MainForm
        {
            get { return _mainForm; }
            set { _mainForm = value; }
        } private frmMain _mainForm;

        /// <summary>
        /// 
        /// </summary>
        public CommuniServerProcessor YeHeProcessor
        {
            get 
            {
                if (_yeheProcessor == null)
                {
                    _yeheProcessor = new CommuniServerProcessor();
                }
                return _yeheProcessor;
            }
        } private CommuniServerProcessor _yeheProcessor;
    }

}
