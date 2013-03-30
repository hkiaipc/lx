using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LXRainCommon
{
    /// <summary>
    /// 
    /// </summary>
    abstract public class BaseOpera
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="commandType"></param>
        public BaseOpera(byte address, byte commandType)
        {
            this.Address = address;
            this.CommandType = commandType;
        }

        #region Address
        /// <summary>
        /// 
        /// </summary>
        public byte Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        } private byte _address;
        #endregion //Address

        /// <summary>
        /// 
        /// </summary>
        public byte CommandNO
        {
            get { return _commandNO; }
            set { _commandNO = value; }
        } private byte _commandNO;

        /// <summary>
        /// 
        /// </summary>
        public byte CommandType
        {
            get { return _commandType; }
            set { _commandType = value; }
        } private byte _commandType;

        public byte[] ToBytes()
        {
            MemoryStream ms = new MemoryStream();
            byte[] h = new byte[] { 0x5b, 0x5b };
            byte[] t = new byte[] { 0x5d, 0x5d };

            ms.Write(h, 0, h.Length);
            ms.WriteByte (this.Address);
            ms.WriteByte(this.CommandType);
            ms.WriteByte(this.CommandNO);

            byte[] bs = OnToBytes();
            ms.Write(bs, 0, bs.Length);
            ms.Write(t, 0, t.Length);

            return ms.ToArray();

        }
        abstract public byte[] OnToBytes();
    }

    /// <summary>
    /// 
    /// </summary>
    public class RainRequest : BaseOpera
    {

        public RainRequest(byte address, DateTime from)
            : base(address,0x01)
        {
            this._lastDateTime = from;
        }

        private DateTime _min = DateTime.Parse("2000-1-1");

        public DateTime LastDateTime
        {
            get
            {
                if (_lastDateTime < _min)
                {
                    _lastDateTime = _min;
                }
                return _lastDateTime;
            }
            set { _lastDateTime = value; }
        } private DateTime _lastDateTime;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        static public bool Parse(byte[] bs, out RainRequest result)
        {
            result = null;

            if (bs != null || bs.Length == 15)
            {
                if (bs[0] == 0x5b &&
                    bs[1] == 0x5b &&
                    bs[3] == 0x01 &&
                    bs[13] == 0x5d &&
                    bs[14] == 0x5d)
                {
                    byte address = bs[2];
                    long ticks = BitConverter.ToInt64(bs, 5);
                    DateTime dt = new DateTime(ticks);

                    result = new RainRequest(address, dt);
                    return true;
                }
            }
            return false;
        }

        public override byte[] OnToBytes()
        {
            return BitConverter.GetBytes(this.LastDateTime.Ticks);
        }
    }

    public class RainResponse : BaseOpera
    {
        public RainResponse(byte address)
            : base(address,0x81)
        {
        }

        public DataTable RainDataTable
        {
            get { return _rainDataTable; }
            set { _rainDataTable = value; }
        } private DataTable _rainDataTable;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override byte[] OnToBytes()
        {
            byte dataCount;
            DateTime[] dts;
            int[] rains;

            GetDatas(out dataCount, out dts, out rains);

            MemoryStream ms = new MemoryStream();

            byte[] bs = null;
            Write(ms, dataCount);

            for (int i = 0; i < _n; i++)
            {
                DateTime dt = dts[i];
                bs = BitConverter.GetBytes(dt.Ticks);
                Write(ms, bs);

                int rain = rains[i];
                bs = BitConverter.GetBytes(rain);
                Write(ms, bs);
            }

            return ms.ToArray();
        }

        private void Write(MemoryStream ms, byte[] buffer)
        {
            ms.Write(buffer, (int)0, buffer.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="b"></param>
        private void Write(MemoryStream ms, byte b)
        {
            ms.WriteByte(b);
        }


        static byte _n = 5;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dts"></param>
        /// <param name="rains"></param>
        private void GetDatas(out byte dataCount, out DateTime[] dts, out int[] rains)
        {
            dts = new DateTime[_n];
            rains = new int[_n];
            dataCount = 0;

            if (_rainDataTable != null)
            {
                byte n = _n;
                if (_rainDataTable.Rows.Count < _n)
                {
                    n = (byte)_rainDataTable.Rows.Count;
                }
                dataCount = n;
                for (int i = 0; i < n; i++)
                {
                    DateTime dt = Convert.ToDateTime(_rainDataTable.Rows[i]["RD_Date"]);
                    int sum = Convert.ToInt32(_rainDataTable.Rows[i]["RD_Sum"]);

                    dts[i] = dt;
                    rains[i] = sum;
                }
            }

        }

        /// <summary>
        /// parse data part
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="dataCount"></param>
        /// <param name="dts"></param>
        /// <param name="rains"></param>
        /// <returns></returns>
        static public bool Parse(byte[] bs, byte dataCount, out DateTime[] dts, out int[] rains)
        {
            dts = null;
            rains = null;

            if (dataCount > 0 && dataCount <= _n)
            {
                dts = new DateTime[dataCount];
                rains = new int[dataCount];

                if (bs != null || bs.Length == (8 + 4) * 5)
                {
                    for (int i = 0; i < dataCount; i++)
                    {
                        int idxDT = 12 * i;
                        int idxRain = 12 * i + 8;

                        long ticks = BitConverter.ToInt64(bs, idxDT);
                        int rain = BitConverter.ToInt32(bs, idxRain);

                        dts[i] = new DateTime(ticks);
                        rains[i] = rain;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
