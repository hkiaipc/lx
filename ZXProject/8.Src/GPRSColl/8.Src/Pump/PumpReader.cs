using System;
using GateDriver;
using GprsSystem;

namespace PumpDriver
{
    /// <summary>
    /// Pump_Read ��ժҪ˵����
    /// </summary>
    public class PumpProcessor
    {
        #region Members

        private int address;
        private int flux;
        private int efficiency;
        private long reWater;
        private long tuWater;
        // 2008-5-28 pump_save @run == null exception
        //
        private string run = string.Empty;
        private string forceRun = string.Empty;
        private string vibrate = string.Empty;
        private string power = string.Empty;
        private int recordNO;
        private int totalRecordCount;

        private string runDateTime = DateTime.MinValue.ToString();
        private string stpDateTime = DateTime.MinValue.ToString();
        private long usWater;

        private string sign = string.Empty;
        private string datetime = DateTime.MinValue.ToString();

        private long inWater;
        private long in_reWater;

        private byte[] crc = new byte[2];
        private CRC_16 CRC = new CRC_16();

        private DataFlag _dataFlag = DataFlag.UNKNOWN;
        #endregion //Members

        #region DataFlag
        /// <summary>
        /// 
        /// </summary>
        public DataFlag DataFlag
        {
            get { return _dataFlag; }
        }
        #endregion //DataFlag

        #region PumpReader
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataLength"></param>
        /// <param name="refValue"></param>
        public PumpProcessor(byte[] data, int Len, ref object oPars)
        {
            //����У��
            //
            if (Len <= 2)
            {
                oPars = null;
                _dataFlag = DataFlag.LENGTH_ERROR;
                return;
            }

            //����У��
            byte[] DataVal = new byte[Len - 2];
            for (int i = 0; i < Len - 2; i++)
            {
                DataVal[i] = data[i];
            }
            crc = CRC.CRC16(DataVal);

            //��������
            if (data[Len - 2] == crc[0] && data[Len - 1] == crc[1])
            {
                address = (int)data[3];//�õ�վ��
                switch (data[5])
                {
                    //ʵʱ����
                    case PumpDefine.FCDefine.FC_READREAL:
                        {
                            // �������ݳ���Ӧ��Ϊ46
                            // �п����ϴ�����Ϊ28��CRCУ����ȷ������
                            //
                            if (data.Length == 46)
                            {
                                //Read_Rlt(data, ref refValue);
                                PumpRealData prd = ParseRealData(data);
                                oPars = prd;
                            }
                            else
                            {
                                _dataFlag = DataFlag.LENGTH_ERROR;
                                oPars = null;
                                return;
                            }
                        }
                        break;
                }
                this._dataFlag = DataFlag.OK;
            }
            else
            {
                this._dataFlag = DataFlag.CRC_ERROR;
                oPars = null;
            }
        }
        #endregion //PumpReader

        #region Read_Rlt
        /// <summary>
        /// ��ȡʵʱ���ݲ���
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        //private void ParseRealData(byte[] data, ref object refValue)
        private PumpRealData ParseRealData(byte[] Data)
        {
            //����״̬
            switch (Data[7])
            {
                case 0x50:
                    run = "������״̬";
                    break;
                case 0x5A:
                    run = "��������״̬";
                    break;
                case 0x5B:
                    run = "������״̬";
                    break;
                default:
                    run = string.Format("δ֪״̬(0x{0})", Data[7].ToString("X"));
                    break;
            }
            //ʣ��ˮ��	
            string strReWater = "";
            for (int i = 8; i < 12; i++)//8,9,10,11
            {
                strReWater += Data[i].ToString("x2");
            }
            reWater = Convert.ToInt32(strReWater, 16);
            //����ˮ��
            string strTuWater = "";
            for (int i = 12; i < 16; i++)//12,13,14,15
            {
                strTuWater += Data[i].ToString("x2");
            }
            tuWater = Convert.ToInt32(strTuWater, 16);
            //����
            flux = (Data[16] * 256 + Data[17]);
            //Ч��
            efficiency = (int)Data[18];

            // 2007-09-18 Modify data[19] == 0x38
            //
            //ǿ��״̬
            //			if(data[19]==0x0){forceRun="����ǿ��";}
            //			if(data[19]==0x1){forceRun="��ֹǿ��";}
            byte forceRunByte = Data[19];
            if (forceRunByte == 0x00)
                forceRun = "����ǿ��";
            else if (forceRunByte == 0x01)
                forceRun = "��ֹǿ��";
            else
                forceRun = string.Format("δ֪(0x{0})", forceRunByte.ToString("X2"));

            //�񶯴�����״̬
            if (Data[20] == 0x1) { vibrate = "��״̬"; }
            if (Data[20] == 0x0) { vibrate = "����״̬"; }
            //����״̬
            if (Data[21] == 0x0) { power = "�е�״̬"; }
            if (Data[21] == 0x1) { power = "���״̬"; }
            //��¼��
            recordNO = (int)(Data[22] * 256 + Data[23]);
            //�ܼ�¼��
            totalRecordCount = (int)(Data[24] * 256 + Data[25]);

            //			//��¼��
            //			noRec=(int)(data[26] * 256 + data[27]);	
            if (Data.Length > 30)
            {
                //��������ʱ��	
                string RunDate = "20" + Data[30].ToString("x2") + "-" + Data[29].ToString("x") + "-" + Data[28].ToString("x");
                string RunTime = Data[33].ToString("x") + ":" + Data[32].ToString("x2") + ":" + Data[31].ToString("x2");
                runDateTime = RunDate + " " + RunTime;
                //ͣ������ʱ��	
                string stopDate = "20" + Data[36].ToString("x2") + "-" + Data[35].ToString("x") + "-" + Data[34].ToString("x");
                string stopTime = Data[39].ToString("x") + ":" + Data[38].ToString("x2") + ":" + Data[37].ToString("x2");
                stpDateTime = stopDate + " " + stopTime;
                //�ڼ���ˮ��
                string strUsWater = "";
                for (int i = 40; i < 44; i++)//40,41,42,43
                {
                    strUsWater += Data[i].ToString("x2");
                }
                usWater = Convert.ToInt32(strUsWater, 16);
            }
            PumpRealData rlt = new PumpRealData(address, flux, efficiency, reWater, tuWater, run, forceRun, vibrate,
                power, recordNO, runDateTime, stpDateTime, usWater);
            rlt.OriginalData = (byte[])Data.Clone();
            //refValue = rlt;
            return rlt;

        }
        #endregion //Read_Rlt

