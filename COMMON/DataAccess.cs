using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace COMMON
{
    public class DataAccess
    {
        public DataAccess()
        {

        }




        #region All Propreties

        private SqlDataReader mydr;
        private SqlTransaction tran;
        private int retvalue;

        private SqlConnection _mycon;
        public SqlConnection mycon
        {
            get { return _mycon; }
            set { _mycon = value; }
        }
        private SqlCommand _mycmd;
        public SqlCommand mycmd
        {
            get { return _mycmd; }
            set { _mycmd = value; }
        }
        private SqlDataAdapter _myda;
        public SqlDataAdapter myda
        {
            get
            {
                if (_myda == null)
                {
                    _myda = new SqlDataAdapter();
                }
                return _myda;
            }
            set { _myda = value; }
        }
        private DataSet _myds;
        public DataSet myds
        {
            get
            {
                if (_myds == null)
                {
                    _myds = new DataSet();
                }
                return _myds;
            }
            set { _myds = value; }
        }
        #endregion

        public void OpenConnection()
        {
            if (_mycon == null)
                _mycon = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            if (_mycon.State != ConnectionState.Closed)
                return;
            _mycon.Open();
        }

        public void CloseConnection()
        {
            if (_mycon == null || _mycon.State != ConnectionState.Open)
                return;
            _mycon.Close();
        }
        private void DisposeConnection()
        {
            if (_mycon != null)
            {
                _mycon.Dispose();
                // Initialize Connection object with null.
                _mycon = null;
            }
        }
        public DataSet GetDataSet(string procname, SqlParameter[] sqlparam)
        {
            try
            {
                _myds = new DataSet();
                OpenConnection();
                _mycmd = new SqlCommand(procname, _mycon);
                _mycmd.CommandType = CommandType.StoredProcedure;
                _mycmd.Connection = _mycon;
                _mycmd.CommandText = procname;
                _mycmd.Parameters.AddRange(sqlparam);
                _myda = new SqlDataAdapter(_mycmd);
                _myda.Fill(_myds);
                CloseConnection();
                DisposeConnection();
                return _myds;
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex);
                return null;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        public DataSet GetDataSet(string procname)
        {
            try
            {
                _myds = new DataSet();
                OpenConnection();
                _mycmd = new SqlCommand(procname, _mycon);
                _mycmd.CommandType = CommandType.StoredProcedure;
                _mycmd.Connection = _mycon;
                _mycmd.CommandText = procname;
                _myda = new SqlDataAdapter(_mycmd);
                _myda.Fill(_myds);
                CloseConnection();
                DisposeConnection();
                return _myds;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }
        public DataSet GetDataSetInline(string qstring)
        {
            try
            {
                _myds = new DataSet();
                OpenConnection();
                _mycmd = new SqlCommand(qstring, _mycon);
                _myda = new SqlDataAdapter(_mycmd);
                _myda.Fill(_myds);
                CloseConnection();
                return _myds;
            }
            catch (Exception) { return null; }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }
        public int executeDMLQuery(string procname, SqlParameter[] sqlparam)
        {
            try
            {
                OpenConnection();
                tran = _mycon.BeginTransaction();
                _mycmd = new SqlCommand(procname, _mycon, tran);
                _mycmd.CommandType = CommandType.StoredProcedure;
                _mycmd.Connection = _mycon;
                _mycmd.CommandText = procname;
                _mycmd.Parameters.AddRange(sqlparam);
                retvalue = _mycmd.ExecuteNonQuery();
                if (((DbParameterCollection)_mycmd.Parameters).Contains("ReturnValue"))
                    retvalue = Convert.ToInt32(_mycmd.Parameters["ReturnValue"].Value);
                tran.Commit();
                _mycmd.Cancel();
                CloseConnection();
                return retvalue;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }
        public void executeDMLQueryinline(string strq)
        {
            try
            {
                OpenConnection();
                tran = _mycon.BeginTransaction();
                _mycmd = new SqlCommand(strq, _mycon, tran);
                _mycmd.ExecuteNonQuery();
                tran.Commit();
                CloseConnection();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }
        public string getexecutescalar(string procname, SqlParameter[] sqlparam)
        {
            try
            {
                OpenConnection();
                _mycmd = new SqlCommand(procname, _mycon);
                _mycmd.CommandType = CommandType.StoredProcedure;
                _mycmd.Connection = _mycon;
                _mycmd.CommandText = procname;
                _mycmd.Parameters.AddRange(sqlparam);
                string str = _mycmd.ExecuteScalar().ToString();
                CloseConnection();
                return str;
            }
            catch (Exception) { return null; }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }
        public string getexecutescalar(string procname)
        {
            try
            {
                OpenConnection();
                _mycmd = new SqlCommand(procname, _mycon);
                _mycmd.CommandType = CommandType.StoredProcedure;
                _mycmd.Connection = _mycon;
                _mycmd.CommandText = procname;
                string str = _mycmd.ExecuteScalar().ToString();
                CloseConnection();
                return str;
            }
            catch (Exception) { return null; }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }
        public SqlDataReader GetDataReader(string procname, SqlParameter[] sqlparam)
        {
            try
            {
                OpenConnection();
                _mycmd = new SqlCommand(procname, _mycon);
                _mycmd.CommandType = CommandType.StoredProcedure;
                _mycmd.Connection = _mycon;
                _mycmd.CommandText = procname;
                _mycmd.Parameters.AddRange(sqlparam);
                mydr = _mycmd.ExecuteReader(CommandBehavior.CloseConnection);
                return mydr;
            }
            catch (Exception) { return null; }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        public SqlDataReader GetDataReader(string procname)
        {
            try
            {
                OpenConnection();
                _mycmd = new SqlCommand(procname, _mycon);
                _mycmd.CommandType = CommandType.StoredProcedure;
                _mycmd.Connection = _mycon;
                _mycmd.CommandText = procname;
                mydr = _mycmd.ExecuteReader(CommandBehavior.CloseConnection);
                return mydr;
            }
            catch (Exception) { return null; }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        public SqlDataReader getDataReaderInline(string qstr)
        {
            try
            {
                OpenConnection();
                _mycmd = new SqlCommand(qstr, _mycon);
                mydr = _mycmd.ExecuteReader(CommandBehavior.CloseConnection);
                return mydr;
            }
            catch (Exception) { return null; }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }
    }
}
