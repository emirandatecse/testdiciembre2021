USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[up_currencyexchange_register]    Script Date: 19/12/2021 23:22:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[up_currencyexchange_register] 
@pintType                smallint,
@pintId                  int        ,
@pvarCurrencySource      varchar(20),
@pvarCurrencyDestination varchar(20),
@pdecMoneySource         decimal(18,8),
@pdecMoneyDestination    decimal(18,8),
@pdatCreated             datetime

as

begin            
  
	set nocount on     
    
	if @pintType = 1 
	   Begin
			insert into CurrencyExchange (CurrencySource     ,CurrencyDestination,
										  MoneySource        ,MoneyDestination   ,
										  Created)                                            
								  values (@pvarCurrencySource,@pvarCurrencyDestination,
										  @pdecMoneySource   ,@pdecMoneyDestination   ,
										  @pdatCreated)
	   End
	if @pintType = 2 
	   Begin
			update CurrencyExchange 
			       set MoneySource      = @pdecMoneySource,
				       MoneyDestination = @pdecMoneyDestination 
			 where Id = @pintId
	   End
	if @pintType = 3 
	   Begin
			delete CurrencyExchange 
			 where Id = @pintId
	   End
	   
	set nocount off
end
