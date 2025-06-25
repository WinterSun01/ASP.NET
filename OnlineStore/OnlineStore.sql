USE OnlineStoreDb;
GO

DROP TABLE IF EXISTS Reviews;
GO

DROP TABLE IF EXISTS Products;
GO

CREATE TABLE Products 
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);
GO

INSERT INTO Products (Name) VALUES 
(N'Ноутбук Lenovo IdeaPad 3'),
(N'Смартфон Samsung Galaxy A52'),
(N'Наушники Sony WH-1000XM4'),
(N'Монитор LG UltraFine 4K'),
(N'Клавиатура Logitech MX Keys'),
(N'Мышь Logitech MX Master 3S'),
(N'Планшет Apple iPad Air'),
(N'Умные часы Xiaomi Mi Band 7'),
(N'Принтер HP LaserJet Pro'),
(N'Веб-камера Logitech C920');
GO

CREATE TABLE Reviews
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductId INT NOT NULL,
    Author NVARCHAR(100) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    CONSTRAINT FK_Reviews_Products FOREIGN KEY (ProductId) REFERENCES Products(Id)
);
GO

INSERT INTO Reviews (ProductId, Author, Content) VALUES
(1, N'Анастасия', N'Отличный ноутбук, работает быстро и тихо.'),
(2, N'Мария', N'Приятный экран и хорошая камера.'),
(3, N'Михаил', N'Звук на высоте, шумоподавление отличное.'),
(4, N'Иван', N'Монитор чёткий, но цена кусается.'),
(5, N'Екатерина', N'Удобная клавиатура, печатать приятно.');
GO
