CREATE DATABASE GPSWORLD
USE GPSWORLD

CREATE TABLE CLIENTES (
ID_CLIENTES INT PRIMARY KEY,
ID_VENTAS INT,
NIT INT,
TIPO_CLIENTE VARCHAR (50),
NOMBRE VARCHAR(30),
CIUDAD VARCHAR(20),
DIRECCION VARCHAR(50),
TELEFONO INT
)

INSERT INTO CLIENTES VALUES (1,1,1000012,'PERSONA NATURAL','CARLOS','BOGOTA','TR 2 #32 I 35',5254213)
INSERT INTO CLIENTES VALUES (2,2,1000623,'PERSONA NATURAL','MARIA','MEDELLIN','CR 7 #39 T 12',34564213)
INSERT INTO CLIENTES VALUES (3,3,1102364,'PERSONA NATURAL','JOSE','BOGOTA','CLL 5 #02 A 32',5254213)

CREATE TABLE VENTAS (
ID_VENTAS INT PRIMARY KEY,
ID_CLIENTES INT,
ID_ALMACEN INT,
ID_TIEMPO INT,
ID_GPS INT,
TIPO_VENTAS VARCHAR(50),
CODIGO_VENTA INT,
UNIDAD_VENTA INT,
ID_HISTORIAL INT
)


INSERT INTO VENTAS VALUES (1,1,1,1,1,'MAYOR',000001,30,1)
INSERT INTO VENTAS VALUES (2,2,2,2,2,'MENOR',000002,05,2)
INSERT INTO VENTAS VALUES (3,3,3,3,3,'MAYOR',000003,50,3)



CREATE TABLE TIEMPO_VENTA(
ID_TIEMPO INT PRIMARY KEY,
ID_VENTAS INT,
DIA NUMERIC (2),
MES NUMERIC (2),
AÑO NUMERIC (4)
)

INSERT INTO TIEMPO_VENTA VALUES (1,1,05,05,2020)
INSERT INTO TIEMPO_VENTA VALUES (2,2,06,05,2020)
INSERT INTO TIEMPO_VENTA VALUES (3,3,07,05,2020)



CREATE TABLE GPS(
ID_GPS INT PRIMARY KEY,
ID_VENTAS INT,
NOMBRE VARCHAR(30),
PRECIO INT,
TIPO VARCHAR (50)
)



INSERT INTO GPS VALUES (1,1,'GPS34AG',100.000,'HIBRIDO')
INSERT INTO GPS VALUES (2,2,'GPS36AG',200.000,'HIBRIDO ESPECIAL')
INSERT INTO GPS VALUES (3,3,'GPS342AG',100.000,'HIBRIDO')


CREATE TABLE BODEGA(
ID_BODEGA INT PRIMARY KEY,
ID_ALMACEN INT,
TIPO_BODEGA VARCHAR(30),
NOMBRE VARCHAR(30),
DIRECCION VARCHAR(30),
CIUDAD VARCHAR(30),
TELEFONO INT
)


INSERT INTO BODEGA VALUES (1,1,'COMPUESTOS','CALLE34','CALLE 34 DIG 31','BOGOTA',234566)
INSERT INTO BODEGA VALUES (2,2,'REPUESTOS','AV 1 MAYO','AV 1 DE MAYO #56-42','BOGOTA',234466)
INSERT INTO BODEGA VALUES (3,3,'COMPUESTOS','ESTATAL','CALLE 80 #67-32','BOGOTA',231566)


CREATE TABLE ALMACEN (
ID_ALMACEN INT PRIMARY KEY,
ID_BODEGA INT,
ID_VENTAS INT,
ID_EMPLEADO INT,
NOMBRE VARCHAR(30),
CIUDAD VARCHAR(30),
TELEFONO INT,
DIRECCION VARCHAR (30)
)

INSERT INTO ALMACEN VALUES (1,1,1,1,'TRIBUTARIO','BOGOTA',23456782,'CHAPINERO ALTO #53-45')
INSERT INTO ALMACEN VALUES (2,2,2,2,'EXTRAORDINARIO','BOGOTA',23454562,'CALLE CARRETAS #45-45')
INSERT INTO ALMACEN VALUES (3,3,3,3,'REPUESTOS','CALI',23056782,'PRIMAVERA 1D 45')


CREATE TABLE EMPLEADOS(
ID_EMPLEADO INT PRIMARY KEY,
ID_ALMACEN INT,
NOMBRE VARCHAR(30),
CEDULA INT,
DIRECCION VARCHAR(30),
TELEFONO INT,
SALARIO INT
)

INSERT INTO EMPLEADOS VALUES (1,1,'MARINO',1234564,'CALLE 26 #34',34567451,900.000)
INSERT INTO EMPLEADOS VALUES (2,2,'MARIANA',12334564,'CALLE 34 #31',34535451,900.000)
INSERT INTO EMPLEADOS VALUES (3,3,'MARIANO',123355164,'CALLE INGLES #13',34507451,900.000)


