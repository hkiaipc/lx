using System;
using System.Windows.Forms;

namespace GprsSystem
{
	/// <summary>
	/// 
	/// </summary>
	public class FormAdjuster
	{
        /// <summary>
        /// 
        /// </summary>
		private FormAdjuster()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        static public void SetOptionTypeForm( Form form )
        {
            if ( form != null )
            {
                form.ShowInTaskbar = false;

                //����ư�ť��û��ͼ��
                //
                form.FormBorderStyle = FormBorderStyle.FixedDialog; 
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ShowInTaskbar = false;
            }
        }
	}
}
