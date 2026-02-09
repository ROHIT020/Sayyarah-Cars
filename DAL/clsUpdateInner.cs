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
    #region Rohit26092025
    public class clsUpdateInner
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

        public DataSet GetDataByChassisNo(string typeId)
        {
            try
            {
                typeId = typeId.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = { new SqlParameter("@ChassisNolist", typeId) };
                return da.GetDataSet("USP_GetChassisData", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Update-transport

        public DataSet UpdateShippingDetails(string CID, string PID, string AID, string Adate, string iPageNo, string iPageRecords)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm =
                {   new SqlParameter("@categoryid", CID),
                    new SqlParameter("@productid", PID),                    
                    new SqlParameter("@auctionid", AID),
                    new SqlParameter("@Adate", Adate),
                    new SqlParameter("@PageIndex", Convert.ToInt32(iPageNo)),
                    new SqlParameter("@PageSize", Convert.ToInt32(iPageRecords))
                };
                return da.GetDataSet("USP_GetAllTransportDetails", prm);
            }
            catch (Exception)
            {
                return new DataSet();
            }
        }
        public int UpdateTransportData(string PID, string Confirm, string TransportDate, string uid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm =
                {   new SqlParameter("@ProductId", PID),
                    new SqlParameter("@TransportConfirm", Confirm),
                    new SqlParameter("@TransportDate", TransportDate),                   
                    new SqlParameter("@UID", uid)             
                };
                return da.executeDMLQuery("USP_AddTransportDetails", prm);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion


        public DataSet InsertUpdateData(string CID, string PID, string CUID, string AID, string Adate, string iPageNo, string iPageRecords)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm =
                {
                    new SqlParameter("@categoryid", CID),
                    new SqlParameter("@productid", PID),
                    new SqlParameter("@clientid", CUID),
                    new SqlParameter("@auctionid", AID),
                    new SqlParameter("@Adate", Adate),
                    new SqlParameter("@PageIndex", Convert.ToInt32(iPageNo)),
                    new SqlParameter("@PageSize", Convert.ToInt32(iPageRecords))
                };
                return da.GetDataSet("USP_GetAllUpdateDetails", prm);
            }
            catch (Exception)
            {
                return new DataSet();
            }
        }

        public int InsertInnerData(string PID, string Iname, string Iweight, string Iprice, string uid, string PItype)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm =
                {
                    new SqlParameter("@productid", PID),
                    new SqlParameter("@Iname", Iname),
                    new SqlParameter("@Iprice", Iprice),
                    new SqlParameter("@Iweight", Iweight),
                    new SqlParameter("@UID", uid),
                    new SqlParameter("@PItype", PItype)
                };
                return da.executeDMLQuery("addInnerDetails", prm);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region Rohit - Update Consignee
        public DataSet UpdateConsigneeAll(string CID, string PID, string CUID, string AID, string Adate, string iPageNo, string iPageRecords)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm =
                {
                    new SqlParameter("@categoryid", CID),
                    new SqlParameter("@productid", PID),
                    new SqlParameter("@clientid", CUID),
                    new SqlParameter("@auctionid", AID),
                    new SqlParameter("@adate", Adate),
                    new SqlParameter("@PageIndex", Convert.ToInt32(iPageNo)),
                    new SqlParameter("@PageSize", Convert.ToInt32(iPageRecords))
                };
                return da.GetDataSet("USP_UpdateConsigneeAll", prm);
            }
            catch (Exception)
            {
                return new DataSet();
            }
        }
        #endregion

        #region Rohit - Update Consignee Document

        
        public int AddConsignee(string productid, string cfs, string consigname, string contact, string address, string aid, string uid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm =
                {
                    new SqlParameter("@productid", productid),
                    new SqlParameter("@cfs", cfs),
                    new SqlParameter("@consigname", consigname),
                    new SqlParameter("@contact", contact),
                    new SqlParameter("@address", address),
                    new SqlParameter("@aid", aid),
                    new SqlParameter("@uid", uid)
                };
                return da.executeDMLQuery("USP_InsertConsigneDataDML", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
        public int AddConsigneeDocs(entUploadConsignee consignee, string uid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm =
                {
                    new SqlParameter("@Id", consignee.Id),
                    new SqlParameter("@ProductId", consignee.productId),
                    new SqlParameter("@ConsigneeName", consignee.ConsigneeName),
                    new SqlParameter("@ConsigneeContact", consignee.ConsigneeContact),
                    new SqlParameter("@PassportImg1", consignee.PassportImg1),
                    new SqlParameter("@PassportImg2", consignee.PassportImg2),
                    new SqlParameter("@PassportImg3", consignee.PassportImg3),
                    new SqlParameter("@DocumentSnils", consignee.DocSnils),
                    new SqlParameter("@DocumentInn", consignee.DocInn),
                    new SqlParameter("@DocumentPayment", consignee.DocPayment),
                    new SqlParameter("@ConsigneeAddress", consignee.ConsigneeAddress),
                    new SqlParameter("@Uid", Convert.ToInt32(uid))
                };
                return da.executeDMLQuery("USP_UpdateConsigneDataDML", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet GetConsigneeDataByID(entUploadConsignee obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm =
                {
                    new SqlParameter("@Id", obj.Id),
                    new SqlParameter("@Action", obj.action)
                };
                return da.GetDataSet("USP_GetConsigneeDataById", prm);
            }
            catch (Exception)
            {
                return new DataSet();
            }
        }
        #endregion

        #region Auction Car
        public DataSet GetAuctionByChassisNo(string typeId)
        {
            try
            {
                typeId = typeId.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = { new SqlParameter("@ChassisNolist", typeId) };
                return da.GetDataSet("USP_GetAuctionCarByChassis", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllUpdateAuction(string CID, string PID, string AGP, string AID, string Adate, string LotNo, string iPageNo, string iPageRecords)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm =
                {   new SqlParameter("@CategoryId", CID),
                    new SqlParameter("@ProductId", PID),
                    new SqlParameter("@AuctionGroup", AGP),
                    new SqlParameter("@AuctionId", AID),
                    new SqlParameter("@ADate", Adate),
                    new SqlParameter("@LotNo", LotNo),
                    new SqlParameter("@PageIndex", Convert.ToInt32(iPageNo)),
                    new SqlParameter("@PageSize", Convert.ToInt32(iPageRecords))
                };
                return da.GetDataSet("USP_GetAllAuctionCarData", prm);
            }
            catch (Exception)
            {
                return new DataSet();
            }
        }
        public int UpdateAuctionCar(string productid, string oldauction, string newauction, string transport, string auctiondate, string remark, string uid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm =
                {   new SqlParameter("@ProductId", productid),
                    new SqlParameter("@OldAuctionId", oldauction),
                    new SqlParameter("@NewAuctionId", newauction),
                    new SqlParameter("@TransportId",transport),
                    new SqlParameter("@AuctionDate", auctiondate),
                    new SqlParameter("@Remark",remark),
                    new SqlParameter("@UID", uid)
                };
                return da.executeDMLQuery("USP_AddAuctionCarData", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region View Auction
        public DataSet ViewAuctionByChassisNo(string typeId)
        {
            try
            {
                typeId = typeId.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = { new SqlParameter("@ChassisNolist", typeId) };
                return da.GetDataSet("USP_ViewAuctionCarByChassis", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ViewAllUpdateAuction(string CID, string PID, string AGP, string AID, string Adate, string LotNo, string iPageNo, string iPageRecords)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm =
                {   new SqlParameter("@CategoryId", CID),
                    new SqlParameter("@ProductId", PID),
                    new SqlParameter("@AuctionGroup", AGP),
                    new SqlParameter("@AuctionId", AID),
                    new SqlParameter("@ADate", Adate),
                    new SqlParameter("@LotNo", LotNo),
                    new SqlParameter("@PageIndex", Convert.ToInt32(iPageNo)),
                    new SqlParameter("@PageSize", Convert.ToInt32(iPageRecords))
                };
                return da.GetDataSet("USP_ViewAllAuctionCarData", prm);
            }
            catch (Exception)
            {
                return new DataSet();
            }
        }
        public int DeleteAuctionCar(string Id, string Pid, string Uid)
        {
            da = new DataAccess();
            SqlParameter[] prm = {
               new SqlParameter("@Id", Id),
               new SqlParameter("@Pid", Pid),
               new SqlParameter("@Uid", Uid)

            };
            return da.executeDMLQuery("USP_DeleteAuctionCar", prm);
        }
        #endregion
    }
}
