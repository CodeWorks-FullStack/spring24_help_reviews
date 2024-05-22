-- Active: 1715633441965@@127.0.0.1@3306@adaptable_shaman_540684_db
CREATE TABLE
  IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
  ) default charset utf8mb4 COMMENT '';

CREATE TABLE
  restaurants (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    name VARCHAR(255) NOT NULL,
    imgUrl VARCHAR(1000) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    visits INT NOT NULL,
    isShutdown BOOLEAN NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
  );