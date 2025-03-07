
CREATE PROCEDURE GetSupplierSummary
    @SupplierName NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.producer_name AS SupplierName,  
        p.main_category AS MainCategory,  
        p.sub_category AS SubCategory,  
        SUM(i.qty) AS TotalStockQuantity,  
        CAST(
            (
                SUM(i.qty * ISNULL(CAST(pr.Column6 AS DECIMAL(18,2)), 0) * (1 + ISNULL(CAST(pr.Column5 AS DECIMAL(18,2)), 0) / 100))
            ) 
            / NULLIF(SUM(i.qty), 0)
        AS DECIMAL(18,2)) AS AveragePriceIncludingVAT,  
        CAST(
            SUM(i.qty * ISNULL(CAST(pr.Column6 AS DECIMAL(18,2)), 0) * (1 + ISNULL(CAST(pr.Column5 AS DECIMAL(18,2)), 0) / 100))
        AS DECIMAL(18,2)) AS TotalStockValueIncludingVAT,
        CASE
            WHEN p.is_vendor = 0 THEN 'Warehouse'  
            WHEN p.is_vendor = 1 THEN 'Supplier'  
            ELSE 'Unknown'  
        END AS ShippedBy  
    FROM dbo.Products p
    INNER JOIN dbo.Inventory i ON p.product_id = i.product_id
    INNER JOIN dbo.Prices pr ON p.sku = pr.Column2
    WHERE p.producer_name = @SupplierName  
    GROUP BY 
        p.producer_name, 
        p.main_category, 
        p.sub_category, 
        p.is_vendor  
    HAVING SUM(i.qty) > 0  
    ORDER BY 
        p.main_category, 
        p.sub_category, 
        p.is_vendor;
END;
