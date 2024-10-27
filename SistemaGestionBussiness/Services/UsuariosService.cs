using SistemaGestionData.DataAccess;
using SistemaGestionData.InterfaceDataAccess;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness.Services
{
    public interface IUsuariosService
    {
        Usuario CreateUsuario(Usuario usuario);
        void DeleteUsuario(int id);
        Usuario? GetOneUsuario(int id);
        List<Usuario> GetUsuarios();
        Task<Usuario?> Login(string email, string password);
        void UpdateUsuario(int id, Usuario usuario);
    }

    public class UsuariosService : IUsuariosService
    {
        private IUsuarioDataAccess _usuarioDataAccess;

        public UsuariosService(IUsuarioDataAccess usuarioDataAccess)
        {
            _usuarioDataAccess = usuarioDataAccess;
        }

        public List<Usuario> GetUsuarios()
        {
            return _usuarioDataAccess.GetAllUsuario();
        }
        public Usuario? GetOneUsuario(int id)
        {
            return _usuarioDataAccess.ObtenerUsuario(id);
        }
        public Usuario CreateUsuario(Usuario usuario)
        {
            return _usuarioDataAccess.createUsuario(usuario);
        }

        public void UpdateUsuario(int id, Usuario usuario)
        {
            _usuarioDataAccess.modificarUsuario(id, usuario);
        }
        public void DeleteUsuario(int id)
        {
            _usuarioDataAccess.DeleteUsuario(id);
        }
        public async Task<Usuario?> Login(string email, string password)
        {
            return await _usuarioDataAccess.Login(email, password);
        }

    }
}
