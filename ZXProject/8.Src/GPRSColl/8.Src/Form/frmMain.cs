using System;
using System.Windows;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

using System.Net;
using System.Net.Sockets;
using System.Threading;

using System.Xml;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

using GateDriver;
using PumpDriver;
using Xdgk.Common;
using Utilities;
using XD2122GateImporter ;

namespace GprsSystem
{
    /// <summary>
    /// frmMain 的摘要说明。
    /// </summary>
    public class frmMain : System.Windows.Forms.Form
    {
        #region FormMembers
        private System.Windows.Forms.ToolBar toolBar;
        private System.Windows.Forms.ToolBarButton Separator1;
        private System.Windows.Forms.ToolBarButton Separator3;
        private System.Windows.Forms.ToolBarButton toolBarHelp;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem menuItemToolBar;
        private System.Windows.Forms.MenuItem menuItemStatusBar;
        private System.Windows.Forms.MenuItem menuItem18;
        private System.Windows.Forms.MenuItem menuItemInfo;
        private System.Windows.Forms.Timer timer_correct;
        private System.Windows.Forms.ContextMenu contextMenu_Pump;
        private System.Windows.Forms.MenuItem menuItemGateCon;
        private System.Windows.Forms.MenuItem menuItemPumpCon;
        private System.Windows.Forms.ToolBarButton toolBarSelect;
        private System.Windows.Forms.ToolBarButton toolbarLogin;
        private System.Windows.Forms.ToolBarButton toolBarLogout;
        private System.Windows.Forms.ToolBarButton Separator0;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.ListView listView_Gate;
        private System.Windows.Forms.ListView listView_Pump;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItemGate;
        private System.Windows.Forms.MenuItem menuItemPump;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem Cm_Pump_Rlt;
        private System.Windows.Forms.MenuItem Cm_Pump_Run;
        private System.Windows.Forms.MenuItem Cm_Pump_Stp;
        private System.Windows.Forms.MenuItem menuItem_Login;
        private System.Windows.Forms.MenuItem menuItem_Logout;
        private System.Windows.Forms.MenuItem menuItem_Exit;
        private System.Windows.Forms.MenuItem menuItemAbout;
        private System.Windows.Forms.MenuItem menuItem_Password;
        private System.Windows.Forms.ToolBarButton toolBarGate;
        private System.Windows.Forms.ToolBarButton toolBarPump;
        private System.Windows.Forms.ToolBarButton toolBarInfo;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenu contextMenu_Gate;
        private System.Windows.Forms.MenuItem Cm_Gate_Rlt;
        private System.Windows.Forms.MenuItem Cm_Gate_His;
        private System.Windows.Forms.MenuItem Cm_Gate_Par;
        private System.Windows.Forms.MenuItem Cm_Gate_Tm;
        private System.Windows.Forms.MenuItem Cm_Gate_O_Lock;
        private System.Windows.Forms.MenuItem Cm_Gate_C_Lock;
        private System.Windows.Forms.MenuItem Cm_Gate_R_Lock;
        private System.Windows.Forms.MenuItem menuItemConfig;
        private System.Windows.Forms.MenuItem menuItemPumpInfo;
        private System.Windows.Forms.MenuItem menuItemGateInfo;
        private System.Windows.Forms.MenuItem menuPumpOtherCmd;
        private System.Windows.Forms.MenuItem menuGateOtherCmd;
        private System.Windows.Forms.MenuItem menuItemFont;
        private System.Windows.Forms.MenuItem menuItemGridLines;
        private MenuItem mnuTest;
        private System.ComponentModel.IContainer components;
        #endregion //FormMembers

        #region frmMain
        public frmMain()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.InfoList_All = DeviceInfoManager.DeviceInfoList;
        }

        #endregion //frmMain

