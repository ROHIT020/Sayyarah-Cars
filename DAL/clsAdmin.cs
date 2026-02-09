using COMMON;
using ENTITY;
using ENTITY.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class clsAdmin
    {
        DataAccess da;

        #region Added By Ramesh
        public int AddShip(AddShip addShip, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[13];
                prm[0] = new SqlParameter("@ShippingCompanyId", addShip.ShippingCompany);
                prm[1] = new SqlParameter("@PortId", addShip.PortFrom);
                prm[2] = new SqlParameter("@TerminalId", addShip.TerminalName);
                prm[3] = new SqlParameter("@CountryId", addShip.CountryName);
                prm[4] = new SqlParameter("@ShipName", addShip.ShipName);
                prm[5] = new SqlParameter("@DepartureDate", addShip.DepartureDate);
                prm[6] = new SqlParameter("@ArrivalDate", addShip.ArrivalDate);
                prm[7] = new SqlParameter("@ShipFreight", addShip.ShipFreight);
                prm[8] = new SqlParameter("@UID", UID);
                prm[9] = new SqlParameter("@shiptype", addShip.shiptype);
                prm[10] = new SqlParameter("@ShipCapacity", addShip.ShipCapacity);
                prm[11] = new SqlParameter("@ShipUse", addShip.ShipUse);
                prm[12] = new SqlParameter("@Action", "INSERT");
                return da.executeDMLQuery("USP_ManageShipDML", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet ViewaShipDetails(string shipingCompanyId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@ShippingCompanyId", Convert.ToInt32(shipingCompanyId));
                prm[1] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("USP_ManageShipDML", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet ViewaShipDetailsById(string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                prm[1] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("USP_ManageShipDML", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int updateAddShip(AddShip addShip, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[14];
                prm[0] = new SqlParameter("@ShippingCompanyId", addShip.ShippingCompany);
                prm[1] = new SqlParameter("@PortId", addShip.PortFrom);
                prm[2] = new SqlParameter("@TerminalId", addShip.TerminalName);
                prm[3] = new SqlParameter("@CountryId", addShip.CountryName);
                prm[4] = new SqlParameter("@ShipName", addShip.ShipName);
                prm[5] = new SqlParameter("@DepartureDate", addShip.DepartureDate);
                prm[6] = new SqlParameter("@ArrivalDate", addShip.ArrivalDate);
                prm[7] = new SqlParameter("@ShipFreight", addShip.ShipFreight);
                prm[8] = new SqlParameter("@UID", UID);
                prm[9] = new SqlParameter("@Id", addShip.Id);
                prm[10] = new SqlParameter("@shiptype", addShip.shiptype);
                prm[11] = new SqlParameter("@ShipCapacity", addShip.ShipCapacity);
                prm[12] = new SqlParameter("@ShipUse", addShip.ShipUse);
                prm[13] = new SqlParameter("@Action", "UPDATE");
                return da.executeDMLQuery("USP_ManageShipDML", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet DeleteShipDetail(int ID, int UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@UID", Convert.ToInt32(UID));
                prm[1] = new SqlParameter("@Id", Convert.ToInt32(ID));
                prm[2] = new SqlParameter("@Action", "DELETE");
                return da.GetDataSet("USP_ManageShipDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getShipingPortTAndCountryData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetMasterData");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet getShipingPriceMasterData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetShipPriceMaster");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int addShipingPrice(ShipingPriceModel shipingPrice, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@ShipingCompanyId", shipingPrice.ShipingCompany);
                prm[1] = new SqlParameter("@ProductId", shipingPrice.ProductType);
                prm[2] = new SqlParameter("@CountryId", shipingPrice.CountryName);
                prm[3] = new SqlParameter("@PortId", shipingPrice.PortName);
                prm[4] = new SqlParameter("@FreightPrice", shipingPrice.FreightPrice);
                prm[5] = new SqlParameter("@UID", UID);
                return da.executeDMLQuery("InsertShippingPrice", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet getAllShipinPriceData(string shipindId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(shipindId));
                return da.GetDataSet("GetShipingPrice", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet deleteShipingPrice(int ID, int UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[1] = new SqlParameter("@Id", Convert.ToInt32(ID));
                return da.GetDataSet("DeleteShipingPricing", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet viewaShipinPriceById(string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                return da.GetDataSet("GetShipingPrice", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int updateShipiningPrice(ShipingPriceModel shipingPrice, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[7];
                prm[0] = new SqlParameter("@ShipingCompanyId", shipingPrice.ShipingCompany);
                prm[1] = new SqlParameter("@PortId", shipingPrice.PortName);
                prm[2] = new SqlParameter("@ProductId", shipingPrice.ProductType);
                prm[3] = new SqlParameter("@CountryId", shipingPrice.CountryName);
                prm[4] = new SqlParameter("@FreightPrice", shipingPrice.FreightPrice);
                prm[5] = new SqlParameter("@MUID", UID);
                prm[6] = new SqlParameter("@Id", shipingPrice.Id);
                return da.executeDMLQuery("updateShipingPrice", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet getCurrencyMasterData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetCurrenctMaster");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int updateCurrenctMaster(string Id, string Rate, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@RateB", Rate);
                prm[1] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[2] = new SqlParameter("@Id", Convert.ToInt32(Id));
                return da.executeDMLQuery("UpdateCurrencyMaster", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int addCurrency(string currencyType, string Symbol, string rate, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("CtypeF", Convert.ToInt32(currencyType));
                prm[1] = new SqlParameter("CtypeT", Convert.ToInt32(Symbol));
                prm[2] = new SqlParameter("Rate", Convert.ToDecimal(rate));
                prm[3] = new SqlParameter("UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddCurrenctType", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int addCurrencyType(string currencyType, string Symbol, string rate, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("CtypeF", Convert.ToInt32(currencyType));
                prm[1] = new SqlParameter("CtypeT", Convert.ToInt32(Symbol));
                prm[2] = new SqlParameter("Rate", Convert.ToDecimal(rate));
                prm[3] = new SqlParameter("UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddCurrenctType", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet getAllCurrencyType()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetAllCurrency");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int deleteCurrencymaster(int Id, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", Id);
                prm[1] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("DeleteCurrenct", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int addBankDetails(Addbankdetails addbankdetails, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[8];
                prm[0] = new SqlParameter("@CompanyName", addbankdetails.CompanyName);
                prm[1] = new SqlParameter("@BankName", addbankdetails.BankName);
                prm[2] = new SqlParameter("@BranchName", addbankdetails.BranchName);
                prm[3] = new SqlParameter("@AccountName", addbankdetails.AccountName);
                prm[4] = new SqlParameter("@SwiftName", addbankdetails.SwiftName);
                prm[5] = new SqlParameter("@AccountNo", addbankdetails.AccountNo);
                prm[6] = new SqlParameter("@Address", addbankdetails.Address);
                prm[7] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddbankDetails", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet getAllBankDetails()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetBankDetails");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet getAllBankDetailsById(string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                return da.GetDataSet("GetBankDetails", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int updateBankDetailsById(Addbankdetails addbankdetails, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[9];
                prm[0] = new SqlParameter("@CompanyName", addbankdetails.CompanyName);
                prm[1] = new SqlParameter("@BankName", addbankdetails.BankName);
                prm[2] = new SqlParameter("@BranchName", addbankdetails.BranchName);
                prm[3] = new SqlParameter("@AccountName", addbankdetails.AccountName);
                prm[4] = new SqlParameter("@SwiftName", addbankdetails.SwiftName);
                prm[5] = new SqlParameter("@AccountNo", addbankdetails.AccountNo);
                prm[6] = new SqlParameter("@Address", addbankdetails.Address);
                prm[7] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[8] = new SqlParameter("@Id", addbankdetails.Id);
                return da.executeDMLQuery("UpdateBankDetails", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int deleteBankDetails(string Id, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                prm[1] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                return da.executeDMLQuery("deleteBankDetailsById", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int addFaqDetails(string Qusetuion, string Answer, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@Question", Qusetuion);
                prm[1] = new SqlParameter("@Answer", Answer);
                prm[2] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_AddFaq", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet getAllFaq(string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.GetDataSet("GetAllFaq", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getFaqByid(string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                return da.GetDataSet("GetAllFaq", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateFaqById(string Question, string Answer, int Id, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@Id", Id);
                prm[1] = new SqlParameter("@Question", Question);
                prm[2] = new SqlParameter("@Answer", Answer);
                prm[3] = new SqlParameter("MUID", Convert.ToInt32(UID));
                return da.executeDMLQuery("UpdateFaqById", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int deleteFaqById(int Id, int UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", Id);
                prm[1] = new SqlParameter("MUID", UID);
                return da.executeDMLQuery("DeleteFaq", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet getCountry()
        {
            try
            {
                da = new DataAccess();

                return da.GetDataSet("GetCountry");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int addDealer(DealerRegistrationModel dealerRegistration, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[33];
                prm[0] = new SqlParameter("@BusinessName", dealerRegistration.BusinessName);
                prm[1] = new SqlParameter("@TradeName", dealerRegistration.TradeName);
                prm[2] = new SqlParameter("@BusinessType", dealerRegistration.BusinessType);
                prm[3] = new SqlParameter("@EstablishmentDate", dealerRegistration.EstablishmentDate);
                prm[4] = new SqlParameter("@IndustryType", dealerRegistration.IndustryType);
                prm[5] = new SqlParameter("@ProductsServices", dealerRegistration.ProductsServices);
                prm[6] = new SqlParameter("@StreetAddress", dealerRegistration.StreetAddress);
                prm[7] = new SqlParameter("@City", dealerRegistration.City);
                prm[8] = new SqlParameter("@StateProvince", dealerRegistration.StateProvince);
                prm[9] = new SqlParameter("@ZIP", dealerRegistration.ZIP);
                prm[10] = new SqlParameter("@Country", Convert.ToInt32(dealerRegistration.Country));
                prm[11] = new SqlParameter("@PrimaryContact", dealerRegistration.PrimaryContact);
                prm[12] = new SqlParameter("@JobTitle", dealerRegistration.JobTitle);
                prm[13] = new SqlParameter("@Phone", dealerRegistration.Phone);
                prm[14] = new SqlParameter("@FaxNumber", dealerRegistration.FaxNumber);
                prm[15] = new SqlParameter("@Email", dealerRegistration.Email);
                prm[16] = new SqlParameter("@WebsiteURL", dealerRegistration.WebsiteURL);
                prm[17] = new SqlParameter("@TaxIdentification", dealerRegistration.TaxIdentification);
                prm[18] = new SqlParameter("@LicenseNumber", dealerRegistration.LicenseNumber);
                prm[19] = new SqlParameter("@CertificateNumber", dealerRegistration.CertificateNumber);
                prm[20] = new SqlParameter("@BankName", dealerRegistration.BankName);
                prm[21] = new SqlParameter("@AccountNumber", dealerRegistration.AccountNumber);
                prm[22] = new SqlParameter("@AccountHolder", dealerRegistration.AccountHolder);
                prm[23] = new SqlParameter("@BranchIFSCSWIFTCode", dealerRegistration.BranchIFSCSWIFTCode);
                prm[24] = new SqlParameter("@NumberofEmployees", dealerRegistration.NumberofEmployees);
                prm[25] = new SqlParameter("@AnnualRevenue", dealerRegistration.AnnualRevenue);
                prm[26] = new SqlParameter("@GeographicalArea", dealerRegistration.GeographicalArea);
                prm[27] = new SqlParameter("@DealershipSought", dealerRegistration.DealershipSought);
                prm[28] = new SqlParameter("@BusinessLicense", dealerRegistration.BusinessLicense);
                prm[29] = new SqlParameter("@VATCertificate", dealerRegistration.VATCertificate);
                prm[30] = new SqlParameter("@IDProofofOwner", dealerRegistration.IDProofofOwner);
                prm[31] = new SqlParameter("@SignedDealerAgreement", dealerRegistration.SignedDealerAgreement);
                prm[32] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddDealer", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet getAllDealerReg()
        {
            try
            {
                da = new DataAccess();

                return da.GetDataSet("GetAllDealerReg");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet getAllDealerRegistrationById(string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                return da.GetDataSet("GetAllDealerReg", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateDealer(DealerRegistrationModel dealerRegistration, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[34];
                prm[0] = new SqlParameter("@BusinessName", dealerRegistration.BusinessName);
                prm[1] = new SqlParameter("@TradeName", dealerRegistration.TradeName);
                prm[2] = new SqlParameter("@BusinessType", dealerRegistration.BusinessType);
                prm[3] = new SqlParameter("@EstablishmentDate", dealerRegistration.EstablishmentDate);
                prm[4] = new SqlParameter("@IndustryType", dealerRegistration.IndustryType);
                prm[5] = new SqlParameter("@ProductsServices", dealerRegistration.ProductsServices);
                prm[6] = new SqlParameter("@StreetAddress", dealerRegistration.StreetAddress);
                prm[7] = new SqlParameter("@City", dealerRegistration.City);
                prm[8] = new SqlParameter("@StateProvince", dealerRegistration.StateProvince);
                prm[9] = new SqlParameter("@ZIP", dealerRegistration.ZIP);
                prm[10] = new SqlParameter("@Country", Convert.ToInt32(dealerRegistration.Country));
                prm[11] = new SqlParameter("@PrimaryContact", dealerRegistration.PrimaryContact);
                prm[12] = new SqlParameter("@JobTitle", dealerRegistration.JobTitle);
                prm[13] = new SqlParameter("@Phone", dealerRegistration.Phone);
                prm[14] = new SqlParameter("@FaxNumber", dealerRegistration.FaxNumber);
                prm[15] = new SqlParameter("@Email", dealerRegistration.Email);
                prm[16] = new SqlParameter("@WebsiteURL", dealerRegistration.WebsiteURL);
                prm[17] = new SqlParameter("@TaxIdentification", dealerRegistration.TaxIdentification);
                prm[18] = new SqlParameter("@LicenseNumber", dealerRegistration.LicenseNumber);
                prm[19] = new SqlParameter("@CertificateNumber", dealerRegistration.CertificateNumber);
                prm[20] = new SqlParameter("@BankName", dealerRegistration.BankName);
                prm[21] = new SqlParameter("@AccountNumber", dealerRegistration.AccountNumber);
                prm[22] = new SqlParameter("@AccountHolder", dealerRegistration.AccountHolder);
                prm[23] = new SqlParameter("@BranchIFSCSWIFTCode", dealerRegistration.BranchIFSCSWIFTCode);
                prm[24] = new SqlParameter("@NumberofEmployees", dealerRegistration.NumberofEmployees);
                prm[25] = new SqlParameter("@AnnualRevenue", dealerRegistration.AnnualRevenue);
                prm[26] = new SqlParameter("@GeographicalArea", dealerRegistration.GeographicalArea);
                prm[27] = new SqlParameter("@DealershipSought", dealerRegistration.DealershipSought);
                prm[28] = new SqlParameter("@BusinessLicense", dealerRegistration.BusinessLicense);
                prm[29] = new SqlParameter("@VATCertificate", dealerRegistration.VATCertificate);
                prm[30] = new SqlParameter("@IDProofofOwner", dealerRegistration.IDProofofOwner);
                prm[31] = new SqlParameter("@SignedDealerAgreement", dealerRegistration.SignedDealerAgreement);
                prm[32] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[33] = new SqlParameter("@Id", dealerRegistration.Id);
                return da.executeDMLQuery("UpdateDealerReg", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int deleteDealerRegById(int Id, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", Id);
                prm[1] = new SqlParameter("MUID", Convert.ToInt32(UID));
                return da.executeDMLQuery("DeleteDelerReg", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet getAllcategory()
        {
            try
            {
                da = new DataAccess();

                return da.GetDataSet("GetAllCategoty");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int addAdditionalInfo(Additionalinfo additionalinfo, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@CategoryId", additionalinfo.CategoryId);
                prm[1] = new SqlParameter("@AdditinalInfoName", additionalinfo.AdditinalInfoName);
                prm[2] = new SqlParameter("@InfoTypeId", additionalinfo.InfoType);
                prm[3] = new SqlParameter("@Status", additionalinfo.Status);
                prm[4] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddAdditionalInfo", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet getAllAdditionInfo(int Id, string CategodyId, string InfoTypeId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@Id", Id);
                prm[1] = new SqlParameter("@CategoryId", Convert.ToInt32(CategodyId));
                prm[2] = new SqlParameter("InfoTypeId", Convert.ToInt32(InfoTypeId));
                return da.GetDataSet("GetAdditionalInfo", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet getAllAdditionInfoById(int Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                return da.GetDataSet("GetAdditionalInfo", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int updateAdditionalInfo(Additionalinfo additionalinfo, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@CategoryId", additionalinfo.CategoryId);
                prm[1] = new SqlParameter("@AdditinalInfoName", additionalinfo.AdditinalInfoName);
                prm[2] = new SqlParameter("@InfoTypeId", additionalinfo.InfoType);
                prm[3] = new SqlParameter("@Status", additionalinfo.Status);
                prm[4] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[5] = new SqlParameter("@Id", additionalinfo.Id);
                return da.executeDMLQuery("UpdateAdditionalData", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int deleteAdditionalById(string Id, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                prm[1] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                return da.executeDMLQuery("DeleteAdditionInfo", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int AddDepartment(Department department, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@DepartmentName", department.DepartmentName);
                prm[1] = new SqlParameter("@DepartmentCode", department.Departmentcode);
                prm[2] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddDepartment", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet getAllDepartment(int Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Id);
                return da.GetDataSet("GetAllDepartment", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int deleteDepartment(string Id, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                prm[1] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                return da.executeDMLQuery("DeleteDepartment", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int updateDepartment(Department department, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@DepartmentName", department.DepartmentName);
                prm[1] = new SqlParameter("@DepartmentCode", department.Departmentcode);
                prm[2] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[3] = new SqlParameter("@Id", department.Id);
                return da.executeDMLQuery("UpdateDepartment", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int AddGroup(string GroupName, string UID)
        {

            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@GroupName", GroupName);
                prm[1] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddGroup", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet GetAllGroup(int Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Id);
                return da.GetDataSet("GetAllGroup", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateGroup(string GroupName, string Id, string UID)
        {

            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@GroupName", GroupName);
                prm[1] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[2] = new SqlParameter("@Id", Convert.ToInt32(Id));
                return da.executeDMLQuery("UpdateGroup", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int DeleteGroup(string Id, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                prm[1] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                return da.executeDMLQuery("DeleteGroup", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int addLedgerHead(LedgerHead ledgerHead, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@LedgerGroupId", ledgerHead.GroupName);
                prm[1] = new SqlParameter("@LedgerHeadName", ledgerHead.LedgerHeadName);
                prm[2] = new SqlParameter("@ShortCode", ledgerHead.Shortcode);
                prm[3] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddGroupHead", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int updateLedgerHead(LedgerHead ledgerHead, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@LedgerGroupId", ledgerHead.GroupName);
                prm[1] = new SqlParameter("@LedgerHeadName", ledgerHead.LedgerHeadName);
                prm[2] = new SqlParameter("@ShortCode", ledgerHead.Shortcode);
                prm[3] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[4] = new SqlParameter("@Id", ledgerHead.Id);
                return da.executeDMLQuery("UpdateGroupHead", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet GetAllLedgerHead(int Id, string LedgerGroupId, string LedgerName, string ShortCode)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@Id", Id);
                prm[1] = new SqlParameter("@LedgerGroupId", Convert.ToInt32(LedgerGroupId));
                prm[2] = new SqlParameter("@LedgerHeadName", LedgerName);
                prm[3] = new SqlParameter("@ShortCode", ShortCode);
                return da.GetDataSet("GetAllLedgerHead", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteLedgherHead(string Id, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                prm[1] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                return da.executeDMLQuery("DeleteLedgerHead", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int addFuzokuhin(FuzokuhinModel fuzokuhinModel, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@FuzokuhinName", fuzokuhinModel.FuzokuhinName);
                prm[1] = new SqlParameter("@Price", fuzokuhinModel.Price);
                prm[2] = new SqlParameter("@Status", fuzokuhinModel.ActiveDeActive);
                prm[3] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddFuzokuhin", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int updateFuzokuhinById(FuzokuhinModel fuzokuhinModel, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@FuzokuhinName", fuzokuhinModel.FuzokuhinName);
                prm[1] = new SqlParameter("@Price", fuzokuhinModel.Price);
                prm[2] = new SqlParameter("@Status", fuzokuhinModel.ActiveDeActive);
                prm[3] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[4] = new SqlParameter("@Id", fuzokuhinModel.Id);
                return da.executeDMLQuery("UpdateFuzokuhin", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int deleteFuzokuhin(string Id, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                prm[1] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                return da.executeDMLQuery("DeleteFuzokuhin", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet ViewTransportAuction()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetTransportAuction");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet GetAllPortView()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetAllPortMaster");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet viewYardByAuctioId(string AuctionId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@AuctionId", Convert.ToInt32(AuctionId));
                return da.GetDataSet("GetYardNameByAID", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int updateTransportPrice(string TransportId, string AuntionId, string YardId, string PID, string Price, string TaxPrice, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[7];
                prm[0] = new SqlParameter("@AuctionId", AuntionId);
                prm[1] = new SqlParameter("@YardId", YardId);
                prm[2] = new SqlParameter("@TransportId", TransportId);
                prm[3] = new SqlParameter("@PID", PID);
                prm[4] = new SqlParameter("@Price", Price);
                prm[5] = new SqlParameter("@TaxPrice", TaxPrice);
                prm[6] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddTransportPrice", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet viewPortByCountryId(string CountryId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@CountryId", Convert.ToInt32(CountryId));
                return da.GetDataSet("GetAllPortByCID", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int UpdateFobPriceByRID(string CountryId, string RegionId, string FobId, string PortId, string Price, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@ContryId", Convert.ToInt32(CountryId));
                prm[1] = new SqlParameter("@RegionId", Convert.ToInt32(RegionId));
                prm[2] = new SqlParameter("@PortId", Convert.ToInt32(PortId));
                prm[3] = new SqlParameter("@Price", Convert.ToDecimal(Price));
                prm[4] = new SqlParameter("@FOBId", FobId);
                prm[5] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddNewFobByRID", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getAllAuctionByRID(string StateId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@RID", Convert.ToInt32(StateId));
                return da.GetDataSet("GETAuctionByRID", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet GetAllPortAndShippingName()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetPortShippingName");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int Updatetransportshipping(TransportInfo transportInfo, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[13];
                prm[0] = new SqlParameter("@CountryId", transportInfo.CountryId);
                prm[1] = new SqlParameter("@StateId", transportInfo.RegionId);
                prm[2] = new SqlParameter("@AuctionId", transportInfo.AuctionId);
                prm[3] = new SqlParameter("@TransportId", transportInfo.TransportId);
                prm[4] = new SqlParameter("@NormalShipingId", transportInfo.NormailShipId);
                prm[5] = new SqlParameter("@NormalPortId", transportInfo.NormailPortId);
                prm[6] = new SqlParameter("@ConsShipingId", transportInfo.ConsShipId);
                prm[7] = new SqlParameter("@ConsPortId", transportInfo.ConsPortId);
                prm[8] = new SqlParameter("@CutShipingId", transportInfo.CutShipId);
                prm[9] = new SqlParameter("@CutPortId", transportInfo.CutPortId);
                prm[10] = new SqlParameter("@ContainerPortId", transportInfo.ContainerPortId);
                prm[11] = new SqlParameter("@ContainerShipingId", transportInfo.ContainerShipId);
                prm[12] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddUpdateTransportInfo", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetTransportshipinB(string CountryId, string RegionId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@CountryId", Convert.ToInt32(CountryId));
                prm[1] = new SqlParameter("@RegionId", Convert.ToInt32(RegionId));
                return da.GetDataSet("GetTrnsportShipping", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet GetUpdatelogisticData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetUpdatelogisticMasterData");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int addVideo(AddVideoModel addVideoModel, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@VideoLanguage", addVideoModel.VideoLanguage);
                prm[1] = new SqlParameter("@VideoTitle", addVideoModel.VideoTitle);
                prm[2] = new SqlParameter("@VideoUrl", addVideoModel.VideoUrl);
                prm[3] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddVideo", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
        public DataSet getAllVideoData()
        {
            try
            {
                da = new DataAccess();

                return da.GetDataSet("GetAllVideo");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet getAllVideoDataById(string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                return da.GetDataSet("GetAllVideo", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int deleteVideoDataById(string Id, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                prm[1] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                return da.executeDMLQuery("DeleteVideoData", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int updateVideo(AddVideoModel addVideoModel, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@VideoLanguage", addVideoModel.VideoLanguage);
                prm[1] = new SqlParameter("@VideoTitle", addVideoModel.VideoTitle);
                prm[2] = new SqlParameter("@VideoUrl", addVideoModel.VideoUrl);
                prm[3] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[4] = new SqlParameter("@Id", addVideoModel.Id);
                return da.executeDMLQuery("UpdateVideoData", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }

        }
        public DataSet GetMakeInvoiceMasterData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetMakeInvoiceMasterData");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int AddBankReceiptInvoice(MakeInvoice makeInvoice, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[10];
                prm[0] = new SqlParameter("@ChassisNo", makeInvoice.ChassisNo);
                prm[1] = new SqlParameter("@ClientId", Convert.ToInt32(makeInvoice.Customer));
                prm[2] = new SqlParameter("@SenderName", makeInvoice.SenderName);
                prm[3] = new SqlParameter("@Address", makeInvoice.Address);
                prm[4] = new SqlParameter("@BankId", Convert.ToInt32(makeInvoice.BankName));
                prm[5] = new SqlParameter("@CurrencyId", Convert.ToInt32(makeInvoice.CurrencyType));
                prm[6] = new SqlParameter("@Amount", makeInvoice.Amount);
                prm[7] = new SqlParameter("@InvoiceTypeId", Convert.ToInt32(makeInvoice.InvoiceType));
                prm[8] = new SqlParameter("@OtherCharges", makeInvoice.OtherCharges);
                prm[9] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddMakeInvoiceDate", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllInvoiceData(string CustId, string DateFrom, string Dateto)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@ClientId", Convert.ToInt32(CustId));
                prm[1] = new SqlParameter("@Fdate", DateFrom);
                prm[2] = new SqlParameter("@Tdate", Dateto);
                return da.GetDataSet("GetAllMakeInvoice", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetInvoiceDataById(string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                return da.GetDataSet("GetInvoiceDataById", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateInvDataById(MakeInvoice makeInvoice, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[11];
                prm[0] = new SqlParameter("@ChassisNo", makeInvoice.ChassisNo);
                prm[1] = new SqlParameter("@ClientId", Convert.ToInt32(makeInvoice.Customer));
                prm[2] = new SqlParameter("@SenderName", makeInvoice.SenderName);
                prm[3] = new SqlParameter("@Address", makeInvoice.Address);
                prm[4] = new SqlParameter("@BankId", Convert.ToInt32(makeInvoice.BankName));
                prm[5] = new SqlParameter("@CurrencyId", Convert.ToInt32(makeInvoice.CurrencyType));
                prm[6] = new SqlParameter("@Amount", makeInvoice.Amount);
                prm[7] = new SqlParameter("@InvoiceTypeId", Convert.ToInt32(makeInvoice.InvoiceType));
                prm[8] = new SqlParameter("@OtherCharges", makeInvoice.OtherCharges);
                prm[9] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[10] = new SqlParameter("@Id", makeInvoice.Id);
                return da.executeDMLQuery("UpdateInvDataById", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteInvoiceData(string Id, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                prm[1] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                return da.executeDMLQuery("DeleteInvoiceData", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet bindtempinvoice(string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                return da.GetDataSet("GetInvoiceById", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllInvoiceMasterData()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetMasterDataForinvoice");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet GetInvoiceDetailsById(int Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Id);
                return da.GetDataSet("GetInvoiceDetailsById", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet bindfreight(string shippindId, string countryId, string portId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ShipingCompanyId", Convert.ToInt32(shippindId));
                prm[1] = new SqlParameter("@CountryId", Convert.ToInt32(countryId));
                prm[2] = new SqlParameter("@PortId", Convert.ToInt32(portId));
                return da.GetDataSet("GetfreightPrice", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int AddInvoice(MakeInvoiceModel makeInvoiceModel)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[30];
                prm[0] = new SqlParameter("@ProductId", Convert.ToInt32(makeInvoiceModel.ProductId));
                prm[1] = new SqlParameter("@ClientId", Convert.ToInt32(makeInvoiceModel.Customer));
                prm[2] = new SqlParameter("@ProductName", makeInvoiceModel.ProductName);
                prm[3] = new SqlParameter("@ChassisNu", makeInvoiceModel.ChassisNo);
                prm[4] = new SqlParameter("@AuctionId", Convert.ToInt32(makeInvoiceModel.AuctionName));
                prm[5] = new SqlParameter("@ShippingId", Convert.ToInt32(makeInvoiceModel.ShippingCompany));
                prm[6] = new SqlParameter("@InvoiveType", Convert.ToInt32(makeInvoiceModel.InvoiceType));
                prm[7] = new SqlParameter("@PortId", Convert.ToInt32(makeInvoiceModel.PortName));
                prm[8] = new SqlParameter("@CurrencyTypeId", Convert.ToInt32(makeInvoiceModel.CurrencyType));
                prm[9] = new SqlParameter("@PushPrice", makeInvoiceModel.PushPrice);
                prm[10] = new SqlParameter("@FOBPrice", makeInvoiceModel.FOBPrice);
                prm[11] = new SqlParameter("@FreightCharge", makeInvoiceModel.FreightCharge);
                prm[12] = new SqlParameter("@RecycleAmount", makeInvoiceModel.RecycleAmount);
                prm[13] = new SqlParameter("@OtherServices", makeInvoiceModel.OtherServices);
                prm[14] = new SqlParameter("@Insurance", makeInvoiceModel.Insurance);
                prm[15] = new SqlParameter("@InsuranceText", makeInvoiceModel.InsuranceText);
                prm[16] = new SqlParameter("@RadiationPrice", makeInvoiceModel.Radiation);
                prm[17] = new SqlParameter("@InspectionPrice", makeInvoiceModel.InspectionPrice);
                prm[18] = new SqlParameter("@PortPrice", makeInvoiceModel.PortPrice);
                prm[19] = new SqlParameter("@CustomClearance", makeInvoiceModel.CustomClearance);
                prm[20] = new SqlParameter("@CarSelection", makeInvoiceModel.CarSelection);
                prm[21] = new SqlParameter("@Transport", makeInvoiceModel.Transport);
                prm[22] = new SqlParameter("@FinalSoldPrice", makeInvoiceModel.FinalSoldPrice);
                prm[23] = new SqlParameter("@OrderType", makeInvoiceModel.OrderType);
                prm[24] = new SqlParameter("@Discount", makeInvoiceModel.Discount);
                prm[25] = new SqlParameter("@Rate", makeInvoiceModel.Rate);
                prm[26] = new SqlParameter("@InvoiceUsed", Convert.ToInt32(makeInvoiceModel.InvoiceUsed));
                prm[27] = new SqlParameter("@UID", Convert.ToInt32(makeInvoiceModel.UID));
                prm[28] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[28].Direction = ParameterDirection.ReturnValue;
                prm[29] = new SqlParameter("@ProductType", makeInvoiceModel.ProductType);
                return da.executeDMLQuery("AddInvoice", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllCompany()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetAllCompany");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBankDetailsByInvNo(int InvId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@InvoiceNo", InvId);
                return da.GetDataSet("GetAllbankByInvoiceNo", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetInvoiceDataByInvNo(string InvNo)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@InvoiceId", Convert.ToInt32(InvNo));
                return da.GetDataSet("GetInvoiceataById", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMasterDataForTransport()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetMasterTransPortDetails");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllDataForTransport(TransportDetailsModel transportDetailsModel, string iPageNo, int iPageRecords)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[9];
                prm[0] = new SqlParameter("@FromDate", transportDetailsModel.DateFrom);
                prm[1] = new SqlParameter("@ToDate", transportDetailsModel.DateTo);
                prm[2] = new SqlParameter("@AuctionID", Convert.ToInt32(transportDetailsModel.AuctionHouse));
                prm[3] = new SqlParameter("@TransportID", Convert.ToInt32(transportDetailsModel.Transport));
                prm[4] = new SqlParameter("@Nplate", transportDetailsModel.NoPlate);
                prm[5] = new SqlParameter("@Urgent", transportDetailsModel.Urgent);
                prm[6] = new SqlParameter("@PageIndex", iPageNo);
                prm[7] = new SqlParameter("@PageSize", iPageRecords);
                prm[8] = new SqlParameter("@RecordCount", iPageRecords);
                return da.GetDataSet("GetTransportDetails", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUpdateLogisticDataByChno(string ChassisNo)
        {
            try
            {
                ChassisNo = ChassisNo.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Chassisno", ChassisNo);
                return da.GetDataSet("GetLogisticsDataByChasisNo", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Updatelogistics(UpdatelogisticModel updatelogisticModel, string pageNo, int PageSize)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[19];
                prm[0] = new SqlParameter("@CountryId", Convert.ToInt32(updatelogisticModel.CountryName));
                prm[1] = new SqlParameter("@ClientId", Convert.ToInt32(updatelogisticModel.ClientName));
                prm[2] = new SqlParameter("@ShiPId", Convert.ToInt32(updatelogisticModel.ShipName));
                prm[3] = new SqlParameter("@surender", updatelogisticModel.Surrender);
                prm[4] = new SqlParameter("@BrokerId", Convert.ToInt32(updatelogisticModel.Broker));
                prm[5] = new SqlParameter("@DateFrom", updatelogisticModel.Datefrom);
                prm[6] = new SqlParameter("@DateTo", updatelogisticModel.DateTo);
                prm[7] = new SqlParameter("@CarStatus", Convert.ToInt32(updatelogisticModel.CarStatus));
                prm[8] = new SqlParameter("@shipingId", Convert.ToInt32(updatelogisticModel.ShippingCompany));
                prm[9] = new SqlParameter("@PortId", Convert.ToInt32(updatelogisticModel.PortFrom));
                prm[10] = new SqlParameter("@TransportId", Convert.ToInt32(updatelogisticModel.Transport));
                prm[11] = new SqlParameter("@Urgent", updatelogisticModel.Urgent);
                prm[12] = new SqlParameter("@AuctionId", Convert.ToInt32(updatelogisticModel.AuctionHouse));
                prm[13] = new SqlParameter("@NoPlate", updatelogisticModel.NoPlate);
                prm[14] = new SqlParameter("@rikujidate", updatelogisticModel.RikujiDate);
                prm[15] = new SqlParameter("@Loading", updatelogisticModel.Loading);
                prm[16] = new SqlParameter("@PageIndex", pageNo);
                prm[17] = new SqlParameter("@PageSize", PageSize);
                prm[18] = new SqlParameter("@RecordCount", PageSize);
                return da.GetDataSet("UpdatelogisticsData_ALL", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateLogisticById(UpdateLogisticModelData updateLogisticModelData, string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[9];
                prm[0] = new SqlParameter("@ProductInDate", updateLogisticModelData.ProductInDate);
                prm[1] = new SqlParameter("@WishPlanDate", updateLogisticModelData.WishPlanDate);
                prm[2] = new SqlParameter("@WishPInDate", updateLogisticModelData.WishPInDate);
                prm[3] = new SqlParameter("@WishShipDate", updateLogisticModelData.WishShipDate);
                prm[4] = new SqlParameter("@WishArrivalDate", updateLogisticModelData.WishArrivalDate);
                prm[5] = new SqlParameter("@ShipId", updateLogisticModelData.ShipName);
                prm[6] = new SqlParameter("@Surrender", updateLogisticModelData.Surrender);
                prm[7] = new SqlParameter("@Loading", updateLogisticModelData.Loading);
                prm[8] = new SqlParameter("@PurchaseID", Convert.ToInt32(Id));
                return da.executeDMLQuery("UpdateLogisticData", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetClientAndCoountry()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetCountryAndClient");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region created by Ashish
        public int AddAuthor(entAuthor obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@AuthorName", obj.AName);
                prm[1] = new SqlParameter("@AuthorImg", obj.AImage);
                prm[2] = new SqlParameter("@uid", obj.uid);
                prm[3] = new SqlParameter("@Action", "INSERT");
                return da.executeDMLQuery("ManageAuthor", prm);

            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
        public int UpdateAuthor(entAuthor obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@Id", obj.Id);
                prm[1] = new SqlParameter("@AuthorName", obj.AName);
                prm[2] = new SqlParameter("@AuthorImg", obj.AImage);
                prm[3] = new SqlParameter("@uid", obj.uid);
                prm[4] = new SqlParameter("@Action", "UPDATE");
                return da.executeDMLQuery("ManageAuthor", prm);

            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
        public DataSet SelectAuthorById(entAuthor obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", obj.Id);
                prm[1] = new SqlParameter("@Action", "SELECTBYID");
                return da.GetDataSet("ManageAuthor", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectAuthor()
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("ManageAuthor", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteAuthor(entAuthor obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@Id", obj.Id);
                prm[1] = new SqlParameter("@uid", obj.uid);
                prm[2] = new SqlParameter("@Action", "DELETE");
                return da.executeDMLQuery("ManageAuthor", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBrokerDetailsByChassis(string typeId)
        {
            try
            {
                typeId = typeId.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ChassisNo", typeId);
                return da.GetDataSet("USP_GetBrokerDetailsByChassis", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllBrokerDetails(entUpdateBroker obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[8];
                prm[0] = new SqlParameter("@categoryid", obj.CategoryId);
                prm[1] = new SqlParameter("@productid", obj.ProductId);
                prm[2] = new SqlParameter("@AuctionId", obj.AuctionId);
                prm[3] = new SqlParameter("@ClientId", obj.ClientId);
                prm[4] = new SqlParameter("@ShipId", obj.ShipId);
                prm[5] = new SqlParameter("@Adate", obj.Adate);
                prm[6] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[7] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("USP_GetAllUpdateBrokerDetails", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBroker()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_GetBroker");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateBroker(string PID, string BID, string Upby, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@ProductId", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@BrokerId", Convert.ToInt32(BID));
                prm[2] = new SqlParameter("@Upby", Upby);
                prm[3] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_Updatebrokerlog", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet GetModelCodePurchase()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_GetModelCodeFromPurchase");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUpdateVariantByChessis(string typeId)
        {
            try
            {
                typeId = typeId.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ChassisNolist", typeId);
                return da.GetDataSet("USP_GetUpdateVariantByCh", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllUpdateVariant(UpdateVariant obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[8];
                prm[0] = new SqlParameter("@categoryid", obj.CategoryId);
                prm[1] = new SqlParameter("@productid", obj.ProductId);
                prm[2] = new SqlParameter("@ModelCode", obj.ModelId);
                prm[3] = new SqlParameter("@AuctionId", obj.AuctionId);
                prm[4] = new SqlParameter("@Adate", obj.Adate);
                prm[5] = new SqlParameter("@ProductType", obj.ProductType);
                prm[6] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[7] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("USP_GetAllUpdateVariant", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetVariantByProduct(int A)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ProductId", A);
                return da.GetDataSet("USP_GetvariantbyProductId", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateVariant(string PID, string VID, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@PID", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@VID", Convert.ToInt32(VID));
                prm[2] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_UpdateVariantIdbyPID", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        #endregion

        #region Created By Lalit

        public DataSet SelectSellerMaster(string typeid)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@typeid", typeid);
            return da.GetDataSet("USP_SelectSellerDetails", prm);
        }


        #endregion

        #region Purchase
        public DataSet SelectPurchaseById(string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Id);
                return da.GetDataSet("GetPurchaseById", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insertPurchase(entPurchase obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[19];
                prm[0] = new SqlParameter("@SubCId", obj.categoryid);
                prm[1] = new SqlParameter("@PID", obj.productid);
                prm[2] = new SqlParameter("@Cno", obj.ChassisNo);
                prm[3] = new SqlParameter("@MDate", obj.MDate);
                prm[4] = new SqlParameter("@VID", obj.variantid);
                prm[5] = new SqlParameter("@Rdate", Convert.ToInt32(obj.Year));  //In year
                prm[6] = new SqlParameter("@Rgdate", obj.RDate);
                prm[7] = new SqlParameter("@Mileage", obj.Mileage);
                prm[8] = new SqlParameter("@Ccolor", obj.Color);
                prm[9] = new SqlParameter("@Otype", obj.OwnerType);
                prm[10] = new SqlParameter("@OID", obj.OwnerTypeId);
                prm[11] = new SqlParameter("@AID", obj.AID);
                prm[12] = new SqlParameter("@SAID", obj.SAID);
                prm[13] = new SqlParameter("@Adate", obj.ADate);
                prm[14] = new SqlParameter("@LotNo", obj.LotNo);
                prm[15] = new SqlParameter("@Grade", obj.Grade);
                prm[16] = new SqlParameter("@Urgent", obj.Urgent);
                prm[17] = new SqlParameter("@uid", obj.uid);
                prm[18] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[18].Direction = ParameterDirection.ReturnValue;
                return da.executeDMLQuery("AddPurchase", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updatePurchase(entPurchase obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[20];
                prm[0] = new SqlParameter("@SubCId", obj.categoryid);
                prm[1] = new SqlParameter("@PID", obj.productid);
                prm[2] = new SqlParameter("@Cno", obj.ChassisNo);
                prm[3] = new SqlParameter("@MDate", obj.MDate);
                prm[4] = new SqlParameter("@VID", obj.variantid);
                prm[5] = new SqlParameter("@Rdate", Convert.ToInt32(obj.Year));
                prm[6] = new SqlParameter("@Rgdate", obj.RDate);
                prm[7] = new SqlParameter("@Mileage", obj.Mileage);
                prm[8] = new SqlParameter("@Ccolor", obj.Color);
                prm[9] = new SqlParameter("@Otype", obj.OwnerType);
                prm[10] = new SqlParameter("@OID", obj.OwnerTypeId);
                prm[11] = new SqlParameter("@AID", obj.AID);
                prm[12] = new SqlParameter("@SAID", obj.SAID);
                prm[13] = new SqlParameter("@Adate", obj.ADate);
                prm[14] = new SqlParameter("@LotNo", obj.LotNo);
                prm[15] = new SqlParameter("@Grade", obj.Grade);
                prm[16] = new SqlParameter("@Urgent", obj.Urgent);
                prm[17] = new SqlParameter("@uid", obj.uid);
                prm[18] = new SqlParameter("@Id", obj.id);
                prm[19] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[19].Direction = ParameterDirection.ReturnValue;
                return da.executeDMLQuery("UpdatePurchase", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deletePurchase(entPurchase obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@id", obj.id);
                prm[1] = new SqlParameter("@uid", obj.uid);
                return da.executeDMLQuery("DeletePurchase", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SearchPurchaseList(entPurchaseSearch obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[16];
                prm[0] = new SqlParameter("@categoryid", obj.categoryid);
                prm[1] = new SqlParameter("@productid", obj.productid);
                prm[2] = new SqlParameter("@variantid", obj.variantid);
                prm[3] = new SqlParameter("@makerid", obj.makerid);
                prm[4] = new SqlParameter("@bodytypeid", obj.bodytypeid);
                prm[5] = new SqlParameter("@ChassisNo", obj.ChassisNo);
                prm[6] = new SqlParameter("@KmsF", obj.KmsF);
                prm[7] = new SqlParameter("@KmsT", obj.KmsT);
                prm[8] = new SqlParameter("@PriceF", obj.PriceF);
                prm[9] = new SqlParameter("@PriceT", obj.PriceT);
                prm[10] = new SqlParameter("@CC", obj.Mileage);
                prm[11] = new SqlParameter("@color", obj.Color);
                prm[12] = new SqlParameter("@fdate", obj.fdate);
                prm[13] = new SqlParameter("@tdate", obj.tdate);
                prm[14] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[15] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("USP_SearchPurchaseList", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public int insertPurchaseAdditionalInfo(entPurchase_Media obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@PID", obj.PID);
                prm[1] = new SqlParameter("@Data", obj.Data);
                prm[2] = new SqlParameter("@uid", obj.uid);
                prm[3] = new SqlParameter("@Action", obj.mtype);
                return da.executeDMLQuery("Purchase_AdditionalInfoDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectPurchaseAdditionalInfo(string pid, string mtype)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@PID", pid);
                prm[1] = new SqlParameter("@mtype", mtype);
                prm[2] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("Purchase_AdditionalInfoDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Seller

        public int insertSellerProductsAdditionalInfo(entPurchase_Media obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@PID", obj.PID);
                prm[1] = new SqlParameter("@Data", obj.Data);
                prm[2] = new SqlParameter("@uid", obj.uid);
                prm[3] = new SqlParameter("@Action", obj.mtype);
                return da.executeDMLQuery("Seller_AdditionalInfoDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SelectSellerAdditionalInfo(string pid, string mtype)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@PID", pid);
            prm[1] = new SqlParameter("@mtype", mtype);
            prm[2] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("Seller_AdditionalInfoDML", prm);
        }

        public DataSet SelectSellerProductsById(string id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@id", id);
                prm[1] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("USP_ManageSellerDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insertSellerProducts(entPurchase obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[16];
                prm[0] = new SqlParameter("@categoryid", obj.categoryid);
                prm[1] = new SqlParameter("@productid", obj.productid);
                prm[2] = new SqlParameter("@variantid", obj.variantid);
                prm[3] = new SqlParameter("@ChassisNo", obj.ChassisNo);
                prm[4] = new SqlParameter("@MDate", obj.MDate);
                prm[5] = new SqlParameter("@RDate", obj.RDate);
                prm[6] = new SqlParameter("@Mileage", obj.Mileage);
                prm[7] = new SqlParameter("@Color", obj.Color);
                //prm[8] = new SqlParameter("@SellerType", obj.SellerType);
                //prm[9] = new SqlParameter("@SID", obj.SID);
                prm[10] = new SqlParameter("@SAID", obj.SAID);
                prm[11] = new SqlParameter("@ADate", obj.ADate);
                //prm[12] = new SqlParameter("@ptype1", obj.ptype1);
                //prm[13] = new SqlParameter("@ptype2", obj.ptype2);
                prm[14] = new SqlParameter("@uid", obj.uid);
                prm[15] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[15].Direction = ParameterDirection.ReturnValue;
                return da.executeDMLQuery("AddSellerProducts", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateSellerProducts(entPurchase obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[17];
                prm[0] = new SqlParameter("@id", obj.id);
                prm[1] = new SqlParameter("@categoryid", obj.categoryid);
                prm[2] = new SqlParameter("@productid", obj.productid);
                prm[3] = new SqlParameter("@variantid", obj.variantid);
                prm[4] = new SqlParameter("@ChassisNo", obj.ChassisNo);
                prm[5] = new SqlParameter("@MDate", obj.MDate);
                prm[6] = new SqlParameter("@RDate", obj.RDate);
                prm[7] = new SqlParameter("@Mileage", obj.Mileage);
                prm[8] = new SqlParameter("@Color", obj.Color);
                //prm[9] = new SqlParameter("@SellerType", obj.SellerType);
                //prm[10] = new SqlParameter("@SID", obj.SID);
                prm[11] = new SqlParameter("@SAID", obj.SAID);
                prm[12] = new SqlParameter("@ADate", obj.ADate);
                //prm[13] = new SqlParameter("@ptype1", obj.ptype1);
                //prm[14] = new SqlParameter("@ptype2", obj.ptype2);
                prm[15] = new SqlParameter("@uid", obj.uid);
                prm[16] = new SqlParameter("@Action", "UPDATE");
                return da.executeDMLQuery("USP_ManageSellerDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deleteSellerProducts(entPurchase obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@id", obj.id);
                prm[1] = new SqlParameter("@uid", obj.uid);
                prm[2] = new SqlParameter("@Action", "DELETE");
                return da.executeDMLQuery("USP_ManageSellerDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SearchSellerList(entPurchaseSearch obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[16];
                prm[0] = new SqlParameter("@categoryid", obj.categoryid);
                prm[1] = new SqlParameter("@productid", obj.productid);
                prm[2] = new SqlParameter("@variantid", obj.variantid);
                prm[3] = new SqlParameter("@makerid", obj.makerid);
                prm[4] = new SqlParameter("@bodytypeid", obj.bodytypeid);
                prm[5] = new SqlParameter("@ChassisNo", obj.ChassisNo);
                prm[6] = new SqlParameter("@KmsF", obj.KmsF);
                prm[7] = new SqlParameter("@KmsT", obj.KmsT);
                prm[8] = new SqlParameter("@PriceF", obj.PriceF);
                prm[9] = new SqlParameter("@PriceT", obj.PriceT);
                prm[10] = new SqlParameter("@CC", obj.Mileage);
                prm[11] = new SqlParameter("@color", obj.Color);
                prm[12] = new SqlParameter("@fdate", obj.fdate);
                prm[13] = new SqlParameter("@tdate", obj.tdate);
                prm[14] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[15] = new SqlParameter("@PageSize", obj.PageSize);

                return da.GetDataSet("USP_SearchSellerList", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Seller

        #region created by Ashish
        public int AddBroker(entBroker obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@Bcname", obj.Bcname);
                prm[1] = new SqlParameter("@EmailID", obj.EmailID);
                prm[2] = new SqlParameter("@Password", obj.Password);
                prm[3] = new SqlParameter("@uid", obj.uid);
                prm[4] = new SqlParameter("@Action", "INSERT");
                return da.executeDMLQuery("Managebroker", prm);

            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int UpdateBroker(entBroker obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@Id", obj.ID);
                prm[1] = new SqlParameter("@Bcname", obj.Bcname);
                prm[2] = new SqlParameter("@EmailID", obj.EmailID);
                prm[3] = new SqlParameter("@Password", obj.Password);
                prm[4] = new SqlParameter("@uid", obj.uid);
                prm[5] = new SqlParameter("@Action", "UPDATE");
                return da.executeDMLQuery("Managebroker", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SelectBrokerById(entBroker obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", obj.ID);
                prm[1] = new SqlParameter("@Action", "SELECTBYID");
                return da.GetDataSet("Managebroker", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SelectBroker()
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("Managebroker", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteBroker(entBroker obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@Id", obj.ID);
                prm[1] = new SqlParameter("@uid", obj.uid);
                prm[2] = new SqlParameter("@Action", "DELETE");
                return da.executeDMLQuery("Managebroker", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet BrokerCompanyBind()
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Action", "SELECTBYBROKER");
                return da.GetDataSet("Managebroker", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddBrokerAddress(entBrokerAddress obj)
        {
            try
            {

                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[7];
                prm[0] = new SqlParameter("@BCompanyId", obj.BCompanyId);
                prm[1] = new SqlParameter("@BName", obj.BName);
                prm[2] = new SqlParameter("@ContactNo", obj.ContactNo);
                prm[3] = new SqlParameter("@EmailID", obj.EmailID);
                prm[4] = new SqlParameter("@BAddress", obj.BAddress);
                prm[5] = new SqlParameter("@uid", obj.uid);
                prm[6] = new SqlParameter("@Action", "INSERT");
                return da.executeDMLQuery("ManagebrokerAddress", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateBrokerAddress(entBrokerAddress obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[8];
                prm[0] = new SqlParameter("@Id", obj.Id);
                prm[1] = new SqlParameter("@BCompanyId", obj.BCompanyId);
                prm[2] = new SqlParameter("@BName", obj.BName);
                prm[3] = new SqlParameter("@ContactNo", obj.ContactNo);
                prm[4] = new SqlParameter("@EmailID", obj.EmailID);
                prm[5] = new SqlParameter("@BAddress", obj.BAddress);
                prm[6] = new SqlParameter("@uid", obj.uid);
                prm[7] = new SqlParameter("@Action", "UPDATE");
                return da.executeDMLQuery("ManagebrokerAddress", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectBrokerAddressById(entBrokerAddress obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", obj.Id);
                prm[1] = new SqlParameter("@Action", "SELECTBYID");
                return da.GetDataSet("ManagebrokerAddress", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectBrokerAddress()
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("ManagebrokerAddress", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteBrokerAddress(entBrokerAddress obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@Id", obj.Id);
                prm[1] = new SqlParameter("@uid", obj.uid);
                prm[2] = new SqlParameter("@Action", "DELETE");
                return da.executeDMLQuery("ManagebrokerAddress", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectBCompanyById(int id, string date)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@Id", id);
                prm[1] = new SqlParameter("@DOE", date);
                prm[2] = new SqlParameter("@Action", "SELECTBYIDBCOMPANY");
                return da.GetDataSet("ManagebrokerAddress", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet BrokerCNameBind()
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Action", "SELECTBYBROKERNAME");
                return da.GetDataSet("Managebroker", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet BrokerNameBind(int id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@BCompanyId", id);
                prm[1] = new SqlParameter("@Action", "SELECTBROKERBYID");
                return da.GetDataSet("ManagebrokerAddress", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ClinetBind()
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Action", "CLIENTSELECTBYID");
                return da.GetDataSet("ClientRegistrationDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AddClientBroker(entClientBroker obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@BCompanyId", obj.BCompanyId);
                prm[1] = new SqlParameter("@BrokerId", obj.BrokerId);
                prm[2] = new SqlParameter("@ClientId", obj.ClientId);
                prm[3] = new SqlParameter("@uid", obj.uid);
                prm[4] = new SqlParameter("@Action", "INSERT");
                return da.executeDMLQuery("ManageClientBroker", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SelectClientBroker()
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("ManageClientBroker", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteClientBroker(entClientBroker obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@Id", obj.Id);
                prm[1] = new SqlParameter("@uid", obj.uid);
                prm[2] = new SqlParameter("@Action", "DELETE");
                return da.executeDMLQuery("ManageClientBroker", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ClientBrokerSearch(int BCID, int BID, int CID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@BCompanyId", BCID);
                prm[1] = new SqlParameter("@BrokerId", BID);
                prm[2] = new SqlParameter("@ClientId", CID);
                prm[3] = new SqlParameter("@Action", "SELECTBYCLIENTSEARCH");
                return da.GetDataSet("ManageClientBroker", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet AllDropDownMaster()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_GetUpdateCatAndAuction");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetProductByCategory(int A)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@CategoryId", A);
                return da.GetDataSet("USP_GetProductByCategory", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetUpdateShippingDetails(string typeId)
        {
            try
            {
                typeId = typeId.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ChassisNolist", typeId);
                return da.GetDataSet("USP_GetUpdateShippingDetails", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllUpdateshipping(entUpdateShippingDetails obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@categoryid", obj.CategoryId);
                prm[1] = new SqlParameter("@productid", obj.ProductId);
                prm[2] = new SqlParameter("@AuctionId", obj.AuctionId);
                prm[3] = new SqlParameter("@Adate", obj.Adate);
                prm[4] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[5] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("USP_GetAllUpdateShippingDetails", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllMaster()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_GetMasterUpdateshipping");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateTransport(string PID, string TID, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@PID", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@TID", Convert.ToInt32(TID));
                prm[2] = new SqlParameter("@Uid", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_AddTransportlog", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int UpdateShipping(string PID, string SID, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@PID", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@SID", Convert.ToInt32(SID));
                prm[2] = new SqlParameter("@Uid", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_AddShippinglog", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
        public int UpdatePortFrom(string PID, string PFID, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@PID", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@PFID", Convert.ToInt32(PFID));
                prm[2] = new SqlParameter("@Uid", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_AddPortFromlog", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int UpdatePortTo(string PID, string PTID, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@PID", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@PTID", Convert.ToInt32(PTID));
                prm[2] = new SqlParameter("@Uid", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_AddPortTolog", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int UpdateSoldCountry(string PID, string SCID, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@PID", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@SCID", Convert.ToInt32(SCID));
                prm[2] = new SqlParameter("@Uid", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_AddSoldCountrylog", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet GetUpdateProductDateByChessis(string typeId)
        {
            try
            {
                typeId = typeId.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ChassisNolist", typeId);
                return da.GetDataSet("USP_GetUpdateProductDateByCh", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllUpdateProductDate(UpdateProductDate obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@categoryid", obj.CategoryId);
                prm[1] = new SqlParameter("@productid", obj.ProductId);
                prm[2] = new SqlParameter("@AuctionId", obj.AuctionId);
                prm[3] = new SqlParameter("@Adate", obj.Adate);
                prm[4] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[5] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("USP_GetAllUpdateProductDate", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateProductInDate(string PID, string ProductINDate, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@ProductId", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@ProductIndate", ProductINDate);
                prm[2] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_AddProductInlog", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
        public int UpdateWishDInDate(string PID, string WishDIndate, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@ProductId", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@WishDidate", WishDIndate);
                prm[2] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_AddWishDIDatelog", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
        public int UpdateWishProductInDate(string PID, string ProductINDate, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@ProductId", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@ProductIndate", ProductINDate);
                prm[2] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_AddWishProductInlog", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
        public int UpdateWishShipDate(string PID, string WishShipdate, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@ProductId", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@WishShipdate", WishShipdate);
                prm[2] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_AddWishShiplog", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int UpdateWishArrivalDate(string PID, string WishArrivaldate, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@ProductId", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@WishArrivaldate", WishArrivaldate);
                prm[2] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_AddWishArrivallog", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
        #endregion

        #region Push Price

        public int insertPushPrice(entPushPrice obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[30];
                prm[0] = new SqlParameter("@PID", obj.PID);
                prm[1] = new SqlParameter("@Ctype", obj.CurrencyType);
                prm[2] = new SqlParameter("@PPType", obj.PPType);
                prm[3] = new SqlParameter("@PushPrice", obj.PushPrice);
                prm[4] = new SqlParameter("@PushPriceTax", obj.PushPriceTax);
                prm[5] = new SqlParameter("@ABFType", obj.ABFType);
                prm[6] = new SqlParameter("@AuctionFeed", obj.AuctionFeed);
                prm[7] = new SqlParameter("@AuctionFeedTax", obj.AuctionFeedTax);
                prm[8] = new SqlParameter("@NoPlate", obj.NoPlate);
                prm[9] = new SqlParameter("@NoPlateTax", obj.NoPlateTax);
                prm[10] = new SqlParameter("@NoPlateNTax", obj.NoPlateNTax);
                prm[11] = new SqlParameter("@Security", obj.Security);
                prm[12] = new SqlParameter("@SecurityTax", obj.SecurityTax);
                prm[13] = new SqlParameter("@SecurityNTax", obj.SecurityNTax);
                prm[14] = new SqlParameter("@Transport", obj.Transport);
                prm[15] = new SqlParameter("@TransportTax", obj.TransportTax);
                prm[16] = new SqlParameter("@Cancellation", obj.Cancellation);
                prm[17] = new SqlParameter("@CancellationTax", obj.CancellationTax);
                prm[18] = new SqlParameter("@CarPanalty", obj.CarPanalty);
                prm[19] = new SqlParameter("@RecycleFee", obj.RecycleFee);
                prm[20] = new SqlParameter("@OtherType", obj.OtherType);
                prm[21] = new SqlParameter("@OtherTypeAmt", obj.OtherTypeAmt);
                prm[22] = new SqlParameter("@OtherTypeTax", obj.OtherTypeTax);
                prm[23] = new SqlParameter("@OtherNType", obj.OtherNType);
                prm[24] = new SqlParameter("@OtherNTypeAmt", obj.OtherNTypeAmt);
                prm[25] = new SqlParameter("@TotalAmount", obj.Total);
                prm[26] = new SqlParameter("@Remarks", obj.Remarks);
                prm[27] = new SqlParameter("@uid", obj.uid);
                prm[28] = new SqlParameter("@Action", "INSERT");
                prm[29] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[29].Direction = ParameterDirection.ReturnValue;
                return da.executeDMLQuery("ProductPushPriceDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdatePushDate(entPushPrice obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@PID", obj.PID);
                prm[1] = new SqlParameter("@DOE", obj.DOE);
                prm[2] = new SqlParameter("@uid", obj.uid);
                prm[3] = new SqlParameter("@Action", "PUSHDATE");
                prm[4] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[4].Direction = ParameterDirection.ReturnValue;
                return da.executeDMLQuery("ProductPushPriceDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectPushPrice(string PID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@PID", PID);
                prm[1] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("ProductPushPriceDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SelectPushPriceByChassisNo(string Cno)
        {
            string Query = null;
            da = new DataAccess();
            Query = @"select P.id,P.ChassisNo,P.SAID as AID,  
b.Name as [AName],P.ADate,P.LotNo,Ctype,PPType,cast(isnull(AP.PushPrice,0) as decimal)PushPrice,cast(isnull(AP.PushPriceTax,0) as decimal)PushPriceTax,ABFType,  
cast(isnull(AP.AuctionFeed,0) as decimal)AuctionFeed,cast(isnull(AP.AuctionFeedTax,0) as decimal)AuctionFeedTax,  
cast(isnull(AP.NoPlate,0) as decimal)NoPlate,cast(isnull(AP.NoPlateTax,0) as decimal)NoPlateTax,cast(isnull(AP.NoPlateNTax,0) as decimal)NoPlateNTax,  
cast(isnull(AP.Security,0) as decimal)Security,cast(isnull(AP.SecurityTax,0) as decimal)SecurityTax,  
cast(isnull(AP.SecurityNTax,0) as decimal)SecurityNTax,cast(isnull(AP.Transport,0) as decimal)Transport,cast(isnull(AP.TransportTax,0) as decimal)TransportTax,  
cast(isnull(AP.Cancellation,0) as decimal)Cancellation,cast(isnull(AP.CancellationTax,0) as decimal)CancellationTax,cast(isnull(AP.CarPanalty,0) as decimal)CarPanalty,  
cast(isnull(AP.RecycleFee,0) as decimal)RecycleFee,OtherType,cast(isnull(AP.OtherTypeAmt,0) as decimal)OtherTypeAmt,cast(isnull(AP.OtherTypeTax,0) as decimal)OtherTypeTax,  
OtherNType,cast(isnull(AP.OtherNTypeAmt,0) as decimal)OtherNTypeAmt,  
cast(isnull(AP.TotalAmount,0) as decimal)TotalAmount,Remarks,AP.DOE from dbo.Purchase P  
left join dbo.ProductPushPrice AP  on P.id=AP.PID  
left join Auction A on P.SID=A.Id  
left join Auction B on P.SAID=B.Id  
where P.status=1 and P.archive=0 and P.SellerType=3 and  P.ChassisNo in (" + Cno + ") order by p.ID DESC";
            return da.GetDataSetInline(Query);
        }
        public DataSet SearchPushPrice(entSearchPushPrice obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@GID", obj.GID);
                prm[1] = new SqlParameter("@AID", obj.AID);
                prm[2] = new SqlParameter("@Adate", obj.Adate);
                prm[3] = new SqlParameter("@SAID", obj.SAID);
                prm[4] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[5] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("USP_SearchPushPrice", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Rohit
        public int AddAuctionBuy(entAuctionBuying obj, string uid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@Name", obj.Name);
                prm[1] = new SqlParameter("@uid", uid);
                prm[2] = new SqlParameter("@Action", "INSERT");
                return da.executeDMLQuery("AuctionBuyingDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int IsBuyingExists(entAuctionBuying obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@Name", obj.Name);
                prm[1] = new SqlParameter("@Action", "ISEXISTS");
                prm[2] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[2].Direction = ParameterDirection.ReturnValue;
                return da.executeDMLQuery("AuctionBuyingDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateAuctionBuy(entAuctionBuying obj, string uid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@Id", obj.Id);
                prm[1] = new SqlParameter("@Name", obj.Name);
                prm[2] = new SqlParameter("@muid", uid);
                prm[3] = new SqlParameter("@Action", "UPDATE");
                return da.executeDMLQuery("AuctionBuyingDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ViewAllBuying()
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("AuctionBuyingDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetBuyingById(string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@id", Convert.ToInt32(Id));
                prm[1] = new SqlParameter("@Action", "SELECTBYID");
                return da.GetDataSet("AuctionBuyingDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteAuctionBuying(entAuctionBuying obj)
        {

            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@id", obj.Id);
                prm[1] = new SqlParameter("@uid", obj.uid);
                prm[2] = new SqlParameter("@Action", "DELETE");
                return da.executeDMLQuery("AuctionBuyingDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public class clsUpdateInner
        {
            DataAccess da;
            public DataSet AllUpdateDropdown()
            {
                try
                {
                    da = new DataAccess();
                    return da.GetDataSet("USP_GetAllDropdown");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
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
            public DataSet GetUpdateInnerData(string typeId)
            {
                try
                {
                    typeId = typeId.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                    da = new DataAccess();
                    SqlParameter[] prm = new SqlParameter[1];
                    prm[0] = new SqlParameter("@ChassisNolist", typeId);
                    return da.GetDataSet("USP_GetChassisData", prm);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public DataSet InsertUpdateData(string CID, string PID, string CUID, string AID, string Adate, string iPageNo, string iPageRecords)
            {
                try
                {
                    da = new DataAccess();
                    SqlParameter[] prm = new SqlParameter[8];
                    prm[0] = new SqlParameter("@CID", CID);
                    prm[1] = new SqlParameter("@PID", PID);
                    prm[2] = new SqlParameter("@CUID", CUID);
                    prm[3] = new SqlParameter("@AID", AID);
                    prm[4] = new SqlParameter("@DOE", Adate);
                    prm[5] = new SqlParameter("@PageIndex", iPageNo);
                    prm[6] = new SqlParameter("@PageSize", iPageRecords);
                    prm[7] = new SqlParameter("@RecordCount", iPageRecords);
                    return da.GetDataSet("USP_GetAllUpdateDetails", prm);
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                    return new DataSet();
                }
            }
            public int InsertInnerData(string PID, string Iname, string Iweight, string Iprice, string uid, string PItype)
            {
                try
                {
                    da = new DataAccess();
                    SqlParameter[] prm = new SqlParameter[6];
                    prm[0] = new SqlParameter("@PID", PID);
                    prm[1] = new SqlParameter("@Iname", Iname);
                    prm[2] = new SqlParameter("@Iprice", Iprice);
                    prm[3] = new SqlParameter("@Iweight", Iweight);
                    prm[4] = new SqlParameter("@UID", uid);
                    prm[5] = new SqlParameter("@PItype", PItype);
                    return da.executeDMLQuery("addInnerDetails", prm);
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                    return 0;
                }
            }
        }

        #endregion

        #region Rohit 27082025
        public int addOtherAuctionBuy(entOtherTypeBuy obj, string uid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@Name", obj.Name);
                prm[1] = new SqlParameter("@uid", uid);
                prm[2] = new SqlParameter("@Action", "INSERT");
                return da.executeDMLQuery("OtherAuctionBuyingDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int IsOtherAuctionExists(entOtherTypeBuy obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@Name", obj.Name);
                prm[1] = new SqlParameter("@Action", "ISEXISTS");
                prm[2] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[2].Direction = ParameterDirection.ReturnValue;
                return da.executeDMLQuery("OtherAuctionBuyingDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updateOtherAuctionBuy(entOtherTypeBuy obj, string uid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@Id", obj.Id);
                prm[1] = new SqlParameter("@Name", obj.Name);
                prm[2] = new SqlParameter("@muid", uid);
                prm[3] = new SqlParameter("@Action", "UPDATE");
                return da.executeDMLQuery("OtherAuctionBuyingDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet viewAllOtherAuctionBuy()
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("OtherAuctionBuyingDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getAllOtherAuctionById(string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@id", Convert.ToInt32(Id));
                prm[1] = new SqlParameter("@Action", "SELECTBYID");
                return da.GetDataSet("OtherAuctionBuyingDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int deleteOtherAuction(entOtherTypeBuy obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@id", obj.Id);
                prm[1] = new SqlParameter("@uid", obj.uid);
                prm[2] = new SqlParameter("@Action", "DELETE");
                return da.executeDMLQuery("OtherAuctionBuyingDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Created By Ashish 26/08/25
        public DataSet AllPortBind()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_GetAllPort");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddPortAndAuction(string selectedPort, string id, string days, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@PID", selectedPort);
                prm[1] = new SqlParameter("@AID", id);
                prm[2] = new SqlParameter("@Days", days);
                prm[3] = new SqlParameter("@UID", UID);
                return da.executeDMLQuery("InsertAddAuctionPort", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        #endregion

        #region Invoice Management
        public DataSet GetMastersDataForInvoice()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_GetMastersDataForInvoice");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region created by Ashish 11/09/25
        public DataSet TransportBind()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_SelectTransport");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetRegion()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_GetRegion");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateTransportRID(string RID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@RID", RID);
                return da.executeDMLQuery("USP_UpdateTransportRID", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public int AddTransportToCity(string TransportId, string RID, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@TID", TransportId);
                prm[1] = new SqlParameter("@RID", RID);
                prm[2] = new SqlParameter("@UID", UID);
                return da.executeDMLQuery("USP_AddTransportToCityR", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
        public DataSet FindtransPortRID(int TID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@TID", TID);
                return da.GetDataSet("USP_ViewTransportRID", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllAnotherStatus(UpdateAnotherStatus obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[13];
                prm[0] = new SqlParameter("@CategoryId", obj.CategoryId);
                prm[1] = new SqlParameter("@ProductId", obj.ProductId);
                prm[2] = new SqlParameter("@AuctionId", obj.AuctionId);
                prm[3] = new SqlParameter("@ShippingId", obj.ShippingId);
                prm[4] = new SqlParameter("@PortId", obj.PortFromId);
                prm[5] = new SqlParameter("@SCountryId", obj.SoldCountryId);
                prm[6] = new SqlParameter("@UrgentId", obj.Urgent);
                prm[7] = new SqlParameter("@Adate", obj.Adate);
                prm[8] = new SqlParameter("@RikujiDate", obj.RDate);
                prm[9] = new SqlParameter("@DRdate", obj.DRDate);
                prm[10] = new SqlParameter("@RegisDate", obj.RegisDate);
                prm[11] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[12] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("USP_GetAllAnotherStatus", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAnotherStatusByChassis(string typeId)
        {
            try
            {
                typeId = typeId.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ChassisNolist", typeId);
                return da.GetDataSet("USP_GetAnotherStatusByCh", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateDocReceiveDate(string PID, string DRD, string DRRemark, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@ProductId", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@DRD", DRD);
                prm[2] = new SqlParameter("@DRRemark", DRRemark);
                prm[3] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_AddDReceiveDate", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
        public int UpdateDocSendDate(string PID, string DSD, string DSRemark, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@ProductId", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@DSD", DSD);
                prm[2] = new SqlParameter("@DSRemark", DSRemark);
                prm[3] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_AddDSendDate", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet GetSDropDown()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_GetSurrenderDrop");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllLoadingSurrender(UpdateLoadingSurrender obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[9];
                prm[0] = new SqlParameter("@ShippingId", obj.ShippingId);
                prm[1] = new SqlParameter("@ClientId", obj.ClientId);
                prm[2] = new SqlParameter("@PortId", obj.PortId);
                prm[3] = new SqlParameter("@ShipId", obj.ShipId);
                prm[4] = new SqlParameter("@SurrenderId", obj.SurrenderId);
                prm[5] = new SqlParameter("@ChassisNo", obj.ChassisNo);
                prm[6] = new SqlParameter("@BrokerId", obj.BrokerId);
                prm[7] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[8] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("USP_GetAllLoadingSurrender", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateSurrender(string PID, int Surrender, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@ProductId", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@Surrender", Surrender);
                prm[2] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_UpdateSurrender", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
        public int UpdateLoading(string PID, int Loading, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@ProductId", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@Loading", Loading);
                prm[2] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_Updateloading", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet GetShippingEmail(int A)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@SID", A);
                return da.GetDataSet("USP_GetShippingEmail", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUpdateDSdateByChe(string ChassissNo)
        {
            try
            {
                ChassissNo = ChassissNo.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ChassisNolist", ChassissNo);
                return da.GetDataSet("USP_GetUpdateDSendDateByChe", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllDSendDate(entDocumnetSendDate obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@categoryid", obj.CategoryId);
                prm[1] = new SqlParameter("@productid", obj.ProductId);
                prm[2] = new SqlParameter("@AuctionId", obj.AuctionId);
                prm[3] = new SqlParameter("@Adate", obj.Adate);
                prm[4] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[5] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("USP_GetAllDocSendDate", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateDSShippingPort(string ID, string SID, string PFID, string Date, string Uid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@ID", Convert.ToInt32(ID));
                prm[1] = new SqlParameter("@SID", Convert.ToInt32(SID));
                prm[2] = new SqlParameter("@PFID", Convert.ToInt32(PFID));
                prm[3] = new SqlParameter("@DSD", Date);
                prm[4] = new SqlParameter("@UID", Convert.ToInt32(Uid));
                return da.executeDMLQuery("USP_AddAllDSendLog", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet GetNotifyByChassiss(string typeId)
        {
            try
            {
                typeId = typeId.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ChassisNolist", typeId);
                return da.GetDataSet("USP_UpdateNotifyGetByCh", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllUpdateNotify(entNotifyPartyCFS obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[7];
                prm[0] = new SqlParameter("@categoryid", obj.CategoryId);
                prm[1] = new SqlParameter("@productid", obj.ProductId);
                prm[2] = new SqlParameter("@ClientId", obj.ClientId);
                prm[3] = new SqlParameter("@AuctionId", obj.AuctionId);
                prm[4] = new SqlParameter("@Adate", obj.Adate);
                prm[5] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[6] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("USP_GetAllUpdateNotify", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddNotify(string PID, string notify, string address, string contact, string Email, string uid, string upby)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[7];
                prm[0] = new SqlParameter("@PID", Convert.ToInt32(PID));
                prm[1] = new SqlParameter("@Notify", notify);
                prm[2] = new SqlParameter("@Naddress", address);
                prm[3] = new SqlParameter("@Ncontact", contact);
                prm[4] = new SqlParameter("@Nemail", Email);
                prm[5] = new SqlParameter("@Upby", upby);
                prm[6] = new SqlParameter("@UID", Convert.ToInt32(uid));
                return da.executeDMLQuery("USP_AddNotifyMaster", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet GetDConfirmationByChas(string typeId)
        {
            try
            {
                typeId = typeId.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ChassisNolist", typeId);
                return da.GetDataSet("USP_GetDConfirmationByCha", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllDConfirmation(DocumentConfirmation obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[16];
                prm[0] = new SqlParameter("@ShippingId", obj.ShippingId);
                prm[1] = new SqlParameter("@ShipNameId", obj.ShipNameId);
                prm[2] = new SqlParameter("@PortId", obj.PortId);
                prm[3] = new SqlParameter("@Loading", obj.Loading);
                prm[4] = new SqlParameter("@Urgent", obj.Urgent);
                prm[5] = new SqlParameter("@CustomerId", obj.CustomerId);
                prm[6] = new SqlParameter("@ProductIndate", obj.ProductIndate);
                prm[7] = new SqlParameter("@ProductType", obj.ProductType);
                prm[8] = new SqlParameter("@RikujiDate", obj.RikujiDate);
                prm[9] = new SqlParameter("@SoldCountry", obj.SoldCountry);
                prm[10] = new SqlParameter("@FDate", obj.FDate);
                prm[11] = new SqlParameter("@TDate", obj.TDate);
                prm[12] = new SqlParameter("@TransportId", obj.TransportId);
                prm[13] = new SqlParameter("@CarStatus", obj.CarStatus);
                prm[14] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[15] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("USP_GetAllDocConfirmation", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Shiplock(string ID, string Uid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@PID", Convert.ToInt32(ID));
                prm[1] = new SqlParameter("@UID", Convert.ToInt32(Uid));
                return da.executeDMLQuery("USP_ShipLock", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet GetInspection(string Chassis)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ChassisNo", Chassis);
                return da.GetDataSet("USP_GetInspectionByCh", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetAddAllInspection(Inspection obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[15];
                prm[0] = new SqlParameter("@ChassisNo", obj.ChassisNo);
                prm[1] = new SqlParameter("@InsRRDate", obj.InsRRDate);
                prm[2] = new SqlParameter("@InsRRRemark", obj.InsRRRemark);
                prm[3] = new SqlParameter("@PayFInsDate", obj.PayFInsDate);
                prm[4] = new SqlParameter("@PayFInsRemark", obj.PayFInsRemark);
                prm[5] = new SqlParameter("@InsDate", obj.InsDate);
                prm[6] = new SqlParameter("@InsDRemark", obj.InsDRemark);
                prm[7] = new SqlParameter("@InsStatus", obj.InsStatus);
                prm[8] = new SqlParameter("@InsSRemark", obj.InsSRemark);
                prm[9] = new SqlParameter("@InsDocSend", obj.InsDocSend);
                prm[10] = new SqlParameter("@InsDocSRemark", obj.InsDocSRemark);
                prm[11] = new SqlParameter("@InsDocBack", obj.InsDocBack);
                prm[12] = new SqlParameter("@InsDocBRemark", obj.InsDocBRemark);
                prm[13] = new SqlParameter("@Certificate", obj.Certificate);
                prm[14] = new SqlParameter("@Uid", obj.Uid);
                return da.executeDMLQuery("USP_GetAllInspection", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int deleteInspectionDetails(string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                return da.executeDMLQuery("USP_Deleteinspection", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Blogs
        public int insertBlogs(entBlogs obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[7];
                prm[0] = new SqlParameter("@TopicId", obj.TopicId);
                prm[1] = new SqlParameter("@BlogTitle", obj.BlogTitle);
                prm[2] = new SqlParameter("@BlogURL", obj.BlogURL);
                prm[3] = new SqlParameter("@BlogDate", obj.BlogDate);
                prm[4] = new SqlParameter("@BlogImage", obj.BlogImage);
                prm[5] = new SqlParameter("@uid", obj.uid);
                prm[6] = new SqlParameter("@Action", "INSERT");
                return da.executeDMLQuery("USP_ManageBlogsDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateBlogs(entBlogs obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[8];
                prm[0] = new SqlParameter("@id", obj.id);
                prm[1] = new SqlParameter("@TopicId", obj.TopicId);
                prm[2] = new SqlParameter("@BlogTitle", obj.BlogTitle);
                prm[3] = new SqlParameter("@BlogURL", obj.BlogURL);
                prm[4] = new SqlParameter("@BlogDate", obj.BlogDate);
                prm[5] = new SqlParameter("@BlogImage", obj.BlogImage);
                prm[6] = new SqlParameter("@uid", obj.uid);
                prm[7] = new SqlParameter("@Action", "UPDATE");
                return da.executeDMLQuery("USP_ManageBlogsDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deleteBlogs(entBlogs obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@id", obj.id);
                prm[1] = new SqlParameter("@uid", obj.uid);
                prm[2] = new SqlParameter("@Action", "DELETE");
                return da.executeDMLQuery("USP_ManageBlogsDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AssignAuthortoBlog(entBlogs obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@id", obj.id);
                prm[1] = new SqlParameter("@uid", obj.uid);
                prm[2] = new SqlParameter("@Authorid", obj.BlogAuthor);
                prm[3] = new SqlParameter("@Action", "ASSIGNAUTHOR");
                prm[4] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[4].Direction = ParameterDirection.ReturnValue;
                return da.executeDMLQuery("USP_ManageBlogsDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet selectBlogByid(entBlogs obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@id", obj.id);
                prm[1] = new SqlParameter("@Action", "SELECTBYID");
                return da.GetDataSet("USP_ManageBlogsDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet selectBlogForPreview(string id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@id", id);
                return da.GetDataSet("USP_GetblogdetailsForPreview", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet selectBlogs()
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("USP_ManageBlogsDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBlogTopic()
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Action", "SELECTBLOGTOPIC");
                return da.GetDataSet("USP_ManageBlogsDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Akash

        // Update-Doc-Receive-Date
        public DataSet GetAllUpdateDocRD(UpdateDocReceiveDate obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@ADate", obj.ADate);
                prm[1] = new SqlParameter("@Urgent", obj.Urgent);
                prm[2] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[3] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("GetAllUpdateDocRDate", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUpdateDocRDByChassisNo(string ChassisNo)
        {
            try
            {
                ChassisNo = ChassisNo.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ChassisNO", ChassisNo);
                return da.GetDataSet("GetUpdateDocRByChassisNo", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateDataForUDRD(string ProductID, string DrDate)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@ProductID", ProductID);
                prm[1] = new SqlParameter("@DRdate", DrDate);
                return da.executeDMLQuery("UpdateDocStatus", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Purchase Report
        public DataSet GetDropDownPurchaseReport()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetDDPurchaseReport");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllPurchaseReport(PurchaseReport obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@ShippingID", obj.ShipingID);
                prm[1] = new SqlParameter("@AuctionID", obj.AuctionID);
                prm[2] = new SqlParameter("@ChassisNo", obj.ChassisNo);
                prm[3] = new SqlParameter("@FromDate", obj.FromDate);
                prm[4] = new SqlParameter("@ToDate", obj.ToDate);
                return da.GetDataSet("GetAllPurchaseReport", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Client Report

        public DataSet GetDropDownClientReport()
        {
            da = new DataAccess();
            return da.GetDataSet("GetDDClientReport");
        }

        public DataSet GetAllClientReport(string ClientID)
        {
            try
            {

                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ClientID", ClientID);
                return da.GetDataSet("GetAllClientReport", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Auction Report

        public DataSet GetDropDownAuctionReport()
        {
            da = new DataAccess();
            return da.GetDataSet("GetDDAuctionReport");
        }

        public DataSet GetAllAuctionReport()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            return da.GetDataSet("GetAllAuctionReport");
        }

        public DataSet GetDropDownByID(string ID)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@AGroup", ID);
            return da.GetDataSet("GetDDAuctionReportByID", prm);
        }

        //Update Broker New 

        public DataSet GetDropDownUpdateBrokerNew()
        {
            da = new DataAccess();
            return da.GetDataSet("GetDDUpdateBrokerNew");

        }

        public DataSet GetAllUpdateBrokerNew(UpdateBrokerNew obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[8];
                prm[0] = new SqlParameter("@CategoryID", obj.CategoryID);
                prm[1] = new SqlParameter("@ProductID", obj.ProductID);
                prm[2] = new SqlParameter("@ClientID", obj.ClientID);
                prm[3] = new SqlParameter("@ShipID", obj.ShipID);
                prm[4] = new SqlParameter("@AuctionID", obj.AuctionID);
                prm[5] = new SqlParameter("@AuctionDate", obj.AuctionDate);
                prm[6] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[7] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("GetAllUpdateBrokerNew", prm);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUpdateBrokerNewByChassisNo(string Chassisno)
        {
            try
            {

                Chassisno = Chassisno.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ChassisNo", Chassisno);
                return da.GetDataSet("GetUpdateBrokerNewByChassisNo", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateBrokerNewLog(UpdateBrokerNewDetails obj)
        {
            try
            {

                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@ProductID", obj.Productid);
                prm[1] = new SqlParameter("@BrokerID", obj.BrokerID);
                prm[2] = new SqlParameter("@UpBy", obj.UPBY);
                prm[3] = new SqlParameter("@UID", obj.UID);
                return da.executeDMLQuery("UpdateBrokerNewLog", prm);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Shipping History

        public DataSet GetDropDownShippingHistory()
        {
            da = new DataAccess();
            return da.GetDataSet("GetDDShippingHistory");
        }

        public DataSet GetAllShippingHistory(ShippingHistory obj)
        {
            try
            {

                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@ShippingID", obj.ShippingID);
                prm[1] = new SqlParameter("@ChassisNo", obj.ChassisNo);
                prm[2] = new SqlParameter("@FromDate", obj.FromDate);
                prm[3] = new SqlParameter("@ToDate", obj.ToDate);
                return da.GetDataSet("GetAllShippingHistory", prm);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        // Port History

        public DataSet GetDropDownPortHistory()
        {
            da = new DataAccess();
            return da.GetDataSet("GetDDPortHistory");
        }

        public DataSet GetAllPortHistory(PortHistory obj)
        {
            try
            {

                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@PortID", obj.PortID);
                prm[1] = new SqlParameter("@ChassisNo", obj.ChassisNO);
                prm[2] = new SqlParameter("@FromDate", obj.FromDate);
                prm[3] = new SqlParameter("@ToDate", obj.ToDate);
                return da.GetDataSet("GetAllPortHistory", prm);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Bill-No-History 

        public DataSet GetAllBillNoHistory(BillNoHistory billNoHistory)
        {
            try
            {

                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@ChassisNo", billNoHistory.ChassisNo);
                prm[1] = new SqlParameter("@FromDate", billNoHistory.FromDate);
                prm[2] = new SqlParameter("@ToDate", billNoHistory.ToDate);
                return da.GetDataSet("GetAllBillNoHistory", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // TransPort History

        public DataSet GetDropDownTransportHistory()
        {
            da = new DataAccess();
            return da.GetDataSet("GetDDTransportHistory");
        }

        public DataSet GetAllTransportHistory(TransportHistory transportHistory)
        {
            try
            {
                da = new DataAccess();

                SqlParameter[] prm = new SqlParameter[4];
                prm[0] = new SqlParameter("@TranportID", transportHistory.TransportID);
                prm[1] = new SqlParameter("@ChassisNo", transportHistory.ChassisNo);
                prm[2] = new SqlParameter("@FromDate", transportHistory.FromDate);
                prm[3] = new SqlParameter("@ToDate", transportHistory.ToDate);
                return da.GetDataSet("GetAllTransportHistory", prm);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // Transport-Bill

        public DataSet GetDropDownTransportBill()
        {
            try
            {

                da = new DataAccess();
                return da.GetDataSet("GetDDFTranportBill");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDropDownTransportBillByID(string CategoryID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@CategoryID", CategoryID);
                return da.GetDataSet("GetDDTransportBillByID", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetTransportBillByChassisNo(string ChassisNo)
        {
            da = new DataAccess();

            ChassisNo = ChassisNo.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");

            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@ChassisNo", ChassisNo);
            return da.GetDataSet("GetTransportBillByChassisNO", prm);
        }
        public DataSet GetAllTransportBill(GetTransportBill TransBill)
        {
            try
            {

                da = new DataAccess();

                SqlParameter[] prm = new SqlParameter[7];
                prm[0] = new SqlParameter("@CategoryID", TransBill.CategoryID);
                prm[1] = new SqlParameter("@ProductID", TransBill.ProductID);
                prm[2] = new SqlParameter("@AuctionID", TransBill.AuctionID);
                prm[3] = new SqlParameter("@TransportID", TransBill.TransportID);
                prm[4] = new SqlParameter("@ADate", TransBill.TransportDate);
                prm[5] = new SqlParameter("@PageIndex", TransBill.Pageindex);
                prm[6] = new SqlParameter("@PageSize", TransBill.Pagesize);


                return da.GetDataSet("GetAllTransportBill", prm);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddTransportBill(TransportBill billdata)
        {
            try
            {

                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[9];

                prm[0] = new SqlParameter("@PID", billdata.PID);
                prm[1] = new SqlParameter("@TID", billdata.TID);
                prm[2] = new SqlParameter("@Tcharges", billdata.Tcharges);
                prm[3] = new SqlParameter("@Extracharges", billdata.Extracharges);
                prm[4] = new SqlParameter("@Tamount", billdata.Tamount);
                prm[5] = new SqlParameter("@Extraamt", billdata.Extraamt);
                prm[6] = new SqlParameter("@Remark", billdata.Remark);
                prm[7] = new SqlParameter("@UID", billdata.UID);
                prm[8] = new SqlParameter("@DOE", billdata.DOE);
                return da.executeDMLQuery("AddTranportBill", prm);
            }
            catch (Exception ex)
            {
                string S = ex.Message;
                return 0;
            }
        }


        #endregion

        #region Anjali 

        public DataSet CategoryBind()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_GetCategoryData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getProduct(int prod)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@CategoryId", prod);
                return da.GetDataSet("Productbycategory", par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUpdateData(string typeId)
        {
            try
            {
                typeId = typeId.Replace("'", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ChassisNo", typeId);
                return da.GetDataSet("USP_GetShippingByCH", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUpdateshippingdata(UpdateShipping obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@categoryid", obj.CategoryId);
                prm[1] = new SqlParameter("@productid", obj.ProductId);
                prm[2] = new SqlParameter("@AuctionId", obj.AuctionId);
                prm[3] = new SqlParameter("@Adate", obj.Adate);
                prm[4] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[5] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("GetUpdateshippdata", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetallShippingbind()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_MasterShipping");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateShippingData(string pid, string SID, string uid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@PID", Convert.ToInt32(pid));
                par[1] = new SqlParameter("@SID", SID);
                par[2] = new SqlParameter("@Uid", Convert.ToInt32(uid));
                return da.executeDMLQuery("USP_AddShippinglog", par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateProtFormData(string Pid, string Pfid, string Uid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@PID", Convert.ToInt32(Pid));
                prm[1] = new SqlParameter("@PFID", Convert.ToInt32(Pfid));
                prm[2] = new SqlParameter("@Uid", Convert.ToInt32(Uid));
                return da.executeDMLQuery("USP_AddPortFromlog", prm);

            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        #endregion 

        #region Unsold-Ship-Car
        public DataSet GetAllUnsoldShipDDL()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_GetUnsoldDropDown");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet GetAllUnsoldShipCar(entUnsoldShipCar obj)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[11];
                prm[0] = new SqlParameter("@ShippingId", obj.ShippingId);
                prm[1] = new SqlParameter("@CountryId", obj.CountryId);
                prm[2] = new SqlParameter("@ClientId", obj.ClientId);
                prm[3] = new SqlParameter("@PortId", obj.PortId);
                prm[4] = new SqlParameter("@ShipId", obj.ShipId);
                prm[5] = new SqlParameter("@SurrenderId", obj.SurrenderId);
                prm[6] = new SqlParameter("@ChassisNo", obj.ChassisNo);
                prm[7] = new SqlParameter("@DateFrom", obj.DateFrom);
                prm[8] = new SqlParameter("@DateTo", obj.DateTo);
                prm[9] = new SqlParameter("@PageIndex", obj.PageIndex);
                prm[10] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("USP_GetAllUnsoldShipCar", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }
        #endregion
    }
}
