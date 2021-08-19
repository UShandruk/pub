USE [DbHomeLibrary]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteBook]    Script Date: 19.08.2021 21:02:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_DeleteBook] 
	-- Add the parameters for the stored procedure here
	@Id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DELETE FROM [dbo].[Books]
      WHERE Id = @Id
END
GO


