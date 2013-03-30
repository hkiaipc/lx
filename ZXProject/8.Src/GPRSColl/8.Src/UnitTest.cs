//using System;
//using NUnit;
//using NUnit.Framework;
//using Utilities;
//using System.Diagnostics;
//using GateDriver;


//namespace GprsSystem
//{
//    /// <summary>
//    /// UnitTest 的摘要说明。
//    /// </summary>
//    [TestFixture]
//    public class UnitTest
//    {
//        private SGDtu Unname = new SGDtu();
//        //[SetUp]
//        public UnitTest()
//        {
//            //
//            // TODO: 在此处添加构造函数逻辑
//            //
//        }

//        [Test]
//        public void t_GetDtuData()
//        {
//            // [108]
//            string s = "7B 09 00 6C 31 33 34 38 33 35 36 39 38 34 37 21 58 44 35 A1 1A 25 50 00 00 E1 "
//                     + "58 00 03 B2 88 04 AB 64 00 00 00 00 F9 00 F9 00 F9 23 06 07 30 53 10 23 06 07 "
//                     + "30 53 10 00 00 00 00 5B 94 21 58 44 35 A1 1A 25 50 00 00 E1 58 00 03 B2 88 04 "
//                     + "AB 64 00 00 00 00 F9 00 F9 00 F9 23 06 07 30 53 10 23 06 07 30 53 10 00 00 00 "
//                     + "00 5B 94 7B";
//            byte[] bs = CT.StringToBytes( s, null, StringFormat.Hex );
//            Debug.Assert( bs.Length == 108 );
//            byte[][] dtudatas = SGDtu.GetDtuData( bs );
//            Assert.IsNotNull( dtudatas );
//            Assert.AreEqual( 1, dtudatas.Length );
//            Assert.AreEqual( 108, dtudatas[0].Length );


//            // [3][0x33]
//            s =   "7c 09 00 33 31 33 34 30 33 33 35 38 38 31 39 40 58 44 26 0B 3C 23 00 A0 07 06 26 12 30 "
//                + "00 02 0B 02 14 00 48 00 00 FF F7 F4 76 00 08 0B 8A 00 02 B4 AB 7B 7B 09 00 33 31 33 34 "
//                + "30 33 33 35 38 38 31 39 40 58 44 26 0B 3C 23 00 A0 07 06 26 12 30 00 02 0B 02 14 00 48 "
//                + "00 00 FF F7 F4 76 00 08 0B 8A 00 02 B4 AB 7B 7B 09 00 33 31 33 34 30 33 33 35 38 38 31 " 
//                + "39 40 58 44 26 0B 3C 23 00 A0 07 06 26 12 30 00 02 0B 02 14 00 48 00 00 FF F7 F4 76 00 " 
//                + "08 0B 8A 00 02 B4 AB 7c";
//            bs = CT.StringToBytes( s, null, StringFormat.Hex );
//            Debug.Assert( bs.Length == 0x33 * 3 );
//            dtudatas = SGDtu.GetDtuData( bs );
//            Assert.IsNotNull( dtudatas );
//            Assert.AreEqual( 1, dtudatas.Length );
//            Assert.AreEqual( 0x33, dtudatas[0].Length );
//        }
//        [Test]
//        public void t_GetDtuData_HeartBeat()
//        {
//            // [22 ]
//             string s = "7B 01 00 16 31 33 34 30 33 31 35 34 33 32 39 0A 1B BE 2D 0F A0 7B";
//            byte[] bs = CT.StringToBytes( s, null, StringFormat.Hex );
//            Debug.Assert( bs.Length == 22 );
//            byte[][] dtudatas = SGDtu.GetDtuData( bs );
//            Assert.IsNotNull( dtudatas );
//            Assert.AreEqual( 1, dtudatas.Length );
//            Assert.AreEqual( 22, dtudatas[0].Length );
//        }

//        [Test]
//        public void t_GetDtuData_return_null()
//        {
//            // [22 ]
//            string[] ss = new string[3];
//            ss[0] = "7B 01 00 17 31 33 34 30 33 31 35 34 33 32 39 0A 1B BE 2D 0F A0 7B";
//            ss[1] = "7B 01 00 16 31 33 34 30 33 31 35 34 33 32 39 0A 1B BE 2D 0F A0 7c";
//            ss[2] = "8B 01 00 17 31 33 34 30 33 31 35 34 33 32 39 0A 1B BE 2D 0F A0 7B";
//            foreach( string s in ss )
//            {
//                byte[] bs = CT.StringToBytes( s, null, StringFormat.Hex );
//                Debug.Assert( bs.Length == 22 );
//                byte[][] dtudatas = SGDtu.GetDtuData( bs );
//                Assert.IsNull( dtudatas );
//            }
//        }


//        [Test]
//        public void t_GetControllerData()
//        {
//            string s = "40 58 44 33 0B 3C 03 00 45 00 01 7D 01 01 00 14 00 6C 00 02 A0 09 00 97 F3 "
//                     + "40 58 44 34 0B 3C 23 01 87 07 06 26 11 45 00 01 7D 01 02 00 14 00 6C 00 02 " 
//                     + "98 AB 00 41 4E 25 FF 02 AB 65 "
//                     + "21 58 44 35 A1 1A 25 50 00 00 E1 58 00 03 B2 88 04 AB 64 00 00 00 00 F9 00 " 
//                     + "F9 00 F9 23 06 07 30 53 10 23 06 07 30 53 10 00 00 00 00 5B 94 "
//                     + "21 58 44 35 A1 1A 25 50 00 00 E1 58 00 03 B2 88 04 AB 64 00 00 00 00 F9 00 " 
//                     + "F9 00 F9 23 06 07 30 53 10 23 06 07 30 53 10 00 00 00 00 5B 94";
//            byte[] bs = CT.StringToBytes( s, null, StringFormat.Hex );
//            byte[][] cds = GateController.Pick( bs );
//            Assert.IsNotNull( cds );
//            Assert.AreEqual( 1, cds.Length );
//            Assert.AreEqual( 0x23, cds[0].Length );


//            cds = PumpController.Pick( bs );
//            Assert.AreEqual( 2, cds.Length );
//            Assert.AreEqual( 0x25 + 9, cds[0].Length );
//        }


//        [Test]
//        public void t_Gate_Lock_bytes()
//        {
//            string s = "7B 09 00 2B 31 33 37 33 31 35 32 35 37 34 34 40 58 44 37 0B 24 1B 01 91 01 2C 01 2C 00 00 FF FF FF FF 00 00 00 00 FF FF 4B CC 7B";
//            s = "40 58 44 37 0B 24 1B 01 91 01 2C 01 2C 00 00 FF FF FF FF 00 00 00 00 FF FF 4B CC";
//            byte[] bs = CT.StringToBytes( s, null, StringFormat.Hex );
            
//            object obj = new object();
//            GateReader gr = new GateReader( bs, ref obj);
//            Assert.IsTrue ( obj != null );
//            Assert.IsTrue ( obj is Gate_Rlt );
//            Assert.IsNotNull( ((Gate_Rlt)obj).Lock_OC == "未知状态");
//        }
//    }
//}
