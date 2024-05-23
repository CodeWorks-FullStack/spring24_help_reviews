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
    visits INT NOT NULL DEFAULT 0,
    isShutdown BOOLEAN NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
  );

DROP TABLE restaurants;

CREATE TABLE
  reports (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    title VARCHAR(255) NOT NULL,
    body VARCHAR(1000) NOT NULL,
    imgUrl VARCHAR(1000),
    restaurantId INT NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (restaurantId) REFERENCES restaurants (id) ON DELETE CASCADE,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
  );

SELECT
  restaurants.*,
  COUNT(reports.id) AS reportCount
FROM
  restaurants
  LEFT JOIN reports ON reports.restaurantId = restaurants.id
GROUP BY
  (restaurants.id);