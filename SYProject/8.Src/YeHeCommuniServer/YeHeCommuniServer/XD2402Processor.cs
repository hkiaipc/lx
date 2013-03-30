using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi ;
using Xdgk.Common ;

namespace CommuniServer
{
    /// <summary>
    /// 
    /// </summary>
    public class XD2402Processor
    {
        /// <summary>
        /// 
        /// </summary>
        static public void ProduceExecutedTask( Task t , ParseResult pr )
        {
            if (pr.Success)
            {
                ProcessSuccess(t, pr);
            }
            else
            {
                ProcessFail(t, pr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="pr"></param>
        private static void ProcessSuccess(Task task, ParseResult pr)
        {
            XD2402Device xd2402 = task.Device as XD2402Device;
            //if (StringHelper.Equal(task.Opera.Name, XD2402OperaNames.ReadReal))
            //{
            //    ProcessReadReal(xd2402, pr);
            //}
            //else
            if (StringHelper.Equal(task.Opera.Name, XD2402OperaNames.ReadRecordIndex))
            {
                ProcessReadRecordIndex(xd2402, pr);
            }
            else if (StringHelper.Equal(task.Opera.Name, XD2402OperaNames.ReadRecord))
            {
                ProcessReadRecord(pr, xd2402);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        static private DateTime FixDateTime(DateTime dt)
        {
            int year = dt.Year;
            if (year < 0x100)
            {
                dt = dt.AddYears(2000);
            }
            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pr"></param>
        /// <param name="xd2402"></param>
        private static void ProcessReadRecord(ParseResult pr, XD2402Device xd2402)
        {
            int recordIndex = Convert.ToInt32(pr.NameObjects.GetObject("RecordIndex"));
            DateTime dt = Convert.ToDateTime(pr.NameObjects.GetObject("DT"));
            // 11 -> 2011
            //
            dt = FixDateTime(dt);

            int wl1 = Convert.ToInt32(pr.NameObjects.GetObject("WL1"));
            int wl2 = Convert.ToInt32(pr.NameObjects.GetObject("WL2"));

            uint instantFlux = Convert.ToUInt32(pr.NameObjects.GetObject("InstantFlux"));
            uint usedAmount = Convert.ToUInt32(pr.NameObjects.GetObject("UsedAmount"));
            int remainAmount = Convert.ToInt32(pr.NameObjects.GetObject("RemainAmount"));
            int height = Convert.ToInt32(pr.NameObjects.GetObject("height"));

            wl1 = wl1 / 10;
            wl2 = wl2 / 10;
            //DitchData d = new DitchData(wl1, wl2, instantFlux, 0, 0);
            SetAndSaveDitchData(xd2402, dt, wl1, wl2, instantFlux, usedAmount, remainAmount, height);
            if (recordIndex >= xd2402.LastRecordIndex)
            {
                AddDownTask(xd2402);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Test(XD2402Device d)
        {
            SetAndSaveDitchData(d, DateTime.Now, 1, 2, 3, 4, 5, 6);
        }

        #region SetAndSaveDitchData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="wl1"></param>
        /// <param name="wl2"></param>
        /// <param name="voltage"></param>
        private static void SetAndSaveDitchData(XD2402Device xd2402, DateTime dt, int wl1, int wl2, uint instantFlux, 
            uint usedAmount, int remainAmount, int height)
        {
            //xd2402.DitchData = new DitchData(dt, wl1, wl2, instantFlux, usedAmount, voltage);
            xd2402.Data = new XD2402Data(dt, wl1, wl2, height, (int)instantFlux, (int)usedAmount, remainAmount);
            DB.XD2400DataDBI.Insert(xd2402, xd2402.Data as XD2402Data);
        }
        #endregion //SetAndSaveDitchData

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xd2402"></param>
        /// <param name="pr"></param>
        private static void ProcessReadRecordIndex(XD2402Device xd2402, ParseResult pr)
        {
            // process read record index
            //
            UInt16 index = Convert.ToUInt16(pr.NameObjects.GetObject("RecordIndex"));

            // create new read record task
            //
            if (xd2402.IsLastRecordIndexValid())
            {
                int readedIndex = xd2402.LastRecordIndex;
                for (int i = readedIndex + 1; i <= index; i++)
                {
                    Opera readRecordOpera = xd2402.DeviceDefine.CreateOpera(XD2402OperaNames.ReadRecord);
                    readRecordOpera.SendPart["RecordIndex"] = i;
                    Task t = new Task(xd2402, readRecordOpera, new ImmediateStrategy());
                    YeHeCommuniServerApp.Default.CommuniSoft.TaskManager.Tasks.Add(t);
                    
                }
            }
            else
            {
                // down 
                //
                AddDownTask(xd2402);
            }

            // set new record index
            //
            xd2402.LastRecordIndex = index;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="pr"></param>
        private static void ProcessFail(Task task, ParseResult pr)
        {
            XD2402Device  xd2402 = task.Device as XD2402Device;
            if (StringHelper.Equal(task.Opera.Name, XD2402OperaNames.ReadRecord))
            {
                int recordIndex = Convert.ToInt32(task.Opera.SendPart["RecordIndex"]);
                if (recordIndex >= xd2402.LastRecordIndex)
                {
                    AddDownTask(xd2402);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xd2402"></param>
        private static void AddDownTask(XD2402Device xd2402)
        {
            Opera downOP = xd2402.DeviceDefine.CreateOpera(XD2402OperaNames.Down);
            Task downTask = new Task(xd2402, downOP, new ImmediateStrategy());
            YeHeCommuniServerApp.Default.CommuniSoft.TaskManager.Tasks.Add(downTask);
        }
    }
}
