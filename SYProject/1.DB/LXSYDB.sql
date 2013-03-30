set quoted_identifier on 
GO

/****** ����: �û� dbo    �ű�����: 2011-9-8 10:56:49 ******/
/****** ����: �û� guest    �ű�����: 2011-9-8 10:56:49 ******/
if not exists (select * from dbo.sysusers where name = N'guest' and hasdbaccess = 1)
	EXEC sp_grantdbaccess N'guest'
GO

/****** ����: ������ dbo.tg_insert_gatedata    �ű�����: 2011-9-8 10:56:51 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tg_insert_gatedata]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[tg_insert_gatedata]
GO

/****** ����: ��ͼ dbo.vGateDataLast    �ű�����: 2011-9-8 10:56:51 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vGateDataLast]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vGateDataLast]
GO

/****** ����: ��ͼ dbo.vGateData    �ű�����: 2011-9-8 10:56:51 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vGateData]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vGateData]
GO

/****** ����: �� [dbo].[tblGateDataLast]    �ű�����: 2011-9-8 10:56:51 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblGateDataLast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblGateDataLast]
GO

/****** ����: �� [dbo].[tblDeviceDitch]    �ű�����: 2011-9-8 10:56:51 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDeviceDitch]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblDeviceDitch]
GO

/****** ����: �� [dbo].[tblDitchData]    �ű�����: 2011-9-8 10:56:51 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDitchData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblDitchData]
GO

/****** ����: �� [dbo].[tblGateData]    �ű�����: 2011-9-8 10:56:51 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblGateData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblGateData]
GO

/****** ����: �� [dbo].[tblDevice]    �ű�����: 2011-9-8 10:56:51 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDevice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblDevice]
GO

/****** ����: �� [dbo].[tblStation]    �ű�����: 2011-9-8 10:56:51 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblStation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblStation]
GO

/****** ����: �� [dbo].[tblWLFluxMap]    �ű�����: 2011-9-8 10:56:51 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblWLFluxMap]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblWLFluxMap]
GO

/****** ����: �� [dbo].[tblStation]    �ű�����: 2011-9-8 10:56:51 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblStation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblStation] (
	[StationID] [int] IDENTITY (1, 1) NOT NULL ,
	[Deleted] [bit] NULL ,
	[Name] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Remark] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[CommuniType] [int] NULL ,
	[CommuniTypeContent] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	CONSTRAINT [PK_tblStation] PRIMARY KEY  CLUSTERED 
	(
		[StationID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
END

GO


/****** ����: �� [dbo].[tblWLFluxMap]    �ű�����: 2011-9-8 10:56:52 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblWLFluxMap]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblWLFluxMap] (
	[WLFluxGuanXiID] [int] NOT NULL ,
	[WL] [real] NULL ,
	[Flux] [real] NULL 
) ON [PRIMARY]
END

GO


/****** ����: �� [dbo].[tblDevice]    �ű�����: 2011-9-8 10:56:52 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDevice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblDevice] (
	[DeviceID] [int] IDENTITY (1, 1) NOT NULL ,
	[StationID] [int] NULL ,
	[Name] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Address] [int] NULL ,
	[DeviceKind] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[DeviceType] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Deleted] [bit] NULL ,
	[Remark] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	CONSTRAINT [PK_tblDevice] PRIMARY KEY  CLUSTERED 
	(
		[DeviceID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblDevice_tblStation] FOREIGN KEY 
	(
		[StationID]
	) REFERENCES [dbo].[tblStation] (
		[StationID]
	)
) ON [PRIMARY]
END

GO


/****** ����: �� [dbo].[tblDeviceDitch]    �ű�����: 2011-9-8 10:56:52 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDeviceDitch]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblDeviceDitch] (
	[DeviceID] [int] NULL ,
	[HasWL1] [bit] NULL ,
	[HasWL2] [bit] NULL ,
	[LowLimit] [int] NULL ,
	[HighLimit] [int] NULL ,
	[FluxFormula] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	CONSTRAINT [FK_tblDeviceDitch_tblDevice] FOREIGN KEY 
	(
		[DeviceID]
	) REFERENCES [dbo].[tblDevice] (
		[DeviceID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


/****** ����: �� [dbo].[tblDitchData]    �ű�����: 2011-9-8 10:56:52 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDitchData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblDitchData] (
	[DitchDataID] [int] IDENTITY (1, 1) NOT NULL ,
	[DeviceID] [int] NULL ,
	[DT] [datetime] NULL ,
	[WL1] [real] NULL ,
	[WL2] [real] NULL ,
	[InstantFlux] [float] NULL ,
	[UsedAmount] [int] NULL ,
	[Voltage] [int] NULL ,
	CONSTRAINT [PK_tblDitchData] PRIMARY KEY  CLUSTERED 
	(
		[DitchDataID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblDitchData_tblDevice] FOREIGN KEY 
	(
		[DeviceID]
	) REFERENCES [dbo].[tblDevice] (
		[DeviceID]
	)
) ON [PRIMARY]
END

GO


/****** ����: �� [dbo].[tblGateData]    �ű�����: 2011-9-8 10:56:52 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblGateData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblGateData] (
	[GateDataID] [int] IDENTITY (1, 1) NOT NULL ,
	[DeviceID] [int] NULL ,
	[DT] [datetime] NULL ,
	[WL1] [float] NULL ,
	[WL2] [float] NULL ,
	[Height] [float] NULL ,
	[InstantFlux] [float] NULL ,
	[UsedAmount] [float] NULL ,
	[RemainAmount] [float] NULL ,
	CONSTRAINT [PK_tblGateData] PRIMARY KEY  CLUSTERED 
	(
		[GateDataID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblGateData_tblDevice] FOREIGN KEY 
	(
		[DeviceID]
	) REFERENCES [dbo].[tblDevice] (
		[DeviceID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


/****** ����: �� [dbo].[tblGateDataLast]    �ű�����: 2011-9-8 10:56:52 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblGateDataLast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblGateDataLast] (
	[GateDataLastID] [int] IDENTITY (1, 1) NOT NULL ,
	[GateDataID] [int] NULL ,
	[DeviceID] [int] NULL ,
	CONSTRAINT [PK_tblGateDataLast] PRIMARY KEY  CLUSTERED 
	(
		[GateDataLastID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblGateDataLast_tblGateData] FOREIGN KEY 
	(
		[GateDataID]
	) REFERENCES [dbo].[tblGateData] (
		[GateDataID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** ����: ��ͼ dbo.vGateData    �ű�����: 2011-9-8 10:56:52 ******/
