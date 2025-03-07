CREATE PROCEDURE dbo.InsertOrUpdateProducts
    @Products dbo.ProductType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    MERGE INTO Products AS target
    USING @Products AS source
    ON target.product_id = source.product_id
    WHEN MATCHED THEN
        UPDATE SET
            target.SKU = source.SKU,
            target.name = source.name,
            target.EAN = source.EAN,
            target.producer_name = source.producer_name,
            target.main_category = source.main_category,
            target.sub_category = source.sub_category,
            target.child_category = source.child_category,
            target.is_wire = source.is_wire,
            target.shipping = source.shipping,
            target.available = source.available,
            target.is_vendor = source.is_vendor,
            target.default_image = source.default_image
    WHEN NOT MATCHED THEN
        INSERT (product_id, SKU, name, EAN, producer_name, main_category, sub_category, child_category, is_wire, shipping, available, is_vendor, default_image)
        VALUES (source.product_id, source.SKU, source.name, source.EAN, source.producer_name, source.main_category, source.sub_category, source.child_category, source.is_wire, source.shipping, source.available, source.is_vendor, source.default_image);
END
