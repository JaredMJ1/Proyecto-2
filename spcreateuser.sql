CREATE PROCEDURE dbo.usp_UpdateUsuario
    @Id INT,
    @Name NVARCHAR(100),
    @Lastname NVARCHAR(100),
    @Email NVARCHAR(150),
    @Phone NVARCHAR(20),
    @Status NVARCHAR(20)
AS
BEGIN
    UPDATE Usuario
    SET
        Name = @Name,
        Lastname = @Lastname,
        Email = @Email,
        Phone = @Phone,
        Status = @Status,
        UpdatedAt = GETDATE()
    WHERE Id = @Id;
END
GO


CREATE PROCEDURE dbo.usp_DeleteUsuario
    @Id INT
AS
BEGIN
    UPDATE Usuario
    SET
        Status = 'INACTIVE',
        UpdatedAt = GETDATE()
    WHERE Id = @Id;
END
GO
