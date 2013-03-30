using System;
using System.Collections.Generic;
using System.Text;

namespace XD2206DataImporter
{
    /// <summary>
    /// 
    /// </summary>
    public class TransItemFactory
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param deviceType="nm"></param>
        /// <returns></returns>
        static public TransItem Create(NameMap nm, FromDBI fromDBI, ToDBI toDBI, WriteDelegate writeDelegate)
        {
            TransItem item = new TransItem(writeDelegate);
            item.FromDevice = CreateFromDevice(nm.FromName, fromDBI);
            item.ToDevice = CreateToDevice(nm.ToName, toDBI, nm.Elvation, writeDelegate);
            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param deviceType="p"></param>
        /// <returns></returns>
        private static FromDevice CreateFromDevice(string name, FromDBI fromDBI)
        {
            FromDevice fd = new FromDevice();
            fd.DBI = fromDBI;
            fd.Name = name;
            fd.ID = fromDBI.ReadFromDeviceID(name);
            return fd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param deviceType="p"></param>
        /// <returns></returns>
        private static ToDevice CreateToDevice(string name, ToDBI toDBI, float elvation, WriteDelegate writeDelegate)
        {
            ToDevice to = new ToDevice(writeDelegate);
            to.DBI = toDBI;
            to.Name = name;
            to.ID = toDBI.ReadToDeviceID(name);
            // TODO:
            //
            //to.ComAdr = toDBI.ReadToDeviceComAdr(to.ID);
            to.Elvation = elvation;
            return to;
        }
    }
}
