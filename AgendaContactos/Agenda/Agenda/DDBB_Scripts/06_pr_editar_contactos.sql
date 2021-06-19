--Editar Contacto
CREATE OR ALTER PROCEDURE PR_ACTUALIZAR_CONTACTO
	@id_contacto int,
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


	update contactos
	   set apellido_nombre  = @apellidoNombre,
		   genero		    = @id_genero,
		   id_pais		    = @idPais,
		   localidad		= @localidad,
		   id_cont_int		= @idContInterno,
		   organizacion		= @organizacion,
		   id_area			= @idArea,
		   id_activo		= @idActicvo,
		   direccion		= @direccion,
		   tel_fijo			= @tel_fijo,
		   tel_cel			= @tel_cel,
		   e_mail			= @email,
		   skype			= @skype
	where id_contacto = @id_contacto;


END 


