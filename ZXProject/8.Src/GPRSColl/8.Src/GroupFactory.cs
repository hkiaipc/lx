using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GprsSystem
{
    public class GroupFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceInfoArray"></param>
        static public void CreateGroupCollection(ArrayList deviceInfoArray)
        {
            GroupCollection groups = GroupCollection.Default;

            foreach (DeviceInfo di in deviceInfoArray)
            {
                Group g = groups.GetGroup(di.IP);
                g.DeviceInfoCollection.Add(di);
                di.Group = g;
            }

            //Console.WriteLine(string.Format("create group: {0}",groups.Count));
            //foreach (Group g in groups)
            //{
            //    Console.WriteLine(string.Format ("IP: {0}", g.IP));
            //}
        }
    }
}
