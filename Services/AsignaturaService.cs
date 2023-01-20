using BackEnd_NuvisoftEducation.Conexion;
using BackEnd_NuvisoftEducation.IServices;
using BackEnd_NuvisoftEducation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Linq;

namespace BackEnd_NuvisoftEducation.Services
{
    public class AsignaturaService : IAsignaturaService
    {
        tb_asignatura _oAsignatura = new tb_asignatura();
        List<tb_asignatura> _oAsignaturaList = new List<tb_asignatura>();
        public tb_asignatura AddAsignatura(tb_asignatura oAsignatura)
        {
            _oAsignatura = new tb_asignatura();

            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var asignatura = conex.Query<tb_asignatura>("SP_InsertAsignatura", this.setParameters(oAsignatura),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oAsignatura.Error = ex.Message;
            }
            return _oAsignatura;
        }

        public string DeleteAsignatura(int asignaturaId)
        {
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var paramId = new DynamicParameters();
                        paramId.Add("@codAsignatura", asignaturaId);
                        conex.Query("SP_DeleteAsignatura", paramId, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oAsignatura.Error = ex.Message;
            }
            return _oAsignatura.Error;
        }

        public tb_asignatura GetAsignaturaId(int asignaturaId)
        {
            _oAsignatura = new tb_asignatura();
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                    }
                    var paramId = new DynamicParameters();
                    paramId.Add("@codAsignatura", asignaturaId);
                    var oAsignaturaId = conex.Query<tb_asignatura>("SP_SelectAsignatura", paramId, commandType: CommandType.StoredProcedure).ToList();

                    if (oAsignaturaId != null && oAsignaturaId.Count() > 0)
                    {
                        _oAsignatura = oAsignaturaId.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oAsignatura.Error = ex.Message;
            }
            return _oAsignatura;
        }

        public List<tb_asignatura> GetAsignaturasList()
        {
            _oAsignaturaList = new List<tb_asignatura>();
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                    }
                    var oAsignaturaList = conex.Query<tb_asignatura>("SP_SelectAsignaturaAll", commandType: CommandType.StoredProcedure).ToList();

                    if (oAsignaturaList != null && oAsignaturaList.Count() > 0)
                    {
                        _oAsignaturaList = oAsignaturaList;
                    }
                }
            }
            catch (Exception ex)
            {
                _oAsignatura.Error = ex.Message;
            }
            return _oAsignaturaList;
        }

        public tb_asignatura UpdateAsignatura(tb_asignatura oAsignatura)
        {
            _oAsignatura = new tb_asignatura();

            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var oAsignaturaUp = conex.Query<tb_asignatura>("SP_UpdateUsuario", this.setParameters(oAsignatura), commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oAsignatura.Error = ex.Message;
            }
            return _oAsignatura;
        }

        private DynamicParameters setParameters(tb_asignatura oAsignatura)
        {
            DynamicParameters parameters = new DynamicParameters();

            if (oAsignatura.codAsignatura != 0)
            {
                parameters.Add("@codAsignatura", oAsignatura.codAsignatura);
            }
            parameters.Add("@nombre", oAsignatura.nombre);
            parameters.Add("@descripcion", oAsignatura.descripcion);
            return parameters;
        }
    }
}
