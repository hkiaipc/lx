using System;
using System.Collections;

        #region CheckHead
namespace GprsSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class PumpController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        static private bool CheckHead( byte[] datas, int index )
        {
            return PumpDefine.HEAD.IsMatch( datas, index );
        }
        #endregion //CheckHead

        #region CheckDevType
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        static private bool CheckDevType( byte[] datas, int index )
        {
            return PumpDefine.DEV_TYPE.IsMatch( datas, index );
        }
        #endregion //CheckDevType

        #region Pick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        static public byte[][] Pick( byte[] userData )
        {
            if ( userData == null || userData.Length == 0 )
                return null;
            ArrayList al = new ArrayList();
            
            if ( userData.Length >= PumpDefine.MIN_LEN )
            {
                for ( int i=0; i<userData.Length - PumpDefine.MIN_LEN; i++ )
                {
                    if ( CheckHead( userData, i ) &&
                        CheckDevType( userData, i ) )
                    {
                        int innerDataLen = userData[ i + PumpDefine.DATALEN.BeginPostion ];
                        int dataLen = innerDataLen + 9;
                        if ( dataLen < PumpDefine.MIN_LEN )
                            continue;
                        int tailPos = i + dataLen - 1;
                        if ( tailPos < userData.Length )
                        {
                            byte[] bs = new byte[ dataLen ];
                            Array.Copy ( userData, i, bs, 0, dataLen );
                            al.Add( bs );
                        }
                    }
                }
            }

            if ( al.Count != 0 )
            {
                byte[][] r = new byte[al.Count][];
                for( int i=0; i<al.Count; i++ )
                {
                    r[ i ] = al[ i ] as byte[];
                }
                return r;
            }

            return null;
        }
        #endregion //Pick
    }
}


