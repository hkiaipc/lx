using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace XD2206DataImporter
{
    /// <summary>
    /// 
    /// </summary>
    public class Importer
    {

        /// <summary>
        /// 
        /// </summary>
        private WriteDelegate _writeDelegate;

        public Importer(WriteDelegate writeDelegate)
        {
            _writeDelegate = writeDelegate;
        }

        private Timer Timer
        {
            get
            {
                if (_timer == null)
                {
                    _timer = new Timer();

                    // 2 minute per time
                    //
                    _timer.Interval = 10 * 1000;
                    _timer.Tick += new EventHandler(_timer_Tick);
                }
                return _timer;
            }
        } private Timer _timer;

        public void Start()
        {
            Timer.Start();
        }

        public void Stop()
        {
            Timer.Stop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param deviceType="sender"></param>
        /// <param deviceType="e"></param>
        void _timer_Tick(object sender, EventArgs e)
        {
            this.Doit();
        }

        /// <summary>
        /// 
        /// </summary>
        private Config Config
        {
            get
            {
                if (_config == null)
                {
                    _config = CreateConfig();
                }
                return _config;
            }
        } private Config _config;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Config CreateConfig()
        {
            string filename = Path.Combine(Application.StartupPath, "xd2206import.xml");
            Config config = null;
            try
            {
                config = (Config)Config.Load(typeof(Config), filename);
            }
            catch (Exception ex)
            {
                config = new Config();
                config.FromConnectionString = "f";
                config.ToConnectionString = "t";
                config.ImportInterval = TimeSpan .Parse ("00:00:10");

                NameMap nm = new NameMap();
                nm.FromName = "FN";
                nm.ToName = "TN";

                config.NameMapCollection.Add(nm);

                config.Save(filename);
                NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
                Environment.Exit(1);
            }
            return config;
        }

        /// <summary>
        /// 
        /// </summary>
        private DateTime _lastExecuteDT;

        public void Doit()
        {
            if (Config.Enabled)
            {
                if (NeedExecute())
                {
                    ExecuteImport();
                    _lastExecuteDT = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool NeedExecute()
        {
            TimeSpan ts = DateTime.Now - _lastExecuteDT;
            if (ts > _config.ImportInterval || ts < TimeSpan.Zero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ExecuteImport()
        {
            foreach (TransItem item in this.TransItemCollection)
            {
                DateTime lastDT = item.ToDevice.ReadLastDataDateTime();
                DataTable tbl = item.FromDevice.ReadDataTable(lastDT);

                item.ToDevice.WriteDataTable(tbl);
            }
        }

        #region ImportItemCollection
        /// <summary>
        /// 
        /// </summary>
        public TransItemCollection TransItemCollection
        {
            get
            {
                if (_transItemCollection == null)
                {
                    // create
                    //
                    _transItemCollection = new TransItemCollection();
                    foreach ( NameMap nm in Config.NameMapCollection )
                    {
                        TransItem item = TransItemFactory.Create(nm, this.Config.FromDBI, this.Config.ToDBI, _writeDelegate);
                        _transItemCollection.Add(item);
                    }
                }
                return _transItemCollection;
            }
            set
            {
                _transItemCollection = value;
            }
        } private TransItemCollection _transItemCollection;
        #endregion //ImportItemCollection


    }
}
