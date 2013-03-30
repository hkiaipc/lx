using System;
using System.Collections;
using System.Text;

namespace GprsSystem
{
	/// <summary>
	/// LogItem 的摘要说明。
	/// </summary>
    public class LogItem
    {
        #region NameValuePair
        class NameValuePair
        {
            private string _name;
            private string _value;
            private bool   _onlyName; 
            private int    _nameCnCharCount; 

            public NameValuePair( string name, string value )
            {
                _name = name;
                CalcNameCnCharCount();
                _value = value;
            }

            public NameValuePair( string name )
            {
                _name = name;
                _onlyName = true;
            }

            public int NameCnCharCount
            {
                get { return _nameCnCharCount; }
            }

            private void CalcNameCnCharCount()
            {
                _nameCnCharCount = CalcCnCharCount( _name );
            }

            static private int CalcCnCharCount( string name )
            {
                char[] cs = name.ToCharArray();
                int ccc = 0;
                foreach ( char c in cs )
                {
                    if ( c > 255 )
                        ccc ++;
                }
                return ccc;
            }

            
            public string Name
            {
                get { return _name; }
                set 
                {
                    _name = value; 
                    CalcNameCnCharCount();
                }
            }

            public string Value
            {
                get { return _value; }
                set { _value = value;}
            }

            public bool OnlyName
            {
                get { return _onlyName; }
            }
        }
        #endregion //NameValuePair


        private ArrayList   _list = new ArrayList( 5 );
        private int         _maxNameLength = 8; //"DateTime" 's length
        private bool        _shouldLog = false;
        private bool        _hasDateTime = true;
        
        static private string s_filedSeparator = Environment.NewLine;
        static private string s_logItemSeparator = Environment.NewLine;
        static private string s_nameValueSeparator = " : ";
        
        /// <summary>
        /// 
        /// </summary>
        static public string S_FidldSeparator
        {
            get { return s_filedSeparator; }
            set { s_filedSeparator = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        static public string S_LogItemSeparator
        {
            get { return s_logItemSeparator; }
            set { s_logItemSeparator = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _filedSeparator;
        private string _logItemSeparator;
        private string _nameValueSeparator;

        /// <summary>
        /// 
        /// </summary>
        public string NameValueSeparator
        {
            get { return _nameValueSeparator; }
            set { _nameValueSeparator = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FiledSeparator
        {
            get { return _filedSeparator; }
            set { _filedSeparator = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool HasDateTime
        {
            get { return _hasDateTime; }
            set 
            { 
                if ( _hasDateTime != value )
                    _hasDateTime = value; 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LogItemSeparator
        {
            get { return _logItemSeparator; }
            set { _logItemSeparator = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public LogItem()
        {  
            _filedSeparator = s_filedSeparator;
            _logItemSeparator = s_logItemSeparator;
            _nameValueSeparator = s_nameValueSeparator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public LogItem( string name, object value ) : this()
        {
            Add( name, value );
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Add( string name, object value )
        {
            string sv = GetString( value );
            NameValuePair nvp = new NameValuePair( name, sv );
            
            _list.Add( nvp );

            int length = nvp.Name.Length + nvp.NameCnCharCount;
            if ( length > _maxNameLength )
                _maxNameLength = length;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void Add( string name )
        {
            NameValuePair nvp = new NameValuePair( name );
            _list.Add( nvp );
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ShouldLog
        {
            get { return _shouldLog; }
            set { _shouldLog = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetFormatString(int cnCharCount)
        {
            return string.Format( "{{0,-{0}}}{1}{{1}}{{2}}", _maxNameLength - cnCharCount, _nameValueSeparator );
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string formatString = GetFormatString(0);

            StringBuilder sb = new StringBuilder();

            if ( HasDateTime )
                sb.AppendFormat( formatString, "DateTime", DateTime.Now, _filedSeparator );

            foreach ( object obj in _list )
            {
                NameValuePair nvp = obj as NameValuePair;
            
                if ( nvp.OnlyName )
                {
                    sb.Append( nvp.Name + _filedSeparator );
                }
                else
                {
                    
                    formatString = GetFormatString( nvp.NameCnCharCount );
                    if ( nvp.Value.IndexOf( "\n" ) != -1 )
                    {
                        string fillString = GetFillString();
                        sb.AppendFormat( 
                            // nvp.NameCnCharCount == 0 ? formatString : GetFormatString( nvp.NameCnCharCount ), 
                            formatString,
                            nvp.Name, 
                            FormatMultiLineString( nvp.Value, fillString ), 
                            _filedSeparator 
                            );
                    }
                    else
                    {
                        sb.AppendFormat( formatString, nvp.Name, nvp.Value, _filedSeparator );
                    }
                }
            }

            sb.Append( _logItemSeparator );
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetFillString()
        {
            return new string(' ', _maxNameLength + _nameValueSeparator.Length );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fillCount"></param>
        /// <returns></returns>
        //        static private string FormatMultiLineString( string value,  int fillCount )
        static private string FormatMultiLineString( string value,  string fillString)
        {
            return value.Replace( "\n", "\n" + fillString );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static private string GetString( object value )
        {
            if ( value == null )
                return "<null>";
            return value.ToString();
        }
    }

}
