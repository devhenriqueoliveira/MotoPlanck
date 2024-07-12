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

-- Create Deliveryman table
CREATE TABLE IF NOT EXISTS Deliverymans (
    Id UUID PRIMARY KEY,
    Cnpj VARCHAR(14) NOT NULL,
    Cnh VARCHAR(12) NOT NULL,
	TypeCnh VARCHAR(2) NOT NULL,
	PictureCnhId VARCHAR(400) NOT NULL,
	UserId UUID NOT NULL
);

-- Create Plan table
CREATE TABLE IF NOT EXISTS Plans (
    Id UUID PRIMARY KEY,
    Day SMALLINT NOT NULL,
    Amount REAL NOT NULL,
	RatePercentage SMALLINT NOT NULL
);

-- Create Rent table
CREATE TABLE IF NOT EXISTS Rentals (
    Id UUID PRIMARY KEY,
    InitialDate DATE NOT NULL,
	FinalDate DATE NOT NULL,
	ForecastDate DATE NOT NULL,
    MotorcycleId UUID NOT NULL,
	DeliverymanId UUID NOT NULL,
	PlanId UUID NOT NULL
);

-- Print success message
DO $$ BEGIN RAISE NOTICE 'Tables created successfully'; END $$;