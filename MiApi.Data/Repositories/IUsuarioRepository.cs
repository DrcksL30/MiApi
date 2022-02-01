using MiApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApi.Data.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObtenerUsuariosActivos();
        Task<Usuario> ObtenerUsuarioDetalles(int id);
        Task<bool> InsertarUsuario(Usuario usuario);
        Task<bool> ActualizarUsuario(Usuario usuario);
        Task<Usuario> DesactivarUsuario(int id);

    }
}
