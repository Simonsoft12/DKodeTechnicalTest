CREATE TABLE dbo.Inventory
(
    id INT IDENTITY(1,1) PRIMARY KEY, 
    product_id INT NOT NULL,               
    sku NVARCHAR(50) NOT NULL,     
    unit NVARCHAR(50) NOT NULL, 
    qty DECIMAL(18, 3),      
    manufacturer NVARCHAR(255),  
    shipping NVARCHAR(100),    
    shipping_cost DECIMAL(18, 2)
);
