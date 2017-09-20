USE ONLINE_SHOP
GO
IF OBJECT_ID('uspCau1b','P') IS NOT NULL
	DROP PROC uspCau1b

GO
CREATE PROC uspCau1b
	@a float = 0,
	@b float = 0,
	@tong float OUT
AS
	SET @tong= @a + @b
GO

DECLARE @x float = 10.1 , @y float = 20.1 , @tong float 
EXEC  uspCau1b @x , @y , @tong OUT
PRINT @tong

