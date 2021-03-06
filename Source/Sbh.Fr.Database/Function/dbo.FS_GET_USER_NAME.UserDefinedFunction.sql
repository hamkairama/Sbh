SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<bejos>
-- Create date: <Juni, 2018>
-- Description:	<GetUserNAme>
-- =============================================
CREATE FUNCTION [dbo].[FS_GET_USER_NAME]
(
	-- Add the parameters for the function here
	@ID int 
)
RETURNS VARCHAR(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @RESULT VARCHAR(50)

	-- Add the T-SQL statements to compute the return value here
	SELECT @RESULT = USER_NAME FROM SBH_TM_USER_ADMIN WHERE ID = @ID

	-- Return the result of the function
	RETURN @RESULT

END
GO
