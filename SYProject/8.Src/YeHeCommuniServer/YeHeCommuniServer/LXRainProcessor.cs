using System;
using Xdgk.Common;
using Xdgk.Communi;
using LXRainCommon;

namespace CommuniServer
{
    public class LXRainProcessor
    {
        static public void ProcessExecutedTask(Task task, ParseResult pr)
        {
            byte recordCount = Convert.ToByte(pr.NameObjects.GetObject("RecordCount"));
            byte[] bs = (byte[])pr.NameObjects.GetObject("Record");

            DateTime[] dts;
            int[] rains;

            bool b = LXRainCommon.RainResponse.Parse(bs, recordCount, out dts, out rains);
            if (b)
            {
                for (int i = 0; i < recordCount; i++)
                {
                    LXRainData rainData = new LXRainData();
                    rainData.DT = dts[i];
                    rainData.Rain = rains[i];

                    LXRainDevice rainDevice = task.Device as LXRainDevice;
                    rainDevice.LXRainData = rainData;
                }
            }

        }
    }

}
