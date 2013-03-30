using System;
using System.IO;
using GprsSystem;

namespace GateDriver
{
    /// <summary>
    /// �������������࣬��������浽oPars�����С��������������oParsΪnull��
    /// </summary>
    public class GateReader
    {
        private int comAdr;
        private int beforeLevel;
        private int behindLevel;
        private int height;
        private float flux;
        private long reWater;
        private long tuWater;
        private string power = string.Empty;
        private string lock_OC = string.Empty;

        private int noRec;
        private string datetime = DateTime.MinValue.ToString();

        private int toRec;
        private long inWater;

        private int width;
        private int bottomHeight;
        private float freeFlux;
        private float undrFlux;
        private int beforeCorrect;
        private int behindCorrect;

        private byte[] crc = new byte[2];
        private CRC_16 CRC = new CRC_16();

        private DataFlag _dataFlag;

        #region DataFlag
        /// <summary>
        /// ��ȡ����״̬��־
        /// </summary>
        public DataFlag DataFlag
        {
            get { return _dataFlag; }
        }
        #endregion //DataFlag

        #region GateReader
        /// <summary>
        /// �������Կ��Ų��������
        /// </summary>
        /// <param name="data">�û�����</param>
        /// <param name="dataLength"></param>
        /// <param name="refValue">���ؽ��</param>
        public GateReader(byte[] data, ref object oPars)
        {
            int dataLength = 0;
            if (data != null)
            {
                dataLength = data.Length;
            }

            //TODO: len < 2, 2007-06-25 Added
            //
            //����У��
            if (dataLength <= 2)
            {
                oPars = null;
                _dataFlag = DataFlag.LENGTH_ERROR;
                return;
            }

            byte[] dataValue = new byte[dataLength - 2];
            for (int i = 0; i < dataLength - 2; i++)
            {
                dataValue[i] = data[i];
            }
            crc = CRC.CRC16(dataValue);

            //��������(��У��)
            //
            // crc success
            //
            if (data[dataLength - 2] == crc[0] && data[dataLength - 1] == crc[1])
            {
                //�õ�վ��
                comAdr = (int)data[3];

                // data[5] - Function code
                //
                switch (data[5])
                {
                    //��������
                    case 0x23:
                        Read_Par(data, ref oPars);
                        break;
                    //ʵʱ����
                    case 0x24:
                        Read_Rlt(data, ref oPars);
                        break;
                    //��ʷ��¼
                    case 0x25:
                        {
                            if (!Read_His(data, ref oPars))
                            {
                                _dataFlag = DataFlag.DATA_ERROR;
                                oPars = null;
                                return;
                            }
                            break;
                        }
                    //����ˮ����¼
                    //
                    case 0x37:
                        Read_InWater(data, ref oPars);
                        break;

                    //���һ����¼
                    //
                    case 0x3C:
                        if (!Read_His(data, ref oPars))
                        {
                            _dataFlag = DataFlag.DATA_ERROR;
                            oPars = null;
                            return;
                        }
                        break;

                    //��ȡ״̬��
                    //
                    default:
                        Read_Sts(data, ref oPars);
                        break;
                }
                _dataFlag = DataFlag.OK;
            }
            else
            {
                _dataFlag = DataFlag.CRC_ERROR;
                oPars = null;
            }
        }
        #endregion //GateReader

        #region Read_Rlt
        /// <summary>
        /// ��ȡʵʱ���ݲ���
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private void Read_Rlt(byte[] Data, ref object oPars)
        {
            //ʵ��բ��
            height = Data[7] * 256 + Data[8];
            //բǰˮλ
            beforeLevel = Data[9] * 256 + Data[10];
            //բ��ˮλ
            behindLevel = Data[11] * 256 + Data[12];
            //˲ʱ����
            if (Data[13] == 0xFF && Data[14] == 0xFF)
            {
                flux = 9999;//����˲ʱ����
            }
            else
            {
                flux = (Data[13] * 256 + Data[14]) / 100f;//��ȷ˲ʱ����
            }
            //ʣ��ˮ��
            string strReWater = "";
            for (int i = 15; i < 19; i++)//15,16,17,18
            {
                strReWater += Data[i].ToString("x2");
            }
            reWater = Convert.ToInt32(strReWater, 16);
            //����ˮ��
            string strTuWater = "";
            for (int i = 19; i < 23; i++)//19,20,21,22
            {
                strTuWater += Data[i].ToString("x2");
            }
            tuWater = Convert.ToInt32(strTuWater, 16);
            //����״̬
            if (Data[23] == 0x00) { power = "�е�״̬"; }
            if (Data[23] == 0xFF) { power = "���״̬"; }
            //������״̬
            switch (Data[24])
            {
                case 0x00:
                    lock_OC = "ǿ��״̬";
                    break;

                case 0x01:
                    lock_OC = "ǿ��״̬";
                    break;

                case 0x02:
                    lock_OC = "����״̬";
                    break;

                default:
                    lock_OC = "δ֪״̬";
                    break;

            }
            oPars = new Gate_Rlt(comAdr, beforeLevel, behindLevel, height, flux, reWater, tuWater, power, lock_OC);
        }
        #endregion //Read_Rlt

