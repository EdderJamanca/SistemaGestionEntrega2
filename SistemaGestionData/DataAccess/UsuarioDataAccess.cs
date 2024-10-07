using Microsoft.EntityFrameworkCore;
using SistemaGestionData.Context;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.DataAccess
{
    public class UsuarioDataAccess
    {
        private readonly SistemaGestionContext _context;

        public UsuarioDataAccess(SistemaGestionContext context)
        {
            _context = context;
        }

        public  List<Usuario> GetAllUsuario()
        {

            return _context.Usuarios.ToList();
        }

        public Usuario createUsuario(Usuario usuario)
        {

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;


        }
        public  Usuario ObtenerUsuario(int idusuario)
        {

            Usuario usuario = _context.Usuarios.FirstOrDefault(p => p.Id == idusuario);
            return usuario;

        }

        public  void modificarUsuario(int id, Usuario usuario)
        {

            Usuario usuarioActual = ObtenerUsuario(id);
            if (usuarioActual != null)
            {
                usuarioActual.Nombre = usuario.Nombre;
                usuarioActual.Apellido = usuario.Apellido;
                usuarioActual.NombreUsuario = usuario.NombreUsuario;

                _context.SaveChanges();
            }
                
  

        }
        public  void DeleteUsuario(int id)
        {
            var usuario = ObtenerUsuario(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges(); // Guardar cambios en la base de datos
            }
        }
    }
}
