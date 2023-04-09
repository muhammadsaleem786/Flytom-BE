using Common.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModel
{
    public class DataAccessManager
    {
        string ConnectionString = "";
        public DataAccessManager()
        {
            ConnectionString = AppSettingHelper.GetDefaultConnection();
        }

        public static object ExecuteNonQuery(string Command, Hashtable hsh_Parameters, string outParamName, SqlDbType type4outParam, int size4OutParam)
        {
            SqlConnection objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["HMSContext"].ConnectionString);
            SqlCommand objCommand = new SqlCommand(Command, objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                if (hsh_Parameters != null)
                {
                    IDictionaryEnumerator obj_Enm = hsh_Parameters.GetEnumerator();
                    while (obj_Enm.MoveNext())
                    {
                        objCommand.Parameters.AddWithValue(obj_Enm.Key.ToString(), obj_Enm.Value);
                    }
                }

                objCommand.Parameters[outParamName].SqlDbType = type4outParam;
                if (size4OutParam > 0)
                    objCommand.Parameters[outParamName].Size = size4OutParam;
                objCommand.Parameters[outParamName].Direction = ParameterDirection.Output;

                objConnection.Open();
                objCommand.ExecuteNonQuery();

                return objCommand.Parameters[outParamName].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objCommand != null)
                {
                    objCommand.Dispose();
                }
                if (!(objConnection.State == ConnectionState.Closed))
                {
                    objConnection.Close();
                }
            }
        }
        public int ExecuteNonQuery(string Command, Hashtable hsh_Parameters)
        {
            SqlConnection objConnection = new SqlConnection(ConnectionString);
            SqlCommand objCommand = new SqlCommand(Command, objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                if (hsh_Parameters != null)
                {
                    IDictionaryEnumerator obj_Enm = hsh_Parameters.GetEnumerator();
                    while (obj_Enm.MoveNext())
                    {
                        objCommand.Parameters.AddWithValue(obj_Enm.Key.ToString(), obj_Enm.Value);
                    }
                }

                objConnection.Open();
                return objCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objCommand != null)
                {
                    objCommand.Dispose();
                }
                if (!(objConnection.State == ConnectionState.Closed))
                {
                    objConnection.Close();
                }
            }
        }
        public SqlDataReader ExecuteReaderWithCommand(string Command)
        {
            SqlConnection objConnection = new SqlConnection(ConnectionString);
            SqlCommand objCommand = new SqlCommand(Command, objConnection);

            try
            {
                objConnection.Open();
                return (objCommand.ExecuteReader(CommandBehavior.CloseConnection));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objCommand != null)
                {
                    objCommand.Dispose();
                }
            }
        }

        public DataSet GetDataSet(string Command, Hashtable hsh_Parameters)
        {
            try
            {
                SqlDataAdapter objDA = new SqlDataAdapter(Command, ConnectionString);
                objDA.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                if (hsh_Parameters != null)
                {
                    IDictionaryEnumerator obj_Enm = hsh_Parameters.GetEnumerator();
                    while (obj_Enm.MoveNext())
                    {
                        objDA.SelectCommand.Parameters.AddWithValue(obj_Enm.Key.ToString(), obj_Enm.Value);
                    }
                }
                DataSet objDS = new DataSet();
                objDA.Fill(objDS);
                return (objDS);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDataTable(string Command, SqlParameter[] SQL_Parameters)
        {
            try
            {
                SqlDataAdapter objDA = new SqlDataAdapter(Command, AppSettingHelper.GetDefaultConnection());
                objDA.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                foreach (SqlParameter sqlParameter in SQL_Parameters)
                    objDA.SelectCommand.Parameters.Add(sqlParameter);

                DataTable objDS = new DataTable();
                objDA.Fill(objDS);
                return (objDS);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetDataTable(string Command)
        {
            try
            {
                SqlDataAdapter objDA = new SqlDataAdapter(Command, ConnectionString);

                DataTable objDS = new DataTable();
                objDA.Fill(objDS);
                return (objDS);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
