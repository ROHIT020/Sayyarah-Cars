using COMMON;
using ENTITY;
using System;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class clsUseMasters
    {
        DataAccess da;


        public static DataSet CallSearchProcedure(string procedureName, string searchText)
        {
            try
            {
                DataAccess da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@SearchText", searchText);
                return da.GetDataSet(procedureName, prm);
            }
            catch
            {
                throw;
            }
        }
        public DataSet ListCountry()
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Action", "FORUSE");
                return da.GetDataSet("USP_CountryMasterDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet PortBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "FORUSE");
            return da.GetDataSet("USP_PortMasterDML", prm);
        }
        public DataSet ListPortByCountryID(string CountryId)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Action", "FORUSE");
            prm[1] = new SqlParameter("@CountryId", CountryId);
            return da.GetDataSet("USP_PortMasterDML", prm);
        }
        public DataSet ListCompanyDetails(string cid="0")
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@id", cid);
            return da.GetDataSet("USP_SelectCompanyDetails",prm);
        }
    }
}
