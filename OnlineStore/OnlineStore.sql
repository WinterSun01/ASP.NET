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
(N'������� Lenovo IdeaPad 3'),
(N'�������� Samsung Galaxy A52'),
(N'�������� Sony WH-1000XM4'),
(N'������� LG UltraFine 4K'),
(N'���������� Logitech MX Keys'),
(N'���� Logitech MX Master 3S'),
(N'������� Apple iPad Air'),
(N'����� ���� Xiaomi Mi Band 7'),
(N'������� HP LaserJet Pro'),
(N'���-������ Logitech C920');
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
(1, N'���������', N'�������� �������, �������� ������ � ����.'),
(2, N'�����', N'�������� ����� � ������� ������.'),
(3, N'������', N'���� �� ������, �������������� ��������.'),
(4, N'����', N'������� ������, �� ���� ��������.'),
(5, N'���������', N'������� ����������, �������� �������.');
GO
