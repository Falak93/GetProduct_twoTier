﻿Create Database GetProd
Go

Use GetProd
Go

Create Table Gproducts
(
	ProductID int PRIMARY KEY IDENTITY(1,1),
	ProductName nvarchar(50),
	Design nvarchar(50),
	Color nvarchar(50),
)
Go