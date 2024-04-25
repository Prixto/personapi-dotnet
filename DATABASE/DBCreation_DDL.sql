CREATE DATABASE persona_db;
GO

USE persona_db;
GO

CREATE TABLE profesion (
    id INT PRIMARY KEY,
    nom VARCHAR(90) NOT NULL,
    des TEXT
);

CREATE TABLE persona (
    cc INT PRIMARY KEY,
    nombre VARCHAR(45) NOT NULL,
    apellido VARCHAR(45) NOT NULL,
    genero CHAR(1) CHECK (genero IN ('M', 'F'))NOT NULL,
    edad INT NOT NULL
);

CREATE TABLE estudios (
    id_prof INT NOT NULL,
    cc_per INT NOT NULL,
    fecha DATE NOT NULL,
    univer VARCHAR(50) NOT NULL,
	CONSTRAINT estudio_persona_fk PRIMARY KEY (id_prof, cc_per),
    --PRIMARY KEY (id_prof, cc_per),
    FOREIGN KEY (id_prof) REFERENCES profesion(id),
    FOREIGN KEY (cc_per) REFERENCES persona(cc),
    --CONSTRAINT estudio_persona_fk FOREIGN KEY (id_prof, cc_per) REFERENCES estudios(id_prof, cc_per)
);
CREATE TABLE telefono (
  num VARCHAR(15) PRIMARY KEY,
  oper VARCHAR(45) NOT NULL,
  duenio INT,
  FOREIGN KEY (duenio) REFERENCES persona(cc)
);