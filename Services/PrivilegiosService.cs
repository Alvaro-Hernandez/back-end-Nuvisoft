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
    public class PrivilegiosService : IPrivilegiosService
    {
        tb_privilegios _oPrivilegio = new tb_privilegios();
        List<tb_privilegios> _oPrivilegioList = new List<tb_privilegios>();
        public tb_privilegios AddPrivilegios(tb_privilegios oPrivilegios)
        {
            _oPrivilegio = new tb_privilegios();

            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var privilegios = conex.Query<tb_privilegios>("SP_InsertPrivilegios", this.setParameters(oPrivilegios),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oPrivilegio.Error = ex.Message;
            }
            return _oPrivilegio;
        }

        public string DeletePrivilegios(int privilegioId)
        {
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var paramId = new DynamicParameters();
                        paramId.Add("@codPrivilegios", privilegioId);
                        conex.Query("SP_DeletePrivilegio", paramId, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oPrivilegio.Error = ex.Message;
            }
            return _oPrivilegio.Error;
        }

        public tb_privilegios GetPrivilegioId(int privilegioId)
        {
            _oPrivilegio = new tb_privilegios();
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                    }
                    var paramId = new DynamicParameters();
                    paramId.Add("@codPrivilegios", privilegioId);
                    var oPrivilegioId = conex.Query<tb_privilegios>("SP_SelectPrivilegio", paramId, commandType: CommandType.StoredProcedure).ToList();

                    if (oPrivilegioId != null && oPrivilegioId.Count() > 0)
                    {
                        _oPrivilegio = oPrivilegioId.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oPrivilegio.Error = ex.Message;
            }
            return _oPrivilegio;
        }

        public List<tb_privilegios> GetPrivilegiosList()
        {
            _oPrivilegioList = new List<tb_privilegios>();
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                    }
                    var oPrivilegioList = conex.Query<tb_privilegios>("SP_SelectPrivilegiosAll", commandType: CommandType.StoredProcedure).ToList();

                    if (oPrivilegioList != null && oPrivilegioList.Count() > 0)
                    {
                        _oPrivilegioList = oPrivilegioList;
                    }
                }
            }
            catch (Exception ex)
            {
                _oPrivilegio.Error = ex.Message;
            }
            return _oPrivilegioList;
        }

        public tb_privilegios UpdatePrivilegios(tb_privilegios oPrivilegios)
        {
            _oPrivilegio = new tb_privilegios();

            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var oRolUp = conex.Query<tb_privilegios>("SP_UpdatePrivilegios", this.setParameters(oPrivilegios), commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oPrivilegio.Error = ex.Message;
            }
            return _oPrivilegio;
        }

        private DynamicParameters setParameters(tb_privilegios oPrivilegio)
        {
            DynamicParameters parameters = new DynamicParameters();

            if (oPrivilegio.codPrivilegios != 0)
            {
                parameters.Add("@codPrivilegios", oPrivilegio.codPrivilegios);
            }
            parameters.Add("@codRol", oPrivilegio.codRol);
            parameters.Add("@codUsuario", oPrivilegio.codUsuario);
            return parameters;
        }
    }
}
