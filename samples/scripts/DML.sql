use [ExemploProduto]
go

-- load categoria table
INSERT INTO Categoria (Descricao) VALUES ('Aves')
INSERT INTO Categoria (Descricao) VALUES ('Mamiferos')
INSERT INTO Categoria (Descricao) VALUES ('Repteis')
INSERT INTO Categoria (Descricao) VALUES ('Chocolate')
INSERT INTO Categoria (Descricao) VALUES ('Vegetal')
INSERT INTO Categoria (Descricao) VALUES ('Mineral')
INSERT INTO Categoria (Descricao) VALUES ('Calcado')

-- load fornecedor table
INSERT INTO Fornecedor (Nome, Telefone, DataCadastro) VALUES ('Astrogildo','1111-2222','20100101')
INSERT INTO Fornecedor (Nome, Telefone, DataCadastro) VALUES ('Beutrano','4444-5454','20100101')

-- load min produto
INSERT INTO Produto (Nome, Descricao, IdCategoria, IdFornecedor) VALUES ('Tenis Kichute','O Tenis mais estranho ja fabricado',1,1)
INSERT INTO Produto (Nome, Descricao, IdCategoria, IdFornecedor) VALUES ('Canario Belga','',1,1)
INSERT INTO Produto (Nome, Descricao, IdCategoria, IdFornecedor) VALUES ('Caixa Bombom','',1,1)
INSERT INTO Produto (Nome, Descricao, IdCategoria, IdFornecedor) VALUES ('Lagarto','',1,1)
INSERT INTO Produto (Nome, Descricao, IdCategoria, IdFornecedor) VALUES ('Crocodilo','',1,1)
INSERT INTO Produto (Nome, Descricao, IdCategoria, IdFornecedor) VALUES ('Tenis Conga','',1,1)
INSERT INTO Produto (Nome, Descricao, IdCategoria, IdFornecedor) VALUES ('Teste','',1,1)
INSERT INTO Produto (Nome, Descricao, IdCategoria, IdFornecedor) VALUES ('Outro','Outro',1,1)
