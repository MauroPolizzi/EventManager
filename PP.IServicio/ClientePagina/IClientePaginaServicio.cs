using System.Collections.Generic;

namespace PP.IServicio.PaginaCliente
{
    public interface IClientePaginaServicio
    {
        void Agregar(ClientePaginaDto dto);

        void Eliminar(long id);

        void Modificar(ClientePaginaDto dto);

        IEnumerable<ClientePaginaDto> Obtener(string cadenaBuscar);

        ClientePaginaDto ObtenerPorId(long id);

        void Guardar();
    }
}
