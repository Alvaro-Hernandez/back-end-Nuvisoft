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
    public class UsuarioService : IUsuarioService
    {
        tb_usuario _oUsuario = new tb_usuario();
        List<tb_usuario> _oUsuarioList = new List<tb_usuario>();

        public tb_usuario AddUsuario(tb_usuario oUsuario)
        {
            _oUsuario = new tb_usuario();

            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var usuario = conex.Query<tb_usuario>("SP_InsertUsuario", this.setParameters(oUsuario),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oUsuario.Error = ex.Message;
            }
            return _oUsuario;
        }

        public string DeleteUsuario(int usuarioId)
        {
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var paramId = new DynamicParameters();
                        paramId.Add("@codUsuario", usuarioId);
                        conex.Query("SP_DeleteUsuario", paramId, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oUsuario.Error = ex.Message;
            }
            return _oUsuario.Error;
        }

        public tb_usuario GetUsuarioId(int usuarioId)
        {
            _oUsuario = new tb_usuario();
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                    }
                    var paramId = new DynamicParameters();
                    paramId.Add("@codUsuario", usuarioId);
                    var oUsuarioId = conex.Query<tb_usuario>("SP_SelectPrivilegio", paramId, commandType: CommandType.StoredProcedure).ToList();

                    if (oUsuarioId != null && oUsuarioId.Count() > 0)
                    {
                        _oUsuario = oUsuarioId.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oUsuario.Error = ex.Message;
            }
            return _oUsuario;
        }

        public List<tb_usuario> GetUsuarioList()
        {
            _oUsuarioList = new List<tb_usuario>();
            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                    }
                    var oUsuarioList = conex.Query<tb_usuario>("SP_SelectPrivilegiosAll", commandType: CommandType.StoredProcedure).ToList();

                    if (oUsuarioList != null && oUsuarioList.Count() > 0)
                    {
                        _oUsuarioList = oUsuarioList;
                    }
                }
            }
            catch (Exception ex)
            {
                _oUsuario.Error = ex.Message;
            }
            return _oUsuarioList;
        }

        public tb_usuario UpdateRol(tb_usuario oUsuario)
        {
            _oUsuario = new tb_usuario();

            try
            {
                using (IDbConnection conex = new SqlConnection(Global.ConnectionString))
                {
                    if (conex.State == ConnectionState.Closed)
                    {
                        conex.Open();
                        var oUsuarioUp = conex.Query<tb_rol>("SP_UpdateUsuario", this.setParameters(oUsuario), commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oUsuario.Error = ex.Message;
            }
            return _oUsuario;
        }

        private DynamicParameters setParameters(tb_usuario oUsuario)
        {
            DynamicParameters parameters = new DynamicParameters();

            if (oUsuario.codUsuario != 0)
            {
                parameters.Add("@codUsuario", oUsuario.codUsuario);
            }
            parameters.Add("@codColegio", oUsuario.codColegio);
            parameters.Add("@nombres", oUsuario.nombres);
            parameters.Add("@apellidos", oUsuario.apellidos);
            parameters.Add("@email", oUsuario.email);
            parameters.Add("@usuario", oUsuario.usuario);
            parameters.Add("@contrasena", oUsuario.contrasena);
            parameters.Add("@dni", oUsuario.dni);
            return parameters;
        }
    }
}
