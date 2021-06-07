using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using PP.Dominio.Enum;

namespace PP.IServicio.Evento
{
    public class EventoDetailDto
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

        public long TipoEventoId { get; set; }

        public string TipoEventoDescripcion { get; set; }

        //====================== ENTRADA


        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string NombreEntrada { get; set; }


        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        public int CantidadDisponible { get; set; }


        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        public decimal Precio { get; set; }


        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string DescripcionEntrada { get; set; }


        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        public int MaximoPermitido { get; set; }


        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        public int MinimoPermitido { get; set; }

        //public long EvetnoId { get; set; }

        public TipoEntrada TipoEntrada { get; set; }

        //=================== FECHA


        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Time)]
        public TimeSpan HoraDesde { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Time)]
        public TimeSpan HoraHasta { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaDesde { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaHasta { get; set; }

        //==================== UBICACION

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string NombreEstablecimiento { get; set; }


        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string PrimDireccion { get; set; }

        public string SegDireccion { get; set; }

        public long LocalidadId { get; set; }

        public string LocalidadDescripcion { get; set; }
    }
}
