USE ONLINE_SHOP
GO
IF OBJECT_ID('uspCau1','P') IS NOT NULL
	DROP PROC uspCau1

GO
CREATE PROC uspCau1
	@a int = 0,
	@b int = 0
AS
	RETURN @a + @b
GO

DECLARE @x int = 10 , @y int = 20 , @tong int = 0
EXEC @tong = uspCau1 @x , @y
PRINT @tong

