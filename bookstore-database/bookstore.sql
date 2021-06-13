CREATE DATABASE bookstore;
USE bookstore;

CREATE TABLE authors (
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    author varchar(50) NOT NULL UNIQUE,
);

CREATE TABLE publishers (
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    publisher varchar(50) NOT NULL UNIQUE,
);

CREATE TABLE languages (
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    language varchar(50) NOT NULL UNIQUE,
);

CREATE TABLE books (
    id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    title varchar(100),
    published_date DATE,
    comments varchar(500),
    plot varchar(8000),
	author_id int,
	publisher_id int,
	language_id int,
	FOREIGN KEY(author_id) REFERENCES authors(id),
	FOREIGN KEY(publisher_id) REFERENCES publishers(id),
	FOREIGN KEY(language_id) REFERENCES languages(id)
);

CREATE TABLE genres (
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    genre varchar(20) NOT NULL UNIQUE,
);

CREATE TABLE books_genres(
    book_id int,
    genre_id int,
    FOREIGN KEY(book_id) REFERENCES books(id),
    FOREIGN KEY(genre_id) REFERENCES genres(id),
	CONSTRAINT movie_id PRIMARY KEY (book_id, genre_id)
);