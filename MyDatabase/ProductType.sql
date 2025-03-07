CREATE TYPE dbo.ProductType AS TABLE
(
    product_id INT PRIMARY KEY,
    SKU NVARCHAR(50),
    name NVARCHAR(255),
    EAN NVARCHAR(50),
    producer_name NVARCHAR(255),
    main_category NVARCHAR(255),                
    sub_category NVARCHAR(255),            
    child_category NVARCHAR(255),
    is_wire INT,
    shipping NVARCHAR(100),    
    available INT,
    is_vendor INT,
    default_image NVARCHAR(2000)
);
