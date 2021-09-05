using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Web2021B.Data.Model;

namespace Web2021B.Data.Service
{
    public class EstudianteService : IEstudianteService
    {
        private readonly SqlConnectionConfiguration _configuration;
        private string id_estudiante;

        public EstudianteService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> EstudianteInsert(Estudiante estudiante)
        {
            using (var conn = new SqlConnection(_configuration.Value))

            {
                var parameters = new DynamicParameters();
                parameters.Add("id_estudiante", estudiante.id_estudiante, DbType.Int32);
                parameters.Add("nombre", estudiante.nombre, DbType.String);
                parameters.Add("celular", estudiante.celular, DbType.String);
                parameters.Add("celular", estudiante.universidad, DbType.String);
                parameters.Add("semestre", estudiante.semestre, DbType.String);

                if (estudiante.id_estudiante == 0 || estudiante.nombre == "" || estudiante.celular == "" || estudiante.universidad == "" || estudiante.semestre == "")
                {
                    return false;
                }
                else
                {
                    const string query = @"INSERT INTO Estudiante (id_estudiante, nombre, celular, universidad, semestre) VALUES (@id_estudiante, @nombre,
                         @celular, @universidad, @semestre)";
                    await conn.ExecuteAsync(query, new { estudiante.id_estudiante, estudiante.nombre, estudiante.celular, estudiante.universidad, estudiante.semestre }, commandType: CommandType.Text);
                }
            }

            return true;
        }
    }
}


