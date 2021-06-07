using System.Collections.Generic;
using System.Linq;
using PP.Dominio.Repositorio.ClientePagina;
using PP.Dominio.Repositorio.Usuario;
using PP.InfraestructuraRepositorio;
using PP.IServicio.PaginaCliente;
using PP.Servicio.Usuario;
using PP.Servicio._01.Helpers;

namespace PP.Servicio.ClientePagina
{
    public class ClientePaginaServicio : IClientePaginaServicio
    {
        private readonly ClientePaginaRepositorio _clientePaginaRepositorio;
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public ClientePaginaServicio()
            :this(new ClientePaginaRepositorio(), new UsuarioRepositorio())
        {
            
        }
        public ClientePaginaServicio(ClientePaginaRepositorio clientePaginaRepositorio,
            UsuarioRepositorio usuariosRepositorio)
        {
            _clientePaginaRepositorio = clientePaginaRepositorio;
            _usuarioRepositorio = usuariosRepositorio;
        }

        public void Agregar(ClientePaginaDto dto)
        {
            var clientePagina = new Dominio.Entidades.ClientePagina
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                Celular = dto.Celular,
                Email = dto.Email,
                Domicilio = dto.Domicilio
            };

            _clientePaginaRepositorio.Add(clientePagina);
            _clientePaginaRepositorio.Save();

            var PassEncriptada = Encriptar.EncriptarCadena(dto.Nombre);

            var usuario = new Dominio.Entidades.Usuario
            {
                ClienteId = clientePagina.Id,
                NombreUsuario = dto.Email,
                Password = PassEncriptada,
                EstaBloqueado = false,
            };

            _usuarioRepositorio.Add(usuario);
            _usuarioRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var clientePagina = _clientePaginaRepositorio.GetById(id);

            _clientePaginaRepositorio.Delete(clientePagina.Id);
            _clientePaginaRepositorio.Save();
        }

        public void Guardar()
        {
            _clientePaginaRepositorio.Save();
        }

        public void Modificar(ClientePaginaDto dto)
        {
            var clientePagina = _clientePaginaRepositorio.GetById(dto.Id);

            _clientePaginaRepositorio.UpDate(clientePagina);

            clientePagina.Nombre = dto.Nombre;
            clientePagina.Apellido = dto.Apellido;
            clientePagina.Telefono = dto.Telefono;
            clientePagina.Celular = dto.Celular;
            clientePagina.Email = dto.Email;
            clientePagina.Domicilio = dto.Domicilio;

            _clientePaginaRepositorio.Save();
        }

        public IEnumerable<ClientePaginaDto> Obtener(string cadenaBuscar)
        {
            return _clientePaginaRepositorio.GetAll().Where(x => x.Apellido.Contains(cadenaBuscar))
                .Select(x => new ClientePaginaDto
                {
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    Telefono = x.Telefono,
                    Celular = x.Celular,
                    Email = x.Email,
                    Domicilio = x.Domicilio,
                    Id = x.Id,
                    RowVersion = x.RowVersion

                }).OrderBy(x => x.Nombre).ToList();
        }

        public ClientePaginaDto ObtenerPorId(long id)
        {
            var clientePagina = _clientePaginaRepositorio.GetById(id);

            var cliente = new ClientePaginaDto
            {
                Apellido = clientePagina.Apellido,
                Nombre = clientePagina.Nombre,
                Telefono = clientePagina.Telefono,
                Celular = clientePagina.Celular,
                Domicilio = clientePagina.Domicilio,
                Email = clientePagina.Email,
                Id = clientePagina.Id,
                RowVersion = clientePagina.RowVersion
            };

            return cliente;
        }

    }
}
