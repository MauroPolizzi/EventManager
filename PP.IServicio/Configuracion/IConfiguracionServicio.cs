using System.Collections.Generic;

namespace PP.IServicio.Configuracion
{
    public interface IConfiguracionServicio
    {
        void Agregar(ConfiguracionDto dto);

        void Eliminar(long id);

        void Modificar(ConfiguracionDto dto);

        IEnumerable<ConfiguracionDto> Obtener();

        ConfiguracionDto ObtenerPorId(long id);

        void Guardar();
    }
}
