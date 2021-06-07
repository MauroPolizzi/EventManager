using System;
using System.ComponentModel.DataAnnotations;
using PP.Servicio.Base.DtoBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace PP.IServicio.Evento
{
    public class EventoDto : DtoBase
    {
        public string Nombre { get; set; }

        public string Imagen { get; set; }

        [DataType(DataType.ImageUrl)]
        [NotMapped]
        public HttpPostedFileBase ImagenFile { get; set; }

        public string Descripcion { get; set; }

        public string Email { get; set; }

        public string NombreOrganizador { get; set; }

        public string ApellidoOrganizador { get; set; }

        public string InformacionAdicional { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public bool Eliminado { get; set; }

        public DateTime FechaDesde { get; set; }

        public TimeSpan HoraDesde { get; set; }
        
        public long TipoEventoId { get; set; }

        public string UbicacionEstablecimiento { get; set; }

        public string UbicacionPrimDireccion { get; set; }
    }
}
