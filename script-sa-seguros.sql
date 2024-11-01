CREATE DATABASE saseguros;

USE saseguros;

CREATE TABLE IF NOT EXISTS cliente(
    dni INT NOT NULL UNIQUE PRIMARY KEY,
    nombreCompleto VARCHAR(100) NOT NULL,
    edad INT NOT NULL,
    genero ENUM('femenino', 'masculino', 'otro') NOT NULL,
    estado BOOLEAN NOT NULL,
    estadoCivil BOOLEAN NOT NULL,
    maneja BOOLEAN NOT NULL,
    lentes BOOLEAN NOT NULL,
    diabetes BOOLEAN NOT NULL,
    otraEnfermedad VARCHAR(100)
);