        #region Dispose
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (this.menuItem_Exit.Enabled)
            {
                if (disposing)
                {
                    if (components != null)
                    {
                        components.Dispose();
                    }
                    //关闭所有套结字
                    //Close_Socket();
                    //关闭GprsSystem进程
                    System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("GprsSystem");
                    foreach (System.Diagnostics.Process p in process)
                    {
                        p.Kill();
                    }
                }
                base.Dispose(disposing);
            }
        }

        #endregion //Dispose

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.toolbarLogin = new System.Windows.Forms.ToolBarButton();
            this.toolBarLogout = new System.Windows.Forms.ToolBarButton();
            this.Separator0 = new System.Windows.Forms.ToolBarButton();
            this.toolBarGate = new System.Windows.Forms.ToolBarButton();
            this.toolBarPump = new System.Windows.Forms.ToolBarButton();
            this.toolBarInfo = new System.Windows.Forms.ToolBarButton();
            this.Separator1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarSelect = new System.Windows.Forms.ToolBarButton();
            this.Separator3 = new System.Windows.Forms.ToolBarButton();
            this.toolBarHelp = new System.Windows.Forms.ToolBarButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem_Login = new System.Windows.Forms.MenuItem();
            this.menuItem_Logout = new System.Windows.Forms.MenuItem();
            this.menuItem_Password = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem_Exit = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItemGateCon = new System.Windows.Forms.MenuItem();
            this.menuItemPumpCon = new System.Windows.Forms.MenuItem();
            this.menuItemConfig = new System.Windows.Forms.MenuItem();
            this.menuItemFont = new System.Windows.Forms.MenuItem();
            this.menuItemGridLines = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItemGate = new System.Windows.Forms.MenuItem();
            this.menuItemPump = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItemInfo = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItemToolBar = new System.Windows.Forms.MenuItem();
            this.menuItemStatusBar = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.mnuTest = new System.Windows.Forms.MenuItem();
            this.listView_Gate = new System.Windows.Forms.ListView();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.timer_correct = new System.Windows.Forms.Timer(this.components);
            this.contextMenu_Pump = new System.Windows.Forms.ContextMenu();
            this.Cm_Pump_Rlt = new System.Windows.Forms.MenuItem();
            this.Cm_Pump_Run = new System.Windows.Forms.MenuItem();
            this.Cm_Pump_Stp = new System.Windows.Forms.MenuItem();
            this.menuItemPumpInfo = new System.Windows.Forms.MenuItem();
            this.menuPumpOtherCmd = new System.Windows.Forms.MenuItem();
            this.listView_Pump = new System.Windows.Forms.ListView();
            this.contextMenu_Gate = new System.Windows.Forms.ContextMenu();
            this.Cm_Gate_Rlt = new System.Windows.Forms.MenuItem();
            this.Cm_Gate_His = new System.Windows.Forms.MenuItem();
            this.Cm_Gate_Par = new System.Windows.Forms.MenuItem();
            this.Cm_Gate_Tm = new System.Windows.Forms.MenuItem();
            this.Cm_Gate_O_Lock = new System.Windows.Forms.MenuItem();
            this.Cm_Gate_C_Lock = new System.Windows.Forms.MenuItem();
            this.Cm_Gate_R_Lock = new System.Windows.Forms.MenuItem();
            this.menuItemGateInfo = new System.Windows.Forms.MenuItem();
            this.menuGateOtherCmd = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolbarLogin,
            this.toolBarLogout,
            this.Separator0,
            this.toolBarGate,
            this.toolBarPump,
            this.toolBarInfo,
            this.Separator1,
            this.toolBarSelect,
            this.Separator3,
            this.toolBarHelp});
            this.toolBar.ButtonSize = new System.Drawing.Size(16, 16);
            this.toolBar.DropDownArrows = true;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(600, 41);
            this.toolBar.TabIndex = 1;
            this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // toolbarLogin
            // 
            this.toolbarLogin.Name = "toolbarLogin";
            this.toolbarLogin.Text = "登录";
            // 
            // toolBarLogout
            // 
            this.toolBarLogout.ImageIndex = 1;
            this.toolBarLogout.Name = "toolBarLogout";
            this.toolBarLogout.Text = "注销";
            // 
            // Separator0
            // 
            this.Separator0.Name = "Separator0";
            this.Separator0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarGate
            // 
            this.toolBarGate.ImageIndex = 2;
            this.toolBarGate.Name = "toolBarGate";
            this.toolBarGate.Text = "口门";
            // 
            // toolBarPump
            // 
            this.toolBarPump.ImageIndex = 3;
            this.toolBarPump.Name = "toolBarPump";
            this.toolBarPump.Text = "泵站";
            // 
            // toolBarInfo
            // 
            this.toolBarInfo.ImageIndex = 4;
            this.toolBarInfo.Name = "toolBarInfo";
            this.toolBarInfo.Text = "信息";
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarSelect
            // 
            this.toolBarSelect.Name = "toolBarSelect";
            this.toolBarSelect.Text = "运行";
            // 
            // Separator3
            // 
            this.Separator3.Name = "Separator3";
            this.Separator3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarHelp
            // 
            this.toolBarHelp.ImageIndex = 5;
            this.toolBarHelp.Name = "toolBarHelp";
            this.toolBarHelp.Text = "关于";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem9,
            this.menuItem5,
            this.menuItem15,
            this.menuItem18});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_Login,
            this.menuItem_Logout,
            this.menuItem_Password,
            this.menuItem4,
            this.menuItem_Exit});
            this.menuItem1.Text = "系统(&F)";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem_Login
            // 
            this.menuItem_Login.Index = 0;
            this.menuItem_Login.Text = "用户登录(&N)";
            this.menuItem_Login.Click += new System.EventHandler(this.menuItem_Login_Click);
            // 
            // menuItem_Logout
            // 
            this.menuItem_Logout.Index = 1;
            this.menuItem_Logout.Text = "用户注销(&O)";
            this.menuItem_Logout.Click += new System.EventHandler(this.menuItem_Logout_Click);
            // 
            // menuItem_Password
            // 
            this.menuItem_Password.Index = 2;
            this.menuItem_Password.Text = "修改密码(&P)";
            this.menuItem_Password.Click += new System.EventHandler(this.menuItem_Password_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "-";
            // 
            // menuItem_Exit
            // 
            this.menuItem_Exit.Index = 4;
            this.menuItem_Exit.Text = "退出(&E)";
            this.menuItem_Exit.Click += new System.EventHandler(this.menuItem_Exit_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemGateCon,
            this.menuItemPumpCon,
            this.menuItemConfig,
            this.menuItemFont,
            this.menuItemGridLines});
            this.menuItem9.Text = "配置(&S)";
            // 
            // menuItemGateCon
            // 
            this.menuItemGateCon.Index = 0;
            this.menuItemGateCon.Text = "口门配置(&G)";
            this.menuItemGateCon.Visible = false;
            this.menuItemGateCon.Click += new System.EventHandler(this.menuItemGateCon_Click);
            // 
            // menuItemPumpCon
            // 
            this.menuItemPumpCon.Index = 1;
            this.menuItemPumpCon.Text = "泵站配置(&P)";
            this.menuItemPumpCon.Visible = false;
            this.menuItemPumpCon.Click += new System.EventHandler(this.menuItemPumpCon_Click);
            // 
            // menuItemConfig
            // 
            this.menuItemConfig.Index = 2;
            this.menuItemConfig.Text = "选项(&O)";
            this.menuItemConfig.Click += new System.EventHandler(this.menuItemConfig_Click);
            // 
            // menuItemFont
            // 
            this.menuItemFont.Index = 3;
            this.menuItemFont.Text = "字体(&F)";
            this.menuItemFont.Click += new System.EventHandler(this.menuItemFont_Click);
            // 
            // menuItemGridLines
            // 
            this.menuItemGridLines.Index = 4;
            this.menuItemGridLines.Text = "网格(&G)";
            this.menuItemGridLines.Click += new System.EventHandler(this.menuItemGridLines_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemGate,
            this.menuItemPump,
            this.menuItem11,
            this.menuItemInfo});
            this.menuItem5.Text = "窗体(&W)";
            // 
            // menuItemGate
            // 
            this.menuItemGate.Index = 0;
            this.menuItemGate.Text = "口门(&G)";
            this.menuItemGate.Click += new System.EventHandler(this.menuItemGate_Click);
            // 
            // menuItemPump
            // 
            this.menuItemPump.Index = 1;
            this.menuItemPump.Text = "泵站(&P)";
            this.menuItemPump.Click += new System.EventHandler(this.menuItemPump_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 2;
            this.menuItem11.Text = "-";
            // 
            // menuItemInfo
            // 
            this.menuItemInfo.Index = 3;
            this.menuItemInfo.Text = "信息(&M)";
            this.menuItemInfo.Click += new System.EventHandler(this.menuItemInfo_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 3;
            this.menuItem15.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemToolBar,
            this.menuItemStatusBar});
            this.menuItem15.Text = "查看(&V)";
            // 
            // menuItemToolBar
            // 
            this.menuItemToolBar.Checked = true;
            this.menuItemToolBar.Index = 0;
            this.menuItemToolBar.Text = "工具栏(&T)";
            this.menuItemToolBar.Click += new System.EventHandler(this.menuItemToolBar_Click);
            // 
            // menuItemStatusBar
            // 
            this.menuItemStatusBar.Checked = true;
            this.menuItemStatusBar.Index = 1;
            this.menuItemStatusBar.Text = "状态条(&S)";
            this.menuItemStatusBar.Click += new System.EventHandler(this.menuItemStatusBar_Click);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 4;
            this.menuItem18.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAbout,
            this.mnuTest});
            this.menuItem18.Text = "帮助(&H)";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 0;
            this.menuItemAbout.Text = "关于(&A)";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // mnuTest
            // 
            this.mnuTest.Index = 1;
            this.mnuTest.Text = "Test";
            this.mnuTest.Click += new System.EventHandler(this.mnuTest_Click);
            // 
            // listView_Gate
            // 
            this.listView_Gate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Gate.FullRowSelect = true;
            this.listView_Gate.Location = new System.Drawing.Point(0, 41);
            this.listView_Gate.Name = "listView_Gate";
            this.listView_Gate.Size = new System.Drawing.Size(600, 221);
            this.listView_Gate.TabIndex = 2;
            this.listView_Gate.UseCompatibleStateImageBehavior = false;
            this.listView_Gate.View = System.Windows.Forms.View.Details;
            this.listView_Gate.DoubleClick += new System.EventHandler(this.listView_Gate_DoubleClick);
            // 
            // statusBar
            // 
            this.statusBar.AllowDrop = true;
            this.statusBar.Location = new System.Drawing.Point(0, 262);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(600, 24);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusBar";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanel1.Icon")));
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "statusBarPanel1";
            this.statusBarPanel1.Width = 477;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "statusBarPanel2";
            this.statusBarPanel2.Width = 107;
            // 
            // timer_correct
            // 
            this.timer_correct.Enabled = true;
            this.timer_correct.Interval = 1000;
            this.timer_correct.Tick += new System.EventHandler(this.timer_correct_Tick);
            // 
            // contextMenu_Pump
            // 
            this.contextMenu_Pump.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Cm_Pump_Rlt,
            this.Cm_Pump_Run,
            this.Cm_Pump_Stp,
            this.menuItemPumpInfo,
            this.menuPumpOtherCmd});
            this.contextMenu_Pump.Popup += new System.EventHandler(this.contextMenu_Pump_Popup);
            // 
            // Cm_Pump_Rlt
            // 
            this.Cm_Pump_Rlt.Index = 0;
            this.Cm_Pump_Rlt.Text = "实时状态(&S)";
            this.Cm_Pump_Rlt.Click += new System.EventHandler(this.Cm_Pump_Rlt_Click);
            // 
            // Cm_Pump_Run
            // 
            this.Cm_Pump_Run.Index = 1;
            this.Cm_Pump_Run.Text = "强制启泵(&R)";
            this.Cm_Pump_Run.Click += new System.EventHandler(this.Cm_Pump_Run_Click);
            // 
            // Cm_Pump_Stp
            // 
            this.Cm_Pump_Stp.Index = 2;
            this.Cm_Pump_Stp.Text = "强制停泵(&S)";
            this.Cm_Pump_Stp.Click += new System.EventHandler(this.Cm_Pump_Stp_Click);
            // 
            // menuItemPumpInfo
            // 
            this.menuItemPumpInfo.Index = 3;
            this.menuItemPumpInfo.Text = "泵站信息(&I)";
            this.menuItemPumpInfo.Click += new System.EventHandler(this.menuItemPumpInfo_Click);
            // 
            // menuPumpOtherCmd
            // 
            this.menuPumpOtherCmd.Index = 4;
            this.menuPumpOtherCmd.Text = "其他命令(&O)";
            this.menuPumpOtherCmd.Click += new System.EventHandler(this.menuPumpOtherCmd_Click);
            // 
            // listView_Pump
            // 
            this.listView_Pump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Pump.FullRowSelect = true;
            this.listView_Pump.Location = new System.Drawing.Point(0, 41);
            this.listView_Pump.Name = "listView_Pump";
            this.listView_Pump.Size = new System.Drawing.Size(600, 221);
            this.listView_Pump.TabIndex = 4;
            this.listView_Pump.UseCompatibleStateImageBehavior = false;
            this.listView_Pump.View = System.Windows.Forms.View.Details;
            this.listView_Pump.DoubleClick += new System.EventHandler(this.listView_Pump_DoubleClick);
            // 
            // contextMenu_Gate
            // 
            this.contextMenu_Gate.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Cm_Gate_Rlt,
            this.Cm_Gate_His,
            this.Cm_Gate_Par,
            this.Cm_Gate_Tm,
            this.Cm_Gate_O_Lock,
            this.Cm_Gate_C_Lock,
            this.Cm_Gate_R_Lock,
            this.menuItemGateInfo,
            this.menuGateOtherCmd});
            // 
            // Cm_Gate_Rlt
            // 
            this.Cm_Gate_Rlt.Index = 0;
            this.Cm_Gate_Rlt.Text = "实时状态(&S)";
            this.Cm_Gate_Rlt.Click += new System.EventHandler(this.Cm_Gate_Rlt_Click);
            // 
            // Cm_Gate_His
            // 
            this.Cm_Gate_His.Index = 1;
            this.Cm_Gate_His.Text = "最新记录(&H)";
            this.Cm_Gate_His.Click += new System.EventHandler(this.Cm_Gate_His_Click);
            // 
            // Cm_Gate_Par
            // 
            this.Cm_Gate_Par.Index = 2;
            this.Cm_Gate_Par.Text = "设置参数(&P)";
            this.Cm_Gate_Par.Click += new System.EventHandler(this.Cm_Gate_Par_Click);
            // 
            // Cm_Gate_Tm
            // 
            this.Cm_Gate_Tm.Index = 3;
            this.Cm_Gate_Tm.Text = "数据卡号(&T)";
            this.Cm_Gate_Tm.Click += new System.EventHandler(this.Cm_Gate_Tm_Click);
            // 
            // Cm_Gate_O_Lock
            // 
            this.Cm_Gate_O_Lock.Index = 4;
            this.Cm_Gate_O_Lock.Text = "强制开锁(&O)";
            this.Cm_Gate_O_Lock.Click += new System.EventHandler(this.Cm_Gate_O_Lock_Click);
            // 
            // Cm_Gate_C_Lock
            // 
            this.Cm_Gate_C_Lock.Index = 5;
            this.Cm_Gate_C_Lock.Text = "强制关锁(&C)";
            this.Cm_Gate_C_Lock.Click += new System.EventHandler(this.Cm_Gate_C_Lock_Click);
            // 
            // Cm_Gate_R_Lock
            // 
            this.Cm_Gate_R_Lock.Index = 6;
            this.Cm_Gate_R_Lock.Text = "正常控锁(&N)";
            this.Cm_Gate_R_Lock.Click += new System.EventHandler(this.Cm_Gate_R_Lock_Click);
            // 
            // menuItemGateInfo
            // 
            this.menuItemGateInfo.Index = 7;
            this.menuItemGateInfo.Text = "口门信息(&I)";
            this.menuItemGateInfo.Click += new System.EventHandler(this.menuItemGateInfo_Click);
            // 
            // menuGateOtherCmd
            // 
            this.menuGateOtherCmd.Index = 8;
            this.menuGateOtherCmd.Text = "其他命令(&O)";
            this.menuGateOtherCmd.Click += new System.EventHandler(this.menuGateOtherCmd_Click);
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(600, 286);
            this.Controls.Add(this.listView_Pump);
            this.Controls.Add(this.listView_Gate);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.statusBar);
            this.Menu = this.mainMenu;
            this.Name = "frmMain";
            this.Text = "Gprs采集系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Members

        /// <summary>
        /// 
        /// </summary>
        TcpListener listener;

        //执行采集变量
        bool Run_Stp_Order = false;

        Thread threadListen;

        //引用DbClass类
        DbClass Db = new DbClass();

        /// <summary>
        /// cs_info 集合
        /// </summary>
        ArrayList InfoList_All = null;

        //引用GateDriver的Gate_Send类
        //Gate_Send gate_send=new Gate_Send();
        //
        GateCommandMaker _gateCommandMaker = new GateCommandMaker();

        //引用PumpDriver的Pump_Send类
        //
        PumpCommandMaker _pumpCommandMaker = new PumpCommandMaker();

        /// <summary>
        /// 
        /// </summary>
        DebugLog _log = DebugLog.Default;

        //private string _ip;
        //private int _port;

        private const int DTU_DATA_TYPE_REGISTER_REQUEST = 1;
        private const int DTU_DATA_TYPE_USER_DATA = 2;


        // 2007-07-090 added
        //
        private event SocketEventHandler _socketEvent;


        //private UDPServer _udpServer = new UDPServer();
        //private Thread _udpServerThread;

        private bool _closeConfirm;

        /// <summary>
        /// 
        /// </summary>
        public event CsInfoTimeOutEventHandler CsInfoTimeOutEvnet;

        private frmOne _fo;

        private Importer _importer;

        #endregion //Members

        #region ListenlingThread
        /// <summary>
        /// 启动监听
        /// </summary>
        private void ListeningThread()
        {
            string serverIP = Config.Default.ServerIP;
            int listenPort = Config.Default.ListenPort;
            // 2011-05-04
            //
            //listener = new TcpListener ( IPAddress.Parse( serverIP  ), listenPort );
            listener = new TcpListener(IPAddress.Any, listenPort);
            listener.Start();

            _log.AddCommon(new LogItem("Start listening",
                Config.Default.ServerIP.ToString() + " : " + Config.Default.ListenPort));

            _closeConfirm = true;

            while (true)
            {
                // TODO: 2007-07-03 Added 
                // SocketException: 由于系统缓冲区空间不足或队列已满，不能执行套接字上的操作。
                //
                Socket socket = listener.AcceptSocket();
                _log.AddCommon(new LogItem("AcceptSocket", socket.RemoteEndPoint.ToString()));

                ProcessNewConnect(socket);
            }
        }
        #endregion

        #region ProcessNewConnect
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sck"></param>
        private void ProcessNewConnect(Socket sck)
        {
            Debug.Assert(sck != null && sck.Connected == true);

            IPEndPoint ipep = (IPEndPoint)sck.RemoteEndPoint;
            IPAddress ipAddress = ipep.Address;

            DeviceInfo[] infos = DeviceInfoManager.GetDeviceInfo(ipAddress);
            if (infos == null)
            {
                LogItem li = new LogItem("not find IP in cs_info", ipAddress.ToString());
                _log.AddCommon(li);
            }
            else
            {
                bool closed = false;
                foreach (DeviceInfo info in infos)
                {
                    if (!closed && info.Socket != null)
                    {
                        try
                        {
                            info.Socket.Shutdown(SocketShutdown.Both);
                        }
                        catch (ObjectDisposedException)
                        {
                        }

                        info.Socket.Close();
                        info.Tally.Add(DeviceInfo.TEXT_DISCONNECT, DateTime.Now);
                        closed = true;
                    }

                    info.Socket = sck;
                    info.Tally.Add(DeviceInfo.TEXT_CONNECT, DateTime.Now);

                    if (_socketEvent != null)
                    {
                        _socketEvent(this, new SocketEventArgs(info, true));
                    }
                }
            }
        }
        #endregion //ProcessNewConnect

        #region AddReceiveSocketInfo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sck"></param>
        /// <param name="li"></param>
        private void AddReceiveSocketInfo(Socket sck, LogItem li)
        {
            Debug.Assert(li != null);
            IPAddress ip = null;
            try
            {
                ip = ((IPEndPoint)sck.RemoteEndPoint).Address;
            }
            catch (SocketException socketEx)
            {
                LogItem liT = new LogItem("Get socket.remoteEndPoint Ex", socketEx);
                _log.AddCommon(liT);
                return;
            }

            DeviceInfo[] infos = DeviceInfoManager.GetDeviceInfo(ip);
            if (infos != null)
            {
                string name = string.Empty;
                string sim = string.Empty;
                string sign = string.Empty;

                foreach (DeviceInfo info in infos)
                {
                    name += info.Address;
                    sim += info.Sim;
                    sign += info.DeviceKind;
                }

                li.Add("IP", ip.ToString());
                li.Add("name", name);
                li.Add("sim", sim);
                li.Add("sign", sign);
            }
        }
        #endregion //AddReceiveSocketInfo

        #region ReceiveFunction

        /// <summary>
        /// 接收数据线程 
        /// </summary>
        private void ReceiveFunction()
        {
            while (true)
            {
                foreach (DeviceInfo info in InfoList_All)
                {
                    if (info.Socket != null)
                    {
                        Socket sck = info.Socket;
                        if (sck.Connected &&
                            sck.Available > 0 &&
                            info.IsUse == 1
                            )
                        {
                            byte[] receivedData = new byte[sck.Available];
                            int receivedCount = sck.Receive(receivedData);

                            // add log
                            //
                            LogItem li2 = new LogItem();
                            li2.ShouldLog = true;
                            li2.Add("Received datas", CT.BytesToString(receivedData));
                            AddReceiveSocketInfo(sck, li2);

                            //
                            //
                            if (receivedCount > 0)
                            {
                                //ProcessUserData(receivedData, receivedCount, sck, li2);
                                //continue;

                                if (info.DeviceInfoState.IsSended())
                                {
                                    info.DeviceInfoState.AppendReceivedData(receivedData);
                                }
                                info.FireReceivedDataEvent(receivedData);

                                byte[][] dtuDatas = SGDtu.GetDtuData(receivedData);
                                if (dtuDatas == null)
                                {
                                    li2.ShouldLog = true;
                                    li2.Add("GetDtuData", null);
                                    _log.AddCommon(li2);
                                    continue;
                                }

                                foreach (byte[] bs in dtuDatas)
                                {
                                    // 心跳
                                    //
                                    if (SGDtu.IsDtuHeartBeat(bs))
                                    {
                                        byte[] cmd = MakeDtuRegisteAnswerCommand(bs);

                                        info.Tally.Add(DeviceInfo.TEXT_HEARTBEAT, DateTime.Now);

                                        // 2007-07-06 Added try
                                        //
                                        try
                                        {
                                            sck.Send(cmd, cmd.Length, 0);
                                        }
                                        catch (SocketException socketEx)
                                        {
                                            LogItem exLog = new LogItem("Send heart beat Ex", socketEx.ToString());
                                            _log.AddCommon(exLog);
                                        }
                                    }
                                    else if (SGDtu.IsDtuUserData(bs))
                                    {
                                        // get active deviceinfo
                                        //
                                        if (info.Group.IsUsed())
                                        {
                                            DeviceInfo activedDeviceInfo = info.Group.LastDeviceInfo;
                                            if (activedDeviceInfo != null)
                                            {
                                                ProcessUserData(activedDeviceInfo, bs, bs.Length, sck, li2);
                                            }
                                        }
                                        else
                                        {
                                            ProcessUserData(info, bs, bs.Length, sck, li2);
                                        }
                                    }
                                    else
                                    {
                                        li2.Add("data error");
                                        li2.ShouldLog = true;
                                    }
                                }
                            }
                            if (li2.ShouldLog)
                                _log.AddCommon(li2.ToString());
                        }
                    }
                }
                Thread.Sleep(Config.Default.ReceiveThreadSleepTime);
            }
        }
        #endregion //ReceiveFunction

        #region Gate_Read
        /// <summary>
        /// 读取口门数据,及向关操作，保存、显示信息框等
        /// </summary>
        /// <param name="by">用户数据</param>
        /// <param name="bufLen">用户数据长度，[x]</param>
        internal void Gate_Read(byte[] by, LogItem li)
        {
            //读取数据
            object readpar = new object();

            //引用类
            //GateReader gateReader = new GateReader(by,bufLen,ref readpar);
            GateReader gateReader = new GateReader(by, ref readpar);

            // 2007.06.07 Added check gateReader state
            //
            if (gateReader.DataFlag != DataFlag.OK)
            {
                // log error info
                if (li != null)
                {
                    li.Add("GateReader parse error", gateReader.DataFlag.ToString());
                    li.ShouldLog = true;
                }
                return;
            }

            Debug.Assert(readpar != null, "readpar == null");

            // by[5] - Function code
            //
            switch (by[5])
            {
                //参数数据
                case 0x23:
                    Gate_Msg_Par(readpar);
                    break;

                //实时数据
                case 0x24:
                    // TODO: 2007-07-10 Exception 
                    //
                    Gate_View_Rlt(readpar, this.listView_Gate);
                    break;

                //                    //历史记录
                //                case 0x25:
                //                    Db.Gate_His_Save(ref readpar);
                //                    break;


                case 0x37:
                    //TODO: 输入水量记录??
                    //
                    Gate_Inp gate_inp = (Gate_Inp)readpar;
                    break;


                case 0x3C:
                    // 是循环采集的
                    //最后一条记录
                    //存储记录
                    //
                    Db.Gate_His_Save(ref readpar);
                    Gate_His gateHistoryData = readpar as Gate_His;
                    DeviceInfo info = FindDeviceInfo(gateHistoryData.ComAdr, DeviceInfoManager.TEXT_GATE);
                    if (info != null)
                    {
                        info.LastUpdateDateTime = DateTime.Now;
                        info.Tally.Add(DeviceInfo.TEXT_GATE_CMD3C, DateTime.Now);
                    }

                    //显示记录
                    //
                    Gate_View_His(readpar, this.listView_Gate);
                    break;

                //读取状态量
                default:
                    //                    Gate_Info(readpar);
                    LogItem aLog = new LogItem("Unparse gate data", CT.BytesToString(by));
                    _log.AddCommon(aLog);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commAddress"></param>
        /// <param name="signType"></param>
        /// <returns></returns>
        private DeviceInfo FindDeviceInfo(int commAddress, string signType)
        {
            foreach (object obj in InfoList_All)
            {
                DeviceInfo info = obj as DeviceInfo;
                Debug.Assert(info != null);

                if (info.DeviceAddress == commAddress &&
                    info.DeviceKind == signType)
                    return info;
            }
            return null;
        }

        /// <summary>
        /// 获取实时数据集合
        /// </summary>
        /// <param name="readpar"></param>
        /// <param name="gate_view"></param>
        private void Gate_View_Rlt(object readpar, ListView gate_view)
        {
            //读取数据
            Gate_Rlt gate_rlt = (Gate_Rlt)readpar;
            //获取口门位置
            string Address = "";
            for (int i = 0; i < InfoList_All.Count; i++)
            {
                DeviceInfo info = (DeviceInfo)InfoList_All[i];
                if (info.DeviceAddress == gate_rlt.ComAdr && info.DeviceKind == "Gate")
                {
                    Address = info.Address;
                    break;
                }
            }
            //当前日期时间
            string strDateTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            //显示数据
            for (int i = 0; i < gate_view.Items.Count; i++)
            {
                if (gate_view.Items[i].Text == Address)
                {
                    //日期时间
                    gate_view.Items[i].SubItems[1].Text = strDateTime;
                    //闸前水位
                    gate_view.Items[i].SubItems[2].Text = gate_rlt.BeforeLevel.ToString();
                    //闸后水位
                    gate_view.Items[i].SubItems[3].Text = gate_rlt.BehindLevel.ToString();
                    //实际闸高
                    gate_view.Items[i].SubItems[4].Text = gate_rlt.Height.ToString();
                    //瞬时流量
                    gate_view.Items[i].SubItems[5].Text = gate_rlt.Flux.ToString();
                    //剩余水量
                    gate_view.Items[i].SubItems[6].Text = gate_rlt.ReWater.ToString();
                    //总用水量
                    gate_view.Items[i].SubItems[7].Text = gate_rlt.TuWater.ToString();
                    //供电状态
                    gate_view.Items[i].SubItems[8].Text = gate_rlt.Power;
                    //控锁状态
                    gate_view.Items[i].SubItems[9].Text = gate_rlt.Lock_OC;

                    UpdateGate(gate_view.Items[i]);
                    break;
                }
            }
        }

        /// <summary>
        /// 获取最后一条记录集合
        /// </summary>
        /// <param name="readpar"></param>
        /// <param name="gate_view"></param>
        private void Gate_View_His(object readpar, ListView gate_view)
        {
            //读取数据
            Gate_His gate_his = (Gate_His)readpar;

            //获取口门位置
            string Address = "";
            for (int i = 0; i < InfoList_All.Count; i++)
            {
                DeviceInfo info = (DeviceInfo)InfoList_All[i];
                if (info.DeviceAddress == gate_his.ComAdr && info.DeviceKind == "Gate")
                {
                    Address = info.Address;
                    break;
                }
            }

            //显示数据
            for (int i = 0; i < gate_view.Items.Count; i++)
            {
                if (gate_view.Items[i].Text == Address)
                {
                    //日期时间
                    gate_view.Items[i].SubItems[1].Text = gate_his.DateTime;
                    //闸前水位
                    gate_view.Items[i].SubItems[2].Text = gate_his.BeforeLevel.ToString();
                    //闸后水位
                    gate_view.Items[i].SubItems[3].Text = gate_his.BehindLevel.ToString();
                    //实际闸高
                    gate_view.Items[i].SubItems[4].Text = gate_his.Height.ToString();
                    //瞬时流量
                    gate_view.Items[i].SubItems[5].Text = gate_his.Flux.ToString();
                    //剩余水量
                    gate_view.Items[i].SubItems[6].Text = gate_his.ReWater.ToString();
                    //总用水量
                    gate_view.Items[i].SubItems[7].Text = gate_his.TuWater.ToString();
                    //供电状态
                    gate_view.Items[i].SubItems[8].Text = gate_his.Power;
                    //控锁状态
                    gate_view.Items[i].SubItems[9].Text = gate_his.Lock_OC;
                    UpdateGate(gate_view.Items[i]);
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lvi"></param>
        private void UpdateGate(ListViewItem lvi)
        {
            if (_fo != null)
            {
                if (_fo.StType == "Gate" && _fo.StName == lvi.SubItems[0].Text.Trim())
                {
                    string[] ns = new string[10];
                    string[] vs = new string[10];
                    for (int i = 0; i < 10; i++)
                    {
                        ns[i] = this.listView_Gate.Columns[i].Text;
                        vs[i] = this.listView_Gate.SelectedItems[0].SubItems[i].Text.Trim();
                    }
                    _fo.SetValues(ns, vs);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lvi"></param>
        private void UpdatePump(ListViewItem lvi)
        {
            if (_fo != null)
            {
                if (_fo.StType == "Pump" && _fo.StName == lvi.SubItems[0].Text.Trim())
                {
                    string[] ns = new string[10];
                    string[] vs = new string[10];
                    for (int i = 0; i < 10; i++)
                    {
                        ns[i] = this.listView_Pump.Columns[i].Text;
                        vs[i] = this.listView_Pump.SelectedItems[0].SubItems[i].Text.Trim();
                    }
                    _fo.SetValues(ns, vs);
                }
            }
        }
        /// <summary>
        /// 显示口门参数信息窗口
        /// </summary>
        /// <param name="readpar"></param>
        private void Gate_Msg_Par(object readpar)
        {
            Gate_Par gate_par = (Gate_Par)readpar;
            string caption = "口门参数";
            string gate_msg = "站号:" + gate_par.ComAdr + "\r\n";
            gate_msg = gate_msg + "闸门宽度:" + gate_par.Width + "\r\n";
            gate_msg = gate_msg + "闸底高程:" + gate_par.BottomHeight + "\r\n";
            gate_msg = gate_msg + "自由流系数:" + gate_par.FreeFlux + "\r\n";
            gate_msg = gate_msg + "潜流系数:" + gate_par.UndrFlux + "\r\n";
            gate_msg = gate_msg + "闸前水位量程:" + gate_par.BeforeLevel + "\r\n";
            gate_msg = gate_msg + "闸后水位量程:" + gate_par.BehindLevel + "\r\n";
            gate_msg = gate_msg + "闸前水位修正:" + gate_par.BeforeCorrect + "\r\n";
            gate_msg = gate_msg + "闸后水位修正:" + gate_par.BehindCorrect + "\r\n";


            MessageBox.Show(this, gate_msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示口门状态信息窗口
        /// </summary>
        /// <param name="readpar"></param>
        private void Gate_Info(object readpar)
        {
            Gate_Sts gate_sts = (Gate_Sts)readpar;
            string caption = "信息状态对话框";
            string status = gate_sts.Status;
            MessageBox.Show(this, status, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void ShowReadingMsgbox()
        {
            NUnit.UiKit.UserMessage.DisplayInfo("正在采集, 请稍后再试!");
        }

        #region Gate_Send_Order
        /// <summary>
        /// 发送口门指令
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="function"></param>
        private void Gate_Send_Order(string Address, byte function)
        {
            for (int i = 0; i < InfoList_All.Count; i++)
            {
                DeviceInfo send = (DeviceInfo)InfoList_All[i];
                if (send.DeviceKind == "Gate" && send.Address == Address)
                {
                    if (send.Socket != null && send.Socket.Connected)
                    {
                        if (send.Group.IsUsed())
                        {
                            ShowReadingMsgbox();
                            return;
                        }

                        byte[] sd_g = _gateCommandMaker.Send_zP_zB(send.DeviceAddress, function);
                        byte[] Sd_G = HDBytesWrap(sd_g, send.Sim);
                        send.Socket.Send(Sd_G, Sd_G.Length, 0);

                        send.Group.MarkLastDeviceInfo(send);
                        ShowSendCommandMsgbox(Address, function, Sd_G);
                        break;
                    }
                    else
                    {
                        ShowDisconnectMsg(Address);
                    }
                }
            }
        }
        #endregion

        #region Gate_ListView_Ini
        /// <summary>
        /// 初始化listView口门
        /// </summary>
        /// <param name="gate_view"></param>
        private void Gate_ListView_Ini(ListView gate_view)
        {
            //ListView标头
            gate_view.Columns.Add("位置", gate_view.Width / 9, HorizontalAlignment.Center);
            gate_view.Columns.Add("时间", gate_view.Width / 7, HorizontalAlignment.Center);
            gate_view.Columns.Add("闸前水位", gate_view.Width / 11, HorizontalAlignment.Center);
            gate_view.Columns.Add("闸后水位", gate_view.Width / 11, HorizontalAlignment.Center);
            gate_view.Columns.Add("提闸高度", gate_view.Width / 11, HorizontalAlignment.Center);
            gate_view.Columns.Add("流量", gate_view.Width / 11, HorizontalAlignment.Center);
            //过水量
            gate_view.Columns.Add("剩余水量", gate_view.Width / 11, HorizontalAlignment.Center);
            gate_view.Columns.Add("总用水量", gate_view.Width / 11, HorizontalAlignment.Center);
            gate_view.Columns.Add("供电状态", gate_view.Width / 11, HorizontalAlignment.Center);
            gate_view.Columns.Add("控锁状态", gate_view.Width / 11, HorizontalAlignment.Center);
            //ListView条目
            //Db.Gate_Adr_List(gate_view);
            FillGateListView(gate_view);

            if (this.listView_Gate.Items.Count != 0)
            {
                this.listView_Gate.ContextMenu = this.contextMenu_Gate;
            }
        }
        #endregion

        #region CreateListViewItem
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private ListViewItem CreateListViewItem(DeviceInfo info)
        {
            string text = info.Address;
            ListViewItem item = new ListViewItem(text);
            for (int i = 0; i < 9; i++)
            {
                item.SubItems.Add("-");
            }
            item.Tag = info;
            return item;
        }
        #endregion //CreateListViewItem

        #region FillGateListView
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lv"></param>
        private void FillGateListView(ListView lv)
        {
            foreach (object obj in DeviceInfoManager.DeviceInfoList)
            {
                DeviceInfo info = obj as DeviceInfo;
                if (info.DeviceKind == DeviceInfoManager.TEXT_GATE)
                {
                    lv.Items.Add(CreateListViewItem(info));
                }
            }
        }
        #endregion //FillGateListView

        #region Gate_Operate
        /// <summary>
        /// 口门操作,采集选定的实时数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cm_Gate_Rlt_Click(object sender, System.EventArgs e)
        {
            int row = this.listView_Gate.SelectedItems.Count;
            if (row == 1)
            {
                string Address = this.listView_Gate.SelectedItems[0].SubItems[0].Text.Trim();
                DeviceInfo info = this.listView_Gate.SelectedItems[0].Tag as DeviceInfo;

                if (StringHelper.Equal(info.DeviceType, XD202.DeviceType))
                {
                    DeviceInfo send = info;
                    if (send.Socket != null && send.Socket.Connected)
                    {
                        if (send.Group.IsUsed())
                        {
                            ShowReadingMsgbox();
                            return;
                        }
                        byte[] bs = XD202.CreateReadRealCommand((byte)info.DeviceAddress);
                        bs = HDBytesWrap(bs, send.Sim);
                        send.Socket.Send(bs, bs.Length, 0);
                        send.Group.MarkLastDeviceInfo(send);
                        ShowSendCommandMsgbox(Address, 04, bs);
                    }
                    else
                    {
                        ShowDisconnectMsg(Address);
                    }
                }
                else
                {
                    Gate_Send_Order(Address, 0x24);
                }
            }
            else
            {
                ShowSelectMultiLineMsg();
            }
        }

        private void ShowSelectMultiLineMsg()
        {
            string caption = DeviceInfoManager.TEXT_TIP;
            string txtinfo = "只能对一个控制器进行操作!";
            MessageBox.Show(txtinfo, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        /// <summary>
        /// 采集最新记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cm_Gate_His_Click(object sender, System.EventArgs e)
        {
            int row = this.listView_Gate.SelectedItems.Count;
            if (row == 1)
            {
                string Address = this.listView_Gate.SelectedItems[0].SubItems[0].Text.Trim();
                Gate_Send_Order(Address, 0x3C);
            }
            else
            {
                ShowSelectMultiLineMsg();
            }

        }

        /// <summary>
        /// 采集选定的设置参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cm_Gate_Par_Click(object sender, System.EventArgs e)
        {
            int row = this.listView_Gate.SelectedItems.Count;
            if (row == 1)
            {
                string Address = this.listView_Gate.SelectedItems[0].SubItems[0].Text.Trim();
                Gate_Send_Order(Address, 0x23);
            }
            else
            {
                ShowSelectMultiLineMsg();
            }
        }

        /// <summary>
        /// 采集选定的数据卡号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cm_Gate_Tm_Click(object sender, System.EventArgs e)
        {
            int row = this.listView_Gate.SelectedItems.Count;
            if (row == 1)
            {
                string Address = this.listView_Gate.SelectedItems[0].SubItems[0].Text.Trim();
                Gate_Send_Order(Address, 0x27);
            }
            else
            {
                ShowSelectMultiLineMsg();
            }
        }

        /// <summary>
        /// 强制开锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cm_Gate_O_Lock_Click(object sender, System.EventArgs e)
        {
            int row = this.listView_Gate.SelectedItems.Count;
            if (row == 1)
            {
                string Address = this.listView_Gate.SelectedItems[0].SubItems[0].Text.Trim();
                Gate_Send_Order(Address, 0x2D);
            }
            else
            {
                ShowSelectMultiLineMsg();
            }
        }

        /// <summary>
        /// 强制关锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cm_Gate_C_Lock_Click(object sender, System.EventArgs e)
        {
            int row = this.listView_Gate.SelectedItems.Count;
            if (row == 1)
            {
                string Address = this.listView_Gate.SelectedItems[0].SubItems[0].Text.Trim();
                Gate_Send_Order(Address, 0x2E);
            }
            else
            {
                ShowSelectMultiLineMsg();
            }
        }

        /// <summary>
        /// 正常控锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cm_Gate_R_Lock_Click(object sender, System.EventArgs e)
        {
            int row = this.listView_Gate.SelectedItems.Count;
            if (row == 1)
            {
                string Address = this.listView_Gate.SelectedItems[0].SubItems[0].Text.Trim();
                Gate_Send_Order(Address, 0x2F);
            }
            else
            {
                ShowSelectMultiLineMsg();
            }
        }
        #endregion

        #region IsNewPumpProtocol
        /// <summary>
        /// 检查是否新的泵站通讯协议
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public bool IsNewPumpProtocol(byte[] bs)
        {
            if (bs == null || bs.Length < 5)
                return false;

            return bs[4] == 0x12;
        }
        #endregion //IsNewPumpProtocol

        #region Pump_Read
        /// <summary>
        /// 读取泵站数据
        /// </summary>
        /// <param name="by"></param>
        /// <param name="bufLen"></param>
        //private
        internal void ProcessPumpData(byte[] by, int bufLen, LogItem li)
        {
            //读取数据
            object readpar = new object();

            // 引用类
            //
            PumpProcessor pumpReader = new PumpProcessor(by, bufLen, ref readpar);
            if (pumpReader.DataFlag != DataFlag.OK)
            {
                li.Add("PumpReader parse error", pumpReader.DataFlag);
                li.ShouldLog = true;
                return;
            }

            //Debug.Assert(readpar != null);

            switch (by[5])
            {
                //实时数据+最后一条用水记录
                //
                case 0x1A:
                    {
                        //显示实时状态
                        PumpRealData prd = (PumpRealData)readpar;
                        UpdatePumpListView(prd, this.listView_Pump);

                        //存储记录
                        Db.SavePumpHistoryData(ref readpar);
                        PumpRealData pumpRealdata = readpar as PumpRealData;

                        DeviceInfo info = FindDeviceInfo(pumpRealdata.ComAdr, DeviceInfoManager.TEXT_PUMP);
                        if (info != null)
                        {
                            info.LastUpdateDateTime = DateTime.Now;
                            info.Tally.Add(DeviceInfo.TEXT_PUMP_CMD1A, DateTime.Now);
                        }

                    }
                    break;

                //打卡记录
                case 0x26:
                    //存储记录
                    Db.Pump_Inp_Save(ref readpar);
                    break;
                //读取状态量

                default:
                    //                    Pump_Info(readpar);
                    _log.AddCommon(new LogItem("Unparse pump data", CT.BytesToString(by)));
                    break;
            }
        }

        #region GetPumpName
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commAddress"></param>
        /// <returns></returns>
        public string GetPumpName(int commAddress)
        {
            DeviceInfo info = DeviceInfoManager.GetDeviceInfo(commAddress, DeviceInfoManager.TEXT_PUMP);
            if (info != null)
                return info.Address;

            return null;
        }
        #endregion //GetPumpName

        #region GetPumpListviewItem
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pumpName"></param>
        /// <returns></returns>
        public ListViewItem GetPumpListviewItem(string pumpName)
        {
            if (pumpName != null)
            {
                foreach (ListViewItem lvi in this.listView_Pump.Items)
                {
                    if (lvi.Text.Trim() == pumpName.Trim())
                        return lvi;
                }
            }
            return null;
        }
        #endregion //GetPumpListviewItem


        #region UpdatePumpListviewDateTime
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lvi"></param>
        public void UpdatePumpListviewDateTime(ListViewItem lvi)
        {
            lvi.SubItems[1].Text = DateTime.Now.ToString();
        }
        #endregion //

        #region GetPumpDataIndex
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public int GetPumpDataIndex(int dataType)
        {
            // pump data index in listview item
            switch (dataType)
            {
                case 0x41:
                    return 6;
                case 0x42:
                    return 4;
                case 0x43:
                    return 5;
                case 0x25:
                    return 2;

            }

            return -1;
        }
        #endregion //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readpar"></param>
        /// <param name="pump_view"></param>
        private void UpdatePumpListView(PumpRealData readpar, ListView listView)
        {
            //读取数据
            //
            PumpRealData pump_rlt = (PumpRealData)readpar;

            //获取泵站名称
            //
            string Address = string.Empty;

            for (int i = 0; i < InfoList_All.Count; i++)
            {
                DeviceInfo info = (DeviceInfo)InfoList_All[i];
                if (info.DeviceAddress == pump_rlt.ComAdr && info.DeviceKind == "Pump")
                {
                    Address = info.Address;
                    break;
                }
            }
            if (Address == string.Empty)
                _log.AddCommon(new LogItem("Not find address", pump_rlt.ComAdr));

            //当前日期时间
            //
            string strDateTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

            //显示数据
            //
            for (int i = 0; i < listView.Items.Count; i++)
            {
                if (listView.Items[i].Text == Address)
                {
                    //日期时间, 取DateTime.Now
                    //
                    listView.Items[i].SubItems[1].Text = strDateTime;

                    //流量
                    //
                    listView.Items[i].SubItems[2].Text = pump_rlt.Flux.ToString();

                    //效率
                    //
                    listView.Items[i].SubItems[3].Text = pump_rlt.Efficiency.ToString();

                    //剩余水量
                    //
                    listView.Items[i].SubItems[4].Text = pump_rlt.RemainWater.ToString();

                    //总用水量
                    //
                    listView.Items[i].SubItems[5].Text = pump_rlt.TotalWater.ToString();

                    //当前状态
                    //
                    listView.Items[i].SubItems[6].Text = pump_rlt.Run;

                    //强启状态
                    //
                    listView.Items[i].SubItems[7].Text = pump_rlt.ForceRun;

                    //振动传感器状态
                    //
                    listView.Items[i].SubItems[8].Text = pump_rlt.Vibrate;

                    //电源供电状态
                    //
                    listView.Items[i].SubItems[9].Text = pump_rlt.Power;

                    // fore color
                    //
                    if (pump_rlt.Vibrate == DeviceInfoManager.TEXT_RUNSTATE_VIBRATE)
                    {
                        listView.Items[i].ForeColor = Config.Default.PumpVibrationColor;
                        if (Config.Default.SoundFile != null)
                            WavePlayer.PlaySimple(Config.Default.SoundFile);
                    }
                    else
                    {
                        listView.Items[i].ForeColor = Config.Default.DefaultForeColor;
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// 信息状态对话框
        /// </summary>
        /// <param name="readpar"></param>
        private void Pump_Info(object readpar)
        {
            // TODO: 2006-06-27 Added 
            // 转换无效异常
            //
            Pump_Sts pump_sts = (Pump_Sts)readpar;
            string caption = "信息状态对话框";
            string status = pump_sts.Status;
            MessageBox.Show(this, status, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Pump_Send_Order
        /// <summary>
        /// 发送泵站指令
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="function"></param>
        private void Pump_Send_Order0(string Address, byte function)
        {
            for (int i = 0; i < InfoList_All.Count; i++)
            {
                DeviceInfo send = (DeviceInfo)InfoList_All[i];
                if (send.DeviceKind == "Pump" && send.Address == Address)
                {
                    if (send.Socket != null && send.Socket.Connected)
                    {
                        byte[] sd_p = _pumpCommandMaker.MakeCommandHelp(send.DeviceAddress, function);
                        byte[] Sd_P = HDBytesWrap(sd_p, send.Sim);
                        send.Socket.Send(Sd_P, Sd_P.Length, 0);

                        ShowSendCommandMsgbox(Address, function, Sd_P);
                        break;
                    }
                    else
                    {
                        ShowDisconnectMsg(Address);
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="function"></param>
        /// <param name="sendCommand"></param>
        private void ShowSendCommandMsgbox(string address, byte function, byte[] sendCommand)
        {
            if (Config.Default.ShowSpecifyCommandMsgbox)
            {
                string text = "命令已发送!";
                if (Config.Default.ShowSpecifyCommandContent)
                {
                    text += Environment.NewLine + CT.BytesToString(sendCommand);
                }
                MessageBox.Show(this, text, DeviceInfoManager.TEXT_TIP, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        private void ShowDisconnectMsg(string address)
        {
            string s = address + " GPRS模块未连接或已断开!";

            MessageBox.Show(this, s, DeviceInfoManager.TEXT_TIP,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="uPar"></param>
        /// <param name="function"></param>
        private void Pump_Send_Order1(string Address, int uPar, byte function)
        {
            for (int i = 0; i < InfoList_All.Count; i++)
            {
                DeviceInfo send = (DeviceInfo)InfoList_All[i];
                if (send.DeviceKind == "Pump" && send.Address == Address)
                {
                    if (send.Socket != null && send.Socket.Connected)
                    {

                        byte[] sd_p = _pumpCommandMaker.Send_oP_oB(send.DeviceAddress, uPar, function);
                        byte[] Sd_P = HDBytesWrap(sd_p, send.Sim);
                        send.Socket.Send(Sd_P, Sd_P.Length, 0);
                        break;
                    }
                    else
                    {
                        ShowDisconnectMsg(Address);
                    }
                }
            }
        }
        #endregion

        #region FillPumpListView
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lv"></param>
        private void FillPumpListView(ListView lv)
        {
            foreach (object obj in DeviceInfoManager.DeviceInfoList)
            {
                DeviceInfo info = obj as DeviceInfo;
                if (info.DeviceKind == DeviceInfoManager.TEXT_PUMP)
                {
                    lv.Items.Add(CreateListViewItem(info));
                }
            }
        }
        #endregion //FillPumpListView

        #region Pump_ListView_Ini
        /// <summary>
        /// 初始化listView泵站
        /// </summary>
        /// <param name="pump_view"></param>
        private void Pump_ListView_Ini(ListView pump_view)
        {
            //ListView标头
            pump_view.Columns.Add("位置", pump_view.Width / 9, HorizontalAlignment.Center);
            pump_view.Columns.Add("时间", pump_view.Width / 7, HorizontalAlignment.Center);
            pump_view.Columns.Add("流量", pump_view.Width / 11, HorizontalAlignment.Center);
            pump_view.Columns.Add("效率", pump_view.Width / 11, HorizontalAlignment.Center);
            pump_view.Columns.Add("剩余水量", pump_view.Width / 11, HorizontalAlignment.Center);
            pump_view.Columns.Add("已用水量", pump_view.Width / 11, HorizontalAlignment.Center);
            pump_view.Columns.Add("泵站状态", pump_view.Width / 11, HorizontalAlignment.Center);
            pump_view.Columns.Add("强启状态", pump_view.Width / 11, HorizontalAlignment.Center);
            pump_view.Columns.Add("振动状态", pump_view.Width / 11, HorizontalAlignment.Center);
            pump_view.Columns.Add("供电状态", pump_view.Width / 11, HorizontalAlignment.Center);
            //ListView条目
            //Db.Pump_Adr_List(pump_view);
            FillPumpListView(pump_view);

            if (this.listView_Pump.Items.Count != 0)
            {
                this.listView_Pump.ContextMenu = this.contextMenu_Pump;
            }
        }
        #endregion

        #region Pump_Operate
        /// <summary>
        /// 泵站操作,采集选定的实时数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cm_Pump_Rlt_Click(object sender, System.EventArgs e)
        {
            int row = this.listView_Pump.SelectedItems.Count;
            if (row == 1)
            {
                string Address = this.listView_Pump.SelectedItems[0].SubItems[0].Text.Trim();
                DeviceInfo info = DeviceInfoManager.GetDeviceInfo(Address, DeviceInfoManager.TEXT_PUMP);
                Pump_Send_Order0(Address, PumpDefine.FCDefine.FC_READREAL);
            }
            else
            {
                ShowSelectMultiLineMsg();
            }
        }

        /// <summary>
        /// 强制启泵
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cm_Pump_Run_Click(object sender, System.EventArgs e)
        {

            //TODO: pump v7.05 enable pump run force
            //
            int row = this.listView_Pump.SelectedItems.Count;
            if (row == 1)
            {
                string Address = this.listView_Pump.SelectedItems[0].SubItems[0].Text.Trim();
                Pump_Send_Order1(
                    Address,
                    PumpDefine.ForceStartStopValue.Start,
                    PumpDefine.FCDefine.FC_Force_START_STOP
                    );
            }
            else
            {
                ShowSelectMultiLineMsg();
            }

        }

        /// <summary>
        /// 强制停泵
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cm_Pump_Stp_Click(object sender, System.EventArgs e)
        {
            //TODO: pump v7.05 disable pump run force
            //
            int row = this.listView_Pump.SelectedItems.Count;
            if (row == 1)
            {
                string Address = this.listView_Pump.SelectedItems[0].SubItems[0].Text.Trim();
                Pump_Send_Order1(
                    Address,
                    PumpDefine.ForceStartStopValue.Stop,
                    PumpDefine.FCDefine.FC_Force_START_STOP);
            }
            else
            {
                ShowSelectMultiLineMsg();
            }
        }
        #endregion

        #region Send_Correct
        /// <summary>
        /// 发送采集指令, 采集时钟(15分钟)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_correct_Tick(object sender, System.EventArgs e)
        {
            if (Run_Stp_Order == true)
            {
                //发送采集命令
                ReadDeviceDatas();
            }

            // 刷新口门最新数据
            //
            RefreshGateLastData();
        }
        #endregion

        #region ProcessDisconnective
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sck"></param>
        private void ProcessDisconnective(Socket sck, DeviceInfo sender)
        {
            //TODO: process disconnective socket
            //
            LogItem li = new LogItem("Socket disconnect", sender.IP != null ? sender.IP.ToString() : "<null>");
            _log.AddCommon(li);

            Socket temp = sck;

            foreach (object obj in InfoList_All)
            {
                DeviceInfo info = (DeviceInfo)obj;
                if (info.Socket == temp)
                {
                    if (_socketEvent != null)
                    {
                        _socketEvent(this, new SocketEventArgs(info, false));
                    }
                    info.Socket = null;
                }
            }
            try
            {
                temp.Shutdown(SocketShutdown.Both);
            }
            catch (ObjectDisposedException)
            {
            }
            temp.Close();
        }
        #endregion //ProcessDisconnective


        #region ReadDeviceDatas
        /// <summary>
        /// 读取设备数据
        /// </summary>
        private void ReadDeviceDatas()
        {
            for (int i = 0; i < InfoList_All.Count; i++)
            {
                DeviceInfo deviceInfo = (DeviceInfo)InfoList_All[i];

                Socket socket = deviceInfo.Socket;
                if (socket == null)
                    continue;

                if (!IsConnective(socket))
                {
                    _log.AddCommon(GetSocketString(socket) + " is disconnected");
                    ProcessDisconnective(socket, deviceInfo);

                    continue;
                }

                if (deviceInfo.IsUse != 1)
                    continue;

                if (deviceInfo.DeviceInfoState.IsSended())
                {
                    if (deviceInfo.DeviceInfoState.IsTimeOut(DateTime.Now))
                    {
                        if (CsInfoTimeOutEvnet != null)
                            CsInfoTimeOutEvnet(this, new TimeOutEventArgs(deviceInfo));

                        deviceInfo.DeviceInfoState.Reset();
                    }
                    continue;
                }

                if (
                    deviceInfo.NeedColl(DateTime.Now) &&
                     (!deviceInfo.Group.IsUsed())
                    )
                {
                    deviceInfo.Group.MarkLastDeviceInfo(deviceInfo);

                    deviceInfo.UpdateLastCollDateTime(DateTime.Now);
                    switch (deviceInfo.DeviceKind)
                    {
                        case "Gate":
                            byte[] gateCommand = null;
                            if (StringHelper.Equal(deviceInfo.DeviceType, XD202.DeviceType))
                            {
                                gateCommand = XD202.CreateReadRealCommand((byte)deviceInfo.DeviceAddress);
                            }
                            else
                            {
                                //采集最后一条记录
                                //
                                gateCommand = _gateCommandMaker.Send_zP_zB(deviceInfo.DeviceAddress, 0x3C);

                                //处理采集指令
                                //
                            }

                            gateCommand = HDBytesWrap(gateCommand, deviceInfo.Sim);

                            // TODO: 207-06-26 Addd
                            // System.Net.Sockets.SocketException: 您的主机中的软件放弃了一个已建立的连接。
                            //
                            try
                            {
                                socket.Send(gateCommand, gateCommand.Length, 0);
                                _log.AddCommon("send: " + GetDeviceInfoString(deviceInfo));
                                deviceInfo.DeviceInfoState.SetSendData(gateCommand);
                            }
                            catch (Exception ex)
                            {
                                LogItem li = new LogItem("Send exception", ex.ToString());
                                li.Add("RemoteEndPoint", socket.RemoteEndPoint.ToString());
                                _log.AddCommon(li);

                                deviceInfo.Socket = null;
                            }
                            break;

                        case "Pump":
                            //采集实时数据+最后一条记录
                            //
                            byte[] bsCmd = _pumpCommandMaker.MakeCommandHelp(deviceInfo.DeviceAddress, 0x1A);
                            //处理采集指令
                            //
                            bsCmd = HDBytesWrap(bsCmd, deviceInfo.Sim);
                            try
                            {
                                socket.Send(bsCmd, bsCmd.Length, 0);
                                deviceInfo.DeviceInfoState.SetSendData(bsCmd);

                                _log.AddCommon("send: " + GetDeviceInfoString(deviceInfo));
                            }
                            catch (Exception ex)
                            {
                                LogItem li = new LogItem("Send exception", ex.ToString());
                                li.Add("RemoteEndPoint", socket.RemoteEndPoint.ToString());
                                _log.AddCommon(li);
                                deviceInfo.Socket = null;
                            }
                            //}
                            break;

                        default:
                            _log.AddCommon("not find send.Sign type : " + deviceInfo.DeviceKind);
                            break;
                    }
                }
            }
        }
        #endregion //ReadDeviceDatas


        #region GetDeviceInfoString
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private string GetDeviceInfoString(DeviceInfo info)
        {
            Debug.Assert(info != null);
            string s = string.Format("StationName: {0}\r\nCommAddr: {1}\r\nSign: {2}\r\nSim: {3}\r\nSocket: {4}\r\n",
                info.Address,
                info.DeviceAddress,
                info.DeviceKind,
                info.Sim,
                GetSocketString(info.Socket)
                );

            if (info.DeviceType.Length > 0)
            {
                s += string.Format(
                    "Type: {0}\r\n",
                    info.DeviceType
                    );
            }

            return s;
        }
        #endregion //GetDeviceInfoString


        #region GetSocketString
        /// <summary>
        /// 
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        private string GetSocketString(Socket socket)
        {
            if (socket == null)
                return "<null>";

            string s = string.Empty;
            try
            {
                // return socket.RemoteEndPoint.ToString();
                s = socket.RemoteEndPoint.ToString();
            }
            catch (ObjectDisposedException odex)
            {
                s = odex.ToString();
            }
            return s;
        }
        #endregion //GetSocketString

        #region SetCsinfoCommunicationProtocol
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InfoList_All"></param>
        /// <param name="newpumps"></param>
        private void SetCsinfoCommunicationProtocol(ArrayList InfoList_All, string[] newpumps)
        {
            foreach (object obj in InfoList_All)
            {
                DeviceInfo info = obj as DeviceInfo;
                foreach (string pump in newpumps)
                {
                    if (pump == info.Address)
                    {
                        info.PumpCommunicationProtocolVersion = 705;
                    }
                }
            }
        }
        #endregion //SetCsinfoCommunicationProtocol

        #region Operate_ToolBar_MenuItem
        /// <summary>
        /// 窗体工具拦及菜单操作, 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            //
            //
            this.mnuTest.Visible = Config.Default.IsTest;

            //显示所有采集的
            Gate_ListView_Ini(this.listView_Gate);

            Pump_ListView_Ini(this.listView_Pump);

            SetStatusBarText("滦下灌区用水调度采集系统");

            //string[] newpumps = new NewPumpReader().Read();
            //if ( newpumps != null )
            //{
            //    SetCsinfoCommunicationProtocol( InfoList_All, newpumps );
            //}

            _socketEvent += new SocketEventHandler(frmMain__socketEvent);

            threadListen = new Thread(new ThreadStart(ListeningThread));
            threadListen.Start();

            StartReceiveThread();
            //StartUdpServerThread();


            // start gprs coll
            //
            if (!Run_Stp_Order)
                SwitchRun();

            //_closeConfirm = true;

            // start importer
            //
            _importer = new Importer();
            _importer.Start();
            

        }

        /// <summary>
        /// 
        /// </summary>
        private Thread _receiveThread;

        /// <summary>
        /// 
        /// </summary>
        private void StartReceiveThread()
        {
            _receiveThread = new Thread(new ThreadStart(this.ReceiveFunction));
            _receiveThread.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        private void SetStatusBarText(string text)
        {
            this.statusBar.Panels[0].Text = text;
        }

        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Login_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("禁用功能", DeviceInfoManager.TEXT_TIP, MessageBoxButtons.OK, MessageBoxIcon.Information);

            // frmLogin frm=new frmLogin();
            // frm.GetRole+=new GprsSystem.frmLogin.MyDelegate(Operate_GetRole);
            // frm.isShow=true;
            // frm.Show();
        }

        /// <summary>
        /// 注销操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Logout_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("禁用功能", DeviceInfoManager.TEXT_TIP, MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Operate_GetRole(4);
            //Db.Info_User("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Password_Click(object sender, System.EventArgs e)
        {
            frmPassword frm = new frmPassword();
            frm.Show();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Exit_Click(object sender, System.EventArgs e)
        {
            //Application.Exit();
            Close();
        }

        /// <summary>
        /// 泵站配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemPumpCon_Click(object sender, System.EventArgs e)
        {
            //frmConfigure frm=new frmConfigure();
            //frm.Text="泵站配置";
            //frm.InfoList_Pump();
            //frm.ShowDialog();
        }

        /// <summary>
        /// 口门配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemGateCon_Click(object sender, System.EventArgs e)
        {
            //frmConfigure frm=new frmConfigure();
            //frm.Text="口门配置";
            //frm.InfoList_Gate();
            //frm.ShowDialog();
        }


        /// <summary>
        /// 口门实时数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemGate_Click(object sender, System.EventArgs e)
        {
            this.Text = "Gprs采集系统——口门采集";
            this.listView_Gate.Visible = true;
            this.listView_Pump.Visible = false;
        }



        /// <summary>
        /// 泵站实时数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemPump_Click(object sender, System.EventArgs e)
        {
            this.Text = "Gprs采集系统——泵站采集";
            this.listView_Gate.Visible = false;
            this.listView_Pump.Visible = true;
        }

        /// <summary>
        /// 打开信息窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemInfo_Click(object sender, System.EventArgs e)
        {
            frmInfo frminfo = new frmInfo();
            frminfo.Show();
        }
        /// <summary>
        /// 操作工具条显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemToolBar_Click(object sender, System.EventArgs e)
        {
            if (menuItemToolBar.Checked)
            {
                menuItemToolBar.Checked = false;
                this.toolBar.Visible = false;
            }
            else
            {
                menuItemToolBar.Checked = true;
                this.toolBar.Visible = true;
            }
        }



        /// <summary>
        /// 操作状态条显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemStatusBar_Click(object sender, System.EventArgs e)
        {
            if (menuItemStatusBar.Checked)
            {
                menuItemStatusBar.Checked = false;
                this.statusBar.Visible = false;
            }
            else
            {
                menuItemStatusBar.Checked = true;
                this.statusBar.Visible = true;
            }
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemAbout_Click(object sender, System.EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();

            //TestSavePumpHis();
        }

        /// <summary>
        /// 工具栏操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if (e.Button == this.toolBarSelect)
                SwitchRun();
            else if (e.Button == this.toolBarInfo)
                ShowInfoDialog();


            switch (e.Button.Text)
            {
                case "登录":
                    //                    frmLogin f=new frmLogin();
                    //                    f.GetRole+=new GprsSystem.frmLogin.MyDelegate(Operate_GetRole);
                    //                    f.isShow=true;
                    //                    f.Show();
                    MessageBox.Show("禁用功能", DeviceInfoManager.TEXT_TIP, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "注销":
                    //                    this.Operate_GetRole(4);
                    MessageBox.Show("禁用功能", DeviceInfoManager.TEXT_TIP, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "口门":
                    // this.Text="Gprs采集系统——口门采集";
                    this.listView_Gate.Visible = true;
                    this.listView_Pump.Visible = false;
                    RefreshGateLastData();

                    break;
                case "泵站":
                    // this.Text="Gprs采集系统——泵站采集";
                    this.listView_Gate.Visible = false;
                    this.listView_Pump.Visible = true;
                    break;
                case "信息":
                    frmInfo frminfo = new frmInfo();
                    frminfo.Show();
                    break;

                case "关于":
                    //                    this.Test();
                    frmAbout frm = new frmAbout();
                    frm.ShowDialog();
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void TestSavePumpHis()
        {
            //PumpHistoryData d = new PumpHistoryData(1,2,
            object rd = new PumpRealData(1, 2, 3, 4, 5, "11", "force", "vib", "pow", 1, "run", "stp", 9);
            Db.SavePumpHistoryData(ref rd);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Test()
        {
            string s = "7B 09 00 3E 31 33 34 38 33 39 30 38 33 35 30 " +
                //" 21 58 44 4D A1 1A 25 E0 00 00 50 EA 00 01 5D 3E 41 2C 28 20 00 00 00 1D 00 4E 02 75 27 05 08 40 39 18 27 05 08 53 39 18 00 00 00 17 F4 83 " + 
               "21 58 44 4D A1 1A 25 E0 00 00 5E 9F 00 01 4F 89 41 2C 28 20 00 00 00 1D 00 4E 02 75 27 05 08 40 39 18 27 05 08 53 39 18 00 00 00 17 35 35 " +
            "7B";
            byte[] bs = CT.StringToBytes(s, null, Utilities.StringFormat.Hex);
            //ProcessUserData(bs, bs.Length, new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp), new LogItem());
        }

        #endregion

        #region SwitchRun
        /// <summary>
        /// 
        /// </summary>
        private void SwitchRun()
        {
            this.Run_Stp_Order = !Run_Stp_Order;
            this.toolBarSelect.Text = Run_Stp_Order ? "停止" : "运行";
            this.statusBarPanel2.Text = Run_Stp_Order ? "GPRS采集已运行" : "GPRS采集已停止";
        }
        #endregion //SwitchRun

        #region ShowInfoDialog
        /// <summary>
        /// 
        /// </summary>
        private void ShowInfoDialog()
        {

        }
        #endregion //ShowInfoDialog

        #region Operate_Role
        /// <summary>
        /// Role设定工具拦及菜单操作
        /// </summary>
        /// <param name="Role"></param>
        private void Operate_GetRole(int Role)
        {
            switch (Role)
            {
                case 1:
                    Role_Admin();
                    break;
                case 2:
                    Role_Power();
                    break;
                case 3:
                    Role_Users();
                    break;
                case 4:
                    Role_Guest();
                    break;
            }
        }

        /// <summary>
        /// Admin
        /// </summary>
        private void Role_Admin()
        {
            //主菜单
            this.menuItem_Password.Enabled = true;
            this.menuItem_Exit.Enabled = true;
            this.menuItemGateCon.Enabled = true;
            this.menuItemPumpCon.Enabled = true;
            //工具栏
            //			this.toolBar.Buttons[3].Enabled=true;
            //			this.toolBar.Buttons[4].Enabled=true;
            this.toolBar.Buttons[7].Enabled = true;
            //快捷菜单
            if (this.listView_Gate.Items.Count != 0)
            {
                this.listView_Gate.ContextMenu = this.contextMenu_Gate;
            }
            //			Pump_ListView_Ini(this.listView_Pump);
            if (this.listView_Pump.Items.Count != 0)
            {
                this.listView_Pump.ContextMenu = this.contextMenu_Pump;
            }
        }

        /// <summary>
        /// Power
        /// </summary>
        private void Role_Power()
        {
            //主菜单
            this.menuItem_Password.Enabled = true;
            this.menuItem_Exit.Enabled = true;
            this.menuItemGateCon.Enabled = true;
            this.menuItemPumpCon.Enabled = true;
            //工具栏
            //			this.toolBar.Buttons[3].Enabled=true;
            //			this.toolBar.Buttons[4].Enabled=true;
            this.toolBar.Buttons[7].Enabled = true;
            //快捷菜单
            if (this.listView_Gate.Items.Count != 0)
            {
                this.listView_Gate.ContextMenu = this.contextMenu_Gate;
            }
            //			Pump_ListView_Ini(this.listView_Pump);
            if (this.listView_Pump.Items.Count != 0)
            {
                this.listView_Pump.ContextMenu = this.contextMenu_Pump;
            }
        }
        /// <summary>
        /// Users
        /// </summary>
        private void Role_Users()
        {
            //主菜单
            this.menuItem_Password.Enabled = true;
            this.menuItem_Exit.Enabled = true;
            this.menuItemGateCon.Enabled = true;
            this.menuItemPumpCon.Enabled = true;
            //工具栏
            //			this.toolBar.Buttons[3].Enabled=true;
            //			this.toolBar.Buttons[4].Enabled=true;
            this.toolBar.Buttons[7].Enabled = true;
            //快捷菜单
            if (this.listView_Gate.Items.Count != 0)
            {
                this.listView_Gate.ContextMenu = this.contextMenu_Gate;
            }
            //			Pump_ListView_Ini(this.listView_Pump);
            if (this.listView_Pump.Items.Count != 0)
            {
                this.listView_Pump.ContextMenu = this.contextMenu_Pump;
            }
        }
        /// <summary>
        /// Guest
        /// </summary>
        private void Role_Guest()
        {
            //主菜单
            this.menuItem_Password.Enabled = false;
            this.menuItem_Exit.Enabled = false;
            this.menuItemGateCon.Enabled = false;
            this.menuItemPumpCon.Enabled = false;
            //工具栏
            //			this.toolBar.Buttons[3].Enabled=false;
            //			this.toolBar.Buttons[4].Enabled=false;
            this.toolBar.Buttons[7].Enabled = false;
            //快捷菜单
            this.listView_Gate.ContextMenu = null;
            this.listView_Pump.ContextMenu = null;
        }
        #endregion

        #region Data_Deal
        /// <summary>
        /// 发送指令处理
        /// </summary>
        /// <param name="order"></param>
        /// <param name="sim"></param>
        /// <returns></returns>
        private byte[] HDBytesWrap(byte[] source, string sim)
        {
            return SGDtu.HDBytesWrap(source, sim);
        }

        /// <summary>
        /// 读取数据处理, 提取dtu上传数据中的用户数据部分
        /// </summary>
        /// <remarks>
        /// ----------------------------------------------------------------
        /// 3.5.1 DTU 发送给DSC 的数据包DTU->DSC
        ///
        /// 起始标志     包类型  包长度  DTU身份识别码   结束标志    用户数据
        /// 1byte        1byte   2bytes  11bytes         1byte       max 1024bytes
        /// 0x7B         0x09    0x10    ...             0x7B        ...
        /// ----------------------------------------------------------------
        /// </remarks>
        /// <param name="data">dtu的上传数据</param>
        /// <param name="dataLength">有效数据长度</param>
        /// <returns>用户数据</returns>
        private byte[] Read_Bytes(byte[] data, int Len)
        {
            byte[] inbyte = new byte[Len - 16];
            for (int i = 0; i < Len - 16; i++)
            {
                inbyte[i] = data[i + 15];
            }
            return inbyte;
        }

        /// <summary>
        /// 生成用于向DTU发送的，注册成功指令
        /// </summary>
        /// <remarks>
        /// 当DTU向中心连接时，中心需要向DTU发送注册成功指令。
        /// ---------------------------------------------------
        /// 3.2.2 注册应答包DSC->DTU
        /// 
        /// 
        /// 1) 注册成功
        /// 
        /// 起始标志    包类型  包长度  DTU身份识别码   结束标志
        /// 1byte       1byte   2bytes  11bytes         1byte
        /// 0x7B        0x81    0x10    ...             0x7B
        /// ---------------------------------------------------
        /// </remarks>
        /// <param name="Sim">DTU发送的连接请求数据，包含DTU身份标识码，4 ~ 14 位</param>
        /// <returns>发送给DTU的 byte[]</returns>
        //private byte[] SimToDtu(byte[] Sim)
        private byte[] MakeDtuRegisteAnswerCommand(byte[] registerDatas)
        {
            Debug.Assert(registerDatas != null && registerDatas.Length >= 15);

            //byte[] outbyte=new byte[16];
            byte[] outbyte = new byte[0x10];
            outbyte[0] = 0x7B;
            outbyte[1] = 0x81;
            outbyte[2] = 0x00;
            outbyte[3] = 0x10;
            for (int i = 0; i < 11; i++)//4__14
            {
                outbyte[i + 4] = registerDatas[i + 4];
            }
            outbyte[15] = 0x7B;
            return outbyte;
        }
        #endregion

        #region CheckSocketReceived
        /// <summary>
        /// 检测接收到的数据是否合法, DTU部分
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="receivedDataType">返回接收到的DTU数据的类型，注册请求 或 用户数据</param>
        /// <returns></returns>
        private bool CheckSocketReceived(byte[] bs, out int receivedDataType)
        {
            receivedDataType = -1;
            if (bs == null || bs.Length == 0)
            {
                return false;
            }

            if (bs[0] != 0x7B || bs[bs.Length - 1] != 0x7B)
            {
                return false;
            }

            if (bs[1] == 0x01)
                receivedDataType = DTU_DATA_TYPE_REGISTER_REQUEST;
            else if (bs[1] == 0x09)
                receivedDataType = DTU_DATA_TYPE_USER_DATA;
            return true;
        }
        #endregion //CheckSocketReceived

        #region GetDtuID
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        private string GetDtuID(byte[] bs)
        {
            string id = string.Empty;
            for (int i = 4; i < 4 + 11; i++)
            {
                id += (char)bs[i];
            }

            return id;
        }
        #endregion //GetDtuID

        #region ProcessUserData
        /// <summary>
        /// 处理用户数据
        /// </summary>
        /// <param name="by"> DTU 数据 </param>
        /// <param name="bufLen"></param>
        /// <param name="skt"></param>
        internal void ProcessUserData(DeviceInfo deviceInfo, byte[] by, int bufLen, Socket skt, LogItem li)
        {
            #region 通讯协议
            // ----------------------------------------------------------------
            // 3.5.1 DTU 发送给DSC 的数据包DTU->DSC
            //
            // 起始标志     包类型  包长度  DTU身份识别码   结束标志    用户数据
            // 1byte        1byte   2bytes  11bytes         1byte       <=1024bytes
            // 0x7B         0x09    0x10    ...             0x7B        ...
            // ----------------------------------------------------------------
            #endregion //通讯协议

            bool picked = false;
            // 获取用户数据
            //
            byte[] inbyte = SGDtu.GetUserData(by);
            bufLen = inbyte.Length;

            byte[][] gateCds = GateController.Pick(inbyte);
            if (gateCds != null)
            {
                picked = true;
                foreach (byte[] bs in gateCds)
                {
                    Gate_Read(bs, /*bs.Length,*/ li);
                }
            }

            byte[][] pumpCds = PumpController.Pick(inbyte);
            if (pumpCds != null)
            {
                picked = true;
                foreach (byte[] bs in pumpCds)
                {
                    ProcessPumpData(bs, bs.Length, li);
                }
            }

            //byte[][] pumpCds705 = PumpController705.Pick( inbyte );
            //if ( pumpCds705 != null )
            //{
            //    picked = true;
            //    foreach( byte[] bs in pumpCds705 )
            //    {
            //        Pump_Read( bs, bs.Length, li );
            //    }
            //}

            // for device xd202
            //
            if (StringHelper.Equal(deviceInfo.DeviceKind, "Gate")
                &&
                StringHelper.Equal(deviceInfo.DeviceType, XD202.DeviceType)
                )
            {
                Gate_His gateHistroyData;

                picked = XD202.Process(deviceInfo, inbyte, li, out gateHistroyData);
                if (picked)
                {
                    Gate_View_His(gateHistroyData, this.listView_Gate);
                }
            }

            if (!picked)
            {
                li.Add("pick ctrl data", false);
                li.ShouldLog = true;
            }
        }
        #endregion //ProcessUserData

        #region IsConnective
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sck"></param>
        /// <returns></returns>
        private bool IsConnective(Socket sck)
        {
            if (!sck.Connected)
                return false;

            try
            {
                if (sck.Poll(0, SelectMode.SelectRead))
                {
                    // _log.AddCommon( " sck.Poll(0, SelectMode.SelectRead): " + "true" );
                    //
                    byte[] abytes = new byte[1];
                    int nRead = sck.Receive(abytes, 0, 1, SocketFlags.Peek);
                    if (nRead == 0)
                        return false;
                }
                return true;
            }
            catch (SocketException ex)
            {
                try
                {
                    LogItem li = new LogItem("At IsConnective(Socket)", ex.ToString());
                    if (sck.RemoteEndPoint != null)
                        li.Add("RemoteEndPoint", sck.RemoteEndPoint.ToString());
                    _log.AddCommon(li.ToString());
                }
                catch { }
                return false;
            }
        }
        #endregion //IsConnective

        #region frmMain_Closing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_closeConfirm)
            {
                string msg = "确定要退出吗？";
                string tip = DeviceInfoManager.TEXT_TIP;
                DialogResult dr = MessageBox.Show(this, msg, tip, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion //frmMain_Closing

        #region menuItem1_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, System.EventArgs e)
        {

        }
        #endregion //menuItem1_Click

        #region frmMain__socketEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain__socketEvent(object sender, SocketEventArgs e)
        {
            switch (e.Info.DeviceKind)
            {
                case DeviceInfoManager.TEXT_GATE:
                    foreach (ListViewItem item in listView_Gate.Items)
                    {
                        if (item.Text == e.Info.Address)
                            item.BackColor = e.ConnectEvent ?
                                Config.Default.ConnectionedColor : Config.Default.UnConnectionedColor;
                    }
                    break;

                case DeviceInfoManager.TEXT_PUMP:
                    foreach (ListViewItem item in listView_Pump.Items)
                    {
                        if (item.Text == e.Info.Address)
                        {
                            item.BackColor = e.ConnectEvent ?
                                Config.Default.ConnectionedColor : Config.Default.UnConnectionedColor;
                        }
                    }
                    break;
            }
        }
        #endregion //frmMain__socketEvent

        #region menuItemConfig_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemConfig_Click(object sender, System.EventArgs e)
        {
            frmConfig f = new frmConfig();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog(this);
        }
        #endregion //menuItemConfig_Click

        #region contextMenu_Pump_Popup
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenu_Pump_Popup(object sender, System.EventArgs e)
        {

        }
        #endregion //contextMenu_Pump_Popup

        #region menuItemPumpInfo_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemPumpInfo_Click(object sender, System.EventArgs e)
        {
            if (listView_Pump.SelectedItems.Count >= 1)
            {
                string selText = listView_Pump.SelectedItems[0].Text;
                DeviceInfo info = DeviceInfoManager.GetDeviceInfo(selText, DeviceInfoManager.TEXT_PUMP);
                if (info != null)
                {
                    new frmCsinfo(info).ShowDialog(this);
                }
            }
        }
        #endregion //menuItemPumpInfo_Click

        #region menuItemGateInfo_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemGateInfo_Click(object sender, System.EventArgs e)
        {
            frmCsinfo f = null;
            //            if ( listView_Pump.SelectedItems.Count >= 1 )
            if (listView_Gate.SelectedItems.Count >= 1)
            {
                string selText = listView_Gate.SelectedItems[0].Text;
                DeviceInfo info = DeviceInfoManager.GetDeviceInfo(selText, DeviceInfoManager.TEXT_GATE);
                if (info != null)
                {
                    f = new frmCsinfo(info);//.ShowDialog( this );
                    f.ShowDialog(this);
                }
            }
        }
        #endregion //menuItemGateInfo_Click

        #region menuItemReadRecord_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemReadRecord_Click(object sender, System.EventArgs e)
        {
            //ReadRecord( 0 );
        }
        #endregion //menuItemReadRecord_Click

        #region ReadRecord
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordIdx"></param>
        private void ReadRecord(int recordIdx)
        {
            string address = this.listView_Gate.SelectedItems[0].Text;

            DeviceInfo info = DeviceInfoManager.GetDeviceInfo(address, DeviceInfoManager.TEXT_GATE);

            if (info.Socket != null)
            {
                byte[] cmd = new GateCommandMaker().MakeRecordCmd(info.DeviceAddress, recordIdx);
                //                byte[] cmd = new Gate_Send().MakeGateCmd( info.ComAdr, recordIdx );
                info.Socket.Send(cmd);
            }
        }
        #endregion //ReadRecord

        #region HasGateData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lvi"></param>
        /// <returns></returns>
        private bool HasGateData(ListViewItem lvi)
        {
            for (int i = 1; i <= 6; i++)
            {
                if (lvi.SubItems[i].Text == "-")
                    return false; ;
            }
            return true;
        }
        #endregion //HasGateData

        #region menuPumpOtherCmd_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuPumpOtherCmd_Click(object sender, System.EventArgs e)
        {
            if (listView_Pump.SelectedItems.Count >= 1)
            {
                string selText = listView_Pump.SelectedItems[0].Text;
                DeviceInfo info = DeviceInfoManager.GetDeviceInfo(selText, DeviceInfoManager.TEXT_PUMP);
                if (info != null)
                {
                    new frmCsinfoComm(info).ShowDialog(this);
                }
            }
        }

        #endregion //menuPumpOtherCmd_Click

        #region menuGateOtherCmd_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuGateOtherCmd_Click(object sender, System.EventArgs e)
        {
            if (listView_Gate.SelectedItems.Count >= 1)
            {
                string selText = listView_Gate.SelectedItems[0].Text;
                DeviceInfo info = DeviceInfoManager.GetDeviceInfo(selText, DeviceInfoManager.TEXT_GATE);
                if (info != null)
                {
                    new frmCsinfoComm(info).ShowDialog(this);
                }
            }

        }
        #endregion //menuGateOtherCmd_Click

        #region menuItemFont
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemFont_Click(object sender, System.EventArgs e)
        {
            // this.listView_Gate.GridLines = true;
            Font listFont = this.listView_Gate.Font;
            FontDialog fontDlg = new FontDialog();
            fontDlg.Font = listFont;
            fontDlg.FontMustExist = true;
            if (fontDlg.ShowDialog(this) == DialogResult.OK)
            {
                listFont = fontDlg.Font;
                this.listView_Gate.Font = listFont;
                this.listView_Pump.Font = listFont;
            }
        }
        #endregion menuItemFont

        #region listView_Pump_DoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_Pump_DoubleClick(object sender, System.EventArgs e)
        {
            Debug.Assert(listView_Pump.Columns.Count == 10);
            int row = this.listView_Pump.SelectedItems.Count;
            if (row == 1)
            {
                string[] ns = new string[10];
                string[] vs = new string[10];
                for (int i = 0; i < 10; i++)
                {
                    ns[i] = this.listView_Pump.Columns[i].Text;
                    vs[i] = this.listView_Pump.SelectedItems[0].SubItems[i].Text.Trim();
                }

                frmOne fo = new frmOne();
                _fo = fo;
                fo.StType = "Pump";
                fo.StName = vs[0];
                fo.SetText(vs[0] + " 泵站最新数据");
                fo.SetValues(ns, vs);
                fo.ShowDialog(this);
                _fo = null;
            }
        }
        #endregion //listView_Pump_DoubleClick

        #region listView_Gate_DoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_Gate_DoubleClick(object sender, System.EventArgs e)
        {
            Debug.Assert(listView_Gate.Columns.Count == 10);
            int row = this.listView_Gate.SelectedItems.Count;
            if (row == 1)
            {
                string[] ns = new string[10];
                string[] vs = new string[10];
                for (int i = 0; i < 10; i++)
                {
                    ns[i] = this.listView_Gate.Columns[i].Text;
                    // TODO: i = 8;
                    //
                    vs[i] = this.listView_Gate.SelectedItems[0].SubItems[i].Text.Trim();
                }

                frmOne fo = new frmOne();
                _fo = fo;
                fo.StType = "Gate";
                fo.StName = vs[0];
                fo.SetText(vs[0] + " 口门最新数据");
                fo.SetValues(ns, vs);
                fo.ShowDialog(this);
                _fo = null;
            }
        }
        #endregion //listView_Gate_DoubleClick

        #region menuItemGridLines_Click
        private void menuItemGridLines_Click(object sender, System.EventArgs e)
        {
            this.menuItemGridLines.Checked = !this.menuItemGridLines.Checked;
            this.listView_Gate.GridLines = this.menuItemGridLines.Checked;
            this.listView_Pump.GridLines = this.menuItemGridLines.Checked;
            this.listView_Gate.Refresh();
            this.listView_Pump.Refresh();
        }
        #endregion //menuItemGridLines_Click

        #region frmMain_FormClosed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion //frmMain_FormClosed

        #region Refresh

        /// <summary>
        /// 
        /// </summary>
        private void RefreshGateLastData()
        {
            // 5分钟刷新一次
            //
            bool needRefresh = false;
            TimeSpan ts = DateTime.Now - _lastRefreshGateLastDataDT;
            if (ts < TimeSpan.Zero || ts >= TimeSpan.Parse("00:05:00"))
            {
                needRefresh = true;
            }

            if (needRefresh)
            {
                GateLastData();

                if (Config.Default.HasNewGate)
                {
                    RefreshNewGateLastData();
                    RefreshNewDitchLastData();
                }
                _lastRefreshGateLastDataDT = DateTime.Now;
            }
        }

        /// <summary>
        /// 刷新新版口门数据(xd2402)
        /// </summary>
        private void RefreshNewGateLastData()
        {
            DataTable tbl = DB2.GetDBI().GetGateDataLastDataTable();
            foreach (DataRow row in tbl.Rows)
            {
                bool isfind = false;

                string name = row["name"].ToString();
                string dt = row["dt"].ToString();
                string wl1 = row["wl1"].ToString();
                string wl2 = row["wl2"].ToString();
                string height = row["height"].ToString();
                string instantFlux = row["instantFlux"].ToString();
                string usedAmount = row["usedAmount"].ToString();
                string remainAmount = row["remainAmount"].ToString();

                //for (int i = 0; i < this.listView_Gate.Items.Count; i++)
                foreach (ListViewItem lvi in this.listView_Gate.Items)
                {
                    if (lvi.Text == name)
                    {
                        lvi.SubItems[1].Text = dt;
                        lvi.SubItems[2].Text = wl1;
                        lvi.SubItems[3].Text = wl2;
                        lvi.SubItems[4].Text = height;
                        lvi.SubItems[5].Text = instantFlux;
                        lvi.SubItems[6].Text = remainAmount;
                        lvi.SubItems[7].Text = usedAmount;
                        isfind = true;
                        break;
                    }
                }

                if (!isfind)
                {
                    ListViewItem lvi = new ListViewItem(new string[] { name, dt, wl1, wl2, height, instantFlux, remainAmount, usedAmount, "-", "-" });
                    this.listView_Gate.Items.Add(lvi);
                }
            }
        }

        /// <summary>
        /// 2013-03-29 refresh SangYuan WL 
        /// </summary>
        private void RefreshNewDitchLastData()
        {
            DataTable tbl = DB2.GetDBI().GetDitchDataLastDataTable();
            foreach (DataRow row in tbl.Rows)
            {
                bool isfind = false;

                string name = row["name"].ToString();
                string dt = row["dt"].ToString();
                string wl1 = row["wl1"].ToString();
                string wl2 = row["wl2"].ToString();
                // ditchdata has not height
                //
                string height = "0";
                string instantFlux = row["instantFlux"].ToString();
                string usedAmount = row["usedAmount"].ToString();

                int usedAmountValue = Convert.ToInt32(usedAmount);
                int remainAmountValue = 0 - usedAmountValue;

                string remainAmount = remainAmountValue.ToString();

                //for (int i = 0; i < this.listView_Gate.Items.Count; i++)
                foreach (ListViewItem lvi in this.listView_Gate.Items)
                {
                    if (lvi.Text == name)
                    {
                        lvi.SubItems[1].Text = dt;
                        lvi.SubItems[2].Text = wl1;
                        lvi.SubItems[3].Text = wl2;
                        lvi.SubItems[4].Text = height;
                        lvi.SubItems[5].Text = instantFlux;
                        lvi.SubItems[6].Text = remainAmount;
                        lvi.SubItems[7].Text = usedAmount;
                        isfind = true;
                        break;
                    }
                }

                if (!isfind)
                {
                    ListViewItem lvi = new ListViewItem(new string[] { name, dt, wl1, wl2, height, instantFlux, remainAmount, usedAmount, "-", "-" });
                    this.listView_Gate.Items.Add(lvi);
                }
            }
        }


        private DateTime _lastRefreshGateLastDataDT = DateTime.MinValue;
        /// <summary>
        /// 
        /// </summary>
        private void GateLastData()
        {
            string str = string.Format(
                "select name,DT,BeforeLevel,BehindLevel,Height,Flux,RemainWater,TotalWater from tbl_GateLast");

            string strSql = Config.Default.ConnString;

            SqlConnection con = new SqlConnection(strSql);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(str, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Close();

            System.Data.DataTable tbl = ds.Tables[0];
            foreach (DataRow row in tbl.Rows)
            {
                ProcessDbRow(row, this.listView_Gate);
            }
        }
        #endregion

        #region ProcessDbRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="gate_view"></param>
        private void ProcessDbRow(DataRow row, ListView gate_view)
        {
            string strName = row["name"].ToString();
            string dt = row["DT"].ToString();
            string beforeLevel = row["BeforeLevel"].ToString();//Convert.ToInt32(r["BeforeLevel"]);
            string behindLevel = row["BehindLevel"].ToString();
            string height = row["Height"].ToString();
            string flux = row["Flux"].ToString();
            string remainWater = row["RemainWater"].ToString();
            string totalWater = row["TotalWater"].ToString();
            bool isFind = false;
            //				Gate_Rlt gateRlt = Gate_Rlt.Parse(row);
            //				if(gateRlt != null)
            //				{
            //					glrds.ChangeWithStName(strName,gateRlt);
            //				}
            //显示数据
            for (int i = 0; i < gate_view.Items.Count; i++)
            {
                if (gate_view.Items[i].Text == strName)
                {
                    //日期时间
                    gate_view.Items[i].SubItems[1].Text = dt;
                    //闸前水位
                    gate_view.Items[i].SubItems[2].Text = beforeLevel;
                    //闸后水位
                    gate_view.Items[i].SubItems[3].Text = behindLevel;
                    //实际闸高
                    gate_view.Items[i].SubItems[4].Text = height;
                    //瞬时流量
                    gate_view.Items[i].SubItems[5].Text = flux;
                    //剩余水量
                    gate_view.Items[i].SubItems[6].Text = remainWater;
                    //总用水量
                    gate_view.Items[i].SubItems[7].Text = totalWater;
                    //供电状态
                    //	gate_view.Items[i].SubItems[8].Text=gate_his.Power;
                    //控锁状态
                    //	gate_view.Items[i].SubItems[9].Text=gate_his.Lock_OC;

                    // update one form
                    // 
                    UpdateGate(gate_view.Items[i]);
                    isFind = true;
                    break;
                }
            }

            if (!isFind)
            {
                ListViewItem lvi = new ListViewItem(new string[] { strName, dt, beforeLevel, behindLevel, height, flux, remainWater, totalWater, "-", "-" });
                this.listView_Gate.Items.Add(lvi);
            }
        }
        #endregion //ProcessDbRow

        #region Test

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TEST", "TIP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            TestSavePumpData();
            TestRefershGateLastData();
        }


        /// <summary>
        /// 
        /// </summary>
        private void TestRefershGateLastData()
        {
            RefreshGateLastData();
        }

        /// <summary>
        /// 
        /// </summary>
        private void TestSavePumpData()
        {
            object data = new PumpRealData(79, 1, 1, 1, 1, "run", "force", "vib", "pow", 1, "2011-1-1", "2011-1-1", 1);
            Db.SavePumpHistoryData(ref data);
        }
        #endregion //
    }
}
