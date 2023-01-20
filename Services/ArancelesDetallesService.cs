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
    public class ArancelesDetallesService : IArancelesDetallesService
    {
        tba_detalles _oArancelDetalle = new tba_detalles();
        List<tba_detalles> _oArancelesDetallesList = new List<tba_detalles>();
        public tba_detalles AddArancelDetalle(tba_detalles oArancelDetalle)
        {
            _oArancelDetalle = new tba_detalles();

            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var arancelDetalle = conex.Query<tba_detalles>("SP_InsertDetalles", this.setParameters(oArancelDetalle),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oArancelDetalle.Error = ex.Message;
            }
            return _oArancelDetalle;
        }

        public string DeleteArancelDetalles(int arancelDetallesId)
        {
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var paramId = new DynamicParameters();
                        paramId.Add("@codArancelesDetalles", arancelDetallesId);
                        conex.Query("SP_DeleteDetalles", paramId, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oArancelDetalle.Error = ex.Message;
            }
            return _oArancelDetalle.Error;
        }

        public tba_detalles GetArancelDetalleId(int arancelDetallesId)
        {
            _oArancelDetalle = new tba_detalles();
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                    }
                    var paramId = new DynamicParameters();
                    paramId.Add("@codArancelesDetalles", arancelDetallesId);
                    var oArancelDetalleId = conex.Query<tba_detalles>("SP_SelectDetalle", paramId, commandType: CommandType.StoredProcedure).ToList();

                    if (oArancelDetalleId != null && oArancelDetalleId.Count() > 0)
                    {
                        _oArancelDetalle = oArancelDetalleId.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oArancelDetalle.Error = ex.Message;
            }
            return _oArancelDetalle;
        }

        public List<tba_detalles> GetArancelesDetallesList()
        {
            _oArancelesDetallesList = new List<tba_detalles>();
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                    }
                    var oArancelesDetallesList = conex.Query<tba_detalles>("SP_SelectDetallesAll", commandType: CommandType.StoredProcedure).ToList();

                    if (oArancelesDetallesList != null && oArancelesDetallesList.Count() > 0)
                    {
                        _oArancelesDetallesList = oArancelesDetallesList;
                    }
                }
            }
            catch (Exception ex)
            {
                _oArancelDetalle.Error = ex.Message;
            }
            return _oArancelesDetallesList;
        }

        public tba_detalles UpdateArancelDetalle(tba_detalles oArancelDetalle)
        {
            _oArancelDetalle = new tba_detalles();

            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var oArancelDetalleUp = conex.Query<tba_detalles>("SP_UpdateDetalles", this.setParameters(oArancelDetalle), commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oArancelDetalle.Error = ex.Message;
            }
            return _oArancelDetalle;
        }

        private DynamicParameters setParameters(tba_detalles oArancelesDetalles)
        {
            DynamicParameters parameters = new DynamicParameters();

            if (oArancelesDetalles.codArancelesDetalles != 0)
            {
                parameters.Add("@codArancelesDetalles", oArancelesDetalles.codArancelesDetalles);
            }
            parameters.Add("@codAranceles", oArancelesDetalles.codAranceles);
            parameters.Add("@estado", oArancelesDetalles.estado);
            parameters.Add("@vencimiento", oArancelesDetalles.vencimiento);
            parameters.Add("@cancelacion", oArancelesDetalles.cancelacion);
            parameters.Add("@concepto", oArancelesDetalles.concepto);
            parameters.Add("@monto", oArancelesDetalles.monto);
            return parameters;
        }
    }
}
