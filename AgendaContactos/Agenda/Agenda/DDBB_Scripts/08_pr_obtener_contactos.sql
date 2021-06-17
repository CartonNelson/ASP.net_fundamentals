--Obtener contactos por filtro
CREATE OR ALTER PROCEDURE PR_OBTENER_CONTACTOS
	@apellidoNombre varchar(100),
	@idPais int,
	@localidad varchar(100),
	@fechaIngDesde datetime,
	@fechaIngHasta datetime,
	@idContInterno	int,
	@organizacion varchar(100),
	@idArea	int,
	@idActicvo int

AS
	
BEGIN 


	select id_contacto, apellido_nombre, 
		   g.d_genero as d_genero, c.genero as id_genero , 
		   p.nombre_pais as d_pais, c.id_pais as id_pais, 
		   localidad, 
		   t_conInt.d_dato as d_con_int, c.id_cont_int as id_cont_int, 
		   organizacion, 
		   a.d_area as d_area,c.id_area as id_area,  
		   t_idAct.d_dato as d_activo, c.id_activo as id_activo, 
		   direccion, tel_fijo, tel_cel, e_mail, skype, fecha_ingreso
	from contactos c inner join parametrica t_conInt on c.id_cont_int = t_conInt.c_dato 
		 inner join parametrica t_idAct on c.id_activo = t_idAct.c_dato
		 inner join genero g on c.genero = g.id_genero 
		 inner join pais p on c.id_pais = p.id_pais
		 inner join area a on a.id_area = c.id_area
	where (UPPER(c.apellido_nombre) like ('%'+UPPER(@apellidoNombre)+'%') or @apellidoNombre is null or @apellidoNombre = '')
		and (c.id_pais = @idPais or @idPais is null or @idPais=-1)
	    and (UPPER(c.localidad) like ('%'+UPPER(@localidad)+'%') or @localidad is null or @localidad ='')
	    and c.fecha_ingreso between @fechaIngDesde and @fechaIngHasta
	    and (c.id_cont_int = @idContInterno or @idContInterno is null  or @idContInterno=-1)
	    and (UPPER(c.organizacion) like ('%'+UPPER(@organizacion)+'%') or @organizacion is null or @organizacion ='')
	    and (c.id_area = @idArea  or @idArea=10)
	    and (c.id_activo = @idActicvo or @idActicvo is null or @idActicvo=-1)
		and c.fecha_baja  is null
	order by c.apellido_nombre asc 	

END 




 
