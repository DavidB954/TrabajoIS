using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Usuario
    {
        DAL_Usuario dal_usuario = new DAL_Usuario();

        public BE_Usuario VerificarUsuario(string email, string pass, out string mensaje)
        {
            string Hash = HashHelper.GenerarHash(pass);
           
            return dal_usuario.VerificarUsuario(email, Hash, out mensaje);
        }

        public List<BE_Usuario> ListaUsuarios()
        {
            return dal_usuario.ListaUsuario();
        }

        public void AgregarUsuario(BE_Usuario usuario)
        {
            usuario.HashPassword = HashHelper.GenerarHash(usuario.HashPassword);
            dal_usuario.AgregarUsuario(usuario);
        }

        public void ModificarUsuario(BE_Usuario usuario)
        {
            dal_usuario.ModificarUsuario(usuario);
        }

        public void EliminarUsuario(int id)
        {
            dal_usuario.EliminarUsuario(id);
        }

        public void ResetearPassword(int id, string nuevoPass)
        {
            nuevoPass = HashHelper.GenerarHash(nuevoPass);
            
            dal_usuario.ResetearContrasena(id, nuevoPass);
        }
    }
}