        #region Read_His
        /// <summary>
        /// ��ȡ��ʷ���ݲ���
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private void Read_His(byte[] Data, ref object oPars)
        {
            //��¼��
            recordNO = Data[7] * 256 + Data[8];
            //��������ʱ��	
            string RunDate = "20" + Data[11].ToString("x2") + "-" + Data[10].ToString("x") + "-" + Data[9].ToString("x");
            string RunTime = Data[14].ToString("x") + ":" + Data[13].ToString("x2") + ":" + Data[12].ToString("x2");
            runDateTime = RunDate + " " + RunTime;
            //ͣ������ʱ��	
            string StpDate = "20" + Data[17].ToString("x2") + "-" + Data[16].ToString("x") + "-" + Data[15].ToString("x");
            string StpTime = Data[20].ToString("x") + ":" + Data[19].ToString("x2") + ":" + Data[18].ToString("x2");
            stpDateTime = StpDate + " " + StpTime;
            //�ڼ���ˮ��
            string strUsedWater = "";
            for (int i = 21; i < 25; i++)//21,22,23,24
            {
                strUsedWater += Data[i].ToString("x2");
            }
            usWater = Convert.ToInt32(strUsedWater, 16);
            oPars = new PumpHistoryData(address, recordNO, runDateTime, stpDateTime, usWater);
        }
        #endregion //Read_His

        #region Read_RS_Par
        /// <summary>
        /// ��ȡ�ϴ��ĵ���������ͣ������
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private void Read_RS_Par(byte[] Data, ref object oPars)
        {
            //��־λ
            switch (Data[7])
            {
                case 0x01:
                    sign = "��������";
                    break;
                case 0x02:
                    sign = "����ֹͣ";
                    break;
                case 0x03:
                    sign = "������";
                    break;
                case 0x04:
                    sign = "��ֹͣ";
                    break;
            }
            //��ǰ����ʱ��	
            string RunDate = "20" + Data[10].ToString("x2") + "-" + Data[9].ToString("x") + "-" + Data[8].ToString("x");
            string RunTime = Data[13].ToString("x") + ":" + Data[12].ToString("x2") + ":" + Data[11].ToString("x2");
            datetime = RunDate + " " + RunTime;
            //��ǰ����ˮ��
            string strUsedWater = "";
            for (int i = 14; i < 18; i++)//14,15,16,17
            {
                strUsedWater += Data[i].ToString("x2");
            }
            tuWater = Convert.ToInt32(strUsedWater, 16);
            //��ǰʣ��ˮ��
            string strReWater = "";
            for (int i = 18; i < 22; i++)//18,19,20,21
            {
                strReWater += Data[i].ToString("x2");
            }
            reWater = Convert.ToInt32(strReWater, 16);
            oPars = new Pump_RS(address, sign, datetime, tuWater, reWater);
        }
        #endregion //Read_RS_Par

