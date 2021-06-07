using PP.Dominio.Entidades;
using PP.Dominio.Repositorio.Usuario;
using PP.Repositorio;

namespace PP.InfraestructuraRepositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario> , IUsuarioRepositorio 
    {
    }
}
