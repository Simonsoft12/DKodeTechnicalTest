CREATE TYPE dbo.InventoryType AS TABLE
(
    product_id INT,
    sku NVARCHAR(50),
    unit NVARCHAR(50),
    qty DECIMAL(18, 3),
    manufacturer NVARCHAR(255),
    shipping NVARCHAR(100),    
    shipping_cost DECIMAL(18, 2)
);
