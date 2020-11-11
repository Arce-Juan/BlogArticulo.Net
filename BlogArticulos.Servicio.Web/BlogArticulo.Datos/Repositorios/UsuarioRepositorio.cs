using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Instrumentation;
using System.Data.Entity;
using BlogArticulo.Datos.Contexto;
using BlogArticulo.Datos.Dominio;

namespace BlogArticulo.Datos.Repositorios
{
    public class UsuarioRepositorio
    {
        private BlogArticuloContexto contexto;

        public UsuarioRepositorio()
        {
            contexto = new BlogArticuloContexto();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            try
            {
                return contexto.Usuarios
                    .OrderBy(x => x.Id)
                    .Include(x => x.Perfil)
                    .Include(x => x.Perfil.ListaPermisos)
                    .ToList();
            }
            catch
            {
                return null;
            }
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            return ObtenerUsuarios().Where(x => x.Id == id).FirstOrDefault();
        }

        public Usuario ObtenerUsuarioPorNickYContrasena(string nick, string contrasena)
        {
            return ObtenerUsuarios().Where(x => x.NickName == nick && x.Contrasena == contrasena).FirstOrDefault();
        }

        public void AltaUsuario(Usuario usuario)
        {
            contexto.Usuarios.Add(usuario);
            contexto.SaveChanges();
        }

        public void ModificarUsuario(Usuario usuario)
        {
            var _usuario = contexto.Usuarios.FirstOrDefault(x => x.Id == usuario.Id);
            _usuario.Mail = usuario.Mail;
            _usuario.Contrasena = usuario.Contrasena;
            _usuario.Imagen = usuario.Imagen;
            _usuario.Activo = usuario.Activo;
            _usuario.Perfil_Id = usuario.Perfil_Id;
            contexto.SaveChanges();
        }

        public void EliminarUsuario(Usuario usuario)
        {
            usuario.Activo = 0;
            ModificarUsuario(usuario);
        }

        public void ModificarPerfilUsuario(Usuario usuario)
        {
            var _usuario = ObtenerUsuarioPorId(usuario.Id);
            _usuario.Mail = usuario.Mail;
            _usuario.Contrasena = usuario.Contrasena;
            _usuario.Imagen = usuario.Imagen;
            ModificarUsuario(_usuario);
        }

        public void ModificarActivoYTipoPefil(Usuario usuario)
        {
            var _usuario = ObtenerUsuarioPorId(usuario.Id);
            _usuario.Activo = usuario.Activo;
            _usuario.Perfil_Id = usuario.Perfil_Id;
            ModificarUsuario(_usuario);
        }

    }
}