        #region Read_His
        /// <summary>
        /// ��ȡ��ʷ���ݲ���
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private bool Read_His(byte[] bs, ref object refValue)
        {
            try
            {
                if (bs == null || bs.Length < 32)
                {
                    return false;
                }
                // TODO: 2012-04-24 
                // System.IndexOutOfRangeException: ����������������ޡ�
                //
                //

                //��¼��
                noRec = bs[7] * 256 + bs[8];
                //����ʱ��	
                string Date = "20" + bs[9].ToString("x2") + "-" + bs[10].ToString("x") + "-" + bs[11].ToString("x");
                string Time = bs[12].ToString("x") + ":" + bs[13].ToString("x2") + ":" + bs[14].ToString("x2");
                datetime = Date + " " + Time;

                //            if (datetime.
                // TODO: Added 07-07-16 datetime error
                //
                try
                {
                    DateTime dt = DateTime.Parse(datetime);
                }
                catch (Exception ex)
                {
                    SaveException(bs, ex);
                    //                System.Diagnostics.Debug.Assert( false, datetime );
                    refValue = null;
                    return false;
                }
                //բǰˮλ
                beforeLevel = bs[15] * 256 + bs[16];
                //բ��ˮλ
                behindLevel = bs[17] * 256 + bs[18];
                //ʵ��բ��
                height = bs[19] * 256 + bs[20];
                //˲ʱ����
                if (bs[21] == 0xFF && bs[22] == 0xFF)
                {
                    flux = 9999;//����˲ʱ����
                }
                else
                {
                    flux = (bs[21] * 256 + bs[22]) / 100f;//��ȷ˲ʱ����
                }
                //ʣ��ˮ��
                string strReWater = "";
                for (int i = 23; i < 27; i++)//23,24,25,26
                {
                    strReWater += bs[i].ToString("x2");
                }
                reWater = Convert.ToInt32(strReWater, 16);
                //����ˮ��
                string strTuWater = "";
                for (int i = 27; i < 31; i++)//27,28,29,30
                {
                    strTuWater += bs[i].ToString("x2");
                }
                tuWater = Convert.ToInt32(strTuWater, 16);
                //����״̬
                if (bs[31] == 0x00) { power = "�е�״̬"; }
                if (bs[31] == 0xFF) { power = "���״̬"; }
                //������״̬
                switch (bs[32])
                {
                    case 0x00:
                        lock_OC = "ǿ��״̬";
                        break;
                    case 0x01:
                        lock_OC = "ǿ��״̬";
                        break;
                    case 0x02:
                        lock_OC = "����״̬";
                        break;
                }
                refValue = new Gate_His(comAdr, noRec, datetime, beforeLevel, behindLevel, height, flux, reWater, tuWater, power, lock_OC);
                return true;
            }
            catch (Exception ex)
            {
                SaveException(bs, ex);
                return false;
            }
        }
        #endregion //Read_His

        #region SaveException
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="ex"></param>
        private void SaveException(byte[] bs, Exception ex)
        {
            try
            {
                System.IO.StreamWriter sw = File.AppendText("c:\\read_his.err");
                string s = BitConverter.ToString(bs);
                sw.WriteLine(s);
                sw.WriteLine(ex.ToString());
                sw.WriteLine(datetime);
                sw.Close();
            }
            finally
            {

            }
        }
        #endregion //SaveException

        #region Read_InWater
        /// <summary>
        /// ��ȡ����ˮ����¼
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private void Read_InWater(byte[] Data, ref object oPars)
        {
            //�ܼ�¼��
            toRec = Data[7];
            //��¼��
            noRec = Data[8];
            //����ʱ��	
            string Date = "20" + Data[9].ToString("x2") + "-" + Data[10].ToString("x") + "-" + Data[11].ToString("x");
            string Time = Data[12].ToString("x") + ":" + Data[13].ToString("x2") + ":" + Data[14].ToString("x2");
            datetime = Date + " " + Time;
            //����ˮ��
            string strInWater = "";
            for (int i = 15; i < 19; i++)//15,16,17,18
            {
                strInWater += Data[i].ToString("x2");
            }
            inWater = Convert.ToInt32(strInWater, 16);
            oPars = new Gate_Inp(comAdr, toRec, noRec, datetime, inWater);
        }
        #endregion //Read_InWater


