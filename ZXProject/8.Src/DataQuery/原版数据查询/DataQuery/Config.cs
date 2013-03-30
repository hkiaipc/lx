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
		public SqlConnection strConn;  //数据库的 连接
		public string _class;  //区分是口门还是泵站
		public string _department;  //用于记录所
		public string _place;      //用于记录站
	//	public string _userName;  //保存用户名
	//	public string _passWord;     //保存密码

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
