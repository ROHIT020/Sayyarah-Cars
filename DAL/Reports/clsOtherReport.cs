using COMMON;
using ENTITY;
using ENTITY.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Reports
{
    public class clsOtherReport
    {
        DataAccess da;

        public DataSet GetAllFuzokuhin(int Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Id);
                return da.GetDataSet("GetAllFuzokuhin", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet GetDocumentMasterData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetAllDocumentmasterData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DocumentAllTransportByChasisNo(string ChassisNo)
        {
            try
            {
                ChassisNo = ChassisNo.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Chassisno", ChassisNo);
                return da.GetDataSet("DocumentAllTransportByChasisNo", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDocumentAllTransport(DocumentAllReport documentAllReport, string pageNo, string pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[15];
                prm[0] = new SqlParameter("@FromDate", documentAllReport.AuctionFDate);
                prm[1] = new SqlParameter("@DateTo", documentAllReport.AuctionTDate);
                prm[2] = new SqlParameter("@RikujiDate", documentAllReport.RikujiDate);
                prm[3] = new SqlParameter("@AuctionId", documentAllReport.AuctionName);
                prm[4] = new SqlParameter("@TransportId", documentAllReport.Transport);
                prm[5] = new SqlParameter("@PortId", documentAllReport.PortFrom);
                prm[6] = new SqlParameter("@CountryId", documentAllReport.SoldCountry);
                prm[7] = new SqlParameter("@CarStatus", documentAllReport.CarStatus);
                prm[8] = new SqlParameter("@NoPlate", documentAllReport.NoPlate);
                prm[9] = new SqlParameter("@Urgent", documentAllReport.Urgent);
                prm[10] = new SqlParameter("@Invoicetype", documentAllReport.InvoiceType);
                prm[11] = new SqlParameter("@ReAuction", documentAllReport.Reauction);
                prm[12] = new SqlParameter("@PageIndex", pageNo);
                prm[13] = new SqlParameter("@PageSize", pageSize);
                prm[14] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("GetDocumentAllTransport", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetRikujiReportMasterData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetDocumentRikujiReport");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet GetDocumentByRikujiReport(DocumentRikujiReport documentRikujiReport, int pageNo, int pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[11];
                prm[0] = new SqlParameter("@Rikujidate", documentRikujiReport.RikujiDate);
                prm[1] = new SqlParameter("@CountryId", Convert.ToInt32(documentRikujiReport.SoldCountry));
                prm[2] = new SqlParameter("@ChasisNo", documentRikujiReport.ChassisNo);
                prm[3] = new SqlParameter("@PortId", Convert.ToInt32(documentRikujiReport.PortName));
                prm[4] = new SqlParameter("@Urgent", documentRikujiReport.Urgent);
                prm[5] = new SqlParameter("@InvoiceType", Convert.ToInt32(documentRikujiReport.InvoiceType));
                prm[6] = new SqlParameter("@Reauction", documentRikujiReport.ReAuction);
                prm[7] = new SqlParameter("@UID", Convert.ToInt32(documentRikujiReport.UID));
                prm[8] = new SqlParameter("@PageIndex", pageNo);
                prm[9] = new SqlParameter("@PageSize", pageSize);
                prm[10] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("DocumentRikujiReport", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDocAnotherStatus(DocAnotherStatus docAnotherStatus, int pageNo, int pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[8];
                prm[0] = new SqlParameter("@DocumentCDate", docAnotherStatus.DocChangeDate);
                prm[1] = new SqlParameter("@ChassisNo", docAnotherStatus.ChassisNo);
                prm[2] = new SqlParameter("@InvoiceType", Convert.ToInt32(docAnotherStatus.InvoiceType));
                prm[3] = new SqlParameter("@ReAuction", docAnotherStatus.Reauction);
                prm[4] = new SqlParameter("@UID", docAnotherStatus.UID);
                prm[5] = new SqlParameter("@PageIndex", pageNo);
                prm[6] = new SqlParameter("@PageSize", pageSize);
                prm[7] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("DocumentAnotherStatus", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet checkchasisNo(string chassisNo)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ChassisNo", chassisNo);
                return da.GetDataSet("GetDataByChassisNo", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int addFuzokuhinData(string ChassisNo, string FuzokohinName, string FuzukohinIcon, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@ChassisNo", ChassisNo);
                prm[1] = new SqlParameter("@Fuzokuhin", FuzokohinName);
                prm[2] = new SqlParameter("@FuzokuhinIcon", FuzukohinIcon);
                prm[3] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddFuzokuhin", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDocumentAuctionkanri(DocumentAuctionKanri documentAuctionKanri, int pageNo, int pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[14];
                prm[0] = new SqlParameter("@AuctionId", documentAuctionKanri.AuctionName);
                prm[1] = new SqlParameter("@AuctionDate", documentAuctionKanri.AuctionDate);
                prm[2] = new SqlParameter("@PortId", documentAuctionKanri.PortName);
                prm[3] = new SqlParameter("@ChassisNo", documentAuctionKanri.ChassisNo);
                prm[4] = new SqlParameter("@InvoiceType", documentAuctionKanri.InvoiceType);
                prm[5] = new SqlParameter("@Reauction", documentAuctionKanri.Reauction);
                prm[6] = new SqlParameter("@CountryId", documentAuctionKanri.Country);
                prm[7] = new SqlParameter("@Noplate", documentAuctionKanri.NoPlate);
                prm[8] = new SqlParameter("@Urgent", documentAuctionKanri.Urgent);
                prm[9] = new SqlParameter("@CarStatus", documentAuctionKanri.CarStatus);
                prm[10] = new SqlParameter("@UID", documentAuctionKanri.UID);
                prm[11] = new SqlParameter("@PageIndex", pageNo);
                prm[12] = new SqlParameter("@PageSize", pageSize);
                prm[13] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("DocumentAuctionkanri", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GettransPortStatusMasterData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetTransportStatusMaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet GetAllTransportStatusByChasisNo(string ChassisNo)
        {
            try
            {
                ChassisNo = ChassisNo.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Chassisno", ChassisNo);
                return da.GetDataSet("GetTransportStatusByChno", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAlltranspoortStatus(TransportStatus transportStatus, int PageNo, int pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[14];
                prm[0] = new SqlParameter("@ShippinId", transportStatus.ShippingCompany);
                prm[1] = new SqlParameter("@PortId", transportStatus.PortName);
                prm[2] = new SqlParameter("@ShipId", transportStatus.ShipName);
                prm[3] = new SqlParameter("@Loading", transportStatus.Loading);
                prm[4] = new SqlParameter("@Urgent", transportStatus.Urgent);
                prm[5] = new SqlParameter("@ClientId", transportStatus.CustomerName);
                prm[6] = new SqlParameter("@ProductDate", transportStatus.ProductInDate);
                prm[7] = new SqlParameter("@ProductStatus", transportStatus.ProductInStatus);
                prm[8] = new SqlParameter("@RikujiDate", transportStatus.RikujiDate);
                prm[9] = new SqlParameter("@CountryId", transportStatus.SoldCountry);
                prm[10] = new SqlParameter("@DocStatus", transportStatus.DocumentsStatus);
                prm[11] = new SqlParameter("@PageIndex", PageNo);
                prm[12] = new SqlParameter("@PageSize", pageSize);
                prm[13] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("GetAllTransportStatus", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet GetFullReportmasterData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetFullReportMaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet GetFullReport(FullReport fullReport, int pageNo, int pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[13];
                prm[0] = new SqlParameter("@AuctionDate", fullReport.ActionDate);
                prm[1] = new SqlParameter("@AuctionId", fullReport.ActionName);
                prm[2] = new SqlParameter("@PortId", fullReport.PortFrom);
                prm[3] = new SqlParameter("@CountryId", fullReport.SoldCountry);
                prm[4] = new SqlParameter("@RikujiDate", fullReport.RikujiDate);
                prm[5] = new SqlParameter("@TransportId", fullReport.Transport);
                prm[6] = new SqlParameter("@ShippingId", fullReport.Shipping);
                prm[7] = new SqlParameter("@ChassisNo", fullReport.ChassisNo);
                prm[8] = new SqlParameter("@Urgent", fullReport.Urgent);
                prm[9] = new SqlParameter("@UID", fullReport.UID);
                prm[10] = new SqlParameter("@PageIndex", pageNo);
                prm[11] = new SqlParameter("@PageSize", pageSize);
                prm[12] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("GetFullReports", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet GetDocConformationRpt()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetConfirmationRpt");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet DocumentConfirmationByChasisNo(string chassisNo)
        {
            try
            {
                chassisNo = chassisNo.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Chassisno", chassisNo);
                return da.GetDataSet("GetDocConfirmationRpt", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDocAllCofrnReport(ShipConfirmationReport shipConfirmationReport, int pageNo, int pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[20];
                prm[0] = new SqlParameter("@ShippinId", shipConfirmationReport.ShippingCompany);
                prm[1] = new SqlParameter("@PortId", shipConfirmationReport.PortName);
                prm[2] = new SqlParameter("@Shipid", shipConfirmationReport.ShipName);
                prm[3] = new SqlParameter("@Loading", shipConfirmationReport.Loading);
                prm[4] = new SqlParameter("@Urgent", shipConfirmationReport.Urgent);
                prm[5] = new SqlParameter("@CustomerId", shipConfirmationReport.CustomerName);
                prm[6] = new SqlParameter("@ProductInDate", shipConfirmationReport.ProductInDate);
                prm[7] = new SqlParameter("@ProductInStatus", shipConfirmationReport.ProductInStatus);
                prm[8] = new SqlParameter("@OrderBy", shipConfirmationReport.Orderby);
                prm[9] = new SqlParameter("@RikujiDate", shipConfirmationReport.RikujiDate);
                prm[10] = new SqlParameter("@CountryId", shipConfirmationReport.SoldCountry);
                prm[11] = new SqlParameter("@InvoiceType", shipConfirmationReport.InvoiceType);
                prm[12] = new SqlParameter("@DocStatus", shipConfirmationReport.DocumentsStatus);
                prm[13] = new SqlParameter("@DateFrom", shipConfirmationReport.Datefrom);
                prm[14] = new SqlParameter("@DateTo", shipConfirmationReport.DateTo);
                prm[15] = new SqlParameter("@TransportId", shipConfirmationReport.Transport);
                prm[16] = new SqlParameter("@CarStatus", shipConfirmationReport.CarStatus);
                prm[17] = new SqlParameter("@PageIndex", pageNo);
                prm[18] = new SqlParameter("@PageSize", pageSize);
                prm[19] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("GetAllDocConfirmRpt", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetYardInMasterData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetYardInMasterData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllYardInData(YardInModel yardInModel)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("PortId", yardInModel.PortName);
                prm[1] = new SqlParameter("ChassisNo", yardInModel.ChassisNo);
                prm[2] = new SqlParameter("YardOut", yardInModel.YardOut);
                prm[3] = new SqlParameter("YardOutDate", yardInModel.YardOutDate);
                prm[4] = new SqlParameter("ShipId", yardInModel.ShipName);
                prm[5] = new SqlParameter("UID", Convert.ToInt32(yardInModel.UID));
                return da.GetDataSet("GetAllYardInData", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMasterEmployee()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetEmpMasterData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllAuctionData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetAuctionmaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
