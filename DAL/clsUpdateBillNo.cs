using COMMON;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsUpdateBillNo
    {
        DataAccess da;
        public DataSet GetPortByShipName(int shippingId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prms = { new SqlParameter("@shipId", shippingId) };
                return da.GetDataSet("GetPortByShipId", prms);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet InsertBillNo(string categoryid, string productid, string shippingId, string shipId,string portId, string iPageNo, string iPageRecords)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[7];
                prm[0] = new SqlParameter("@categoryid", categoryid);
                prm[1] = new SqlParameter("@productid", productid);
                prm[2] = new SqlParameter("@shippingId", shippingId);
                prm[3] = new SqlParameter("@shipId", shipId);                
                prm[4] = new SqlParameter("@portId", portId);
                prm[5] = new SqlParameter("@PageIndex", iPageNo);
                prm[6] = new SqlParameter("@PageSize", iPageRecords);                
                return da.GetDataSet("USP_UpdateBillNo", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }
        public int UpdateBillData(string productid, string billno, string uid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@productid", productid);
                prm[1] = new SqlParameter("@billno", billno);                
                prm[2] = new SqlParameter("@UID", uid);
                return da.executeDMLQuery("USP_AddBillNo", prm);                 
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
    }
}
