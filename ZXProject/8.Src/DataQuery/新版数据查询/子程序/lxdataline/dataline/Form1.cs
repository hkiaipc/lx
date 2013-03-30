using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace dataline
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;

            myPane.Title.Text = "测试";
            myPane.XAxis.Title.Text = "时间";
            myPane.YAxis.Title.Text = "温度";

            // Make up some data arrays based on the Sine function
            double x, y1, y2;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            for (int i = 0; i < 36; i++)
            {
                x = (double)i + 5;
                y1 = 1.5 + Math.Sin((double)i * 0.2);
                y2 = 3.0 * (1.5 + Math.Sin((double)i * 0.2));
                list1.Add(x, y1);
                list2.Add(x, y2);
            }

            LineItem myCurve1 = myPane.AddCurve("一次",list1, Color.Red, SymbolType.Diamond);
            LineItem myCurve2 = myPane.AddCurve("二次",list2, Color.Blue, SymbolType.Circle);
            zgc.AxisChange();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CDbConnection.ReadConfig();
            this.checkedListBox1.Items.Clear();
            DataTable station_tb = CDbConnection.getDt("select Address from v_Gate order by id_pole");
            for (int i = 0; i < station_tb.Rows.Count; i++)
            {
                this.checkedListBox1.Items.Add(station_tb.Rows[i]["Address"]);
            }
            this.dtpBegin.Value = DateTime.Now.AddDays(-1);
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            string line = "BeforeLevel";
            Color line_color = Color.LightGreen;
            DataTable tb = new DataTable();
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.CurveList.Clear();
            this.zedGraphControl1.ZoomOutAll(myPane);

            for (int i = 0; i < this.checkedListBox1.CheckedItems.Count; i++)
            {
                string name = this.checkedListBox1.CheckedItems[i].ToString();
                PointPairList list1 = new PointPairList();
                tb = CDbConnection.getDt("select StrTime, " + line + " from v_GateDatas where Address= '" + name + "' and StrTime between '" + dtpBegin.Value.ToString()+ "' and '" + dtpEnd.Value.ToString()+ "'order by StrTime");
                if (tb.Rows.Count == 0)
                {
                    MessageBox.Show(this.checkedListBox1.CheckedItems[i].ToString()+"数据量不足，不能绘制曲线","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    continue;
                }

                for (int j = 0; j < tb.Rows.Count; j++)
                {
                    string time = tb.Rows[j]["StrTime"].ToString();
                    int yearlast = time.IndexOf("-", 0);
                    int monthlast = time.IndexOf("-", yearlast + 1);
                    int daylast = time.IndexOf(" ", monthlast + 1);
                    int hourlast = time.IndexOf(":", daylast + 1);
                    int minituelast = time.IndexOf(":", hourlast + 1);

                    string year = time.Substring(0, 4);
                    string month = time.Substring(yearlast + 1, monthlast - yearlast - 1);
                    string day = time.Substring(monthlast + 1, daylast - monthlast - 1);
                    string hour = time.Substring(daylast + 1, hourlast - daylast - 1);
                    string minitue = time.Substring(hourlast + 1, minituelast - hourlast - 1);
                    string second = time.Substring(minituelast + 1);

                    double x = new XDate(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), Convert.ToInt32(hour), Convert.ToInt32(minitue), Convert.ToInt32(second));

                    double y1 = Convert.ToDouble(tb.Rows[j][1]);
                    list1.Add(x, y1);
                }

                int begin_date_index = dtpBegin.Value.Date.ToString().IndexOf(" ");
                string begin_date = dtpBegin.Value.Date.ToString().Substring(0, begin_date_index);
                int end_data_index = dtpEnd.Value.Date.ToString().IndexOf(" ");
                string end_date = dtpEnd.Value.Date.ToString().Substring(0, end_data_index);

                myPane.Title.Text = begin_date + " 至 " + end_date + " 曲线";
                myPane.XAxis.Title.Text = "时间(h)";
                myPane.YAxis.Title.Text = "";
                myPane.XAxis.Type = AxisType.Date;
                myPane.XAxis.MajorGrid.IsVisible = true;  //珊格子
                myPane.YAxis.MajorGrid.IsVisible = true;
                line_color = Color.Blue; 
                LineItem myCurve1 = myPane.AddCurve(this.checkedListBox1.CheckedItems[i].ToString(), list1, line_color, SymbolType.Diamond);
                myCurve1.Symbol.Fill = new Fill(Color.White);
                myCurve1.Symbol.Size = 7;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true;
                zedGraphControl1.IsShowPointValues = true;
                zedGraphControl1.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
        }

        #region
        private string MyPointValueHandler( ZedGraphControl control, GraphPane pane, CurveItem curve, int iPt)
		{
			PointPair pt = curve[iPt];
            return XDate.XLDateToDateTime(pt.X).ToString()+"  "+ pt.Y.ToString("f0") + " cm";
		}
		#endregion       
        private void button2_Click_1(object sender, EventArgs e)
        {
            zedGraphControl1.DoPrint();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }













    }
}
