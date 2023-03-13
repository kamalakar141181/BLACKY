USE [MyHome]
GO

CREATE PROCEDURE [dbo].[spGetExpenseTypeByID]  
(  
 @ID INT = NULL,  
 @IsDeleted BIT =  NULL 
)  
AS  
BEGIN 
	IF (@IsDeleted IS NULL) 
	BEGIN
		SET @IsDeleted = 0
	END
	
	SELECT 
		* 
	FROM 
		ExpenseTypes 
	WHERE 
		(@ID IS NOT NULL AND ID = @ID)  OR (IsDeleted = @IsDeleted)
END
GO
--------------------------------------------------------------------------------------------


CREATE PROCEDURE [dbo].[spGetExpenseTypeByName]  
(  
 @Name VARCHAR(MAX) = NULL,  
 @IsDeleted BIT =  NULL 
)  
AS  
BEGIN 
	IF (@IsDeleted IS NULL) 
	BEGIN
		SET @IsDeleted = 0
	END

SELECT 
	* 
FROM 
	ExpenseTypes 
WHERE 
	(@Name IS NOT NULL AND Name LIKE '%'+@Name+'%' ) OR (IsDeleted = @IsDeleted)
END

--------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[spUpdateExpenseType]    
(
	@ID INT,
	@Name VARCHAR(MAX),  
	@Description VARCHAR(MAX),
	@ModifiedBy VARCHAR(MAX),   
	@ModifiedDate DATETIME,
	@IsSucceeded BIT = 0 OUTPUT	
)    
AS    
BEGIN 
	IF NOT EXISTS (SELECT TOP 1 * FROM ExpenseTypes WHERE ID = @ID)
	BEGIN
		RAISERROR('Expense Type is not exists.',16,1);
		RETURN;
	END

	BEGIN TRANSACTION
	UPDATE 
		ExpenseTypes 
	SET 
		[Name] = @Name, 
		[Description] = @Description, 
		ModifiedBy = @ModifiedBy, 
		ModifiedDate = @ModifiedDate
	WHERE 
		ID =@ID

	IF @@ROWCOUNT != 1
	BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
	COMMIT TRANSACTION;
	SELECT @IsSucceeded = 1

END

GO


CREATE PROCEDURE spHardDeleteExpenseType  
(
	@ID INT,
	@IsSucceeded BIT = 0 OUTPUT	
)    
AS    
BEGIN 
	IF NOT EXISTS (SELECT TOP 1 * FROM ExpenseTypes WHERE ID = @ID)
	BEGIN
		RAISERROR('Expense Type is not exists.',16,1);
		RETURN;
	END

	BEGIN TRANSACTION

	DELETE FROM ExpenseTypes WHERE ID = @ID

	IF @@ROWCOUNT != 1
	BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
	COMMIT TRANSACTION;
	SELECT @IsSucceeded = 1

END

GO


CREATE PROCEDURE spHardDeleteExpenseType  
(
	@ID INT,
	@IsSucceeded BIT = 0 OUTPUT	
)    
AS    
BEGIN 
	IF NOT EXISTS (SELECT TOP 1 * FROM ExpenseTypes WHERE ID = @ID)
	BEGIN
		RAISERROR('Expense Type is not exists.',16,1);
		RETURN;
	END

	BEGIN TRANSACTION

	DELETE FROM ExpenseTypes WHERE ID = @ID

	IF @@ROWCOUNT != 1
	BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
	COMMIT TRANSACTION;
	SELECT @IsSucceeded = 1

END

GO
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
--SELECT * FROM tblUsers
ALTER PROCEDURE spAddUser 
( 
 @Username VARCHAR(MAX) =NULL,  
 @EmailID VARCHAR(MAX) = NULL, 
 @MobileNumber VARCHAR(MAX) = NULL,  
 @Password VARCHAR(MAX) = NULL,  
 @IsActive BIT = 0,

 @CreatedBy VARCHAR(MAX) = NULL,  
 @ModifiedBy VARCHAR(MAX) = NULL,  
 @CreatedDate DATETIME = NULL,  
 @ModifiedDate DATETIME = NULL,  
 @IsDeleted BIT = 0,  
 @ID INT OUTPUT  
)  
AS  
BEGIN  
 INSERT INTO tblUsers 
	(Username,EmailID,MobileNumber,Password,IsActive,CreatedBy,ModifiedBy,CreatedDate,ModifiedDate,IsDeleted) 
 VALUES 
	(@Username,@EmailID,@MobileNumber,@Password,@IsActive,@CreatedBy,@ModifiedBy,@CreatedDate,@ModifiedDate,@IsDeleted)  
 SELECT @ID = @@IDENTITY  
