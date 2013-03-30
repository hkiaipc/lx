using System;

namespace GprsSystem
{
    /// <summary>
    /// CmdFactory ��ժҪ˵����
    /// </summary>
    public class CmdFactory
    {

        static private readonly string READ_DTU_SETTINGS = "��ȡDTU���ݷ�����������";

        #region CmdFactory
        /// <summary>
        /// 
        /// </summary>
        public CmdFactory()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }
        #endregion //CmdFactory

        #region Cmds
        /// <summary>
        /// 
        /// </summary>
        static public string[] Cmds
        {
            get
            {
                return new string[] { READ_DTU_SETTINGS };
            }
        }
        #endregion //Cmds

        #region CreateCmd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdName"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        static public byte[] CreateCmd(string cmdName, DeviceInfo info)
        {
            System.Diagnostics.Debug.Assert(info != null);
            if (cmdName == READ_DTU_SETTINGS)
            {
                return CreateReadDtuDscSettingCmd(info.Sim);
            }
            return null;
        }
        #endregion //CreateCmd

        #region CreateReadDtuDscSettingCmd
        /// <summary>
        /// ���ɶ�ȡDTU�����ݷ����������õ�����
        /// </summary>
        /// <param name="simCard">��DTU��Sim������</param>
        /// <returns>byte[]</returns>
        static private byte[] CreateReadDtuDscSettingCmd(string simCard)
        {
            byte[] simbs = SGDtu.GetSimNumberBytes(simCard);
            int cmdLen = 0x11;
            byte[] bs = new byte[cmdLen];
            //bs[0] = 0x7B;

            bs[0] = SGDefine.HEAD_VALUE;
            bs[1] = SGDefine.FC_R_DTU_SETTING;
            bs[2] = 0x00;
            bs[3] = (byte)cmdLen;
            Array.Copy(simbs, 0, bs, 4, simbs.Length);
            bs[15] = SGDefine.DtuParamSettingFC.READ_DSC;
            bs[16] = SGDefine.TAIL_VALUE;

            return bs;
        }
        #endregion //CreateReadDtuDscSettingCmd
    }
}
