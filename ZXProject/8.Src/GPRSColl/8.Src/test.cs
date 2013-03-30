//using System;
//using System.Windows.Forms;
//using Utilities;
//using System.Diagnostics;
//using System.Collections;
//using PumpDriver;

//namespace GprsSystem
//{
//    /// <summary>
//    /// test 的摘要说明。
//    /// </summary>
//    public class test
//    {
//        public test()
//        {
//            //
//            // TODO: 在此处添加构造函数逻辑
//            //
////            t2();
////            t1();
////            t_logitem();
////            testpumpcmd24DateConvert();
////            test_pumpRltSave();
////            test_pumpCmd1A();
////            test_create_infoall();
////            test_AAA();
////            test_gate_cmd_0x24();
////            test_logitem_mutli_line();
////            test_frmcsinfo();

//            string[][] ss = new SortNumberReader().Read( SortNumberType.Gate);
//            Debug.Assert( ss != null );

//            ss = new SortNumberReader().Read( SortNumberType.Pump );
//            Debug.Assert( ss == null );
//        }

//        void t2()
//        {
//            string s = "21 58 44 49 A1 1A 25 50 00 00 00 00 00 00 00 00 08 04 64 38 " 
//                     + "00 01 00 01 00 01 02 59 18 09 07 14 22 12 18 09 07 54 23 12 "
//                     + "00 00 00 5B C8 0E";

//            byte[] bs = CT.StringToBytes( s , null, StringFormat.Hex );
//            object obj = null;
//            new PumpDriver.PumpProcessor( bs, bs.Length, ref obj );
//            Debug.Assert( obj is Pump_Rlt );

//        }

//        void test_frmcsinfo()
//        {

////            new Form1().ShowDialog();
////            Cs_Info info = new Cs_Info( "s",1,"1","1",1,"10.1.1.1");
////            info.Tally.AddTallyItem( "aaa");
////
////            new frmCsinfo2( info ).ShowDialog();
//        }


//        void test_logitem_mutli_line()
//        {
////            string s1 = "a\r\nb" + Environment.NewLine + "c." + "d\ne";
////            string s2 = s1.Replace(Environment.NewLine, "___");
////            Debug.Assert( false, s1 + Environment.NewLine + s2 );
//            LogItem l = new LogItem();
//            l.NameValueSeparator = "|-_-|";
//            l.Add( "a", "dd" + Environment.NewLine + "bb" + "\r\n" + "cc" + "\ndd" );
//            Debug.Assert( false, l.ToString() );
//            Debug.Assert( false, new LogItem( "bbb", "fdfdfdf").ToString());
//            Environment.Exit(0);
//        }
////        void test_AAA()
////        {
////            string s = "7B 09 00 33 31 33 34 38 33 35 32 37 30 38 33 40 58 44 22 0B 3C 23 00 1B 07 07 05 16 45 00 02 51 01 D5 00 00 00 00 FF F7 EA B2 00 08 15 4E 00 02 10 C5 7B";
////            byte[] bs = CT.StringToBytes( s, null, StringFormat.Hex );
////            new frmMain().AAA( bs, null, new LogItem() );
////        }

////        private void t1()
////        {
////            byte[] bs = PumpCommunicationV705.MakeReadCurrentRecordNoCmd( 05 );
////            
////            System.Diagnostics.Debug.WriteLine ( BitConverter.ToString( bs ) );
////
////            bs = PumpCommunicationV705.MakeReadHistoryRecordCmd( 05, 43 );
////            System.Diagnostics.Debug.WriteLine ( BitConverter.ToString( bs ) );
////
////        }
////
////        private void t_logitem()
////        {
////            LogItem li = new LogItem("name", "name value" );
////            li.Add( "aaaaaaaaaaaaaaaaaaaaaaaaa", "bbbbbbbbbbbbbb");
////            li.Add( "vvv");
////            li.Add( "12121212121211111111111111111");
////            MessageBox.Show( li.ToString() );
////        }
////
////        private void testpumpcmd24DateConvert()
////        {
////            string s= "21-58-44-37-A1-24-0F-02-24-06-07-09-25-17-00-02-A9-E9-00-00-B1-77-C8-BC";
////            
////            byte[] bs  =CT.StringToBytes( s, new char[] {'-'}, StringFormat.Hex );
////            Debug.Assert( bs.Length == 24 );
////            new frmMain().Pump_Read( bs, bs.Length, null );
////        }
////
//////        private void test_pumpRltSave()
//////        {
//////            object obj = new PumpDriver.Pump_Rlt(83, 892, 100, 18398, 80107, "无运行状态",
//////                    "允许强启","无振状态","市电状态",130, null, null,0);
//////            new DbClass().Pump_His_Save( ref obj );
//////        }
////
////        private void test_pumpCmd1A()
////        {
////            string s = "21 58 44 32 A1 1A 25 50 00 02 50 B1 00 01 7F DF 04 AB 64 00 00 00 00 90 00 90 00 90 25 06 07 58 22 09 25 06 07 07 01 10 00 00 02 F6 E6 65";
////            s = "21 58 44 53 A1 1A 13 50 00 00 47 DE 00 01 38 EB 03 7C 64 00 00 00 00 82 00 81 3A 60";
////            byte[] bs = CT.StringToBytes( s, null, StringFormat.Hex );
////            object obj = null;
////
////            new PumpDriver.Pump_Read( bs, bs.Length, ref obj );
////
////            new DbClass().Pump_His_Save( ref obj );
////        }

////        private void test_create_infoall()
////        {
////            new DbClass().Info_All();
////            ArrayList list = Global.CsinfoList;
////        }

//        private void test_gate_cmd_0x24()
//        {
//            string s = "7B 09 00 2B 31 33 34 30 33 33 35 33 32 34 39 40 58 44 25 0B 24 1B 00 00 02 2D 01 95 00 00 FF E7 BC 74 00 18 43 8C FF 02 57 91 7B";
//            byte[] bs = CT.StringToBytes( s, null, StringFormat.Hex );
//            new frmMain().ProcessUserData( bs, bs.Length, null, new LogItem() );
//        }

//    }
//}
