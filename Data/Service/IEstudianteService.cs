using System;
using Dapper;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web2021B.Data.Model;

namespace Web2021B.Data.Service
{
    public interface IEstudianteService
    {
        Task<bool> EstudianteInsert(Estudiante estudiante);
    }
}