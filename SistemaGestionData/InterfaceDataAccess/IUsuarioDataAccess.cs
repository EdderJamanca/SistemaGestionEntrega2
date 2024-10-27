using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.InterfaceDataAccess
{
    public interface IUsuarioDataAccess
    {
        Usuario createUsuario(Usuario usuario);
        void DeleteUsuario(int id);
        List<Usuario> GetAllUsuario();
        Task<Usuario?> Login(string email, string password);
        void modificarUsuario(int id, Usuario usuario);
        Usuario ObtenerUsuario(int idusuario);
    }
}
