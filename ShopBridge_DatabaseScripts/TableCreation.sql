USE Shabbir

BEGIN TRAN

--To record the details of the product - name, description of the product, etc
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ShobBridgeProductDetails')
BEGIN
	CREATE TABLE ShobBridgeProductDetails
	(
		Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
		SellerId VARCHAR(10) NOT NULL,
		ProductId VARCHAR(10) NOT NULL,
		Category VARCHAR(50) NOT NULL,
		Name VARCHAR(50) NOT NULL,
		Description VARCHAR(2000) NOT NULL
		UNIQUE(SellerId, ProductId)
	)
	PRINT 'ShobBridgeProductDetails TABLE CREATED SUCCESSFULLY'
END
ELSE
	PRINT 'ShobBridgeProductDetails TABLE ALREADY EXISTS'

--To record the pricing of the product, discounted price
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ShopBridgeProductPrice')
BEGIN
	CREATE TABLE ShopBridgeProductPrice
	(
		Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
		SellerId VARCHAR(10) NOT NULL,
		ProductId VARCHAR(10) NOT NULL,
		Price DECIMAL NOT NULL,
		Discount DECIMAL NOT NULL,
		SellingPrice DECIMAL NOT NULL
		UNIQUE(SellerId, ProductId)
	)
	PRINT 'ShopBridgeProductPrice TABLE CREATED SUCCESSFULLY'
END
ELSE
	PRINT 'ShopBridgeProductPrice TABLE ALREADY EXISTS'

--to record the quantity of the product sold and remaining
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ShopBridgeProductQuantity')
BEGIN
	CREATE TABLE ShopBridgeProductQuantity
	(
		Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
		SellerId VARCHAR(10) NOT NULL,
		ProductId VARCHAR(10) NOT NULL,
		QuantityLeft INT NOT NULL,
		QuantitySold INT NOT NULL
		UNIQUE(SellerId, ProductId)
	)
	PRINT 'ShopBridgeProductQuantity TABLE CREATED SUCCESSFULLY'
END
ELSE
	PRINT 'ShopBridgeProductQuantity TABLE ALREADY EXISTS'

COMMIT
--ROLLBACK

--DROP TABLE ShobBridgeProductDetails
--DROP TABLE ShopBridgeProductPrice
--DROP TABLE ShopBridgeProductQuantity

insert into ShobBridgeProductDetails (SellerId, ProductId, Category, Name, Description )
values('123', '234', 'fashion', 'bags', 'school bags')

insert into ShopBridgeProductPrice (SellerId, ProductId, Price, Discount, SellingPrice )
values('123', '234', 500, 50, 450)

insert into ShopBridgeProductQuantity (SellerId, ProductId, QuantityLeft, QuantitySold )
values('123', '234', 7, 3)