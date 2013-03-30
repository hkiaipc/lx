using System;
using System.Windows.Forms;

namespace DataQuery
{
	#region ArgumentChecker
	/// <summary>
	/// Utility 的摘要说明。
	/// </summary>
	public class ArgumentChecker
	{
		private ArgumentChecker()
		{
		}

		public static void CheckNotNull( object obj )
		{
			if ( obj == null )
				throw new ArgumentNullException ();
		}
	}
	#endregion
	/// <summary>
	/// 
	/// </summary>
	public class Misc
	{
		public Misc()
		{
		}

		static private bool InArray(int[] array,int n)
		{
			if(array==null)
				return false;
			foreach(int i in array)
			{
				if(i==n)
					return true;
			}
			return false;
		}

		static public DataGridTableStyle CreateDataGridTableStyle(string tableMappingName,string[] dbColName,
			string[] dgShowName,int[] boolColumnIndex)
		{
			ArgumentChecker.CheckNotNull(dbColName);
			ArgumentChecker.CheckNotNull(dgShowName);
			if(dbColName.Length !=dgShowName.Length )
				throw new ArgumentException("dbColName.length !=dgShowName.Length");

			DataGridTableStyle dgts=new DataGridTableStyle();
			dgts.MappingName=tableMappingName;

			DataGridColumnStyle dgcs=null;
			for(int i=0;i<dbColName.Length;i++)
			{
				if(InArray(boolColumnIndex,i))
					dgcs=new DataGridBoolColumn();
				else
					dgcs=new DataGridTextBoxColumn();
				dgcs.MappingName=dbColName[i];
				dgcs.HeaderText=dgShowName[i];

				dgts.GridColumnStyles.Add(dgcs);
			}
			return dgts;
		}

		static public DataGridTableStyle CreateDataGridTableStyle(string tableMappingName, string[] dbColName, 
			string[] dgShowName, int[] boolColumnIndex, int [] columnWidth )
		{
			ArgumentChecker.CheckNotNull(dbColName);
			ArgumentChecker.CheckNotNull(dgShowName);
			if ( dbColName.Length != dgShowName.Length )
				throw new ArgumentException( "dbColName.Length != dgShowName.Length" );

			DataGridTableStyle dgts = new DataGridTableStyle();
			dgts.MappingName = tableMappingName;

			DataGridColumnStyle dgcs = null;
			for ( int i=0; i<dbColName.Length; i++ )
			{
				if ( InArray( boolColumnIndex, i ) )
					dgcs = new DataGridBoolColumn ();
				else
					dgcs = new DataGridTextBoxColumn();
				if ( columnWidth != null && i < columnWidth.Length )
				{
					dgcs.Width = columnWidth[ i ];
				}

				dgcs.MappingName = dbColName[i];
				dgcs.HeaderText = dgShowName[i];

				dgts.GridColumnStyles.Add( dgcs );
			}

			return dgts;

		}
	}
}