CREATE TABLE HISTORIAL (
ID_HISTORIAL INT PRIMARY KEY,
ID_VENTAS INT,
FECHA DATE,
USUARIO VARCHAR (30),
OBSERVACION VARCHAR (30),
CODIGO_VENTA INT
)


INSERT INTO HISTORIAL VALUES (1,1, GETDATE(),SYSTEM_USER,'REGISTRO INSERTADO',000001)
INSERT INTO HISTORIAL VALUES (2,2, GETDATE(),SYSTEM_USER,'REGISTRO INSERTADO',000002)
INSERT INTO HISTORIAL VALUES (3,3, GETDATE(),SYSTEM_USER,'REGISTRO INSERTADO',000003)



ALTER TABLE VENTAS ADD CONSTRAINT FK_VENTAS_CLIENTES
FOREIGN KEY (ID_CLIENTES) REFERENCES CLIENTES (ID_CLIENTES)

ALTER TABLE VENTAS ADD CONSTRAINT FK_VENTAS_TIEMPOVENTA
FOREIGN KEY (ID_TIEMPO) REFERENCES TIEMPO_VENTA (ID_TIEMPO)

ALTER TABLE VENTAS ADD CONSTRAINT FK_VENTAS_GPS
FOREIGN KEY (ID_GPS) REFERENCES GPS (ID_GPS)

ALTER TABLE VENTAS ADD CONSTRAINT FK_VENTAS_ALMACEN
FOREIGN KEY (ID_ALMACEN) REFERENCES ALMACEN (ID_ALMACEN)

ALTER TABLE ALMACEN ADD CONSTRAINT FK_ALMACEN_BODEGA
FOREIGN KEY (ID_BODEGA) REFERENCES BODEGA (ID_BODEGA)

ALTER TABLE ALMACEN ADD CONSTRAINT FK_ALMACEN_EMPLEADO
FOREIGN KEY (ID_EMPLEADO) REFERENCES EMPLEADOS (ID_EMPLEADO)

ALTER TABLE VENTAS ADD CONSTRAINT FK_HISTORIAL_VENTAS
FOREIGN KEY (ID_HISTORIAL) REFERENCES HISTORIAL (ID_HISTORIAL)

--- TRIGGERS VENTAS ---
--- REGISTRAR ---
GO
CREATE TRIGGER IV
ON VENTAS FOR INSERT
AS
SET NOCOUNT ON
DECLARE @CODIGO_VENTA INT
SELECT @CODIGO_VENTA = CODIGO_VENTA FROM inserted
INSERT INTO HISTORIAL VALUES (1, 1,GETDATE(), SYSTEM_USER, 'Registro insertado', @CODIGO_VENTA) 
GO

--- ELIMINAR ---
GO
CREATE TRIGGER EV
ON VENTAS FOR DELETE
AS
SET NOCOUNT ON
DECLARE @CODIGO_VENTA INT
SELECT @CODIGO_VENTA = CODIGO_VENTA FROM deleted
INSERT INTO HISTORIAL VALUES (1, 1,GETDATE(), SYSTEM_USER, 'Registro eliminado', @CODIGO_VENTA) 
GO

--- ACTUALIZAR ---
GO
CREATE TRIGGER AV
ON VENTAS FOR UPDATE
AS
SET NOCOUNT ON
DECLARE @CODIGO_VENTA INT
SELECT @CODIGO_VENTA = CODIGO_VENTA FROM inserted
INSERT INTO HISTORIAL VALUES (1, 1,GETDATE(), SYSTEM_USER, 'Registro actualizado', @CODIGO_VENTA) 
GO


SELECT * FROM VENTAS
SELECT * FROM HISTORIAL

--- PROCESOS ALMACENADOS ---

GO
CREATE PROCEDURE CONSULTARC
AS
SELECT * FROM CLIENTES

GO 
CREATE PROCEDURE INSERTARV
@ID_VENTAS INT,
@ID_CLIENTES INT,
@ID_ALMACEN INT,
@ID_TIEMPO INT,
@ID_GPS INT,
@TIPO_VENTAS VARCHAR(50),
@CODIGO_VENTA INT,
@UNIDAD_VENTA INT,
@ID_HISTORIAL INT
AS
INSERT INTO VENTAS VALUES (@ID_VENTAS, @ID_CLIENTES, @ID_ALMACEN, @ID_TIEMPO, @ID_GPS, @TIPO_VENTAS, @CODIGO_VENTA, @UNIDAD_VENTA, @ID_HISTORIAL)

GO
CREATE PROCEDURE ELIMINARE (
@ID_EMPLEADO INT,
@ID_ALMACEN INT,
@NOMBRE VARCHAR(30),
@CEDULA INT,
@DIRECCION VARCHAR(30),
@TELEFONO INT,
@SALARIO INT
)
AS 
DELETE FROM EMPLEADOS WHERE @ID_EMPLEADO = ID_EMPLEADO AND @ID_ALMACEN = ID_ALMACEN AND @NOMBRE = NOMBRE AND @CEDULA = CEDULA AND @DIRECCION = DIRECCION
AND @TELEFONO = TELEFONO AND @SALARIO = SALARIO