        #region Read_Par
        /// <summary>
        /// ��ȡ�������ݲ���
        /// </summary>
        /// <param name="data">�û�����</param>
        /// <param name="refValue">���ؽ��</param>
        private void Read_Par(byte[] Data, ref object oPars)
        {
            //�ӻ���ַ
            comAdr = Data[7];
            //ʵ��բ��
            width = Data[8] * 256 + Data[9];
            //բ�׸߳�
            bottomHeight = Data[10] * 256 + Data[11];
            //������ϵ��
            freeFlux = Data[12] / 100;
            //Ǳ��ϵ��
            undrFlux = Data[21] / 100;
            //բǰˮλ����
            beforeLevel = Data[13] * 256 + Data[14];
            //բ��ˮλ����
            behindLevel = Data[15] * 256 + Data[16];
            //բǰˮλ����
            if (Data[17] == 0x43) { beforeCorrect = (int)Data[18]; }
            if (Data[17] == 0x45) { beforeCorrect = (int)Data[18] * -1; }
            //բ��ˮλ����
            if (Data[19] == 0x43) { behindCorrect = (int)Data[20]; }
            if (Data[19] == 0x45) { behindCorrect = (int)Data[20] * -1; }
            oPars = new Gate_Par(comAdr, width, bottomHeight, freeFlux, undrFlux, beforeLevel, behindLevel, beforeCorrect, behindCorrect);
        }
        #endregion //Read_Par

        #region Read_Sts
        /// <summary>
        /// ��ȡ�ϴ�����״̬
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private void Read_Sts(byte[] Data, ref object oPars)
        {
            // data[5] - function code
            //
            switch (Data[5])
            {
                //����״̬
                case 0x2D:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "�����ɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "����ʧ��");
                    }
                    break;
                //����״̬
                case 0x2E:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "�����ɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "����ʧ��");
                    }
                    break;
                //����������״̬
                case 0x2F:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "�������������óɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "��������������ʧ��");
                    }
                    break;
                //�ϴ����ݿ���
                case 0x27:
                    string strTm = "";
                    for (int i = 7; i < 15; i++)//7,8,9,10,11,12,13,14
                    {
                        strTm += Data[i].ToString("x2") + " ";
                    }
                    oPars = new Gate_Sts(comAdr, "���ݿ���:" + "\r\n" + strTm);
                    break;
                //�޸Ĵӻ�ջ�Ų�����
                case 0x16:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "�޸Ĵӻ�ջ�Ų����ʳɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "�޸Ĵӻ�ջ�Ų�����ʧ��");
                    }
                    break;
                //�޸�բ��
                case 0x17:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "�޸�բ��ɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "�޸�բ��ʧ��");
                    }
                    break;
                //�޸�բ�׸߳�
                case 0x18:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "�޸�բ�׸̳߳ɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "�޸�բ�׸߳�ʧ��");
                    }
                    break;
                //�޸�����ϵ��
                case 0x19:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "�޸�����ϵ���ɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "�޸�����ϵ��ʧ��");
                    }
                    break;
                //�޸�բǰˮλ����
                case 0x1A:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "�޸�բǰˮλ���̳ɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "�޸�բǰˮλ����ʧ��");
                    }
                    break;
                //�޸�բ��ˮλ����
                case 0x1B:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "�޸�բ��ˮλ���̳ɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "�޸�բ��ˮλ����ʧ��");
                    }
                    break;
                //�޸�����
                case 0x1E:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "�޸����ڳɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "�޸�����ʧ��");
                    }
                    break;
                //�޸�ʱ��
                case 0x1F:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "�޸�ʱ��ɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "�޸�ʱ��ʧ��");
                    }
                    break;
                //����ˮ��
                case 0x20:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "����ˮ���ɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "����ˮ��ʧ��");
                    }
                    break;
                //�����ˮ��
                case 0x21:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "�����ˮ���ɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "�����ˮ��ʧ��");
                    }
                    break;
                //���ݿ�����
                case 0x22:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "���ݿ����óɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "���ݿ�����ʧ��");
                    }
                    break;
                //�����ʷ��¼
                case 0x26:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "�����ʷ��¼�ɹ�");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "�����ʷ��¼ʧ��");
                    }
                    break;
            }
        }
        #endregion //Read_Sts
    }
}
