using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Excel;
using System.IO;
using Point=System.Drawing.Point;

namespace DataQuery
{
	#region GateDataDayPrint
	/// <summary>
	/// GateDatadayPrint。
	/// </summary>
	public class GateDataDayPrint
	{

		private DateTime _Dtime;
		private System.Data.DataTable _table;

		private Point ptTitle=new Point(1,1);
		private Point ptDataBegin=new Point(1,4);

		public GateDataDayPrint(DateTime Dtime,System.Data.DataTable table)
		{
			_Dtime=Dtime;
			Debug.Assert(table !=null);
			_table=table;
			
		}

		public void Export()
		{
			Excel.ApplicationClass e = Open( GetFileName() );
			if ( e != null )
			{
				e.Cells[ ptTitle.Y, ptTitle.X ] = MakeTitle();
				int rowOffset = 0;
				foreach( DataRow row in _table.Rows )
				{
					string Address   = row[0].ToString().Trim();
					string StrTime = row[1].ToString().Trim();
					string BeforeLevel = row[2].ToString().Trim();
					string BehindLevel     = row[3].ToString().Trim();
					string Hight     = row[4].ToString().Trim();
					string Flus     = row[5].ToString().Trim();
					string ReWater     = row[6].ToString().Trim();
					string ToWater     = row[8].ToString().Trim();
					string YesReWater   =row[7].ToString().Trim();
					string DayWaUse    =row[9].ToString().Trim();
					string AllWater     = row[10].ToString().Trim();
					//string Lock     = row[9].ToString().Trim();
                    
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 0 ] = Address;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 1 ] = StrTime;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 2 ] = BeforeLevel;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 3 ] = BehindLevel;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 4 ] = Hight;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 5 ] = Flus;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 6 ] = ReWater;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 7 ] = ToWater;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 8 ] = YesReWater;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 9 ] = DayWaUse;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 10 ] = AllWater;
					//e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 9 ] = Lock;
					rowOffset ++;
				}
				e.Visible = true;
				e = null;
				GC.Collect();
			}
		}

		private string GetFileName()
		{
			string str = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) +
				"\\GateData1.xls";

			return str;
		}

		private string MakeTitle()
		{
			string s = string.Format(
				"{0} 的口门数据",
				_Dtime
				);
			return s;
		}

		private Excel.ApplicationClass Open( string xlsFileName )
		{
			try
			{
				Excel.ApplicationClass excelCls = new ApplicationClass();
				Excel.Workbook excelWb = excelCls.Workbooks.Add( xlsFileName );
				return excelCls;
			}
			catch( Exception ex )
			{
				MessageBox.Show(
					ex.ToString(),
					"错误",MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);
				return null;
			}
		}
	}
	#endregion

	#region  PumpDataDayPrint
	/// <summary>
	/// PumpDatadayPrint。
	/// </summary>
	public class PumpDataDayPrint
	{

		private DateTime _Dtime;
		private System.Data.DataTable _table;

		private Point ptTitle=new Point(1,1);
		private Point ptDataBegin=new Point(1,4);

		public PumpDataDayPrint(DateTime Dtime,System.Data.DataTable table)
		{
			_Dtime=Dtime;
			Debug.Assert(table !=null);
			_table=table;
			
		}

		public void Export()
		{
			Excel.ApplicationClass e = Open( GetFileName() );
			if ( e != null )
			{
				e.Cells[ ptTitle.Y, ptTitle.X ] = MakeTitle();
				int rowOffset = 0;
				foreach( DataRow row in _table.Rows )
				{
					string Address   = row[0].ToString().Trim();
					string StrTime = row[1].ToString().Trim();
					string Flus = row[2].ToString().Trim();
					string Efficiency     = row[3].ToString().Trim();
					string ReWater     = row[4].ToString().Trim();
					string YesReWater  =row[7].ToString().Trim();
					string DayWaterUse =row[8].ToString().Trim();
					string ToWater     = row[5].ToString().Trim();
					string AllWater     = row[6].ToString().Trim();
					// string ForceRun     = row[7].ToString().Trim();
					//string Vibrate     = row[8].ToString().Trim();
					// string Power     = row[9].ToString().Trim();
                    
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 0 ] = Address;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 1 ] = StrTime;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 2 ] = Flus;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 3 ] = Efficiency;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 4 ] = ReWater;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 5 ] = YesReWater;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 7 ] = DayWaterUse;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 6 ] = ToWater;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 8 ] = AllWater;
					// e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 9 ] = Power;
					rowOffset ++;
				}
				e.Visible = true;
				
				e = null;
				GC.Collect();
			}
		}

		private string GetFileName()
		{
			string str = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) +
				"\\PumpData1.xls";

			return str;
		}

		private string MakeTitle()
		{
			string s = string.Format(
				"{0} 的泵站数据",
				_Dtime
				);
			return s;
		}

		private Excel.ApplicationClass Open( string xlsFileName )
		{
			try
			{
				Excel.ApplicationClass excelCls = new ApplicationClass();
				Excel.Workbook excelWb = excelCls.Workbooks.Add( xlsFileName );
				return excelCls;
			}
			catch( Exception ex )
			{
				MessageBox.Show(
					ex.ToString(),
					"错误",MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);
				return null;
			}
		}
	}
	#endregion
}
