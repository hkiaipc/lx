using System;
using System.IO;
namespace GprsSystem
{
    

    /// <summary>
    /// ILog 的摘要说明。
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 
        /// </summary>
        bool WithDateTime
        {
            get;
            set;
        }

        void Add( object content );
        void Add( object name, object content );

        bool Open();
        void Close();
    }

    #region FileLog
    /// <summary>
    /// 
    /// </summary>
    public class FileLog : ILog
    {
        string m_Path;
        System.IO.StreamWriter m_SW = null; 
        bool _withDateTime = true;

        public bool WithDateTime
        {
            get { return _withDateTime; }
            set { _withDateTime = value; }
        }

        public FileLog() : this(".\\default.log")
        {
        }

        public FileLog(string path)
        {
            this.m_Path = path;
        }

        public bool Open()
        {
            m_SW = File.AppendText(m_Path);
            return true;
        }
		
        private string GetString( object obj )
        {
            if ( obj == null )
                return "<null>";
            else
                return obj.ToString();
        }

        public void Add(object content)
        {
            if (m_SW == null) 
                Open();

            if ( _withDateTime )
                m_SW.Write( DateTime.Now.ToString() + " " );
            m_SW.WriteLine ( GetString( content ) );
            m_SW.Flush();
        }

        public void Add(object name, object content)
        {
            if ( m_SW == null )
                Open();

            if ( _withDateTime )
                m_SW.Write(  DateTime.Now.ToString() + " " );
            m_SW.WriteLine ( GetString( name ) + " " + GetString( content ) );
            m_SW.Flush();
        }

        public void Close()
        {
            if ( m_SW != null )
            {
                m_SW.Close();
                m_SW = null;
            }
        }
    }

    #endregion //FileLog
}
