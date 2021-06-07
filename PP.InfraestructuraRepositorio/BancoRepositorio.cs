using PP.Dominio.Entidades;
using PP.Dominio.Repositorio.Banco;
using PP.Repositorio;

namespace PP.InfraestructuraRepositorio
{
    public class BancoRepositorio : Repositorio<Banco> , IBancoRepositorio 
    {
    }
}
