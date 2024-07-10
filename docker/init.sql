-- Create Motorcycle table
CREATE TABLE IF NOT EXISTS Motorcycles (
    Id UUID PRIMARY KEY,
    Year SMALLINT NOT NULL,
    Plate VARCHAR(20) NOT NULL,
    Model VARCHAR(100) NOT NULL
);

-- Create User table
CREATE TABLE IF NOT EXISTS Users (
    Id UUID PRIMARY KEY,
    FirstName VARCHAR(30) NOT NULL,
    LastName VARCHAR(30) NOT NULL,
    Login VARCHAR(16) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    BirthDate DATE NOT NULL,
    RoleId UUID NOT NULL
);

-- Create Role table
CREATE TABLE IF NOT EXISTS Roles (
    Id UUID PRIMARY KEY,
    Name VARCHAR(30) NOT NULL,
    Description VARCHAR(200) NOT NULL,
	Active BOOLEAN NOT NULL
);

-- Print success message
DO $$ BEGIN RAISE NOTICE 'Tables created successfully'; END $$;