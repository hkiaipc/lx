//using System;
//using NUnit.Framework;

//namespace GprsSystem
//{
//    /// <summary>
//    /// SGDtuTest 的摘要说明。
//    /// </summary>
//    /// 
//    [TestFixture]
//    public class SGDtuTest
//    {
//        public SGDtuTest()
//        {
//            //
//            // TODO: 在此处添加构造函数逻辑
//            //
//        }

//        [Test]
//        public void t_GetSimNumber()
//        {
//            string sim = "12312312312";
//            byte[] bs = SGDtu.GetSimNumberBytes( sim );
//            Assert.AreEqual( bs.Length, sim.Length );
//            //Assert.AreEqual( sim, SGDtu.GetSimNumber( bs ));
//            Assert.AreEqual(0x31, bs[0]);
//            Assert.AreEqual(0x32, bs[1]);
//            Assert.AreEqual(0x33, bs[2]);

//        }

//        [Test]
//        public void t_MakeDtuCommand()
//        {
//            byte fc = 01;
//            string sim = "12345678901";
//            byte[] ud = new byte[ 10 ];

//            byte[] cmd = SGDtu.MakeDtuCommand( fc, sim, ud );
//            Assert.AreEqual( 10 + 16, cmd.Length );
//            Assert.AreEqual( 10, SGDtu.GetUserData( cmd ).Length );
//            Assert.AreEqual( sim, SGDtu.GetSimNumber( cmd ) );
//        }
//    }
//}
