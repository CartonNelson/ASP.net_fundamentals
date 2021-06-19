--Activar/desactivar
CREATE OR ALTER PROCEDURE PR_ACTIVAR_PAUSAR_CONTACTO
	@id_contacto int,
	@id_activo int
AS
	
BEGIN 
	 

	if (@id_activo = 2) 
		begin
			update contactos set id_activo= 3 where id_contacto = @id_contacto;
		end
	else  
		begin
			update contactos set id_activo= 2 where id_contacto = @id_contacto;
		end


END 