        #region Read_Inp_Water
        /// <summary>
        /// ��ȡ�ϴ����ݿ���������ʱ������
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private void Read_Inp_Water(byte[] Data, ref object oPars)
        {
            //��¼��
            recordNO = Data[7];

            //������ʱ��
            string RunDate = "20" + Data[10].ToString("x2") + "-" + Data[9].ToString("x") + "-" + Data[8].ToString("x");
            string RunTime = Data[13].ToString("x") + ":" + Data[12].ToString("x2") + ":" + Data[11].ToString("x2");
            datetime = RunDate + " " + RunTime;

            //����ˮ��
            string strInWater = "";
            for (int i = 14; i < 18; i++)//14,15,16,17
            {
                strInWater += Data[i].ToString("x2");
            }
            inWater = Convert.ToInt32(strInWater, 16);

            //��ǰʣ��ˮ��
            string strReWater = "";
            for (int i = 18; i < 22; i++)//18,19,20,21
            {
                strReWater += Data[i].ToString("x2");
            }
            reWater = Convert.ToInt32(strReWater, 16);

            //��ǰʣ��ˮ��
            string in_strReWater = "";
            for (int i = 22; i < 26; i++)//22,23,24,25
            {
                in_strReWater += Data[i].ToString("x2");
            }
            in_reWater = Convert.ToInt32(in_strReWater, 16);
            oPars = new Pump_Inp(address, recordNO, datetime, inWater, reWater, in_reWater);
        }
        #endregion //Read_Inp_Water

        #region Read_Sts
        /// <summary>
        /// ��ȡ�ϴ�����״̬
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private void Read_Sts(byte[] Data, ref object oPars)
        {
            switch (Data[5])
            {
                //����״̬
                case 0x00:
                    oPars = new Pump_Sts(address, "���óɹ�");
                    break;
                //ͣ��״̬
                case 0x01:
                    oPars = new Pump_Sts(address, "ͣ�óɹ�");
                    break;
                //ˮ������״̬
                case 0x02:
                    oPars = new Pump_Sts(address, "ˮ�����óɹ�");
                    break;
                //��������
                case 0x03:
                    oPars = new Pump_Sts(address, "�������óɹ�");
                    break;
                //��ͣ������
                case 0x04:
                    oPars = new Pump_Sts(address, "��ͣ�����óɹ�");
                    break;
                //���ݿ�����
                case 0x05:
                    oPars = new Pump_Sts(address, "���ݿ����óɹ�");
                    break;
                //��������
                case 0x07:
                    oPars = new Pump_Sts(address, "�������óɹ�");
                    break;
                //Ч������
                case 0x08:
                    oPars = new Pump_Sts(address, "Ч�����óɹ�");
                    break;
                //վ������
                case 0x09:
                    oPars = new Pump_Sts(address, "վ�����óɹ�");
                    break;
                //�񶯴���������ʱ��
                case 0x0A:
                    oPars = new Pump_Sts(address, "�񶯴���������ʱ�����óɹ�");
                    break;
                //�޸�����
                case 0x0B:
                    oPars = new Pump_Sts(address, "�޸����ڳɹ�");
                    break;
                //�޸�ʱ��
                case 0x0C:
                    oPars = new Pump_Sts(address, "�޸�ʱ��ɹ�");
                    break;
                //������м�¼
                case 0x0D:
                    oPars = new Pump_Sts(address, "������м�¼�ɹ�");
                    break;
                //����򿨼�¼
                case 0x0E:
                    oPars = new Pump_Sts(address, "����򿨼�¼�ɹ�");
                    break;
                //���ʣ��ˮ������ˮ��
                case 0x0F:
                    oPars = new Pump_Sts(address, "���ʣ��ˮ������ˮ���ɹ�");
                    break;
                //�������ʱ��
                case 0x10:
                    oPars = new Pump_Sts(address, "�������ʱ��ɹ�");
                    break;
                //���ñ�վǿ��״̬
                case 0x18:
                    oPars = new Pump_Sts(address, "�������óɹ�");
                    break;
                //��ȡ��������
                case 0x1E:
                    string Pwd_Mn = Convert.ToString(Data[7] * 256 + Data[8]);
                    oPars = new Pump_Sts(address, "��������:" + "\r\n" + Pwd_Mn);
                    break;
                //��ȡ��ͣ������
                case 0x1F:
                    string Pwd_Rs = Convert.ToString(Data[7] * 256 + Data[8]);
                    oPars = new Pump_Sts(address, "��ͣ������:" + "\r\n" + Pwd_Rs);
                    break;
                //��ȡ���ݿ�����
                case 0x20:
                    string Pwd_Dt = Convert.ToString(Data[7] * 256 + Data[8]);
                    oPars = new Pump_Sts(address, "���ݿ�����:" + "\r\n" + Pwd_Dt);
                    break;
                //���ù�������
                case 0x21:
                    oPars = new Pump_Sts(address, "���ù�������ɹ�");
                    break;
                //������ͣ������
                case 0x22:
                    oPars = new Pump_Sts(address, "������ͣ������ɹ�");
                    break;
                //�������ݿ�����
                case 0x23:
                    oPars = new Pump_Sts(address, "�������ݿ�����ɹ�");
                    break;
            }
        }
        #endregion //Read_Sts
    }
}
