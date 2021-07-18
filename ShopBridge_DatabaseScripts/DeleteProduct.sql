USE Shabbir

SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  

CREATE PROCEDURE DeleteProduct
(
	@SellerId varchar(10),
	@ProductId varchar(10)
)
AS 
BEGIN
SET NOCOUNT ON; 

DECLARE @Result VARCHAR(10) = 'FAIL'

BEGIN TRAN

DELETE FROM ShobBridgeProductDetails
WHERE SellerId = @SellerId and ProductId = @ProductId

DELETE FROM ShopBridgeProductPrice
WHERE SellerId = @SellerId and ProductId = @ProductId

DELETE FROM ShopBridgeProductQuantity
WHERE SellerId = @SellerId and ProductId = @ProductId

SET @Result = 'SUCCESS'

COMMIT TRAN

SELECT @Result AS RESULT

END