USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[up_currencyexchange_search]    Script Date: 19/12/2021 23:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[up_currencyexchange_search] 
@pintType                smallint,
@pvarCurrencySource      varchar(20),
@pvarCurrencyDestination varchar(20),
@pdatCreated             datetime

as

begin            
  
	set nocount on     
    
	if @pintType = 1 
	   Begin
			select CurrencySource   ,CurrencyDestination,
				   MoneySource      ,MoneyDestination   ,
				   Created
	          from CurrencyExchange (nolock) 
			 where Created = @pdatCreated
	   End
	if @pintType = 2 
	   Begin
			select CurrencySource   ,CurrencyDestination,
				   MoneySource      ,MoneyDestination   
	          from CurrencyExchange (nolock) 
			 where CurrencySource      = @pvarCurrencySource
			   and CurrencyDestination = @pvarCurrencyDestination
			   and Created             = @pdatCreated
	   End
	if @pintType = 3 
	   Begin
	   select distinct a.Currency  from (
			select CurrencySource  as Currency 
	          from CurrencyExchange (nolock) 
			 where Created = @pdatCreated 
			 union all 
			select distinct CurrencyDestination
	          from CurrencyExchange (nolock) 
			 where Created = @pdatCreated ) a
			       
	   End

	   
	set nocount off
end
