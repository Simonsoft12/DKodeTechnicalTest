CREATE PROCEDURE dbo.InsertOrUpdateInventory
    @InventoryItems dbo.InventoryType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE i
    SET 
        i.sku = iv.sku,
        i.unit = iv.unit,
        i.qty = iv.qty,
        i.manufacturer = iv.manufacturer,
        i.shipping = iv.shipping,
        i.shipping_cost = iv.shipping_cost
    FROM Inventory i
    INNER JOIN @InventoryItems iv ON i.product_id = iv.product_id;

    INSERT INTO Inventory (product_id, sku, unit, qty, manufacturer, shipping, shipping_cost)
    SELECT iv.product_id, iv.sku, iv.unit, iv.qty, iv.manufacturer, iv.shipping, iv.shipping_cost
    FROM @InventoryItems iv
    WHERE NOT EXISTS (SELECT 1 FROM Inventory i WHERE i.product_id = iv.product_id);
END
