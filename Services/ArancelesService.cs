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
    public class ArancelesService : IArancelesService
    {
        tb_aranceles _oArancel = new tb_aranceles();
        List<tb_aranceles> _oArancelesList = new List<tb_aranceles>();

        public tb_aranceles AddArancel(tb_aranceles oArancel)
        {
            _oArancel = new tb_aranceles();

            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var arancel = conex.Query<tb_aranceles>("SP_InsertAranceles", this.setParameters(oArancel),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oArancel.Error = ex.Message;
            }
            return _oArancel;
        }

        public string DeleteArancel(int arancelId)
        {
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var paramId = new DynamicParameters();
                        paramId.Add("@codAranceles", arancelId);
                        conex.Query("SP_DeleteAranceles", paramId, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oArancel.Error = ex.Message;
            }
            return _oArancel.Error;
        }

        public tb_aranceles GetArancelId(int arancelId)
        {
            _oArancel = new tb_aranceles();
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                    }
                    var paramId = new DynamicParameters();
                    paramId.Add("@codAranceles", arancelId);
                    var oArancelId = conex.Query<tb_aranceles>("SP_SelectArancel", paramId, commandType: CommandType.StoredProcedure).ToList();

                    if (oArancelId != null && oArancelId.Count() > 0)
                    {
                        _oArancel = oArancelId.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oArancel.Error = ex.Message;
            }
            return _oArancel;
        }
        public List<tb_aranceles> GetArancelesList()
        {
            _oArancelesList = new List<tb_aranceles>();
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                    }
                    var oArancelesList = conex.Query<tb_aranceles>("SP_SelectColegioAll", commandType: CommandType.StoredProcedure).ToList();

                    if (oArancelesList != null && oArancelesList.Count() > 0)
                    {
                        _oArancelesList = oArancelesList;
                    }
                }
            }
            catch (Exception ex)
            {
                _oArancel.Error = ex.Message;
            }
            return _oArancelesList;
        }

        public tb_aranceles UpdateArancel(tb_aranceles oArancel)
        {
            _oArancel = new tb_aranceles();

            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var oArancelUp = conex.Query<tb_rol>("SP_UpdateAranceles", this.setParameters(oArancel), commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oArancel.Error = ex.Message;
            }
            return _oArancel;
        }

        private DynamicParameters setParameters(tb_aranceles oAranceles)
        {
            DynamicParameters parameters = new DynamicParameters();

            if (oAranceles.codAranceles != 0)
            {
                parameters.Add("@codAranceles", oAranceles.codAranceles);
            }
            parameters.Add("@codUsuario", oAranceles.codUsuario);
            parameters.Add("@estado", oAranceles.estado);
            return parameters;
        }
    }
}
