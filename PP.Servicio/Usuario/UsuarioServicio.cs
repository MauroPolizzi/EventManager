using System;
using System.Collections.Generic;
using System.Linq;
using PP.Dominio.Repositorio.Usuario;
using PP.IServicio.Usuario;
using PP.Servicio._01.Helpers;

namespace PP.Servicio.Usuario
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public void Agregar(UsuarioDto dto)
        {
            var usuario = new Dominio.Entidades.Usuario
            {
                NombreUsuario = dto.NombreUsuario,
                Password = dto.Password,
                EstaBloqueado = dto.EstaBloqueado,
                ClienteId = dto.ClienteId
            };

            _usuarioRepositorio.Add(usuario);
            _usuarioRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var usuario = _usuarioRepositorio.GetById(id);

            _usuarioRepositorio.Delete(usuario.Id);
            _usuarioRepositorio.Save();
        }

        public void Guardar()
        {
            _usuarioRepositorio.Save();
        }

        public void Modificar(UsuarioDto dto)
        {
            var usuario = _usuarioRepositorio.GetById(dto.Id);

            _usuarioRepositorio.UpDate(usuario);

            usuario.NombreUsuario = dto.NombreUsuario;
            usuario.Password = dto.Password;
            usuario.EstaBloqueado = dto.EstaBloqueado;
            usuario.ClienteId = dto.ClienteId;

            _usuarioRepositorio.Save();
        }

        public bool VerificarSiExiste(string nombreUsuario, string password)
        {
            var passEncriptada = Encriptar.EncriptarCadena(password);

            var usuario = _usuarioRepositorio.GetAll().Where(
                x => x.NombreUsuario == nombreUsuario && x.Password == passEncriptada).FirstOrDefault();

            if (usuario == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IEnumerable<UsuarioDto> Obtener(string cadenaBuscar)
        {
            return _usuarioRepositorio.GetAll().Where(x => x.NombreUsuario.Contains(cadenaBuscar))
                .Select(x => new UsuarioDto
                {
                    Id = x.Id,
                    ClienteId = x.ClienteId,
                    EstaBloqueado = x.EstaBloqueado,
                    NombreUsuario = x.NombreUsuario,
                    Password = x.Password,
                    RowVersion = x.RowVersion

                }).ToList();
        }

        public UsuarioDto ObtenerPorId(long id)
        {
            var usuario = _usuarioRepositorio.GetById(id);

            var usuarioId = new UsuarioDto
            {
                NombreUsuario = usuario.NombreUsuario,
                ClienteId = usuario.ClienteId,
                EstaBloqueado = usuario.EstaBloqueado,
                Id = usuario.Id,
                Password = usuario.Password,
                RowVersion = usuario.RowVersion
            };

            return usuarioId;
        }

        public UsuarioDto ObtenerPorNombre (string nombreUsuario, string password)
        {

            var passEncriptada = Encriptar.EncriptarCadena(password);

            var usus =_usuarioRepositorio.GetAll().FirstOrDefault(
                x => x.NombreUsuario == nombreUsuario && x.Password == passEncriptada);

            return new UsuarioDto
            {
                Id = usus.Id,
                ClienteId = usus.ClienteId,
                NombreUsuario = usus.NombreUsuario,
                EstaBloqueado = usus.EstaBloqueado,
                Password = usus.Password,
                RowVersion = usus.RowVersion
            };
        }
    }
}