/*WHERE (dbo.tblDevice.Deleted = 0) AND (dbo.tblStation.Deleted = 0)*/
CREATE VIEW dbo.vGateData
AS
SELECT dbo.tblStation.StationID, dbo.tblDevice.DeviceID, dbo.tblStation.Name, 
      dbo.tblGateData.DT, dbo.tblGateData.WL1, dbo.tblGateData.WL2, 
      dbo.tblGateData.Height, dbo.tblGateData.InstantFlux, dbo.tblGateData.UsedAmount, 
      dbo.tblGateData.RemainAmount
FROM dbo.tblStation INNER JOIN
      dbo.tblDevice ON dbo.tblStation.StationID = dbo.tblDevice.StationID INNER JOIN
      dbo.tblGateData ON dbo.tblDevice.DeviceID = dbo.tblGateData.DeviceID

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** ����: ��ͼ dbo.vGateDataLast    �ű�����: 2011-9-8 10:56:52 ******/
/*WHERE (dbo.tblStation.Deleted = 0) AND (dbo.tblDevice.Deleted = 0)*/
CREATE VIEW dbo.vGateDataLast
AS
SELECT dbo.tblStation.StationID, dbo.tblDevice.DeviceID, dbo.tblGateData.GateDataID, 
      dbo.tblStation.Name, dbo.tblGateData.DT, dbo.tblGateData.WL1, 
      dbo.tblGateData.WL2, dbo.tblGateData.Height, dbo.tblGateData.InstantFlux, 
      dbo.tblGateData.UsedAmount, dbo.tblGateData.RemainAmount
FROM dbo.tblGateDataLast INNER JOIN
      dbo.tblGateData ON 
      dbo.tblGateDataLast.GateDataID = dbo.tblGateData.GateDataID INNER JOIN
      dbo.tblDevice ON dbo.tblGateData.DeviceID = dbo.tblDevice.DeviceID INNER JOIN
      dbo.tblStation ON dbo.tblDevice.StationID = dbo.tblStation.StationID

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** ����: ������ dbo.tg_insert_gatedata    �ű�����: 2011-9-8 10:56:52 ******/

CREATE TRIGGER tg_insert_gatedata ON [dbo].[tblGateData] 
FOR INSERT
AS
declare @deviceID as int
declare @gateDataID as int

select @deviceid = deviceid, @gateDataID = gatedataID from inserted


/*
 * delete exist device data
 */
delete from tblGateDataLast where deviceID = @deviceID

/*
 * insert last ditchdata id
 */
insert into tblGateDataLast(DeviceID, GateDataID) values(@deviceID, @gateDataID)


GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

