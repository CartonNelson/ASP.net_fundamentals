CREATE TABLE contactos (
		id_contacto int identity (1,1),
		apellido_nombre varchar(100) not null,
		genero int not null, --fk genero
		id_pais int not null, --fk pais
		localidad varchar(500),
		id_cont_int int not null, --fk parametrica
		organizacion varchar(200),
		id_area int,	--fk area
		id_activo int not null, --fk parametrica
		direccion varchar(500), 
		tel_fijo varchar(25),
		tel_cel varchar(25),
		e_mail varchar(50),
		skype varchar(50),
		fecha_ingreso datetime,
		----
		fecha_alta datetime,
		fecha_baja	datetime

		
	); 

create table parametrica(
		codigo_tabla int not null,
		c_dato	int not null,
		d_dato	varchar(200) not null
	);

create table area(
	id_area int NOT NULL,
	d_area varchar(200),

);

create table pais( 
		id_pais int not null,
		nombre_pais varchar(200)
);


create table genero ( 
	id_genero int not null,
	d_genero varchar(50)
);

---CONSTRAINTS --------------------------------
--PK
alter table contactos add constraint PK_id_contacto primary key(id_contacto);

alter table parametrica add constraint PK_c_dato primary key(c_dato);

alter table pais add constraint PK_id_pais primary key(id_pais);

alter table area add constraint PK_id_area primary key(id_area);

alter table genero add constraint PK_id_genero primary key(id_genero);

--FK
alter table contactos add constraint FK_contacto_pais foreign key(id_pais) references pais(id_pais); --fk id de pais con pais

alter table contactos add constraint FK_contacto_c_inte foreign key(id_cont_int) references parametrica(c_dato);--fk con interno con parametrica

alter table contactos add constraint FK_contacto_activo foreign key(id_activo) references parametrica(c_dato); --fk activo con parametrica

alter table contactos add constraint FK_contacto_area foreign key(id_area) references area(id_area); --fk id_area con area

alter table contactos add constraint FK_contacto_genero foreign key(genero) references genero(id_genero); --fk id_genero con genero
------------------------------------------------
--DBCC CHECKIDENT ('area', RESEED, 0)  resetear dentity