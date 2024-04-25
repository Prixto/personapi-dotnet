-- Archivo: test_data.sql

USE persona_db;
GO


INSERT INTO profesion (id, nom, des) VALUES
(1, 'Ingeniero de Software', 'Desarrolla y mantiene aplicaciones de software'),
(2, 'Médico', 'Diagnostica y trata enfermedades'),
(3, 'Abogado', 'Proporciona asesoramiento legal'),
(4, 'Profesor', 'Enseña e imparte conocimientos');

INSERT INTO persona (cc, nombre, apellido, genero, edad) VALUES
(1234567890, 'Juan', 'Pérez', 'M', 35),
(9876543210, 'María', 'Gómez', 'F', 28),
(5555555555, 'Carlos', 'López', 'M', 42),
(1111111111, 'Ana', 'Rodríguez', 'F', 25);


INSERT INTO estudios (id_prof, cc_per, fecha, univer) VALUES
(1, 1234567890, '2010-06-15', 'Universidad Nacional'),
(2, 9876543210, '2015-08-20', 'Universidad de los Andes'),
(3, 5555555555, '2005-01-10', 'Universidad Javeriana'),
(4, 1111111111, '2018-09-01', 'Universidad del Rosario');


INSERT INTO telefono (num, oper, duenio) VALUES
('3001234567', 'Operador A', 1234567890),
('3165789012', 'Operador B', 9876543210),
('3207654321', 'Operador C', 5555555555),
('3189876543', 'Operador D', 1111111111);