using System;

namespace GprsSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class DebugLog
    {
        private static DebugLog s_default = new DebugLog();

        private FileLog _filelog = new FileLog();
        private int _logcount;
        private const int MAX_COUNT = 100;

        /// <summary>
        /// 
        /// </summary>
        public static DebugLog Default
        {
            get { return s_default; }
        }

        /// <summary>
        /// 
        /// </summary>
        private frmDebug _frmDebug = new frmDebug();
        /// <summary>
        /// 
        /// </summary>
        public DebugLog()
        {
            _frmDebug.Show();
            _filelog.WithDateTime = false;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public void AddCommon(string s)
        {
            _logcount++;
            if (_logcount >= MAX_COUNT)
            {
                Clear();
            }

            //            string logstr = DateTime.Now + " : " + s  + Environment.NewLine;
            //            string logstr = DateTime.Now + Environment.NewLine 
            //                + s + Environment.NewLine ;

            _frmDebug.CommonTextBox.AppendText(s);
            _filelog.Add(s);

        }

        public void AddCommon(object obj)
        {
            if (obj == null)
                AddCommon("<null>");
            else
                AddCommon(obj.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            _logcount = 0;
            _frmDebug.CommonTextBox.Clear();
        }
    }
}
