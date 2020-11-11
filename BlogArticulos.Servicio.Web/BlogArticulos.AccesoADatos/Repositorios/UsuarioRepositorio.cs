using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogArticulos.AccesoADatos.Entidades;
using BlogArticulos.AccesoADatos.Modelo;

namespace BlogArticulos.AccesoADatos.Repositorios
{
    public class UsuarioRepositorio
    {
        private BlogNoticiasEntities contexto;

        public UsuarioRepositorio()
        {
            contexto = new BlogNoticiasEntities();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            try
            {
                return contexto.Usuario
                    .OrderBy(x => x.idUsuario)
                    .Include(x => x.Perfil)
                    .Include(x => x.Perfil.Permiso)
                    .ToList();
            }
            catch
            {
                return null;
            }
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            return ObtenerUsuarios().Where(x => x.idUsuario == id).FirstOrDefault();
        }

        public Usuario ObtenerUsuarioPorNickYContrasena(string nick, string contrasena)
        {
            return ObtenerUsuarios().Where(x => x.nickName == nick && x.contrasena == contrasena).FirstOrDefault();
        }


    }
}
