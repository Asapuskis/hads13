Create proc insertarUsuario
	@email nvarchar(100),
	@nombre nvarchar(50),
	@apellidos nvarchar(50),
	@numconfir integer,
	@confirmado integer,
	@tipo nvarchar(10),
	@pass nvarchar(50)
as
	insert into Usuarios (email,nombre,apellidos, numconfir, confirmado,tipo,pass) 
	values 
	(@email,@nombre,@apellidos,@numconfir,@confirmado,@tipo,@pass)
go