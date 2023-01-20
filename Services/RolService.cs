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

namespace BackEnd_NuvisoftEducation.Services
{
    public class RolService : IRolService
    {
        tb_rol _oRol = new tb_rol();
        List<tb_rol> _oRolList = new List<tb_rol>();

        public tb_rol AddRol(tb_rol oRol)
        {
            _oRol = new tb_rol();

            try
            {
                using(IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if(conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var Rol = conex.Query<tb_rol>("SP_InsertRol", this.setParameters(oRol),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oRol.Error = ex.Message;
            }
            return _oRol;
        }

        public string DeleteRol(int rolId)
        {
            try
            {
                using(IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if(conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var paramId = new DynamicParameters();
                        paramId.Add("@codRol", rolId);
                        conex.Query("SP_DeleteRol", paramId, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oRol.Error = ex.Message;
            }
            return _oRol.Error;
        }

        public tb_rol GetRolId(int rolId)
        {
            _oRol = new tb_rol();
            try
            {
                using(IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if(conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                    }
                    var paramId = new DynamicParameters();
                    paramId.Add("@codRol", rolId);
                    var oRolId = conex.Query<tb_rol>("SP_SelectRol", paramId, commandType: CommandType.StoredProcedure).ToList();

                    if(oRolId != null && oRolId.Count() > 0)
                    {
                        _oRol = oRolId.SingleOrDefault();
                    }
                }
            }
            catch(Exception ex)
            {
                _oRol.Error = ex.Message;
            }
            return _oRol;
        }

        public List<tb_rol> GetRolList()
        {
            _oRolList = new List<tb_rol>();
            try
            {
                using(IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if(conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                    }
                    var oRolList = conex.Query<tb_rol>("SP_SelectRolAll", commandType: CommandType.StoredProcedure).ToList();

                    if(oRolList != null && oRolList.Count() > 0)
                    {
                        _oRolList = oRolList;
                    }
                }
            }
            catch(Exception ex)
            {
                _oRol.Error = ex.Message;
            }
            return _oRolList;
        }

        public tb_rol UpdateRol(tb_rol oRol)
        {
            _oRol = new tb_rol();

            try
            {
                using(IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if(conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var oRolUp = conex.Query<tb_rol>("SP_UpdateRol", this.setParameters(oRol), commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch(Exception ex)
            {
                _oRol.Error = ex.Message;
            }
            return _oRol;
        }

        private DynamicParameters setParameters(tb_rol oRol)
        {
            DynamicParameters parameters = new DynamicParameters();

            if(oRol.codRol != 0) 
            {
                parameters.Add("@codRol", oRol.codRol);
            }

            parameters.Add("@rol", oRol.rol);
            return parameters;
        }
    }
}
