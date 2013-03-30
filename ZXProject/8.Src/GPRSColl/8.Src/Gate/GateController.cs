using System;
using System.Collections;

namespace GprsSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class GateController
    {

        #region CheckHead
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        static private bool CheckHead( byte[] datas, int index )
        {
            return GateDefine.HEAD.IsMatch( datas, index );
        }
        #endregion //CheckHead

        #region CheckDevType
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        static private bool CheckDevType ( byte[] datas, int index )
        {
            return GateDefine.DEV_TYPE.IsMatch( datas, index );
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
            
            if ( userData.Length >= GateDefine.MIN_LEN )//&& userData.Length < PumpDefine.MIN_LEN )
            {
                // get gate controller data
                //
                for ( int i=0; i<userData.Length - GateDefine.MIN_LEN; i++ )
                {
                    if ( CheckHead( userData, i ) &&
                        CheckDevType( userData, i ) )
                    {
                        int dataLen = userData[ i + GateDefine.DATALEN.BeginPostion ];
                        if ( dataLen < GateDefine.MIN_LEN )
                            continue;

                        int innerDataLen = dataLen - 9;
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

            if ( al.Count == 0 )
            {
                return null;
            }
            else
            {
                byte[][] r = new byte[al.Count][];
                for( int i=0; i<al.Count; i++ )
                {
                    r[ i ] = al[ i ] as byte[];
                }
                return r;
            }
        }
        #endregion //Pick
    }
}
