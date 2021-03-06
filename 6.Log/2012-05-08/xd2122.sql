USE [XD2122DB]
GO
/****** 对象:  Table [dbo].[tbl_Group]    脚本日期: 05/08/2012 09:06:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Group](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](50) NULL,
	[GroupLeader] [nvarchar](50) NULL,
	[ContactWay] [nvarchar](50) NULL,
	[Remark] [nvarchar](100) NULL,
	[Deleted] [bit] NULL,
 CONSTRAINT [PK_tblGroup] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[tbl_XD2122_Record]    脚本日期: 05/08/2012 09:07:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_XD2122_Record](
	[DataID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[DeviceID] [int] NULL,
	[RecordID] [int] NULL,
	[DT] [datetime] NULL,
	[SluiceHeight] [decimal](18, 2) NULL,
	[BeforeDepth] [decimal](18, 2) NULL,
	[AfterDepth] [decimal](18, 2) NULL,
	[Temperature] [decimal](18, 1) NULL,
	[Discharge] [decimal](18, 2) NULL,
	[TotalWaterVolume] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tblDataRecordXD2122] PRIMARY KEY CLUSTERED 
(
	[DataID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[tbl_XD2122_Data]    脚本日期: 05/08/2012 09:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_XD2122_Data](
	[DataID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[DeviceID] [int] NULL,
	[DT] [datetime] NULL,
	[SluiceHeight] [decimal](18, 2) NULL,
	[BeforeDepth] [decimal](18, 2) NULL,
	[AfterDepth] [decimal](18, 2) NULL,
	[Discharge] [decimal](18, 2) NULL,
	[TotalWaterVolume] [decimal](18, 4) NULL,
	[Temperature] [decimal](18, 1) NULL,
	[Signal] [int] NULL,
	[BatteryQuantity] [int] NULL,
 CONSTRAINT [PK_tblDataXD2122] PRIMARY KEY CLUSTERED 
(
	[DataID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[tbl_XD2122_DataLast]    脚本日期: 05/08/2012 09:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_XD2122_DataLast](
	[DataID] [int] NULL
) ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[tbl_XD2122_RecordLast]    脚本日期: 05/08/2012 09:07:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_XD2122_RecordLast](
	[DataID] [int] NULL
) ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[tbl_XD2122_Device]    脚本日期: 05/08/2012 09:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_XD2122_Device](
	[DeviceID] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NULL,
	[DeviceName] [nvarchar](50) NULL,
	[ChannelName] [nvarchar](50) NULL,
	[DeviceType] [nvarchar](50) NULL,
	[DeviceAddress] [int] NULL,
	[TimeOut] [int] NULL,
	[RetryTimes] [int] NULL,
	[LocationX] [int] NULL,
	[LocationY] [int] NULL,
	[Path] [nvarchar](100) NULL,
	[Deleted] [bit] NULL,
	[Remark] [nvarchar](50) NULL,
	[RInterval] [int] NULL,
	[OnTime1] [int] NULL,
	[OnTime2] [int] NULL,
	[OnTime3] [int] NULL,
	[OnTime4] [int] NULL,
	[OnTime5] [int] NULL,
	[OnTime6] [int] NULL,
	[OnTime7] [int] NULL,
	[OnTime8] [int] NULL,
	[OnTime9] [int] NULL,
	[OnTime10] [int] NULL,
	[OnTime11] [int] NULL,
	[OnTime12] [int] NULL,
	[OnTime13] [int] NULL,
	[OnTime14] [int] NULL,
	[OnTime15] [int] NULL,
	[OnTime16] [int] NULL,
	[OnDelay] [int] NULL,
	[Wave] [int] NULL,
	[LowSleep] [int] NULL,
	[LowHeartBeat] [int] NULL,
	[HeartBeat] [int] NULL,
	[IsSet] [bit] NULL,
 CONSTRAINT [PK_tbl_XD2122_Device] PRIMARY KEY CLUSTERED 
(
	[DeviceID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 对象:  Trigger [inster_DataLastXD2122]    脚本日期: 05/08/2012 09:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[inster_DataLastXD2122] ON [dbo].[tbl_XD2122_Data]
FOR INSERT --, UPDATE, DELETE 
AS
BEGIN
declare @m_DeviceID 	int,
	@m_DataID 	int

select  top 1   @m_DataID = [DataID], @m_DeviceID = [DeviceID] from tbl_XD2122_Data order by [DataID] desc

delete from tbl_XD2122_DataLast where [DataID] in ( select [DataID] from v_XD2122_DataLast where [DeviceID] = @m_DeviceID )

insert into tbl_XD2122_DataLast([DataID]) values ( @m_DataID )

END
GO
/****** 对象:  View [dbo].[v_XD2122_Device]    脚本日期: 05/08/2012 09:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_XD2122_Device]
AS
SELECT dbo.tbl_Group.GroupID, dbo.tbl_Group.GroupName, dbo.tbl_XD2122_Device.DeviceID, dbo.tbl_XD2122_Device.DeviceName, dbo.tbl_XD2122_Device.DeviceType, 
               dbo.tbl_XD2122_Device.DeviceAddress, dbo.tbl_XD2122_Device.TimeOut, dbo.tbl_XD2122_Device.RetryTimes, dbo.tbl_XD2122_Device.LocationX, 
               dbo.tbl_XD2122_Device.LocationY, dbo.tbl_XD2122_Device.Deleted, dbo.tbl_XD2122_Device.Remark, dbo.tbl_XD2122_Device.RInterval, 
               dbo.tbl_XD2122_Device.OnTime1, dbo.tbl_XD2122_Device.OnTime2, dbo.tbl_XD2122_Device.OnTime3, dbo.tbl_XD2122_Device.OnTime4, 
               dbo.tbl_XD2122_Device.OnTime5, dbo.tbl_XD2122_Device.OnTime6, dbo.tbl_XD2122_Device.OnTime7, dbo.tbl_XD2122_Device.OnTime8, 
               dbo.tbl_XD2122_Device.OnTime9, dbo.tbl_XD2122_Device.OnTime10, dbo.tbl_XD2122_Device.OnTime11, dbo.tbl_XD2122_Device.OnTime12, 
               dbo.tbl_XD2122_Device.OnTime13, dbo.tbl_XD2122_Device.OnTime14, dbo.tbl_XD2122_Device.OnTime15, dbo.tbl_XD2122_Device.OnTime16, 
               dbo.tbl_XD2122_Device.OnDelay, dbo.tbl_XD2122_Device.LowSleep, dbo.tbl_XD2122_Device.LowHeartBeat, dbo.tbl_XD2122_Device.HeartBeat, 
               dbo.tbl_XD2122_Device.IsSet, dbo.tbl_XD2122_Device.Wave, dbo.tbl_XD2122_Device.ChannelName
FROM  dbo.tbl_Group INNER JOIN
               dbo.tbl_XD2122_Device ON dbo.tbl_Group.GroupID = dbo.tbl_XD2122_Device.GroupID
GO
EXEC dbo.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tbl_Group"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 271
               Right = 216
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbl_XD2122_Device"
            Begin Extent = 
               Top = 7
               Left = 264
               Bottom = 327
               Right = 442
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'USER',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_XD2122_Device'
GO
EXEC dbo.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'USER',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_XD2122_Device'
GO
/****** 对象:  View [dbo].[v_XD2122_DataLast]    脚本日期: 05/08/2012 09:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_XD2122_DataLast]
AS
SELECT dbo.tbl_XD2122_Data.DeviceID, dbo.tbl_XD2122_Data.DT, dbo.tbl_XD2122_Data.BeforeDepth, dbo.tbl_XD2122_Data.AfterDepth, dbo.tbl_XD2122_Data.Discharge, 
               dbo.tbl_XD2122_Data.TotalWaterVolume, dbo.tbl_XD2122_Data.Signal, dbo.tbl_XD2122_Data.BatteryQuantity, dbo.v_XD2122_Device.GroupName, 
               dbo.v_XD2122_Device.DeviceName, dbo.tbl_XD2122_Data.Temperature, dbo.tbl_XD2122_DataLast.DataID, dbo.tbl_XD2122_Data.SluiceHeight
FROM  dbo.tbl_XD2122_Data INNER JOIN
               dbo.tbl_XD2122_DataLast ON dbo.tbl_XD2122_Data.DataID = dbo.tbl_XD2122_DataLast.DataID INNER JOIN
               dbo.v_XD2122_Device ON dbo.tbl_XD2122_Data.DeviceID = dbo.v_XD2122_Device.DeviceID
GO
EXEC dbo.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tbl_XD2122_Data"
            Begin Extent = 
               Top = 20
               Left = 234
               Bottom = 333
               Right = 436
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbl_XD2122_DataLast"
            Begin Extent = 
               Top = 60
               Left = 2
               Bottom = 305
               Right = 160
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "v_XD2122_Device"
            Begin Extent = 
               Top = 7
               Left = 504
               Bottom = 327
               Right = 682
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'USER',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_XD2122_DataLast'
GO
EXEC dbo.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'USER',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_XD2122_DataLast'
GO
/****** 对象:  ForeignKey [FK_tbl_XD2122_Data_tbl_XD2122_Device]    脚本日期: 05/08/2012 09:06:59 ******/
ALTER TABLE [dbo].[tbl_XD2122_Data]  WITH CHECK ADD  CONSTRAINT [FK_tbl_XD2122_Data_tbl_XD2122_Device] FOREIGN KEY([DeviceID])
REFERENCES [dbo].[tbl_XD2122_Device] ([DeviceID])
GO
ALTER TABLE [dbo].[tbl_XD2122_Data] CHECK CONSTRAINT [FK_tbl_XD2122_Data_tbl_XD2122_Device]
GO
/****** 对象:  ForeignKey [FK_tbl_XD2122_DataLast_tbl_XD2122_Data]    脚本日期: 05/08/2012 09:07:00 ******/
ALTER TABLE [dbo].[tbl_XD2122_DataLast]  WITH CHECK ADD  CONSTRAINT [FK_tbl_XD2122_DataLast_tbl_XD2122_Data] FOREIGN KEY([DataID])
REFERENCES [dbo].[tbl_XD2122_Data] ([DataID])
GO
ALTER TABLE [dbo].[tbl_XD2122_DataLast] CHECK CONSTRAINT [FK_tbl_XD2122_DataLast_tbl_XD2122_Data]
GO
/****** 对象:  ForeignKey [FK_tbl_XD2122_Device_tbl_Group]    脚本日期: 05/08/2012 09:07:13 ******/
ALTER TABLE [dbo].[tbl_XD2122_Device]  WITH CHECK ADD  CONSTRAINT [FK_tbl_XD2122_Device_tbl_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[tbl_Group] ([GroupID])
GO
ALTER TABLE [dbo].[tbl_XD2122_Device] CHECK CONSTRAINT [FK_tbl_XD2122_Device_tbl_Group]
GO
/****** 对象:  ForeignKey [FK_tbl_XD2122_Record_tbl_XD2122_Device]    脚本日期: 05/08/2012 09:07:18 ******/
ALTER TABLE [dbo].[tbl_XD2122_Record]  WITH CHECK ADD  CONSTRAINT [FK_tbl_XD2122_Record_tbl_XD2122_Device] FOREIGN KEY([DeviceID])
REFERENCES [dbo].[tbl_XD2122_Device] ([DeviceID])
GO
ALTER TABLE [dbo].[tbl_XD2122_Record] CHECK CONSTRAINT [FK_tbl_XD2122_Record_tbl_XD2122_Device]
GO
/****** 对象:  ForeignKey [FK_tbl_XD2122_RecordLast_tbl_XD2122_Record]    脚本日期: 05/08/2012 09:07:18 ******/
ALTER TABLE [dbo].[tbl_XD2122_RecordLast]  WITH CHECK ADD  CONSTRAINT [FK_tbl_XD2122_RecordLast_tbl_XD2122_Record] FOREIGN KEY([DataID])
REFERENCES [dbo].[tbl_XD2122_Record] ([DataID])
GO
ALTER TABLE [dbo].[tbl_XD2122_RecordLast] CHECK CONSTRAINT [FK_tbl_XD2122_RecordLast_tbl_XD2122_Record]
GO
