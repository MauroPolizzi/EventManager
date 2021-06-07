using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Enum;

namespace PP.Dominio.MetaData
{
    public interface IFormaPago
    {

        decimal Monto { get; set; }
        

        TipoFormaPago TipoFormaPago { get; set; }
    }
}
