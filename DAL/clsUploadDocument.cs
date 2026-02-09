using COMMON;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsUploadDocument
    {
        DataAccess da;

        #region Rohit11092025
        public DataSet DocumentBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECTDOCUMENT");
            return da.GetDataSet("GetUploadMasterDropDown", prm);
        }
        public DataSet AuctionBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECTAUCTION");
            return da.GetDataSet("GetUploadMasterDropDown", prm);
        }
        public DataSet ShippingBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECTSHIPPING");
            return da.GetDataSet("GetUploadMasterDropDown", prm);
        }
        public DataSet TransportBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECTTRANSPORT");
            return da.GetDataSet("GetUploadMasterDropDown", prm);
        }
        public int InsertBillData(entUploadDocument obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@billtypeid", obj.billTypeId);
            prm[1] = new SqlParameter("@selectedid", obj.selectBillTypeId);
            prm[2] = new SqlParameter("@billdate", obj.billDate);
            prm[3] = new SqlParameter("@uploaddocument", obj.uploadDocument);
            prm[4] = new SqlParameter("@uid", obj.uid);
            prm[5] = new SqlParameter("@Action", "INSERTBILL");
            return da.executeDMLQuery("UploadBillInsertion", prm);
        }
        #endregion
    }
}
