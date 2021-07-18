USE Shabbir

SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
--exec GetShopBridgeProdutDetails ''
CREATE PROCEDURE GetShopBridgeProdutDetails
(
	@ProductId varchar(10) = ''
)

AS
BEGIN
	DECLARE @Where VARCHAR(1000) 
	
	SELECT PRODUCT.ProductId, PRODUCT.SellerId, PRODUCT.Name, PRODUCT.Description, PRODUCT.Category, 
	PRICE.Price, Price.Discount, Price.SellingPrice, QUANTITY.QuantityLeft, QUANTITY.QuantitySold 
	--INTO #ProductDetails
	FROM ShobBridgeProductDetails PRODUCT (NOLOCK) 
	INNER JOIN ShopBridgeProductPrice PRICE (NOLOCK) ON PRODUCT.ProductId = PRICE.ProductId
	INNER JOIN ShopBridgeProductQuantity QUANTITY (NOLOCK) ON PRICE.ProductId = QUANTITY.ProductId

	IF @ProductId <> ''
		SELECT * FROM #ProductDetails (NOLOCK) WHERE ProductId = @ProductId
	Else
		SELECT * FROM #ProductDetails (NOLOCK)   
END