GO
CREATE PROCEDURE ACTUALIZARG (
@ID_GPS INT,
@ID_VENTAS INT,
@NOMBRE VARCHAR(30),
@PRECIO INT,
@TIPO VARCHAR (50)
)
AS
UPDATE GPS SET @ID_VENTAS = ID_VENTAS, @NOMBRE = NOMBRE, @PRECIO= PRECIO, @TIPO = TIPO WHERE @ID_GPS = ID_GPS

--- VISTAS ---

GO
CREATE VIEW ABC WITH ENCRYPTION 
AS
SELECT * FROM CLIENTES

GO 
CREATE VIEW DEF WITH ENCRYPTION 
AS
SELECT * FROM VENTAS WHERE UNIDAD_VENTA > 50

GO
CREATE VIEW GHI WITH ENCRYPTION 
AS
SELECT DIA, MES, AÑO FROM TIEMPO_VENTA

GO 
CREATE VIEW JKL WITH ENCRYPTION
AS
SELECT * FROM GPS WHERE PRECIO <> 50000

GO 
CREATE VIEW MNO WITH ENCRYPTION 
AS
SELECT DIRECCION, TELEFONO FROM BODEGA WHERE CIUDAD = 'BOGOTA'

GO
CREATE VIEW PQR WITH ENCRYPTION 
AS
SELECT CIUDAD, TELEFONO, DIRECCION FROM ALMACEN WHERE NOMBRE = 'A%'

GO 
CREATE VIEW STU WITH ENCRYPTION 
AS
SELECT * FROM EMPLEADOS WHERE SALARIO > 950000


--CREACION DE TABLA TB_CNTCINFO (LOGIN)--
CREATE TABLE TB_CLIENT
(
  ID_TBCLIENT int IDENTITY(1,1) PRIMARY KEY,
  NAME_CLIENT VARCHAR(100) NULL,
  USER_WEB VARCHAR(15) NULL,
  PWD_WEB VARCHAR(15) NULL
);

--CREACION TABLA DE LOGIN
CREATE TABLE TB_LOGWEBSYS (
  ID_TBLGWBSYS int IDENTITY(1,1) PRIMARY KEY,
  TB_CNTCINFO_ID_TBCNTCINFO INT NOT NULL,
  SYSTEM_MODULE VARCHAR(150) NULL,
  EVENT_USER VARCHAR(50) NULL,
  STATUS VARCHAR(20) NULL,
  DATE_OPERATION DATE NULL,
  TIME_LOG TIME NULL,
  MSG_OPERATION VARCHAR(200) NULL);

--Insercion de registro en tabla de login (Modificado) 
INSERT INTO TB_CLIENT (USER_WEB,PWD_WEB, NAME_CLIENT) VALUES ('Admin','123','Marin');

--Sentencia para crear procedimiento almacenado Login (Modificado)
CREATE PROCEDURE SP_inicio_Sesion
@USER VARCHAR (20),
@PASS VARCHAR (20)
AS
SELECT USER_WEB,'true' FROM TB_CLIENT WHERE USER_WEB=@USER AND PWD_WEB=@PASS
GO 

--Sentencia para ingresar en log de login
CREATE PROCEDURE SP_acceder
@ID_USER INT,
@FECHA DATE
AS
INSERT INTO TB_LOGWEBSYS (TB_CNTCINFO_ID_TBCNTCINFO,DATE_OPERATION) VALUES (@ID_USER,@FECHA);
GO 

--Sentencia para traer Cliente
CREATE PROCEDURE SP_cliente
@USER VARCHAR (20)
AS
SELECT NAME_CLIENT FROM TB_CLIENT WHERE USER_WEB=@USER
GO 

--Vista
  CREATE PROCEDURE SP_consulta
AS
  SELECT NIT, TIPO_CLIENTE, CLIENTES.NOMBRE AS NOMBRE_CLIENTE, CLIENTES.CIUDAD AS CIUDAD_CLIENTE, CLIENTES.DIRECCION AS DIRECCION_CLIENTE, CLIENTES.TELEFONO AS TELEFONO_CLIENTE, ALMACEN.NOMBRE AS NOMBRE_ALMACEN, ALMACEN.CIUDAD AS CIUDAD_ALMACEN, GPS.NOMBRE AS NOMBRE_GPS,  GPS.PRECIO AS PRECIO_GPS, GPS.TIPO AS TIPO_GPS FROM VENTAS
  INNER JOIN CLIENTES ON CLIENTES.ID_CLIENTES = VENTAS.ID_CLIENTES
  INNER JOIN ALMACEN ON ALMACEN.ID_ALMACEN = VENTAS.ID_ALMACEN
  INNER JOIN GPS ON GPS.ID_GPS = VENTAS.ID_GPS
GO 
