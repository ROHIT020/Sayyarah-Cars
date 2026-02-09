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
    public class clsUpdateRemark
    {
        DataAccess da;
        public DataSet AllUpdateDropdown()
        {
            da = new DataAccess();
            return da.GetDataSet("USP_GetAllDropdown");
        }
        public DataSet GetProductNameByType(int categoryTypeId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prms = { new SqlParameter("@productTypeId", categoryTypeId) };
                return da.GetDataSet("GetProductNameDDL", prms);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetUpdateMakerData(string typeId)
        {
            typeId = typeId.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@ChassisNolist", typeId);
            return da.GetDataSet("USP_GetChassisData", prm);
        }
        
        public DataSet InsertRemarkData(string CID, string PID, string AID, string Adate,string TID, string iPageNo, string iPageRecords)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[7];
                prm[0] = new SqlParameter("@CategoryId", CID);
                prm[1]= new SqlParameter("@ProductId",PID);
                prm[2]= new SqlParameter("@AuctionId",AID);
                prm[3]= new SqlParameter("@Adate",Adate);
                prm[4]= new SqlParameter("@TransportId",TID);
                prm[5] = new SqlParameter("@PageIndex", iPageNo);
                prm[6] = new SqlParameter("@PageSize", iPageRecords);                
                return da.GetDataSet("USP_GetAllRemarkDetails", prm);
            }
            catch(Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }
        public int InsertGridData(string productid, string auctionremark, string rickshawremark, string portremark, string numplate, string numplateremark,string oremark,string uid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[8];
                prm[0] = new SqlParameter("@productid", productid);
                prm[1] = new SqlParameter("@auctionremark", auctionremark);
                prm[2] = new SqlParameter("@rickshawremark", rickshawremark);
                prm[3] = new SqlParameter("@portremark", portremark);
                prm[4] = new SqlParameter("@numplate", numplate);
                prm[5] = new SqlParameter("@numplateremark", numplateremark);
                prm[6] = new SqlParameter("@oremark", oremark);
                prm[7] = new SqlParameter("@uid", uid);
                return da.executeDMLQuery("AddGridDetails", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
    }
}
