USE [DbHomeLibrary]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateBook]    Script Date: 19.08.2021 21:03:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_UpdateBook] 
	-- Add the parameters for the stored procedure here
	@Id int,
	@Author nvarchar(255), 
    @Name nvarchar(255),
    @Content nvarchar(255),
    @Year int,
    @NumberOfVolumes int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

UPDATE [dbo].[Books]
   SET [Author] = @Author,
      [Name] = @Name ,
      [Content] = @Content,
      [Year] = @Year,
      [NumberOfVolumes] = @NumberOfVolumes
 WHERE Id = @Id
END
GO


