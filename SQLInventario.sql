USE [rapichicken]
GO

/****** Object:  Table [dbo].[Inventario]    Script Date: 5/10/2022 01:01:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create TABLE [dbo].[Inventario](
	[Inventario_id] [int] IDENTITY(1,1) NOT NULL,
	[n_producto] [varchar](250) NOT NULL,
	[descripcion] [varchar](500) NULL,
	[tipo_producto] [varchar](50) NOT NULL,
	[estado_producto] [varchar](50) NOT NULL,
	[stock] [int] NOT NULL,
	[detalle_unidad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[Inventario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 5/10/2022 01:01:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create TABLE [dbo].[Usuarios](
	[Usuarios_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](250) NOT NULL,
	[pass] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Usuarios_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Personas]    Script Date: 5/10/2022 01:01:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create TABLE [dbo].[Personas](
	[Personas_id] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](250) NOT NULL,
	[apellidos] [varchar](250) NOT NULL,
	[telefono] [int] NOT NULL,
	[f_nacimiento] [date] NOT NULL,
	[dni] [int] NOT NULL,
	[direccion] [varchar](500) NOT NULL,
	[sexo] [char] NOT NULL,
	[FK_Usuarios] [int] FOREIGN KEY REFERENCES Usuarios(Usuarios_id),
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Personas_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Roles]    Script Date: 5/10/2022 01:01:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create TABLE [dbo].[Roles](
	[Roles_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](250) NOT NULL,
	[description] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Roles_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Personas_has_Roles]    Script Date: 5/10/2022 01:01:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create TABLE [dbo].[Personas_has_Roles](
	[Personas_id] [int],
	[Roles_id] [int],
	CONSTRAINT Personas_has_Roles_id PRIMARY KEY ([Personas_id], [Roles_id]),
	CONSTRAINT FK_Personas FOREIGN KEY ([Personas_id]) REFERENCES Personas ([Personas_id]),
	CONSTRAINT FK_Roles FOREIGN KEY ([Roles_id]) REFERENCES Roles (Roles_id));
GO

/****** Object:  Table [dbo].[Pedidos]    Script Date: 6/10/2022 17:59:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pedidos](
	[Pedidos_id] [int] IDENTITY(1,1) NOT NULL,
	[N_Pedido] [varchar](250) NOT NULL,
	[D_Pedido] [varchar](500) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[NP_C] [varchar](50) NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Pedidos_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Catalogo]    Script Date: 5/10/2022 01:01:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create TABLE [dbo].[Catalogo](
	[Catalogo_id] [int] IDENTITY(1,1) NOT NULL,
	[n_producto] [varchar](250) NOT NULL,
	[descripcion] [varchar](500) NULL,
	[tipo_producto] [varchar](50) NOT NULL,
	[estado_producto] [varchar](50) NOT NULL,
	[stock] [int] NOT NULL,
	[detalle_unidad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Catalogo] PRIMARY KEY CLUSTERED 
(
	[Catalogo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Promociones]    Script Date: 5/10/2022 01:01:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create TABLE [dbo].[Promociones](
	[Promociones_id] [int] IDENTITY(1,1) NOT NULL,
	[n_producto] [varchar](250) NOT NULL,
	[descripcion] [varchar](500) NULL,
	[tipo_producto] [varchar](50) NOT NULL,
	[estado_producto] [varchar](50) NOT NULL,
	[stock] [int] NOT NULL,
	[detalle_unidad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Promociones] PRIMARY KEY CLUSTERED 
(
	[Promociones_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****sp****/
create procedure sp_ListarInventario
as
begin
	select * from Inventario
end
go

create procedure sp_ListarNInventario(
@NombreP varchar(250)
)
as
begin
	select * from Inventario where @NombreP=n_producto
end
go

create procedure sp_GuardarInventario(
@NombreP varchar(250),
@I_D varchar(500),
@T_P varchar(50),
@E_P varchar(50),
@I_Stock int,
@I_D_Unidad varchar(50)
)
as
begin
	insert into Inventario(n_producto,descripcion,tipo_producto,estado_producto,stock,detalle_unidad) 
	values(@NombreP,@I_D,@T_P,@E_P,@I_Stock,@I_D_Unidad)
end
go

