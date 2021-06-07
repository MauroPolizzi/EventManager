using System.Collections.Generic;

namespace PP.IServicio.Banco
{
    public interface IBancoServicio
    {
        void Agregar(BancoDto dto);

        void Eliminar(long id);

        void Modificar(BancoDto dto);

        IEnumerable<BancoDto> Obtener(string cadenaBuscar);

        BancoDto ObtenerPorId(long id);

        void Guardar();
    }
}
