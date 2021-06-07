using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PP.Aplication.ConectionString;
using PP.Dominio.Entidades;

namespace PP.Infraestructura.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(ConectionString.GetWithWindows)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public  IDbSet<Pais> Pais { get; set; }

        public IDbSet<Evento> Evento { get; set; }

        public IDbSet<PreguntaFrecuente> PreguntaFrecuente { get; set; }

        public IDbSet<TipoEvento> TipoEvento { get; set; }

        public IDbSet<Configuracion> Configuracion { get; set; }

        public IDbSet<Inscripcion> Inscripcion { get; set; }

        public IDbSet<ClientePagina> ClientePaginas { get; set; }

        public IDbSet<Usuario> Usuarios { get; set; }

        public IDbSet<FormaPago> FormaPagos { get; set; }

        public IDbSet<Tarjeta> Tarjetas { get; set; }

        public IDbSet<PlanTarjeta> PlanTarjetas { get; set; }

        public IDbSet<FP_Tarjeta> FpTarjetas { get; set; }

        public IDbSet<FP_Transferencia> FpTransferencias { get; set; }

        public IDbSet<Banco> Bancos { get; set; }

        public IDbSet<Detalle> Detalles { get; set; }

        public IDbSet<Entrada> Entradas { get; set; }

        public IDbSet<Factura> Facturas { get; set; }

        public IDbSet<FechaEvento> FechaEventos { get; set; }

        public IDbSet<Localidad> Localidads { get; set; }

        public IDbSet<Provincia> Provincias { get; set; }

        public IDbSet<Ubicacion> Ubicacions { get; set; }
    }
}
