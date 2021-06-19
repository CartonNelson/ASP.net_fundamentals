--insert areas
insert into area (id_area, d_area) values(0,'Marketing');
insert into area (id_area, d_area) values(1,'Finanzas');
insert into area (id_area, d_area) values(2,'RRHH');
insert into area (id_area, d_area) values(3,'Operaciones');
insert into area (id_area, d_area) values(10, 'Ninguna');
 

--insert parametricas
insert into parametrica (codigo_tabla, c_dato, d_dato) values(1, 1, 'TODOS');
insert into parametrica (codigo_tabla, c_dato, d_dato) values(1, 2, 'SI');
insert into parametrica (codigo_tabla, c_dato, d_dato) values(1, 3, 'NO');
 

--insert paises
insert into pais (id_pais, nombre_pais) values (1, 'Argentina');
insert into pais (id_pais, nombre_pais) values (2, 'Uruguay');
insert into pais (id_pais, nombre_pais) values (3, 'Brasil');
insert into pais (id_pais, nombre_pais) values (4, 'Chile');
insert into pais (id_pais, nombre_pais) values (5, 'Italia');


 
--insert genero 
insert into genero(id_genero, d_genero) values(1, 'Masculino');
insert into genero(id_genero, d_genero) values(2, 'Femenino');


--insert contacto
insert into contactos (apellido_nombre, genero, id_pais, localidad, id_cont_int, organizacion, id_area, id_activo, direccion, tel_fijo, tel_cel, e_mail, fecha_ingreso)
				values('Gonzales Dario', 1, 1, 'BS AS', 2, 'EDSA SA', 2, 2, 'calle falsa 123', '2222222', '123213', 'email@email.com', '03/07/2021');

insert into contactos (apellido_nombre, genero, id_pais, localidad, id_cont_int, organizacion, id_area, id_activo, direccion, tel_fijo, tel_cel, e_mail, fecha_ingreso)
				values('perez Juan', 1, 3, 'Rio de Janeiro', 2, 'EDSA SA', 1, 2, 'Gral pinto 123', '3333333', '15256315', 'Jperez@email.com', '12/05/2021');

insert into contactos (apellido_nombre, genero, id_pais, localidad, id_cont_int, organizacion, id_area, id_activo, direccion, tel_fijo, tel_cel, e_mail, fecha_ingreso)
				values('Pereyra Agostina', 2, 5, 'Sicilia', 3, 'EDSA SA', 10, 2, 'Paz 2562', '+39-444555', '+39-155256145', 'Apereyra@email.com', '11/04/2021');

insert into contactos (apellido_nombre, genero, id_pais, localidad, id_cont_int, organizacion, id_area, id_activo, direccion, tel_fijo, tel_cel, e_mail, fecha_ingreso)
				values('Alganaraz Manuela', 2, 4, 'Valparaiso', 3, 'EDSA SA', 3, 3, 'ALberdi 1723', '+56-55482182', '+56-158934274', 'Malganaraz@email.com', '08/4/2021');

insert into contactos (apellido_nombre, genero, id_pais, localidad, id_cont_int, organizacion, id_area, id_activo, direccion, tel_fijo, tel_cel, e_mail, fecha_ingreso)
				values('Garcia Ivan', 1, 2, 'Canelones', 2, 'EDSA SA', 1, 2, 'Gral Belgrano 4586', '+598-652365', '+598-1532145232', 'Igarcia@email.com', '02/05/2021');

insert into contactos (apellido_nombre, genero, id_pais, localidad, id_cont_int, organizacion, id_area, id_activo, direccion, tel_fijo, tel_cel, e_mail, fecha_ingreso)
				values('Gonzales Ricardo', 1, 1, 'BS AS', 2, 'EDSA SA', 2, 2, 'calle falsa 2314', '2222222', '123213', 'email@email.com', '03/06/2021');

insert into contactos (apellido_nombre, genero, id_pais, localidad, id_cont_int, organizacion, id_area, id_activo, direccion, tel_fijo, tel_cel, e_mail, fecha_ingreso)
				values('Martinez Lucas', 1, 3, 'Rio de Janeiro', 2, 'EDSA SA', 1, 3, 'Gral pinto 1 12', '3333333', '15256315', 'email@email.com', '12/05/2021');

insert into contactos (apellido_nombre, genero, id_pais, localidad, id_cont_int, organizacion, id_area, id_activo, direccion, tel_fijo, tel_cel, e_mail, fecha_ingreso)
				values('Juarez Pedro', 1, 5, 'Sicilia', 3, 'EDSA SA', 10, 3, 'Paz 2262', '+39-444555', '+39-155256145', 'Aemail@email.com', '11/05/2021');

insert into contactos (apellido_nombre, genero, id_pais, localidad, id_cont_int, organizacion, id_area, id_activo, direccion, tel_fijo, tel_cel, e_mail, fecha_ingreso)
				values('Micalea Agostini', 2, 4, 'Valparaiso', 3, 'EDSA SA', 3, 3, 'ALberdi 111', '+56-55482182', '+56-158934274', 'email@email.com', '08/05/2021');

insert into contactos (apellido_nombre, genero, id_pais, localidad, id_cont_int, organizacion, id_area, id_activo, direccion, tel_fijo, tel_cel, e_mail, fecha_ingreso)
				values('Ramirez Daniela', 2, 2, 'Canelones', 2, 'EDSA SA', 1, 2, 'Gral Belgrano 426', '+598-652365', '+598-1532145232', 'email@email.comm', '02/06/2021');