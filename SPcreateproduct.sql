CREATE PROCEDURE dbo.usp_UpdateProduct
    @Id INT,
    @Name NVARCHAR(150),
    @Description NVARCHAR(500),
    @Category NVARCHAR(100),
    @Quantity INT,
    @Price DECIMAL(18,2),
    @Status NVARCHAR(20)
AS
BEGIN
    UPDATE Product
    SET
        Name = @Name,
        Description = @Description,
        Category = @Category,
        Quantity = @Quantity,
        Price = @Price,
        Status = @Status,
        UpdatedAt = GETDATE()
    WHERE Id = @Id;
END
GO



CREATE PROCEDURE dbo.usp_DeleteProduct
    @Id INT
AS
BEGIN
    UPDATE Product
    SET
        Status = 'INACTIVE',
        UpdatedAt = GETDATE()
    WHERE Id = @Id;
END
GO
