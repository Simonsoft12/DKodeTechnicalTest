CREATE TABLE dbo.Products
(
    ID INT PRIMARY KEY IDENTITY,
    product_id INT NOT NULL,   
    SKU NVARCHAR(50) NOT NULL,      
    name NVARCHAR(255) NOT NULL,          
    EAN NVARCHAR(50) NOT NULL,               
    producer_name NVARCHAR(255),            
    main_category NVARCHAR(255),               
    sub_category NVARCHAR(255),            
    child_category NVARCHAR(255),               
    is_wire BIT,
    shipping NVARCHAR(100),                   
    available BIT,                  
    is_vendor BIT,                  
    default_image NVARCHAR(2000)              
);
