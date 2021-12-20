USE [Test]
GO

/****** Object:  Table [dbo].[CurrencyExchange]    Script Date: 19/12/2021 23:21:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CurrencyExchange]') AND type in (N'U'))
DROP TABLE [dbo].[CurrencyExchange]
GO

/****** Object:  Table [dbo].[CurrencyExchange]    Script Date: 19/12/2021 23:21:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CurrencyExchange](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CurrencySource] [varchar](20) NULL,
	[CurrencyDestination] [varchar](20) NULL,
	[MoneySource] [decimal](18, 8) NULL,
	[MoneyDestination] [decimal](18, 8) NULL,
	[Created] [datetime] NULL
) ON [PRIMARY]
GO