use rapichicken 
go
create procedure sp_EditarInventario(
@I_Id int,
@NombreP varchar(250),
@I_D varchar(500),
@T_P varchar(50),
@E_P varchar(50),
@I_Stock int,
@I_D_Unidad varchar(50)
)
as
begin
	update Inventario set n_producto = @NombreP,descripcion = @I_D,tipo_producto = @T_P,
	estado_producto = @E_P,detalle_unidad = @I_D_Unidad 
	where Inventario_id = @I_Id
end
go

create procedure sp_EditarStock(
@I_Id int,
@I_Stock int
)
as
begin
	update Inventario set stock = @I_Stock where Inventario_id = @I_Id
end
go

create procedure sp_EliminarInventario(@I_Id int)
as
begin
	delete from Inventario where Inventario_id = @I_Id
end
go

create procedure sp_ObtenerIdInventario(
@I_ID int
)
as
begin
	select * from Inventario where @I_ID=Inventario_id
end
go

create procedure sp_ListarRoles
as
begin
	select * from Roles
end
go

create procedure sp_GuardarRoles(
@NR varchar(250),
@D varchar(500)
)
as
begin
	insert into Roles(name,description) 
	values(@NR,@D)
end
go

create procedure sp_EditarRoles(
@R_Id int,
@NR varchar(250),
@D varchar(500)
)
as
begin
	update Roles set name = @NR,description = @D where Roles_id = @R_Id
end
go

create procedure sp_ObtenerIdRoles(
@R_ID int
)
as
begin
	select * from Roles where @R_ID=Roles_id
end
go

create procedure sp_EliminarRoles(@R_Id int)
as
begin
	delete from Roles where Roles_id = @R_Id
end
go

create procedure sp_ListarPersonal
as
begin
	select Personas.Personas_id as PID,Personas.nombres as NP,Personas.apellidos as AP,Personas.telefono as PT,Personas.f_nacimiento as FN,Personas.dni as DNI,Personas.direccion as DIR,Personas.sexo as SX,Roles.name as RN from Personas
	join Personas_has_Roles on Personas.Personas_id=Personas_has_Roles.Personas_id
	join Roles on Personas_has_Roles.Roles_id=Roles.Roles_id
	where Roles.name != 'Cliente' and Roles.name != 'Invitado'
end
go

create procedure sp_GuardarPersonal(
@NP varchar(250),
@AP varchar(250),
@T int,
@F_N date,
@Dni int,
@D varchar(500),
@S char,
@R_id int
)
as
begin
declare @P_id int
	begin
		insert into Personas(nombres,apellidos,telefono,f_nacimiento,dni,direccion,sexo) 
		values(@NP,@AP,@T,@F_N,@Dni,@D,@S)
	end
	begin
		select @P_id = Personas_id from Personas where dni=@Dni
	end
	begin
		insert into Personas_has_Roles(Personas_id,Roles_id)
		values(@P_id,@R_id)
	end
end
go

create procedure sp_GuardarCliente(
@NP varchar(250),
@AP varchar(250),
@T int,
@F_N date,
@Dni int,
@D varchar(500),
@S char,
@NU varchar(250),
@P varchar(500)
)
as
begin
declare @P_id int
declare @U_id int
	begin
		insert into Personas(nombres,apellidos,telefono,f_nacimiento,dni,direccion,sexo) 
		values(@NP,@AP,@T,@F_N,@Dni,@D,@S)
	end
	begin
		insert into
		Usuarios(name,pass)
		values(@NU,@P)
	end
	begin
		select @P_id = Personas_id from Personas where dni=@Dni
	end
	begin
		insert into Personas_has_Roles(Personas_id,Roles_id)
		values(@P_id,1)
	end
	begin
		select @U_id = Usuarios_id from Usuarios where name=@NU and pass=@P
	end
	begin
		update Personas set FK_Usuarios=@U_id where dni=@Dni
	end
end
go

create procedure sp_ListarCatalogo
as
begin
	select * from Catalogo
end
go

use rapichicken
go
create procedure sp_ListarPromociones
as
begin
	select * from Promociones
end
go

create procedure sp_ObtenerIdCatalogo(
@I_ID int
)
as
begin
	select * from Catalogo where @I_ID=Catalogo_id
end
go

create procedure sp_EditarCatalogo(
@I_ID int,
@Stock int
)
as
begin
	update Catalogo set stock = @Stock where Catalogo_id=@I_ID
end
go

insert into Roles(name,description) 
values ('Cliente','Puede generar carrito de compras')
go
