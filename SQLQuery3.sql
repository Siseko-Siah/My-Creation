
CREATE TABLE CarMakes (
    MakeID INT PRIMARY KEY,
    MakeName VARCHAR(255) NOT NULL,
    CountryOfOrigin VARCHAR(255),
    YearFounded INT,
    Website VARCHAR(255)
);


CREATE TABLE CarModels (
    ModelID INT PRIMARY KEY,
    MakeID INT,
    ModelName VARCHAR(255) NOT NULL,
    Year INT,
    Price DECIMAL(10, 2),
    FuelType VARCHAR(255),
    EngineType VARCHAR(255),
    Transmission VARCHAR(255),
    SeatingCapacity INT,
    Horsepower INT,
    FuelEfficiency VARCHAR(20),
    Description TEXT,
    FOREIGN KEY (MakeID) REFERENCES CarMakes(MakeID)
);

-- Create Vehicle table
CREATE TABLE Vehicle (
    VehicleID INT PRIMARY KEY,
    MakeID INT,
    ModelID INT,
    AverageSpeed DECIMAL(5, 2),
    FuelType VARCHAR(255),
    Year INT,
    Description TEXT,
    FOREIGN KEY (MakeID) REFERENCES CarMakes(MakeID),
    FOREIGN KEY (ModelID) REFERENCES CarModels(ModelID)
);

-- Create Car table (derived from Vehicle)
CREATE TABLE Car (
    VehicleID INT PRIMARY KEY,
    BodyType VARCHAR(255),
    EngineType VARCHAR(255),
    NumDoors INT,
    FOREIGN KEY (VehicleID) REFERENCES Vehicle(VehicleID)
);

-- Create Truck table (derived from Vehicle)
CREATE TABLE Truck (
    VehicleID INT PRIMARY KEY,
    CargoCapacity DECIMAL(10, 2),
    TruckType VARCHAR(255),
    FOREIGN KEY (VehicleID) REFERENCES Vehicle(VehicleID)
);

-- Insert sample data into CarMakes and CarModels (for Foreign Key reference)
INSERT INTO CarMakes (MakeID, MakeName, CountryOfOrigin, YearFounded, Website)
VALUES (1, 'Toyota', 'Japan', 1937, 'https://www.toyota.com');

INSERT INTO CarModels (ModelID, MakeID, ModelName, Year, Price, FuelType, EngineType, Transmission, SeatingCapacity, Horsepower, FuelEfficiency, Description)
VALUES (1, 1, 'Camry', 2023, 25000.00, 'Gasoline', 'V6', 'Automatic', 5, 268, '30 MPG', 'Midsize sedan');

-- Insert sample data into Vehicle, Car, and Truck tables
INSERT INTO Vehicle (VehicleID, MakeID, ModelID, AverageSpeed, FuelType, Year, Description)
VALUES (1, 1, 1, 65.5, 'Gasoline', 2023, 'A reliable family car.');

INSERT INTO Car (VehicleID, BodyType, EngineType, NumDoors)
VALUES (1, 'Sedan', 'V6', 4);

INSERT INTO Truck (VehicleID, CargoCapacity, TruckType)
VALUES (1, 1500.00, 'Pickup');
