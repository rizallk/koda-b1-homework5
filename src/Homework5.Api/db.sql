-- CREATE DATABASE food_ordering;

CREATE TABLE Categories (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  Name VARCHAR(100) NOT NULL,
  Description NVARCHAR(255) NULL,
  CreatedAt DATETIME2 DEFAULT GETDATE(),
  UpdatedAt DATETIME2 NULL
);

CREATE TABLE Menus (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  CategoryId INT NOT NULL,
  Name VARCHAR(100) NOT NULL,
  Price DECIMAL(18,2) NOT NULL,
  Stock INT NOT NULL,
  Description NVARCHAR(255) NULL,
  CreatedAt DATETIME2 DEFAULT GETDATE(),
  UpdatedAt DATETIME2 NULL,

  CONSTRAINT FK_Menus_Categories FOREIGN KEY (CategoryId) 
    REFERENCES Categories(Id) ON DELETE CASCADE,
  CONSTRAINT CHK_Menu_Price CHECK (Price >= 0),
  CONSTRAINT CHK_Menu_Stock CHECK (Stock >= 0)
);

-- Pembuatan indexing
CREATE UNIQUE NONCLUSTERED INDEX IX_Categories_Name ON Categories(Name);
CREATE NONCLUSTERED INDEX IX_Menus_CategoryId ON Menus(CategoryId);
CREATE NONCLUSTERED INDEX IX_Menus_Name ON Menus(Name);

-- Insert data dummy
INSERT INTO Categories (Name, Description) VALUES 
('Food', 'Menu utama dan ayam goreng'),
('Beverage', 'Minuman dingin dan menyegarkan'),
('Dessert', 'Es krim dan makanan manis');

INSERT INTO Menus (CategoryId, Name, Price, Stock, Description) VALUES
(1, 'Original Chicken', 21800, 100, 'Ayam goreng original khas KFC'),
(1, 'Super Besar 1', 45000, 50, '1 Ayam, 1 Nasi, 1 Coca-Cola'),
(1, 'French Fries', 15000, 100, 'Kentang goreng renyah ukuran reguler'),
(2, 'Coca-Cola Medium', 10000, 200, 'Minuman soda cola ukuran sedang'),
(3, 'Soft Ice Cream', 8000, 50, 'Es krim vanilla yang lembut');