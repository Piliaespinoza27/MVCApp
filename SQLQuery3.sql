CREATE DATABASE [ejemploMVC]
GO

USE [ejemploMVC]
GO
/****** Object:  Table [dbo].[alumno]    Script Date: 30/10/2020 11:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[alumno](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[edad] [int] NOT NULL,
	[fk_materia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[materia]    Script Date: 30/10/2020 11:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[alumno]  WITH CHECK ADD FOREIGN KEY([fk_materia])
REFERENCES [dbo].[materia] ([id])
GO
/****** Object:  StoredProcedure [dbo].[AGEGRAR_ALUMNO]    Script Date: 30/10/2020 11:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[AGEGRAR_ALUMNO]
@NOMBRE VARCHAR(50),
@APELLIDO VARCHAR(50),
@EDAD INT,
@FK_MATERIA BIGINT
AS
INSERT INTO alumno VALUES (@NOMBRE, @APELLIDO, @EDAD, @FK_MATERIA)

GO
/****** Object:  StoredProcedure [dbo].[AGREGAR_ALUMNO]    Script Date: 30/10/2020 11:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AGREGAR_ALUMNO]
@NOMBRE VARCHAR(50),
@APELLIDO VARCHAR(50),
@EDAD INT,
@FK_MATERIA BIGINT
AS
INSERT INTO alumno VALUES (@NOMBRE, @APELLIDO, @EDAD, @FK_MATERIA)

GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_ALUMNO]    Script Date: 30/10/2020 11:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CONSULTAR_ALUMNO]
AS
SELECT 
	A.ID,
	A.nombre,
	A.apellido,
	A.edad,
	A.FK_MATERIA,
	M.NOMBRE 
FROM 
	ALUMNO A JOIN MATERIA M ON A.fk_materia = M.id
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_MATERIA]    Script Date: 30/10/2020 11:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CONSULTAR_MATERIA]
	AS
	SELECT * FROM materia

GO
/****** Object:  StoredProcedure [dbo].[ELIMINAR_ALUMNO]    Script Date: 30/10/2020 11:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ELIMINAR_ALUMNO]
@ID BIGINT 
AS
DELETE FROM alumno WHERE id=@ID

GO


CREATE PROC [dbo].[AGREGAR_MATERIA] 
 @nombre nvarchar(50) 
as  
INSERT INTO materia VALUES  (@nombre)
GO


CREATE PROC [dbo].[CONSULTAR_MATERIA] 	
AS 	
SELECT * FROM materia
GO