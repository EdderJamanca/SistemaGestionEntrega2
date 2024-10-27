using Microsoft.EntityFrameworkCore;
using SistemaGestionData.Context;
using SistemaGestionData.InterfaceDataAccess;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.DataAccess
{

    public class UsuarioDataAccess : IUsuarioDataAccess
    {
        private readonly SistemaGestionContext _context;

        public UsuarioDataAccess(SistemaGestionContext context)
        {
            _context = context;
        }

        public List<Usuario> GetAllUsuario()
        {

            return _context.Usuarios.ToList();
        }

        public Usuario createUsuario(Usuario usuario)
        {
            usuario.Salt = Guid.NewGuid().ToString();
            // Genera un salt y un hash para la contraseña
            var salt = Guid.NewGuid().ToString();
            var contrasenaHash = GenerarHash(usuario.Contrasena, salt);
            usuario.Contrasena = contrasenaHash;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;

        }
        public Usuario ObtenerUsuario(int idusuario)
        {

            Usuario usuario = _context.Usuarios.FirstOrDefault(p => p.Id == idusuario);
            return usuario;

        }

        public void modificarUsuario(int id, Usuario usuario)
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
        public void DeleteUsuario(int id)
        {
            var usuario = ObtenerUsuario(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges(); // Guardar cambios en la base de datos
            }
        }

        public async Task<Usuario?> Login(string email, string password)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Mail == email);
            if (usuario == null) return null;
            var isAutentico =VerificarContrasenaHash(password, usuario.Contrasena, usuario.Salt);
            if (!isAutentico)
            {
                return null;
            }
            return usuario;
        }
        private bool VerificarContrasenaHash(string password, string hashAlmacenada, string salt)
        {
            var hash = GenerarHash(password, salt);
            return hashAlmacenada == hash;
        }
        private string GenerarHash(string password, string salt)
        {
            using (var sha256tmp = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password + salt);
                var hash = sha256tmp.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
