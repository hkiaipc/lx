using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Excel;
using System.IO;
using Point=System.Drawing.Point;

namespace DataQuery
{
	#region GateDatasPrint
	/// <summary>
	/// GateDatasPrint。
	/// </summary>
	public class GateDatasPrint
	{

		private DateTime _endTime;
		private DateTime _beginTime;
		private System.Data.DataTable _table;

		private Point ptTitle=new Point(1,1);
		private Point ptDataBegin=new Point(1,4);

		public GateDatasPrint(DateTime beginTime,DateTime endTime,System.Data.DataTable table)
		{
			_beginTime=beginTime;
			_endTime=endTime;
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
					string ToWater     = row[7].ToString().Trim();
					// string YesWaUse    =row[8].ToString().Trim();
					//string DayWaUse    =row[9].ToString().Trim();
					//string Power     = row[8].ToString().Trim();
					//string Lock     = row[9].ToString().Trim();
                    
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 0 ] = Address;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 1 ] = StrTime;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 2 ] = BeforeLevel;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 3 ] = BehindLevel;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 4 ] = Hight;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 5 ] = Flus;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 6 ] = ReWater;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 7 ] = ToWater;
					// e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 8 ] = YesWaUse;
					// e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 9 ] = DayWaUse;
					//e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 8 ] = Power;
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
				"\\GateData.xls";

			return str;
		}

		private string MakeTitle()
		{
			string s = string.Format(
				"{0}---{1} 的口门数据",
				_beginTime,_endTime
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

	#region  PumpDatasPrint
	/// <summary>
	/// PumpDatasPrint。
	/// </summary>
	public class PumpDatasPrint
	{

		private DateTime _beginTime;
		private DateTime _endTime;
		private System.Data.DataTable _table;

		private Point ptTitle=new Point(1,1);
		private Point ptDataBegin=new Point(1,4);

		public PumpDatasPrint(DateTime beginTime,DateTime endTime,System.Data.DataTable table)
		{
			_beginTime=beginTime;
			_endTime=endTime;
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
					// string YesReWater  =row[7].ToString().Trim();
					// string DayWaterUse =row[8].ToString().Trim();
					string ToWater     = row[5].ToString().Trim();
					string Run     = row[6].ToString().Trim();
					// string ForceRun     = row[7].ToString().Trim();
					//string Vibrate     = row[8].ToString().Trim();
					// string Power     = row[9].ToString().Trim();
                    
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 0 ] = Address;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 1 ] = StrTime;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 2 ] = Flus;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 3 ] = Efficiency;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 4 ] = ReWater;
					//  e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 5 ] = YesReWater;
					//  e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 6 ] = DayWaterUse;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 5 ] = ToWater;
					e.Cells[ ptDataBegin.Y + rowOffset, ptDataBegin.X + 6 ] = Run;
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
				"\\PumpData.xls";

			return str;
		}

		private string MakeTitle()
		{
			string s = string.Format(
				"{0}----{1}的泵站数据",
				_beginTime,_endTime
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
