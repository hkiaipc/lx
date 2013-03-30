using System;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Threading;

namespace GprsSystem
{
    /// <summary>
    /// STAThread ��ժҪ˵����
    /// </summary>
    public class STAThread
    {

        #region InitConfig
        static private void InitConfig()
        {
            Config c = Config.Default;
            c.IsLogDtuCorrectData = false;
            c.IsLogDtuHeartBeat = false;
            c.IsLogDtuRegisterAnswer = false;
        }
        #endregion //InitConfig


        #region Main
        /// <summary>
        /// Ӧ�ó��������ڵ㡣
        /// </summary>
        [STAThread]
        static void Main()
        {
            // exceptin handler
            //
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitConfig();



            //��ֹ������������ʵ��
            bool bExist;
            Mutex myMutex = new Mutex(true, "OnlyOneTime", out bExist);

            if (bExist)
            {

                myMutex.ReleaseMutex();


                //������ݿ���Ϣ
                if (!Config.Default.ReadConfig())
                    Application.Exit();

                DbClass Db = new DbClass();
                Db.GetInfoAll();
                GroupFactory.CreateGroupCollection(DeviceInfoManager.DeviceInfoList);

                Application.Run(new frmLogin());
            }
            else
            {
                MessageBox.Show("�����Ѿ����У�", 
                        "��Ϣ", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                Application.Exit();
            }

        }
        #endregion //Main

        #region Application_ThreadException
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ProcessException(e.Exception);
        }
        #endregion //Application_ThreadException

        #region CurrentDomain_UnhandledException
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ProcessException(e.ExceptionObject as Exception);
        }
        #endregion //CurrentDomain_UnhandledException

        #region ProcessException
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        static private void ProcessException(Exception ex)
        {
            string s = string.Format("δ�����쳣\r\n\r\n{0}",
                ex.ToString());

            FileLog fl = new FileLog(".\\UnhandledEx.txt");
            fl.Open();
            fl.WithDateTime = true;
            fl.Add(s);
            fl.Close();

            MessageBox.Show(s, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        #endregion //ProcessException
    }
}
