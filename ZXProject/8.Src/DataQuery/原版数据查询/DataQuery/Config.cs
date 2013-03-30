using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataQuery
{
	/// <summary>
	/// Config 
	/// </summary>
	public class Config
	{
		public SqlConnection strConn;  //���ݿ�� ����
		public string _class;  //�����ǿ��Ż��Ǳ�վ
		public string _department;  //���ڼ�¼��
		public string _place;      //���ڼ�¼վ
	//	public string _userName;  //�����û���
	//	public string _passWord;     //��������

		/// <summary>
		/// Read App.config
		/// </summary>
		public void ReadConfig()
		{
			System.Collections.Specialized.NameValueCollection nvc=System.Configuration.ConfigurationSettings.AppSettings;
			string stringcon=nvc["ConnString"];
			string department=nvc["Department"];
			string place=nvc["Place"];
	//		string userName=nvc["UserName"];
	//		string passWord=nvc["PassWord"];

			strConn=new SqlConnection(stringcon);
			_department=department;
			_place=place;
	//		_userName=userName;
	//		_passWord=passWord;
		}

		public Config()
		{
			this.ReadConfig();
		}
	}
}
