CREATE PROCEDURE [dbo].[Select]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Url] FROM UrlMapping WHERE Id = @Id

END
