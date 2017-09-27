create database ProvEvento;
use ProvEvento;

create table Usuario(
	idUsuario INTEGER IDENTITY(1,1) PRIMARY KEY,
	nombreCompleto VARCHAR(50) NOT NULL,
	nombreUsuario VARCHAR(50) UNIQUE NOT NULL,
	contrasenia VARCHAR(50) NOT NULL,
	tipoPerfil CHAR(1) NOT NULL, 	
);

INSERT INTO Usuario values('Grillo Saltarin', 'gp', '123', 1);
INSERT INTO Usuario values('Pepe Trueno', '123', 'pt', 2);

create table Proveedor(
	idProveedor INTEGER PRIMARY KEY REFERENCES Usuario,
	fechaIngreso Date NOT NULL,
	VIP CHAR(1) NOT NULL,
	arancelVIP DECIMAL(9,2) NULL,
	activo CHAR(1) NOT NULL,
);

INSERT INTO Proveedor VALUES(1, '20100510', 1, 10, 1);
INSERT INTO Proveedor VALUES(2, '19920505', 1, 25, 1);

create table Servicio(
	idServicio INTEGER PRIMARY KEY,
	nombreServicio VARCHAR(50) UNIQUE NOT NULL
);

INSERT INTO Servicio VALUES(1, 'Nacimientos');
INSERT INTO Servicio VALUES(2, 'Cumpleaños');
INSERT INTO Servicio VALUES(3, 'Casamientos');
INSERT INTO Servicio VALUES(4, 'Aniversarios');
INSERT INTO Servicio VALUES(5, 'Fiesta de egresados');
INSERT INTO Servicio VALUES(6, 'Despedidas');
INSERT INTO Servicio VALUES(7, 'Fiesta de fin de año');
INSERT INTO Servicio VALUES(8, 'Dia del niños');
INSERT INTO Servicio VALUES(9, 'Torneos');
INSERT INTO Servicio VALUES(10, 'Reunion ex-alumnos');
INSERT INTO Servicio VALUES(11, 'Torneos');
INSERT INTO Servicio VALUES(12, 'Competencias');
INSERT INTO Servicio VALUES(13, 'Campeonatos');
INSERT INTO Servicio VALUES(14, 'Congresos');
INSERT INTO Servicio VALUES(15, 'Ferias');
INSERT INTO Servicio VALUES(16, 'Concursos');
INSERT INTO Servicio VALUES(17, 'Conciertos');

create table TipoEvento(
	idEvento INTEGER PRIMARY KEY,
	nombreEvento VARCHAR(50) UNIQUE NOT NULL,
	descripcion VARCHAR(50) NOT NULL
);

INSERT INTO TipoEvento VALUES(1,'Decoracion','Se ofrece decoraciones tematicas');
INSERT INTO TipoEvento VALUES(2,'Salon de fiestas','Distintas opciones de tamaño');
INSERT INTO TipoEvento VALUES(3,'Mobiliario','Se ofrece ');
INSERT INTO TipoEvento VALUES(4,'Banquetes','Comida Gorumet');
INSERT INTO TipoEvento VALUES(5,'Candy Bar','Carros de dulces');
INSERT INTO TipoEvento VALUES(6,'Cupcakes','Muffins tematicos y de varios gustos');
INSERT INTO TipoEvento VALUES(7,'Fuente de chocolate','Deliciosa fuente de chocolate en varios tamaños');
INSERT INTO TipoEvento VALUES(8,'Fuente de queso','Deliciosa fuente de queso en varios tamaños');
INSERT INTO TipoEvento VALUES(9,'Mesa de dulces','Se ofrece mesas decoradas de dulces');
INSERT INTO TipoEvento VALUES(10,'Pasteles','Distintos tipos de papeles');
INSERT INTO TipoEvento VALUES(11,'Inflables','Castillos inflables');
INSERT INTO TipoEvento VALUES(12,'Globos','Globos, globos de helio');
INSERT INTO TipoEvento VALUES(13,'Invitaciones','Postales, cartas, distintas formas de invitaciones');
INSERT INTO TipoEvento VALUES(14,'Musica en vivo','Shows en vivo, musicas variadas, artistas invitados');
INSERT INTO TipoEvento VALUES(15,'Magos','Espectaculo de magos');
INSERT INTO TipoEvento VALUES(16,'Payasos','Payasos');
INSERT INTO TipoEvento VALUES(17,'Menage','Utileria y manteleria');

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