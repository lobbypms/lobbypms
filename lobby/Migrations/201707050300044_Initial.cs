namespace lobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodigosTransaccion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(maxLength: 5),
                        GrupoId = c.Int(nullable: false),
                        SubgrupoId = c.Int(nullable: false),
                        GenIVA = c.Boolean(nullable: false),
                        Descripcion = c.String(maxLength: 25),
                        Tipo = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ctGrupos", t => new { t.Id, t.Codigo })
                .ForeignKey("dbo.ctSubgrupos", t => new { t.Id, t.Codigo })
                .Index(t => new { t.Id, t.Codigo });
            
            CreateTable(
                "dbo.ctGrupos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => new { t.Id, t.Codigo });
            
            CreateTable(
                "dbo.ctSubgrupos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(maxLength: 25),
                        CTGrupoId = c.Int(nullable: false),
                        ctGrupo_Id = c.Int(),
                        ctGrupo_Codigo = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => new { t.Id, t.Codigo })
                .ForeignKey("dbo.ctGrupos", t => new { t.ctGrupo_Id, t.ctGrupo_Codigo })
                .Index(t => new { t.ctGrupo_Id, t.ctGrupo_Codigo });
            
            CreateTable(
                "dbo.CotMonExtr",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaCotizacion = c.DateTime(nullable: false),
                        Cotizacion = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Direcciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Calle = c.String(maxLength: 50),
                        Numero = c.Int(),
                        Piso = c.String(maxLength: 5),
                        Departamento = c.String(maxLength: 5),
                        ProvinciaId = c.Int(nullable: false),
                        Localidad = c.String(maxLength: 50),
                        CodigoPostal = c.Int(),
                        PaisId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paises", t => t.PaisId, cascadeDelete: true)
                .ForeignKey("dbo.Provincias", t => t.ProvinciaId, cascadeDelete: true)
                .Index(t => t.ProvinciaId)
                .Index(t => t.PaisId);
            
            CreateTable(
                "dbo.Paises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(maxLength: 2),
                        Descripcion = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Provincias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        NumeroDoc = c.Int(nullable: false),
                        Serie = c.String(nullable: false, maxLength: 128),
                        FechaDoc = c.DateTime(nullable: false),
                        ResvId = c.Int(),
                        TotalNeto = c.Decimal(precision: 18, scale: 2),
                        TotalBruto = c.Decimal(precision: 18, scale: 2),
                        TotalIVA = c.Decimal(precision: 18, scale: 2),
                        Status = c.Int(),
                        RangosFiscal_Id = c.Int(),
                        RangosFiscal_Serie = c.String(maxLength: 4),
                        Reserva_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.NumeroDoc, t.Serie })
                .ForeignKey("dbo.RangosFiscales", t => new { t.RangosFiscal_Id, t.RangosFiscal_Serie })
                .ForeignKey("dbo.Reservas", t => t.Reserva_Id)
                .Index(t => new { t.RangosFiscal_Id, t.RangosFiscal_Serie })
                .Index(t => t.Reserva_Id);
            
            CreateTable(
                "dbo.RangosFiscales",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Serie = c.String(nullable: false, maxLength: 4),
                        PrimerNumero = c.Int(nullable: false),
                        UltimoNumero = c.Int(nullable: false),
                        NumeroActual = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Serie });
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HuespedID = c.Int(nullable: false),
                        HabitacionID = c.Int(),
                        TarifaID = c.Int(nullable: false),
                        Noches = c.Int(nullable: false),
                        FechaLlegada = c.DateTime(nullable: false),
                        FechaSalida = c.DateTime(nullable: false),
                        Adultos = c.Int(nullable: false),
                        Ninios = c.Int(nullable: false),
                        CamaExtra = c.Boolean(nullable: false),
                        Desayuno = c.Boolean(nullable: false),
                        Extra = c.String(maxLength: 256),
                        Status = c.Int(),
                        Perfil_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Habitaciones", t => t.HabitacionID)
                .ForeignKey("dbo.Perfiles", t => t.Perfil_Id)
                .ForeignKey("dbo.Tarifas", t => t.TarifaID, cascadeDelete: true)
                .Index(t => t.HabitacionID)
                .Index(t => t.TarifaID)
                .Index(t => t.Perfil_Id);
            
            CreateTable(
                "dbo.Habitaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoId = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        Piso = c.Int(),
                        Descripcion = c.String(maxLength: 100),
                        Bloqueada = c.Boolean(nullable: false),
                        Cabana = c.Boolean(nullable: false),
                        Ocupada = c.Boolean(nullable: false),
                        HabitacionTipo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TiposHabitacion", t => t.HabitacionTipo_Id)
                .Index(t => t.HabitacionTipo_Id);
            
            CreateTable(
                "dbo.TiposHabitacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Perfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentoId = c.Int(nullable: false),
                        NumeroDocumento = c.String(maxLength: 20),
                        Apellido = c.String(maxLength: 25),
                        Nombre = c.String(maxLength: 25),
                        DireccionId = c.Int(nullable: false),
                        FechaNacimiento = c.DateTime(),
                        NumeroTarjeta = c.String(maxLength: 25),
                        Extra = c.String(maxLength: 256),
                        Email = c.String(maxLength: 50),
                        Estacionamiento = c.Boolean(),
                        PatenteId = c.Int(),
                        TipoDocumento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Direcciones", t => t.DireccionId, cascadeDelete: true)
                .ForeignKey("dbo.Patentes", t => t.PatenteId)
                .ForeignKey("dbo.TiposDocumento", t => t.TipoDocumento_Id)
                .Index(t => t.DireccionId)
                .Index(t => t.PatenteId)
                .Index(t => t.TipoDocumento_Id);
            
            CreateTable(
                "dbo.Patentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TiposDocumento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tarifas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Codigo = c.String(maxLength: 5),
                        Descripcion = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MonedaExtranjera",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Propiedad",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(maxLength: 100),
                        Ciudad = c.String(maxLength: 50),
                        PaisId = c.Int(nullable: false),
                        Telefono = c.String(maxLength: 20),
                        Email = c.String(maxLength: 50),
                        Responsable = c.String(maxLength: 50),
                        Extra = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Nombre)
                .ForeignKey("dbo.Paises", t => t.PaisId, cascadeDelete: true)
                .Index(t => t.PaisId);

            Sql("INSERT [dbo].[Propiedad] ([Nombre], [Direccion], [Ciudad], [PaisId], [Telefono], [Email], [Responsable], [Extra]) VALUES ('Propiedad DEMO', 'Dirección de pruebas 1234', 'Buenos Aires', 13, '(011)4949-7878', 'info@lobbypms.com.ar', 'Gabriel Lopardo', 'Actualizar datos reales')");

            CreateTable(
                "dbo.ReservasNoches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResvId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        RoomRevenue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reserva_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservas", t => t.Reserva_Id)
                .Index(t => t.Reserva_Id);
            
            CreateTable(
                "dbo.Transacciones",
                c => new
                    {
                        NumTransaccion = c.Int(nullable: false, identity: true),
                        NumDocumento = c.Int(nullable: false),
                        Serie = c.String(maxLength: 3),
                        MontoNeto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MontoBruto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IVA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ctSubgrupoId = c.Int(nullable: false),
                        ctGrupoId = c.Int(nullable: false),
                        CodTransaccionId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        HabitacionId = c.Int(nullable: false),
                        ResvId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Extra = c.String(maxLength: 256),
                        CodigoTransaccion_Id = c.Int(),
                        ctGrupo_Id = c.Int(),
                        ctGrupo_Codigo = c.String(maxLength: 5),
                        ctSubgrupo_Id = c.Int(),
                        ctSubgrupo_Codigo = c.String(maxLength: 5),
                        Factura_NumeroDoc = c.Int(),
                        Factura_Serie = c.String(maxLength: 128),
                        Reserva_Id = c.Int(),
                    })
                .PrimaryKey(t => t.NumTransaccion)
                .ForeignKey("dbo.CodigosTransaccion", t => t.CodigoTransaccion_Id)
                .ForeignKey("dbo.ctGrupos", t => new { t.ctGrupo_Id, t.ctGrupo_Codigo })
                .ForeignKey("dbo.ctSubgrupos", t => new { t.ctSubgrupo_Id, t.ctSubgrupo_Codigo })
                .ForeignKey("dbo.Facturas", t => new { t.Factura_NumeroDoc, t.Factura_Serie })
                .ForeignKey("dbo.Habitaciones", t => t.HabitacionId, cascadeDelete: true)
                .ForeignKey("dbo.Reservas", t => t.Reserva_Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.HabitacionId)
                .Index(t => t.UsuarioId)
                .Index(t => t.CodigoTransaccion_Id)
                .Index(t => new { t.ctGrupo_Id, t.ctGrupo_Codigo })
                .Index(t => new { t.ctSubgrupo_Id, t.ctSubgrupo_Codigo })
                .Index(t => new { t.Factura_NumeroDoc, t.Factura_Serie })
                .Index(t => t.Reserva_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Username = c.String(maxLength: 15),
                        Bloqueado = c.Boolean(nullable: false),
                        Administrador = c.Boolean(nullable: false),
                        Password = c.String(),
                        ActualizarPassword = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            //TiposDocumento
            Sql("DBCC CHECKIDENT ('[TiposDocumento]', RESEED, 1)");
            Sql("INSERT [dbo].[TIPOSDOCUMENTO] ([DESCRIPCION]) VALUES (N'CI')");
            Sql("INSERT [dbo].[TIPOSDOCUMENTO] ([DESCRIPCION]) VALUES (N'DNI')");
            Sql("INSERT [dbo].[TIPOSDOCUMENTO] ([DESCRIPCION]) VALUES (N'PASS')");
            Sql("INSERT [dbo].[TIPOSDOCUMENTO] ([DESCRIPCION]) VALUES (N'OTRO')");

            //Paises
            Sql("DBCC CHECKIDENT ('[Paises]', RESEED, 1)");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AF', N'Afganistán')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AX', N'Islas Gland')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AL', N'Albania')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'DE', N'Alemania')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AD', N'Andorra')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AO', N'Angola')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AI', N'Anguilla')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AQ', N'Antártida')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AG', N'Antigua y Barbuda')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AN', N'Antillas Holandesas')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SA', N'Arabia Saudí')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'DZ', N'Argelia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AR', N'Argentina')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AM', N'Armenia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AW', N'Aruba')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AU', N'Australia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AT', N'Austria')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AZ', N'Azerbaiyán')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BS', N'Bahamas')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BH', N'Bahréin')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BD', N'Bangladesh')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BB', N'Barbados')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BY', N'Bielorrusia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BE', N'Bélgica')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BZ', N'Belice')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BJ', N'Benin')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BM', N'Bermudas')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BT', N'Bhután')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BO', N'Bolivia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BA', N'Bosnia y Herzegovina')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BW', N'Botsuana')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BV', N'Isla Bouvet')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BR', N'Brasil')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BN', N'Brunéi')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BG', N'Bulgaria')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BF', N'Burkina Faso')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'BI', N'Burundi')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CV', N'Cabo Verde')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'KY', N'Islas Caimán')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'KH', N'Camboya')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CM', N'Camerún')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CA', N'Canadá')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CF', N'República Centroafricana')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TD', N'Chad')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CZ', N'República Checa')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CL', N'Chile')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CN', N'China')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CY', N'Chipre')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CX', N'Isla de Navidad')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'VA', N'Ciudad del Vaticano')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CC', N'Islas Cocos')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CO', N'Colombia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'KM', N'Comoras')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CD', N'República Democrática del Congo')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CG', N'Congo')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CK', N'Islas Cook')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'KP', N'Corea del Norte')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'KR', N'Corea del Sur')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CI', N'Costa de Marfil')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CR', N'Costa Rica')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'HR', N'Croacia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CU', N'Cuba')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'DK', N'Dinamarca')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'DM', N'Dominica')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'DO', N'República Dominicana')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'EC', N'Ecuador')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'EG', N'Egipto')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SV', N'El Salvador')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AE', N'Emiratos Árabes Unidos')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'ER', N'Eritrea')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SK', N'Eslovaquia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SI', N'Eslovenia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'ES', N'España')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'UM', N'Islas ultramarinas de Estados Unidos')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'US', N'Estados Unidos')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'EE', N'Estonia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'ET', N'Etiopía')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'FO', N'Islas Feroe')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'PH', N'Filipinas')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'FI', N'Finlandia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'FJ', N'Fiyi')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'FR', N'Francia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GA', N'Gabón')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GM', N'Gambia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GE', N'Georgia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GS', N'Islas Georgias del Sur y Sandwich del Sur')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GH', N'Ghana')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GI', N'Gibraltar')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GD', N'Granada')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GR', N'Grecia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GL', N'Groenlandia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GP', N'Guadalupe')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GU', N'Guam')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GT', N'Guatemala')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GF', N'Guayana Francesa')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GN', N'Guinea')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GQ', N'Guinea Ecuatorial')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GW', N'Guinea-Bissau')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GY', N'Guyana')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'HT', N'Haití')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'HM', N'Islas Heard y McDonald')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'HN', N'Honduras')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'HK', N'Hong Kong')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'HU', N'Hungría')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'IN', N'India')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'ID', N'Indonesia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'IR', N'Irán')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'IQ', N'Iraq')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'IE', N'Irlanda')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'IS', N'Islandia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'IL', N'Israel')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'IT', N'Italia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'JM', N'Jamaica')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'JP', N'Japón')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'JO', N'Jordania')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'KZ', N'Kazajstán')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'KE', N'Kenia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'KG', N'Kirguistán')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'KI', N'Kiribati')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'KW', N'Kuwait')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'LA', N'Laos')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'LS', N'Lesotho')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'LV', N'Letonia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'LB', N'Líbano')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'LR', N'Liberia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'LY', N'Libia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'LI', N'Liechtenstein')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'LT', N'Lituania')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'LU', N'Luxemburgo')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MO', N'Macao')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MK', N'ARY Macedonia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MG', N'Madagascar')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MY', N'Malasia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MW', N'Malawi')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MV', N'Maldivas')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'ML', N'Malí')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MT', N'Malta')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'FK', N'Islas Malvinas')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MP', N'Islas Marianas del Norte')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MA', N'Marruecos')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MH', N'Islas Marshall')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MQ', N'Martinica')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MU', N'Mauricio')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MR', N'Mauritania')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'YT', N'Mayotte')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MX', N'México')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'FM', N'Micronesia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MD', N'Moldavia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MC', N'Mónaco')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MN', N'Mongolia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MS', N'Montserrat')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MZ', N'Mozambique')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'MM', N'Myanmar')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'NA', N'Namibia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'NR', N'Nauru')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'NP', N'Nepal')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'NI', N'Nicaragua')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'NE', N'Níger')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'NG', N'Nigeria')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'NU', N'Niue')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'NF', N'Isla Norfolk')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'NO', N'Noruega')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'NC', N'Nueva Caledonia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'NZ', N'Nueva Zelanda')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'OM', N'Omán')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'NL', N'Países Bajos')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'PK', N'Pakistán')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'PW', N'Palau')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'PS', N'Palestina')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'PA', N'Panamá')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'PG', N'Papúa Nueva Guinea')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'PY', N'Paraguay')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'PE', N'Perú')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'PN', N'Islas Pitcairn')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'PF', N'Polinesia Francesa')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'PL', N'Polonia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'PT', N'Portugal')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'PR', N'Puerto Rico')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'QA', N'Qatar')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'GB', N'Reino Unido')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'RE', N'Reunión')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'RW', N'Ruanda')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'RO', N'Rumania')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'RU', N'Rusia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'EH', N'Sahara Occidental')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SB', N'Islas Salomón')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'WS', N'Samoa')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'AS', N'Samoa Americana')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'KN', N'San Cristóbal y Nevis')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SM', N'San Marino')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'PM', N'San Pedro y Miquelón')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'VC', N'San Vicente y las Granadinas')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SH', N'Santa Helena')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'LC', N'Santa Lucía')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'ST', N'Santo Tomé y Príncipe')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SN', N'Senegal')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CS', N'Serbia y Montenegro')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SC', N'Seychelles')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SL', N'Sierra Leona')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SG', N'Singapur')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SY', N'Siria')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SO', N'Somalia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'LK', N'Sri Lanka')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SZ', N'Suazilandia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'ZA', N'Sudáfrica')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SD', N'Sudán')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SE', N'Suecia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'CH', N'Suiza')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SR', N'Surinam')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'SJ', N'Svalbard y Jan Mayen')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TH', N'Tailandia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TW', N'Taiwán')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TZ', N'Tanzania')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TJ', N'Tayikistán')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'IO', N'Territorio Británico del Océano Índico')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TF', N'Territorios Australes Franceses')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TL', N'Timor Oriental')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TG', N'Togo')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TK', N'Tokelau')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TO', N'Tonga')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TT', N'Trinidad y Tobago')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TN', N'Túnez')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TC', N'Islas Turcas y Caicos')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TM', N'Turkmenistán')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TR', N'Turquía')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'TV', N'Tuvalu')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'UA', N'Ucrania')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'UG', N'Uganda')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'UY', N'Uruguay')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'UZ', N'Uzbekistán')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'VU', N'Vanuatu')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'VE', N'Venezuela')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'VN', N'Vietnam')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'VG', N'Islas Vírgenes Británicas')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'VI', N'Islas Vírgenes de los Estados Unidos')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'WF', N'Wallis y Futuna')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'YE', N'Yemen')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'DJ', N'Yibuti')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'ZM', N'Zambia')");
            Sql("INSERT [dbo].[PAISES] ([CODIGO], [DESCRIPCION]) VALUES (N'ZW', N'Zimbabue')");

            //Provincias
            Sql("DBCC CHECKIDENT ('[Provincias]', RESEED, 1)");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Buenos Aires')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Ciudad Autónoma de Buenos Aires')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Catamarca')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Chaco')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Chubut')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Córdoba')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Corrientes')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Entre Ríos')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Formosa')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Jujuy')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'La Pampa')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'La Rioja')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Mendoza')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Misiones')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Neuquén')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Río Negro')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Salta')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'San Juan')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'San Luis')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Santa Cruz')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Santa Fe')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Santia del Estero')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Tierra del Fue')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Tucumán')");
            Sql("INSERT [dbo].[PROVINCIAS] ([DESCRIPCION]) VALUES (N'Otra')");

            //CreateStoredProcedure("dbo.spGetGenericAddress", System.Func<string> genericAddress,
            //                "   IF NOT EXISTS (SELECT *" +
            //                "                  FROM PERF_DIRECCION" +
            //                "                  WHERE CALLE = 'DIRECCION GENERICA')" +
            //                "   BEGIN" +
            //                "       INSERT INTO PERF_DIRECCION" +
            //                "       (CALLE, NUMERO, PISO, DEPARTAMENTO, PROVINCIA, LOCALIDAD, CODIGO_POSTAL, PAIS)" +
            //                "       VALUES ('DIRECCION GENERICA', 1234, NULL, NULL, 25, NULL, 0, 46)" +
            //                "   END" +
            //                "" +
            //                "   SET @genericAddressID = (SELECT" +
            //                "           CONVERT(varchar(10), ID)" +
            //                "       FROM" +
            //                "           PERF_DIRECCION" +
            //                "       WHERE" +
            //                "           CALLE = 'DIRECCION GENERICA')" +
            //                "   RETURN" +
            //                "END", null);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Transacciones", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Transacciones", "Reserva_Id", "dbo.Reservas");
            DropForeignKey("dbo.Transacciones", "HabitacionId", "dbo.Habitaciones");
            DropForeignKey("dbo.Transacciones", new[] { "Factura_NumeroDoc", "Factura_Serie" }, "dbo.Facturas");
            DropForeignKey("dbo.Transacciones", new[] { "ctSubgrupo_Id", "ctSubgrupo_Codigo" }, "dbo.ctSubgrupos");
            DropForeignKey("dbo.Transacciones", new[] { "ctGrupo_Id", "ctGrupo_Codigo" }, "dbo.ctGrupos");
            DropForeignKey("dbo.Transacciones", "CodigoTransaccion_Id", "dbo.CodigosTransaccion");
            DropForeignKey("dbo.ReservasNoches", "Reserva_Id", "dbo.Reservas");
            DropForeignKey("dbo.Propiedad", "PaisId", "dbo.Paises");
            DropForeignKey("dbo.Facturas", "Reserva_Id", "dbo.Reservas");
            DropForeignKey("dbo.Reservas", "TarifaID", "dbo.Tarifas");
            DropForeignKey("dbo.Reservas", "Perfil_Id", "dbo.Perfiles");
            DropForeignKey("dbo.Perfiles", "TipoDocumento_Id", "dbo.TiposDocumento");
            DropForeignKey("dbo.Perfiles", "PatenteId", "dbo.Patentes");
            DropForeignKey("dbo.Perfiles", "DireccionId", "dbo.Direcciones");
            DropForeignKey("dbo.Reservas", "HabitacionID", "dbo.Habitaciones");
            DropForeignKey("dbo.Habitaciones", "HabitacionTipo_Id", "dbo.TiposHabitacion");
            DropForeignKey("dbo.Facturas", new[] { "RangosFiscal_Id", "RangosFiscal_Serie" }, "dbo.RangosFiscales");
            DropForeignKey("dbo.Direcciones", "ProvinciaId", "dbo.Provincias");
            DropForeignKey("dbo.Direcciones", "PaisId", "dbo.Paises");
            DropForeignKey("dbo.CodigosTransaccion", new[] { "Id", "Codigo" }, "dbo.ctSubgrupos");
            DropForeignKey("dbo.ctSubgrupos", new[] { "ctGrupo_Id", "ctGrupo_Codigo" }, "dbo.ctGrupos");
            DropForeignKey("dbo.CodigosTransaccion", new[] { "Id", "Codigo" }, "dbo.ctGrupos");
            DropIndex("dbo.Usuarios", new[] { "Username" });
            DropIndex("dbo.Transacciones", new[] { "Reserva_Id" });
            DropIndex("dbo.Transacciones", new[] { "Factura_NumeroDoc", "Factura_Serie" });
            DropIndex("dbo.Transacciones", new[] { "ctSubgrupo_Id", "ctSubgrupo_Codigo" });
            DropIndex("dbo.Transacciones", new[] { "ctGrupo_Id", "ctGrupo_Codigo" });
            DropIndex("dbo.Transacciones", new[] { "CodigoTransaccion_Id" });
            DropIndex("dbo.Transacciones", new[] { "UsuarioId" });
            DropIndex("dbo.Transacciones", new[] { "HabitacionId" });
            DropIndex("dbo.ReservasNoches", new[] { "Reserva_Id" });
            DropIndex("dbo.Propiedad", new[] { "PaisId" });
            DropIndex("dbo.Perfiles", new[] { "TipoDocumento_Id" });
            DropIndex("dbo.Perfiles", new[] { "PatenteId" });
            DropIndex("dbo.Perfiles", new[] { "DireccionId" });
            DropIndex("dbo.Habitaciones", new[] { "HabitacionTipo_Id" });
            DropIndex("dbo.Reservas", new[] { "Perfil_Id" });
            DropIndex("dbo.Reservas", new[] { "TarifaID" });
            DropIndex("dbo.Reservas", new[] { "HabitacionID" });
            DropIndex("dbo.Facturas", new[] { "Reserva_Id" });
            DropIndex("dbo.Facturas", new[] { "RangosFiscal_Id", "RangosFiscal_Serie" });
            DropIndex("dbo.Direcciones", new[] { "PaisId" });
            DropIndex("dbo.Direcciones", new[] { "ProvinciaId" });
            DropIndex("dbo.ctSubgrupos", new[] { "ctGrupo_Id", "ctGrupo_Codigo" });
            DropIndex("dbo.CodigosTransaccion", new[] { "Id", "Codigo" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Transacciones");
            DropTable("dbo.ReservasNoches");
            DropTable("dbo.Propiedad");
            DropTable("dbo.MonedaExtranjera");
            DropTable("dbo.Tarifas");
            DropTable("dbo.TiposDocumento");
            DropTable("dbo.Patentes");
            DropTable("dbo.Perfiles");
            DropTable("dbo.TiposHabitacion");
            DropTable("dbo.Habitaciones");
            DropTable("dbo.Reservas");
            DropTable("dbo.RangosFiscales");
            DropTable("dbo.Facturas");
            DropTable("dbo.Provincias");
            DropTable("dbo.Paises");
            DropTable("dbo.Direcciones");
            DropTable("dbo.CotMonExtr");
            DropTable("dbo.ctSubgrupos");
            DropTable("dbo.ctGrupos");
            DropTable("dbo.CodigosTransaccion");
        }
    }
}