END  
GO

CREATE PROCEDURE spGetUserByID
(  
	@ID INT = NULL
)  
AS  
BEGIN
	IF (@ID IS NULL) 
		BEGIN
			SELECT * FROM tblUsers WHERE IsDeleted = 0
		END
	ELSE
		BEGIN
			SELECT * FROM tblUsers WHERE ID = @ID AND IsDeleted = 0			
		END
END



CREATE PROCEDURE spGetUserByUsername
(  
	@Username VARCHAR(MAX) = NULL 
)  
AS  
BEGIN
	IF (@Username IS NULL) 
		BEGIN
			SELECT * FROM tblUsers WHERE IsDeleted = 0
		END
	ELSE
		BEGIN
			SELECT * FROM tblUsers WHERE IsDeleted =  0 AND Username LIKE '%'+@Username+'%'
		END
END

GO

CREATE PROCEDURE spGetUserByEmailID
(  
	@EmailID VARCHAR(MAX) = NULL 
)  
AS  
BEGIN
	IF (@EmailID IS NULL) 
		BEGIN
			SELECT * FROM tblUsers WHERE IsDeleted = 0
		END
	ELSE
		BEGIN
			SELECT * FROM tblUsers WHERE IsDeleted =  0 AND Username LIKE '%'+@EmailID+'%'
		END
END

GO

CREATE PROCEDURE spGetUserByMobileNumber
(  
	@MobileNumber VARCHAR(MAX) = NULL 
)  
AS  
BEGIN
	IF (@MobileNumber IS NULL) 
		BEGIN
			SELECT * FROM tblUsers WHERE IsDeleted = 0
		END
	ELSE
		BEGIN
			SELECT * FROM tblUsers WHERE IsDeleted =  0 AND Username LIKE '%'+@MobileNumber+'%'
		END
END

GO

CREATE PROCEDURE spUpdateUser    
(  
	@ID INT,
	@Username VARCHAR(MAX) NULL,  
	@EmailID VARCHAR(MAX) = NULL, 
	@MobileNumber VARCHAR(MAX) = NULL,  
	@Password VARCHAR(MAX) = NULL,  
	@IsActive BIT, 

	@ModifiedBy VARCHAR(MAX) = NULL,   
	@ModifiedDate DATETIME = NULL,    
	@IsDeleted BIT = 0
)    
AS    
BEGIN 
	IF NOT EXISTS (SELECT TOP 1 * FROM tblUsers WHERE ID = @ID)
	BEGIN
		RAISERROR('User is not exists.',16,1);
		RETURN;
	END

	BEGIN TRANSACTION
	DECLARE @SQL nvarchar(1000)  
	SET @SQL =  'UPDATE tblUsers SET '
 
	IF (@Username IS NOT NULL)  
	BEGIN  
		SET @SQL = @SQL + 'Username = ' + '''' + @Username + '''' + ','  
	END  

	IF (@EmailID IS NOT NULL)  
	BEGIN  
		SET @SQL = @SQL + 'EmailID = ' + '''' + @EmailID + '''' + ','  
	END 


	IF (@MobileNumber IS NOT NULL)  
	BEGIN  
		SET @SQL = @SQL + 'MobileNumber = ' + '''' + @MobileNumber + '''' + ','  
	END

  
	IF (@Password IS NOT NULL)  
	BEGIN  
		SET @SQL = @SQL + 'Password = ' + '''' + @Password + ''''+ ','  
	END  
  
	IF (@IsActive IS NOT NULL)  
	BEGIN  
		SET @SQL = @SQL + 'IsActive = ' + CAST(@IsActive AS VARCHAR(20)) + ','  
	END 

	IF (@ModifiedBy IS NOT NULL)  
	BEGIN  
		SET @SQL = @SQL + 'ModifiedBy = ' + '''' + @ModifiedBy + ''''+ ','    
	END  
  
	IF (@ModifiedDate IS NOT NULL)  
	BEGIN  
		SET @SQL = @SQL + 'ModifiedDate = ' + GETDATE()  + ',' 
	END  

	IF (@IsDeleted IS NOT NULL)  
	BEGIN  
		SET @SQL = @SQL + 'IsDeleted = ' + CAST(@IsDeleted AS VARCHAR(20)) + ''''+ ','
	END  

	SET @SQL = @SQL + 'WHERE ' + 'ID =' + CAST(@ID AS VARCHAR(20))   
	SET @SQL = LEFT(@SQL, LEN(@SQL)-1)
	

	IF @@ROWCOUNT != 1
	BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
	COMMIT TRANSACTION;

END

    
    
     
     
     
  
   
   
   
   