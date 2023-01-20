using Dapper;
using System.Data.Common;
using BackEnd_NuvisoftEducation.IServices;
using BackEnd_NuvisoftEducation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_NuvisoftEducation.Conexion;
using System.Net;
using System.Security.Cryptography;

namespace BackEnd_NuvisoftEducation.Services
{
    public class ColegioService : IColegioService
    {
        tb_colegio _oColegio = new tb_colegio();
        List<tb_colegio> _oColegioList = new List<tb_colegio>();

        public tb_colegio AddColegio(tb_colegio oColegio)
        {
            _oColegio = new tb_colegio();

            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var usuario = conex.Query<tb_colegio>("SP_InsertColegio", this.setParameters(oColegio),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oColegio.Error = ex.Message;
            }
            return _oColegio;
        }

        public string DeleteColegio(int colegioId)
        {
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var paramId = new DynamicParameters();
                        paramId.Add("@codColegio", colegioId);
                        conex.Query("SP_DeleteColegio", paramId, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oColegio.Error = ex.Message;
            }
            return _oColegio.Error;
        }

        public tb_colegio GetColegioId(int colegioId)
        {
            _oColegio = new tb_colegio();
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                    }
                    var paramId = new DynamicParameters();
                    paramId.Add("@codColegio", colegioId);
                    var oColegioId = conex.Query<tb_colegio>("SP_SelectColegio", paramId, commandType: CommandType.StoredProcedure).ToList();

                    if (oColegioId != null && oColegioId.Count() > 0)
                    {
                        _oColegio = oColegioId.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oColegio.Error = ex.Message;
            }
            return _oColegio;
        }

        public List<tb_colegio> GetColegioList()
        {
            _oColegioList = new List<tb_colegio>();
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                    }
                    var oColegioList = conex.Query<tb_colegio>("SP_SelectColegioAll", commandType: CommandType.StoredProcedure).ToList();

                    if (oColegioList != null && oColegioList.Count() > 0)
                    {
                        _oColegioList = oColegioList;
                    }
                }
            }
            catch (Exception ex)
            {
                _oColegio.Error = ex.Message;
            }
            return _oColegioList;
        }

        public tb_colegio UpdateColegio(tb_colegio oColegio)
        {
            _oColegio = new tb_colegio();

            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var oColegioUp = conex.Query<tb_rol>("SP_UpdateColegio", this.setParameters(oColegio), commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oColegio.Error = ex.Message;
            }
            return _oColegio;
        }
        private DynamicParameters setParameters(tb_colegio oColegio)
        {
            DynamicParameters parameters = new DynamicParameters();

            if (oColegio.codColegio != 0)
            {
                parameters.Add("@codColegio", oColegio.codColegio);
            }
            parameters.Add("@nombre", oColegio.nombre);
            parameters.Add("@descripcion", oColegio.descripcion);
            parameters.Add("@ubicacion", oColegio.ubicacion);
            parameters.Add("@direccion", oColegio.direccion);
            parameters.Add("@logotipo", oColegio.logotipo);
            parameters.Add("@correo", oColegio.correo);
            parameters.Add("@telefono", oColegio.telefono);
            return parameters;
        }
    }
}
