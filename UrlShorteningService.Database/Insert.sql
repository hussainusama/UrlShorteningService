CREATE PROCEDURE [dbo].[Insert]
	@Url nvarchar(2000),
	@Id int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	 INSERT INTO UrlMapping VALUES (@Url);
	 SET @Id = SCOPE_IDENTITY()

END
