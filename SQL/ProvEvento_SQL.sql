create database ProvEvento;
use ProvEvento;

create table Usuario(
	nombreUsuario VARCHAR(50) PRIMARY KEY NOT NULL,
	password VARCHAR(50) NOT NULL,
	nombreCompleto VARCHAR(50) NOT NULL,
	tipoPerfil VARCHAR(1) NOT NULL, 	
);

SELECT * FROM Proveedor p, Usuario u WHERE p.idProveedor = u.nombreUsuario

INSERT INTO Usuario values('admin1', '202cb962ac59075b964b07152d234b70', ' Heber Gonzalez', 1);
INSERT INTO Usuario values('admin2', '202cb962ac59075b964b07152d234b70', 'Pinion Arturo Fijo', 1);
INSERT INTO Usuario values('20100510', '202cb962ac59075b964b07152d234b70', 'GauchitoDeOro', 2);
INSERT INTO Usuario values('19920505', '202cb962ac59075b964b07152d234b70', 'Brihulu', 2);

create table Proveedor(
	idProveedor VARCHAR(50) FOREIGN KEY REFERENCES Usuario,
	nombreFantasia VARCHAR(50) NOT NULL,
	email VARCHAR(50) UNIQUE NOT NULL,
	fechaIngreso Date NOT NULL,
	telefono VARCHAR(50) NOT NULL,
	VIP CHAR(1) NOT NULL,
	arancelVIP DECIMAL(9,2) NULL,
	activo CHAR(1) NOT NULL,
	FOREIGN KEY(idProveedor) REFERENCES Usuario(nombreUsuario),
	PRIMARY KEY(idProveedor)
);

INSERT INTO Proveedor VALUES('20100510','GauchitoDeOro','confielgaucho@gmail.com','19900610','0303456', 1, 10, 1);
INSERT INTO Proveedor VALUES('19920505','Brihulu','brisabel@hotmail.com','19871110','24019610', 0, 0, 1);

create table TipoEvento(
	idEvento INTEGER PRIMARY KEY,
	nombreEvento VARCHAR(50) UNIQUE NOT NULL
);

INSERT INTO TipoEvento VALUES(1, 'Nacimientos');
INSERT INTO TipoEvento VALUES(2, 'Cumpleaños');
INSERT INTO TipoEvento VALUES(3, 'Casamientos');
INSERT INTO TipoEvento VALUES(4, 'Aniversarios');
INSERT INTO TipoEvento VALUES(5, 'Fiesta de egresados');
INSERT INTO TipoEvento VALUES(6, 'Despedidas');
INSERT INTO TipoEvento VALUES(7, 'Fiesta de fin de año');
INSERT INTO TipoEvento VALUES(8, 'Dia del niños');
INSERT INTO TipoEvento VALUES(9, 'Torneos');
INSERT INTO TipoEvento VALUES(10, 'Reunion ex-alumnos');
INSERT INTO TipoEvento VALUES(11, 'Torneos juveniles');
INSERT INTO TipoEvento VALUES(12, 'Competencias');
INSERT INTO TipoEvento VALUES(13, 'Campeonatos');
INSERT INTO TipoEvento VALUES(14, 'Congresos');
INSERT INTO TipoEvento VALUES(15, 'Ferias');
INSERT INTO TipoEvento VALUES(16, 'Concursos');
INSERT INTO TipoEvento VALUES(17, 'Conciertos');

create table Servicio(
	idServicio INTEGER PRIMARY KEY,
	nombreServicio VARCHAR(50) UNIQUE NOT NULL,
	descripcion VARCHAR(50) NOT NULL
);

INSERT INTO Servicio VALUES(1,'Decoracion','Se ofrece decoraciones tematicas');
INSERT INTO Servicio VALUES(2,'Salon de fiestas','Distintas opciones de tamaño');
INSERT INTO Servicio VALUES(3,'Mobiliario','Se ofrece ');
INSERT INTO Servicio VALUES(4,'Banquetes','Comida Gorumet');
INSERT INTO Servicio VALUES(5,'Candy Bar','Carros de dulces');
INSERT INTO Servicio VALUES(6,'Cupcakes','Muffins tematicos y de varios gustos');
INSERT INTO Servicio VALUES(7,'Fuente de chocolate','Deliciosa fuente de chocolate en varios tamaños');
INSERT INTO Servicio VALUES(8,'Fuente de queso','Deliciosa fuente de queso en varios tamaños');
INSERT INTO Servicio VALUES(9,'Mesa de dulces','Se ofrece mesas decoradas de dulces');
INSERT INTO Servicio VALUES(10,'Pasteles','Distintos tipos de papeles');
INSERT INTO Servicio VALUES(11,'Inflables','Castillos inflables');
INSERT INTO Servicio VALUES(12,'Globos','Globos, globos de helio');
INSERT INTO Servicio VALUES(13,'Invitaciones','Postales, cartas, distintas formas de invitaciones');
INSERT INTO Servicio VALUES(14,'Musica en vivo','Shows en vivo con musica y artistas invitados');
INSERT INTO Servicio VALUES(15,'Magos','Espectaculo de magos');
INSERT INTO Servicio VALUES(16,'Payasos','Payasos');
INSERT INTO Servicio VALUES(17,'Menage','Utileria y manteleria');

