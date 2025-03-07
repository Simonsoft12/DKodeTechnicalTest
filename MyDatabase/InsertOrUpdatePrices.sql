CREATE PROCEDURE dbo.InsertOrUpdatePrices
    @Prices dbo.PriceType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE p
    SET 
        p.Column2 = i.Column2,
        p.Column3 = i.Column3,
        p.Column4 = i.Column4,
        p.Column5 = i.Column5,
        p.Column6 = i.Column6
    FROM Prices p
    INNER JOIN @Prices i ON p.Column1 = i.Column1;

    INSERT INTO Prices (Column1, Column2, Column3, Column4, Column5, Column6)
    SELECT Column1, Column2, Column3, Column4, Column5, Column6
    FROM @Prices i
    WHERE NOT EXISTS (
        SELECT 1 FROM Prices p WHERE p.Column1 = i.Column1
    );
END
