using Dapper;
using MiApi.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApi.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private PostgreSQLConfiguration _connectionString;
        public UsuarioRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> ActualizarUsuario(Usuario usuario)
        {
            var db = dbConnection();
            var sql = @"
                            UPDATE public.info_usuario 
                            SET 
                                id_login = @Id,
                                nombre = @Nombre,
                                apellido_paterno = @Apellido_Paterno
                                apellido_materno = @Apellido_Materno,
                                id_puesto = @Id_Puesto,-
                                activo = @Activo
                           WHERE id = @id;
                        ";
            var result = await db.ExecuteAsync(sql, new { usuario.Id, usuario.Nombre, usuario.Apellido_Paterno, usuario.Apellido_Materno, usuario.Id_Puesto });
            return result > 0;
        }

        public async Task<Usuario> DesactivarUsuario(int id)
        {
            var db = dbConnection();
            var sql = @"
                            UPDATE public.login 
                            SET 
                                activo = false
                           WHERE id = @id;
                        ";
            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }

        public async Task<bool> InsertarUsuario(Usuario usuario)
        {
            var db = dbConnection();
            var sql = @"
                            INSERT INTO public.info_usuario (id_login, nombre, apellido_paterno, apellido_materno, id_puesto)
                            VALUES(@Id, @Nombre, @Apellido_Paterno, @Apellido_Materno, @Id_Puesto);
                        ";
            var result = await db.ExecuteAsync(sql, new { usuario.Id, usuario.Nombre, usuario.Apellido_Paterno, usuario.Apellido_Materno, usuario.Id_Puesto });
            return result > 0;
        }

        public async Task<Usuario> ObtenerUsuarioDetalles(int id)
        {
            
            var db = dbConnection();
            var sql = @"
                            SELECT id_login, nombre, apellido_paterno, apellido_materno, id_puesto FROM public.info_usuario WHERE id = @Id;
                        ";
            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuariosActivos()
        {
            var db = dbConnection();
            var sql = @"
                            SELECT id, correo, password, activo FROM public.login WHERE activo = true;
                        ";
            return await db.QueryAsync<Usuario>(sql, new { });
        }
    }
}