create table ServicioTipoEvento(
	idServicio INTEGER,
	idEvento INTEGER,
	PRIMARY KEY(idServicio,idEvento),
	FOREIGN KEY(idServicio) REFERENCES Servicio(idServicio),
	FOREIGN KEY(idEvento) REFERENCES TipoEvento(idEvento),
);

INSERT INTO ServicioTipoEvento VALUES(1,1);
INSERT INTO ServicioTipoEvento VALUES(1,9);
INSERT INTO ServicioTipoEvento VALUES(1,10);
INSERT INTO ServicioTipoEvento VALUES(1,12);
INSERT INTO ServicioTipoEvento VALUES(2,1);
INSERT INTO ServicioTipoEvento VALUES(2,2);
INSERT INTO ServicioTipoEvento VALUES(2,5);
INSERT INTO ServicioTipoEvento VALUES(2,6);
INSERT INTO ServicioTipoEvento VALUES(2,7);
INSERT INTO ServicioTipoEvento VALUES(2,8);
INSERT INTO ServicioTipoEvento VALUES(2,9);
INSERT INTO ServicioTipoEvento VALUES(2,10);
INSERT INTO ServicioTipoEvento VALUES(2,11);
INSERT INTO ServicioTipoEvento VALUES(2,12);
INSERT INTO ServicioTipoEvento VALUES(2,13);
INSERT INTO ServicioTipoEvento VALUES(2,14);
INSERT INTO ServicioTipoEvento VALUES(2,15);
INSERT INTO ServicioTipoEvento VALUES(2,16);
INSERT INTO ServicioTipoEvento VALUES(2,17);
INSERT INTO ServicioTipoEvento VALUES(3,1);
INSERT INTO ServicioTipoEvento VALUES(3,2);
INSERT INTO ServicioTipoEvento VALUES(3,3);
INSERT INTO ServicioTipoEvento VALUES(3,4);
INSERT INTO ServicioTipoEvento VALUES(3,7);
INSERT INTO ServicioTipoEvento VALUES(3,8);
INSERT INTO ServicioTipoEvento VALUES(3,9);
INSERT INTO ServicioTipoEvento VALUES(3,10);
INSERT INTO ServicioTipoEvento VALUES(3,11);
INSERT INTO ServicioTipoEvento VALUES(3,12);
INSERT INTO ServicioTipoEvento VALUES(3,13);
INSERT INTO ServicioTipoEvento VALUES(3,14);
INSERT INTO ServicioTipoEvento VALUES(4,2);
INSERT INTO ServicioTipoEvento VALUES(4,4);
INSERT INTO ServicioTipoEvento VALUES(4,17);
INSERT INTO ServicioTipoEvento VALUES(5,13);
INSERT INTO ServicioTipoEvento VALUES(5,14);
INSERT INTO ServicioTipoEvento VALUES(6,14);
INSERT INTO ServicioTipoEvento VALUES(7,1);
INSERT INTO ServicioTipoEvento VALUES(7,2);
INSERT INTO ServicioTipoEvento VALUES(7,3);
INSERT INTO ServicioTipoEvento VALUES(7,4);
INSERT INTO ServicioTipoEvento VALUES(8,10);
INSERT INTO ServicioTipoEvento VALUES(8,11);
INSERT INTO ServicioTipoEvento VALUES(8,12);
INSERT INTO ServicioTipoEvento VALUES(8,13);
INSERT INTO ServicioTipoEvento VALUES(9,13);
INSERT INTO ServicioTipoEvento VALUES(9,14);
INSERT INTO ServicioTipoEvento VALUES(10,12);
INSERT INTO ServicioTipoEvento VALUES(10,13);
INSERT INTO ServicioTipoEvento VALUES(10,14);
INSERT INTO ServicioTipoEvento VALUES(11,13);
INSERT INTO ServicioTipoEvento VALUES(11,14);
INSERT INTO ServicioTipoEvento VALUES(12,13);
INSERT INTO ServicioTipoEvento VALUES(12,14);
INSERT INTO ServicioTipoEvento VALUES(13,13);
INSERT INTO ServicioTipoEvento VALUES(13,14);



create table Proveedor_Servicios(
	idProveedor VARCHAR(50) NOT NULL,
	idServicio INTEGER,
	foto VARCHAR(255) UNIQUE NOT NULL,
	descripcion VARCHAR(100) NOT NULL,
	activo CHAR(1) NOT NULL,
	FOREIGN KEY(idProveedor) REFERENCES Proveedor(idProveedor),
	FOREIGN KEY(idServicio) REFERENCES Servicio(idServicio),
	PRIMARY KEY(idProveedor,idServicio)
);



create table ArancelAnualProveedor(
	id INTEGER PRIMARY KEY,
	arancel INTEGER NOT NULL
);

INSERT INTO ArancelAnualProveedor VALUES(1,350);
