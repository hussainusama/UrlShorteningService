CREATE PROCEDURE [dbo].[Select]
	@Id int
AS
	SET NOCOUNT ON;

	SELECT Id, [Url] FROM UrlMapping WHERE Id = @Id

RETURN 0
