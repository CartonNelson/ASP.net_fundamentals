--Insertar Contacto
CREATE OR ALTER PROCEDURE PR_INSERTAR_CONTACTO
	@apellidoNombre varchar(100),
	@id_genero int,
	@idPais int,
	@localidad varchar(100),
	@idContInterno	int,
	@organizacion varchar(100),
	@idArea	int,
	@idActicvo int,
	@direccion varchar(100),
	@tel_fijo varchar(50),
	@tel_cel varchar(50),
	@email varchar(50),
	@skype varchar(50)
AS
	
BEGIN 


	insert into contactos (apellido_nombre, genero, id_pais, localidad, id_cont_int, organizacion, id_area, id_activo, direccion, tel_fijo, tel_cel, e_mail, skype, fecha_ingreso)
	               values (@apellidoNombre, @id_genero, @idPais,@localidad, @idContInterno, @organizacion, @idArea, @idActicvo, @direccion,  @tel_fijo, @tel_cel, @email, @skype, GETDATE());
   


END 


