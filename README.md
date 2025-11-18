# CRUD Básico em MongoDB com C# – Console Application

Este projeto foi desenvolvido como parte de um exercício prático para reforçar os conhecimentos sobre operações CRUD (Create, Read, Update, Delete) utilizando **MongoDB** e **C#** em uma aplicação do tipo **Console Application**.

O objetivo é praticar integração com banco NoSQL, modelagem simples de dados e manipulação de duas collections relacionadas: **Authors** e **Books**.

---

## 📚 Objetivo do Exercício

- Consolidar o uso das operações CRUD no MongoDB.
- Manipular duas collections relacionadas (autores e livros).
- Trabalhar com consultas que envolvem referência entre documentos.
- Utilizar métodos assíncronos com o **MongoDB C# Driver**.
- Criar uma aplicação funcional em **.NET Console**.

---

## 🏗️ Contexto da Aplicação

A aplicação simula o gerenciamento básico de uma pequena biblioteca, onde é possível:

- Cadastrar autores  
- Cadastrar livros associados a autores  
- Exibir todos os autores  
- Exibir todos os livros junto com o nome do autor (simulação de join)  
- Atualizar autores  
- Excluir autores e livros  

As collections utilizadas são:

- **Authors**
- **Books**

---

## 🧱 Estrutura das Collections

### **Authors**

| Campo  | Tipo      | Descrição                           |
|--------|-----------|-------------------------------------|
| Id     | ObjectId  | Gerado automaticamente              |
| Name   | string    | Nome do autor                       |
| Country| string    | País de origem                      |

---

### **Books**

| Campo    | Tipo      | Descrição                                      |
|----------|-----------|------------------------------------------------|
| Id       | ObjectId  | Gerado automaticamente                         |
| Title    | string    | Título do livro                                |
| AuthorId | string    | Id do autor (referência à collection Authors)  |
| Year     | int       | Ano de publicação                              |

---

## ⚙️ Operações CRUD Implementadas

### ✔️ Create
- Inserir pelo menos um autor.  
- Inserir pelo menos um livro relacionado a um autor.

### 🔍 Read
- Listar todos os autores.  
- Listar todos os livros.

### ✏️ Update
- Atualizar dados de um autor (ex.: alterar o país).
- Atualizar dados de um livro (ex.: alterar o autor).

### 🗑️ Delete
- Remover um livro.  
- Remover um autor.

---

## 🖥️ Console Application

A aplicação foi desenvolvida em .NET e executa diretamente no terminal, exibindo mensagens informativas sobre cada operação realizada.  
Todas as operações com banco são assíncronas.

---

## 🐳 Executando o MongoDB com Docker

Para iniciar rapidamente um container MongoDB para a aplicação, utilize o comando:

```bash
docker run -d --name LibraryWithMongoDB \
  -e MONGO_INITDB_ROOT_USERNAME=libraryadmin \
  -e MONGO_INITDB_ROOT_PASSWORD=library123 \
  -p 27017:27017 \
  mongo
