using COMMON;
using ENTITY;
using ENTITY.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Reports
{

    public class Report
    {
        DataAccess da;
        public DataSet GetAllProductChecking(ProductChecking productChecking, int pageNo, int pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[9];
                prm[0] = new SqlParameter("@CreatedId", productChecking.CreatedBy);
                prm[1] = new SqlParameter("@AuctionDate", productChecking.AuctionDate);
                prm[2] = new SqlParameter("@AuctionId", productChecking.AuctionName);
                prm[3] = new SqlParameter("@Urgent", productChecking.Urgent);
                prm[4] = new SqlParameter("@ChassisNo ", productChecking.ChassisNo);
                prm[5] = new SqlParameter("@LID", "0");
                prm[6] = new SqlParameter("@PageIndex", pageNo);
                prm[7] = new SqlParameter("@PageSize", pageSize);
                prm[8] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("GetAllProductChecking", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllActivatedRpt(ActivationReport activationReport, int pageNo, int pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[9];
                prm[0] = new SqlParameter("@ActivatedId", activationReport.ActivatedBy);
                prm[1] = new SqlParameter("@AuctionDate", activationReport.AuctionDate);
                prm[2] = new SqlParameter("@AuctionId", activationReport.AuctionName);
                prm[3] = new SqlParameter("@Urgent", activationReport.Urgent);
                prm[4] = new SqlParameter("@ChassisNo ", activationReport.ChassisNo);
                prm[5] = new SqlParameter("@LID", "0");
                prm[6] = new SqlParameter("@PageIndex", pageNo);
                prm[7] = new SqlParameter("@PageSize", pageSize);
                prm[8] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("GetAllActivationRport", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDailyRptMasterData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetDailyReportMaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllDailyReportData(DailyReport dailyReport,int pageNo,int pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[12];
                prm[0] = new SqlParameter("@CategoryId", dailyReport.Category);
                prm[1] = new SqlParameter("@AuctionDate", dailyReport.AuctionDate);
                prm[2] = new SqlParameter("@Mdate", dailyReport.MDate);
                prm[3] = new SqlParameter("@AuctionId", dailyReport.AuctionName);
                prm[4] = new SqlParameter("@Urgent", dailyReport.Urgent);
                prm[5] = new SqlParameter("@TransportId", dailyReport.TransportName);
                prm[6] = new SqlParameter("@CarStatus", dailyReport.CarStatus);
                prm[7] = new SqlParameter("@RdateFrom", dailyReport.RDateFrom);
                prm[8] = new SqlParameter("@RdateTo", dailyReport.RDateTo);
                prm[9] = new SqlParameter("@PageIndex", pageNo);
                prm[10] = new SqlParameter("@PageSize", pageSize);
                prm[11] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("ViewDailyReport", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetYearlyRptMasterData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetYearlyMasterData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllYearlyRpt(YearlyReport yearlyReport,int pageNo,int pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[16];
                prm[0] = new SqlParameter("@ProductTypeId", yearlyReport.ProductType);
                prm[1] = new SqlParameter("@ChassisNo", yearlyReport.ChassisNo);
                prm[2] = new SqlParameter("@ClientId", yearlyReport.Client);
                prm[3] = new SqlParameter("@AuctionId", yearlyReport.AuctionName);
                prm[4] = new SqlParameter("@RdateFrom", yearlyReport.DateFrom);
                prm[5] = new SqlParameter("@RdateTo", yearlyReport.DateTo);
                prm[6] = new SqlParameter("@Urgent", yearlyReport.Urgent);
                prm[7] = new SqlParameter("@CountryId", yearlyReport.CountryName);
                prm[8] = new SqlParameter("@RegistrationDate", yearlyReport.RegDate);
                prm[9] = new SqlParameter("@ProductIn", yearlyReport.ProductIn);
                prm[10] = new SqlParameter("@CarStatus", yearlyReport.CarStatus);
                prm[11] = new SqlParameter("@MDate", yearlyReport.MDate);
                prm[12] = new SqlParameter("@UID", yearlyReport.UID);
                prm[13] = new SqlParameter("@PageIndex", pageNo);
                prm[14] = new SqlParameter("@PageSize", pageSize);
                prm[15] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("ViewYearlyReport", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetShippingMaster()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetShippingMasterData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllDownloadShiping(DownloadShipping downloadShipping, int pageNo,int pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[15];
                prm[0] = new SqlParameter("@CountryId", downloadShipping.Country);
                prm[1] = new SqlParameter("@ShippingId", downloadShipping.ShippingCmpny);
                prm[2] = new SqlParameter("@ClientId", downloadShipping.Client);
                prm[3] = new SqlParameter("@PortId", downloadShipping.PortName);
                prm[4] = new SqlParameter("@ShipId", downloadShipping.ShipName);
                prm[5] = new SqlParameter("@ChassisNo", downloadShipping.Chassis);
                prm[6] = new SqlParameter("@Surrendor", downloadShipping.Surrender);
                prm[7] = new SqlParameter("@BrokerId", downloadShipping.Broker);
                prm[8] = new SqlParameter("@DateFrom", downloadShipping.DateFrom);
                prm[9] = new SqlParameter("@DateTo", downloadShipping.DateTo);
                prm[10] = new SqlParameter("@CarStatus", downloadShipping.CarStatus);
                prm[11] = new SqlParameter("@UID", downloadShipping.UID);
                prm[12] = new SqlParameter("@PageIndex", pageNo);
                prm[13] = new SqlParameter("@PageSize", pageSize);
                prm[14] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("DownloadShiping", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllDownloadShipingYes(DownloadShipping downloadShipping, int pageNo, int pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[15];
                prm[0] = new SqlParameter("@CountryId", downloadShipping.Country);
                prm[1] = new SqlParameter("@ShippingId", downloadShipping.ShippingCmpny);
                prm[2] = new SqlParameter("@ClientId", downloadShipping.Client);
                prm[3] = new SqlParameter("@PortId", downloadShipping.PortName);
                prm[4] = new SqlParameter("@ShipId", downloadShipping.ShipName);
                prm[5] = new SqlParameter("@ChassisNo", downloadShipping.Chassis);
                prm[6] = new SqlParameter("@Surrendor", downloadShipping.Surrender);
                prm[7] = new SqlParameter("@BrokerId", downloadShipping.Broker);
                prm[8] = new SqlParameter("@DateFrom", downloadShipping.DateFrom);
                prm[9] = new SqlParameter("@DateTo", downloadShipping.DateTo);
                prm[10] = new SqlParameter("@CarStatus", downloadShipping.CarStatus);
                prm[11] = new SqlParameter("@UID", downloadShipping.UID);
                prm[12] = new SqlParameter("@PageIndex", pageNo);
                prm[13] = new SqlParameter("@PageSize", pageSize);
                prm[14] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("DownloadShipingYes", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllDownloadShipingNo(DownloadShipping downloadShipping, int pageNo, int pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[15];
                prm[0] = new SqlParameter("@CountryId", downloadShipping.Country);
                prm[1] = new SqlParameter("@ShippingId", downloadShipping.ShippingCmpny);
                prm[2] = new SqlParameter("@ClientId", downloadShipping.Client);
                prm[3] = new SqlParameter("@PortId", downloadShipping.PortName);
                prm[4] = new SqlParameter("@ShipId", downloadShipping.ShipName);
                prm[5] = new SqlParameter("@ChassisNo", downloadShipping.Chassis);
                prm[6] = new SqlParameter("@Surrendor", downloadShipping.Surrender);
                prm[7] = new SqlParameter("@BrokerId", downloadShipping.Broker);
                prm[8] = new SqlParameter("@DateFrom", downloadShipping.DateFrom);
                prm[9] = new SqlParameter("@DateTo", downloadShipping.DateTo);
                prm[10] = new SqlParameter("@CarStatus", downloadShipping.CarStatus);
                prm[11] = new SqlParameter("@UID", downloadShipping.UID);
                prm[12] = new SqlParameter("@PageIndex", pageNo);
                prm[13] = new SqlParameter("@PageSize", pageSize);
                prm[14] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("DownloadShipingNo", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ShippedCarsMaster()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("ShippedCarsMaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetShipDptMasterData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetShipDeparData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddShipDeparture(ShipDeparture shipDeparture)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@ShipId", shipDeparture.ShipName);
                prm[1] = new SqlParameter("@PortId", shipDeparture.PortName);
                prm[2] = new SqlParameter("@ArrivalDate", shipDeparture.ArrivalDate);
                prm[3] = new SqlParameter("@DepartureDate", shipDeparture.DepartureDate);
                prm[4] = new SqlParameter("@UID", shipDeparture.UID);
                return da.executeDMLQuery("AddShipDeparture", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllShipDeparture(int Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Id);
                return da.GetDataSet("GetAllShipDeparture", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateShipDeparture(ShipDeparture shipDeparture)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@ShipId", shipDeparture.ShipName);
                prm[1] = new SqlParameter("@PortId", shipDeparture.PortName);
                prm[2] = new SqlParameter("@ArrivalDate", shipDeparture.ArrivalDate);
                prm[3] = new SqlParameter("@DepartureDate", shipDeparture.DepartureDate);
                prm[4] = new SqlParameter("@UID", shipDeparture.UID);
                prm[5] = new SqlParameter("@Id", shipDeparture.Id);
                return da.executeDMLQuery("UpdateShipDeparture", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetShippedCars(ShippedCars shippedCars,int pageNo,int pageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[13];
                prm[0] = new SqlParameter("@ShippingId", shippedCars.Shipping);
                prm[1] = new SqlParameter("@CountryId", shippedCars.Country);
                prm[2] = new SqlParameter("@Client", shippedCars.ClientName);
                prm[3] = new SqlParameter("@PortId", shippedCars.Port);
                prm[4] = new SqlParameter("@ShipId", shippedCars.ShipName);
                prm[5] = new SqlParameter("@Chassis", shippedCars.ChassisNo);
                prm[6] = new SqlParameter("@Surrender", shippedCars.Surrender);
                prm[7] = new SqlParameter("@DateFrom", shippedCars.DateFrom);
                prm[8] = new SqlParameter("@DateTo", shippedCars.DateTo);
                prm[9] = new SqlParameter("@UID", shippedCars.UID);
                prm[10] = new SqlParameter("@PageIndex", pageNo);
                prm[11] = new SqlParameter("@PageSize", pageSize);
                prm[12] = new SqlParameter("@RecordCount", pageSize);
                return da.GetDataSet("ShipedCarsReport", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
