USE Shabbir

SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  

--exec aDDProdutDetails '<ProductDetails xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">  <ProductId>string</ProductId>  <SellerId>string</SellerId>  <Name>string</Name>  <Description>string</Description>  <Category>string</Category>  <Price>0</Price>  <Discount>0</Discount>  <SellingPrice>0</SellingPrice>  <QuantitySold>0</QuantitySold>  <QuantityLeft>0</QuantityLeft></ProductDetails>'
alter PROCEDURE aDDProdutDetails
(
	@ProductDetails varchar(max)
)
AS
BEGIN
	SET NOCOUNT ON; 
	DECLARE @ProductId varchar(10),
			@SellerId VARCHAR(10),
			@Category VARCHAR(50),
			@Name VARCHAR(50),
			@Description VARCHAR(2000),
			@Price DECIMAL,
			@Discount DECIMAL,
			@SellingPrice DECIMAL,
			@QuantityLeft INTEGER,
			@QuantitySold INTEGER
	DECLARE @Product xml
	DECLARE @Result VARCHAR(10) = 'FAILURE'
	
	--select cast(@ProductDetails As xml) As 'cast'
	
	BEGIN TRAN
	set @Product = cast(@ProductDetails As xml) 

	SELECT @ProductId = Data.Col.value('(/ProductDetails/ProductId)[1]','varchar(10)') FROM @Product.nodes('/ProductDetails') AS Data(Col)
	SELECT @SellerId = Data.Col.value('(/ProductDetails/SellerId)[1]','varchar(10)') FROM @Product.nodes('/ProductDetails') AS Data(Col)
	SELECT @Category = Data.Col.value('(/ProductDetails/Category)[1]','varchar(50)') FROM @Product.nodes('/ProductDetails') AS Data(Col)
	SELECT @Name = Data.Col.value('(/ProductDetails/Name)[1]','varchar(50)') FROM @Product.nodes('/ProductDetails') AS Data(Col)
	SELECT @Description = Data.Col.value('(/ProductDetails/Description)[1]','varchar(2000)') FROM @Product.nodes('/ProductDetails') AS Data(Col)
	SELECT @Price = Data.Col.value('(/ProductDetails/Price)[1]','DECIMAL') FROM @Product.nodes('/ProductDetails') AS Data(Col)
	SELECT @Discount = Data.Col.value('(/ProductDetails/Discount)[1]','DECIMAL') FROM @Product.nodes('/ProductDetails') AS Data(Col)
	SELECT @SellingPrice = Data.Col.value('(/ProductDetails/SellingPrice)[1]','DECIMAL') FROM @Product.nodes('/ProductDetails') AS Data(Col)
	SELECT @QuantityLeft = Data.Col.value('(/ProductDetails/QuantityLeft)[1]','INTEGER') FROM @Product.nodes('/ProductDetails') AS Data(Col)
	SELECT @QuantitySold = Data.Col.value('(/ProductDetails/QuantitySold)[1]','INTEGER') FROM @Product.nodes('/ProductDetails') AS Data(Col)

	insert into ShobBridgeProductDetails (SellerId, ProductId, Category, Name, Description )
	values(@SellerId, @ProductId, @Category, @Name, @Description)

	insert into ShopBridgeProductPrice (SellerId, ProductId, Price, Discount, SellingPrice )
	values(@SellerId, @ProductId,@Price, @Discount, @SellingPrice)
	
	insert into ShopBridgeProductQuantity (SellerId, ProductId, QuantityLeft, QuantitySold )
	values(@SellerId, @ProductId, @QuantityLeft, @QuantitySold)

	SET @Result = 'SUCCESS'

	COMMIT TRAN

	SELECT @Result AS SUCCESS
END