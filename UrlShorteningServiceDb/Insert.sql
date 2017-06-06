CREATE PROCEDURE [dbo].[Insert]
	@Url nvarchar(2000),
	@Id int OUTPUT
AS
	SET NOCOUNT ON;
	
	BEGIN TRY

     INSERT INTO UrlMapping VALUES (@Url);
	 SET @Id = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH

	DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

  
	 IF ERROR_NUMBER() <> 2627
	 BEGIN
	    SELECT
            @ErrorMessage = ERROR_MESSAGE(), 
            @ErrorSeverity = ERROR_SEVERITY(), 
            @ErrorState = ERROR_STATE(); 

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState); 
 	 END
	 ELSE
      SELECT @Id = Id FROM UrlMapping WHERE [Url] = @Url

	END CATCH

RETURN 0
