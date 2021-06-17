--Borrar Contacto
CREATE OR ALTER PROCEDURE PR_ELIMINAR_CONTACTO
	@id_contacto int
AS
	
BEGIN 


	delete from contactos where id_contacto = @id_contacto;
   


END 