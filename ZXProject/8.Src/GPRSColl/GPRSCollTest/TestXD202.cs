using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using GprsSystem;

namespace GPRSCollTest
{
    [TestFixture]
    public class TestXD202
    {
        [Test]
        public void ParseRealDataTest()
        {
            byte[] bs = null; 

            bs = null;
            object obj = XD202.ParseForTest(bs);
            Assert.IsNull(obj);

            bs = new byte[0];
            obj = XD202.ParseForTest(bs);
            Assert.IsNull(obj);

            bs = new byte[] { 
0x01, 0x04, 0x22, 0x00, 0x00, 0x00, 0x00, 0xF0, 0xE6, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xA9, 0x64
            };
            obj = XD202.ParseForTest(bs);
            Assert.IsNotNull(obj);
            GateDriver.Gate_His his = (GateDriver.Gate_His)obj;
            Assert.AreEqual(1, his.ComAdr);

            Console.WriteLine(his.ToString());
        }

        [Test]
        public void SendCommand()
        {
            byte[] bs = XD202.CreateReadRealCommand(1);
            string s = BitConverter.ToString(bs);
            Console.WriteLine(s);
        }
    }
}
