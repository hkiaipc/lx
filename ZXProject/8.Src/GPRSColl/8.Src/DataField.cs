using System;

namespace GprsSystem
{
    /// <summary>
    /// Êý¾ÝÓò
    /// </summary>
    public struct DataField
    {
        public const int UNSURENESS = -1;

        private int     _beginPosition;
        private int     _dataLength;
        private byte[]  _values;
        private bool    _isAssuredValues;
        

        #region DataField
        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginPosition"></param>
        /// <param name="dataLength"></param>
        /// <param name="values"></param>
        public DataField( int beginPosition, int dataLength, byte[] values )
        {
            _beginPosition = beginPosition;
            _dataLength = dataLength;

            _values = values;            

            if ( values != null )
                _isAssuredValues = true;
            else
                _isAssuredValues = false;
        }
        #endregion //DataField

        #region DataField
        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginPosition"></param>
        /// <param name="dataLength"></param>
        public DataField( int beginPosition, int dataLength ) : this ( beginPosition, dataLength, null )
        {
        }
        #endregion //DataField

        #region DataField
        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginPosition"></param>
        public DataField( int beginPosition ) : this ( beginPosition, 1 )
        {
        }
        #endregion //DataField

        #region BeginPostion
        /// <summary>
        /// 
        /// </summary>
        public int BeginPostion
        {
            get { return _beginPosition; }
            set { _beginPosition = value; }
        }
        #endregion //BeginPostion

        #region DataLength
        /// <summary>
        /// 
        /// </summary>
        public int DataLength
        {
            get { return _dataLength; }
            set { _dataLength = value; }
        }
        #endregion //DataLength

        #region Values
        /// <summary>
        /// 
        /// </summary>
        public byte[] Values
        {
            get { return _values; }
            set { _values = value; }
        }
        #endregion //Values

        #region FirstByte
        /// <summary>
        /// 
        /// </summary>
        public byte FirstByte
        {
            get 
            {
                if (_values != null && _values.Length > 0)
                {
                    return Values[0];
                }
                else
                {
                    throw new InvalidOperationException("datafield values == null or length == 0");
                }
            }
        }
        #endregion //FirstByte

        #region IsAssuredValues
        /// <summary>
        /// 
        /// </summary>
        public bool IsAssuredValues
        {
            get { return _isAssuredValues; }
            set { _isAssuredValues = value; } 
        }
        #endregion //IsAssuredValues


        #region IsMatch
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool IsMatch( byte[] datas, int index )
        {
            if ( datas == null )
                return false;
            if ( this._beginPosition == UNSURENESS ||
                this._dataLength == UNSURENESS    ||
                this._isAssuredValues == false    || 
                this._values == null )
                return false;

            int b = index + _beginPosition;
            int e = b + _dataLength;
            
            if ( b > datas.Length || e > datas.Length )
                return false;

            for ( int i=0; i<_dataLength; i++ )
            {
                if ( datas[ b + i ] != _values[ i ] )
                    return false;
            }
            return true;
        }
        #endregion //IsMatch
    }

	
}
