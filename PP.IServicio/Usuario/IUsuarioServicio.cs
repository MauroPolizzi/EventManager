using System.Collections.Generic;

namespace PP.IServicio.Usuario
{
    public interface IUsuarioServicio
    {
        void Agregar(UsuarioDto dto);

        void Eliminar(long id);

        void Modificar(UsuarioDto dto);

        IEnumerable<UsuarioDto> Obtener(string cadenaBuscar);

        UsuarioDto ObtenerPorId(long id);

        void Guardar();
    }
}
