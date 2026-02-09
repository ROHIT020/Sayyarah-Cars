using COMMON;
using ENTITY;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class clsMasters
    {
        DataAccess da;
        public DataSet checkAdminLogin(string emailid, string password)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@username", emailid);
            prm[1] = new SqlParameter("@password", password);
            prm[2] = new SqlParameter("@Action", "IsValidUID");
            return da.GetDataSet("AdminLoginInfoDML", prm);
        }
        public DataSet getAdminLoginDetails(string id)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@id", id);
            prm[1] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("AdminLoginInfoDML", prm);
        }
        public DataSet ListAdminLoginDetails()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("AdminLoginInfoDML", prm);
        }

        public int ChangeAdminPassword(string id, string oldpassword, string password)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[5];
            prm[0] = new SqlParameter("@id", id);
            prm[1] = new SqlParameter("@password", oldpassword);
            prm[2] = new SqlParameter("@newpwd", password);
            prm[3] = new SqlParameter("@Action", "UPDATE");
            prm[4] = new SqlParameter("ReturnValue", SqlDbType.Int);
            prm[4].Direction = ParameterDirection.ReturnValue;
            return da.executeDMLQuery("AdminLoginInfoDML", prm);
        }
        public DataSet checkUserLogin(string emailid, string password)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@username", emailid);
            prm[1] = new SqlParameter("@password", password);
            prm[2] = new SqlParameter("@Action", "IsValidUID");
            return da.GetDataSet("UserLoginInfoDML", prm);
        }

        public int ChangeUserPassword(string id, string oldpassword, string password)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[5];
            prm[0] = new SqlParameter("@id", id);
            prm[1] = new SqlParameter("@password", oldpassword);
            prm[2] = new SqlParameter("@newpwd", password);
            prm[3] = new SqlParameter("@Action", "UPDATE");
            prm[4] = new SqlParameter("ReturnValue", SqlDbType.Int);
            prm[4].Direction = ParameterDirection.ReturnValue;
            return da.executeDMLQuery("UserLoginInfoDML", prm);
        }
        public DataSet getUserLoginDetails(string id)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@id", id);
            prm[1] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("UserLoginInfoDML", prm);
        }
        public DataSet bindMenu(entmanu obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@PID", obj.PID);
            prm[1] = new SqlParameter("@Action", "SELECTBYPID");
            prm[2] = new SqlParameter("@utype", obj.utype);
            return da.GetDataSet("ManageMenuDML", prm);
        }
        public DataSet SelectMenuByID(entmanu obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@ID", obj.ID);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("ManageMenuDML", prm);
        }

        public int AssignMenu(entmanu obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@UID", obj.uid);
            prm[1] = new SqlParameter("@MID", obj.MenuURL);
            prm[2] = new SqlParameter("@AssignedBy", obj.ID);
            prm[3] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("AssignMenusDML", prm);
        }
        public DataSet getAssignedMenuByUID(string uid)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@UID", uid);
            prm[1] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("AssignMenusDML", prm);
        }
        public DataSet bindAssignedMenuByUID(string uid)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@UID", uid);
            prm[1] = new SqlParameter("@Action", "MENUBYUID");
            return da.GetDataSet("AssignMenusDML", prm);
        }

        public DataSet bindUserMenuByUtype(string utype)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@utype", utype);
            prm[1] = new SqlParameter("@Action", "MENUBYUTYPE");
            return da.GetDataSet("AssignMenusDML", prm);
        }
        public int InsertMenu(entmanu obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@MenuTitle", obj.MenuTitle);
            prm[1] = new SqlParameter("@MenuURL", obj.MenuURL);
            prm[2] = new SqlParameter("@PID", obj.PID);
            prm[3] = new SqlParameter("@uid", obj.uid);
            prm[4] = new SqlParameter("@utype", obj.utype);
            prm[5] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("ManageMenuDML", prm);
        }
        public int updateMenu(entmanu obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[7];
            prm[0] = new SqlParameter("@id", obj.ID);
            prm[1] = new SqlParameter("@MenuTitle", obj.MenuTitle);
            prm[2] = new SqlParameter("@MenuURL", obj.MenuURL);
            prm[3] = new SqlParameter("@PID", obj.PID);
            prm[4] = new SqlParameter("@uid", obj.uid);
            prm[5] = new SqlParameter("@utype", obj.utype);
            prm[6] = new SqlParameter("@Action", "UPDATE");
            return da.executeDMLQuery("ManageMenuDML", prm);
        }
        public int DeleteMenu(entmanu obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@id", obj.ID);
            prm[1] = new SqlParameter("@uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("ManageMenuDML", prm);
        }
        public DataSet BindUserMasters()
        {
            da = new DataAccess();
            return da.GetDataSet("USP_GetUserMasters");
        }
        public DataSet SelectAuctionBuyType()
        {
            da = new DataAccess();
            return da.GetDataSet("USP_GetAuctionBuyType");
        }
        public DataSet SelectCurrencyType()
        {
            da = new DataAccess();
            return da.GetDataSetInline("select id,Ctype+' ('+Symbol+')' as Ctype  from dbo.CurrencyType where status=1 and archive=0");
        }
        #region Ashsih 17072025
        public DataSet CountryBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageCountry", prm);
        }

        public int InsertLocation(entLocation obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[5];
            prm[0] = new SqlParameter("@CountryId", obj.CountryId);
            prm[1] = new SqlParameter("@LocationName", obj.LocationName);
            prm[2] = new SqlParameter("@uid", obj.uid);
            prm[3] = new SqlParameter("@Action", "INSERT");
            prm[4] = new SqlParameter("@Archive", obj.Archive);
            return da.executeDMLQuery("ManageLocation", prm);
        }

        public DataSet SelectlocationByID(entLocation obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("ManageLocation", prm);
        }

        public int DeleteLocation(entLocation obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("ManageLocation", prm);
        }

        public DataSet Selectlocation()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageLocation", prm);
        }

        public int updateLocation(entLocation obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@CountryId", obj.CountryId);
            prm[2] = new SqlParameter("@LocationName", obj.LocationName);
            prm[3] = new SqlParameter("@uid", obj.uid);
            prm[4] = new SqlParameter("@Action", "UPDATE");
            prm[5] = new SqlParameter("@Archive", obj.Archive);
            return da.executeDMLQuery("ManageLocation", prm);
        }
        #endregion


        #region Created by Ashsih 18072025
        public int InsertTransport(entTransport obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[8];
            prm[0] = new SqlParameter("@CountryId", obj.CountryId);
            prm[1] = new SqlParameter("@TransportName", obj.TransportName);
            prm[2] = new SqlParameter("@Address", obj.Address);
            prm[3] = new SqlParameter("@Email", obj.Email);
            prm[4] = new SqlParameter("@FaxNumber", obj.FaxNumber);
            prm[5] = new SqlParameter("@uid", obj.uid);
            prm[6] = new SqlParameter("@Archive", obj.Archive);
            prm[7] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("MangeTransport", prm);
        }

        public DataSet SelectTransport()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("MangeTransport", prm);
        }

        public int DeleteTransport(entTransport obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("MangeTransport", prm);
        }

        public int updateTransport(entTransport obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[9];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@CountryId", obj.CountryId);
            prm[2] = new SqlParameter("@TransportName", obj.TransportName);
            prm[3] = new SqlParameter("@Address", obj.Address);
            prm[4] = new SqlParameter("@Email", obj.Email);
            prm[5] = new SqlParameter("@FaxNumber", obj.FaxNumber);
            prm[6] = new SqlParameter("@uid", obj.uid);
            prm[7] = new SqlParameter("@Action", "UPDATE");
            prm[8] = new SqlParameter("@Archive", obj.Archive);
            return da.executeDMLQuery("MangeTransport", prm);
        }
        public DataSet SelectTransportById(entTransport obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("MangeTransport", prm);
        }


        public int InsertShipping(entShipping obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[8];
            prm[0] = new SqlParameter("@CountryId", obj.CountryId);
            prm[1] = new SqlParameter("@ShippingName", obj.ShippingName);
            prm[2] = new SqlParameter("@ShippingRate", obj.ShippingRate);
            prm[3] = new SqlParameter("@Email", obj.Email);
            prm[4] = new SqlParameter("@Contact", obj.Contact);
            prm[5] = new SqlParameter("@uid", obj.uid);
            prm[6] = new SqlParameter("@Archive", obj.Archive);
            prm[7] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("ManageShipping", prm);
        }

        public DataSet SelectShipping()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageShipping", prm);
        }

        public int DeleteShipping(entShipping obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("ManageShipping", prm);
        }

        public int updateShipping(entShipping obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[9];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@CountryId", obj.CountryId);
            prm[2] = new SqlParameter("@ShippingName", obj.ShippingName);
            prm[3] = new SqlParameter("@ShippingRate", obj.ShippingRate);
            prm[4] = new SqlParameter("@Email", obj.Email);
            prm[5] = new SqlParameter("@Contact", obj.Contact);
            prm[6] = new SqlParameter("@uid", obj.uid);
            prm[7] = new SqlParameter("@Archive", obj.Archive);
            prm[8] = new SqlParameter("@Action", "UPDATE");
            return da.executeDMLQuery("ManageShipping", prm);
        }

        public DataSet SelectShippingById(entShipping obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("ManageShipping", prm);
        }


        public int InsertPortPrice(entPortPrice obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[8];
            prm[0] = new SqlParameter("@CountryFromId", obj.CountryFromId);
            prm[1] = new SqlParameter("@CountryToId", obj.CountryToId);
            prm[2] = new SqlParameter("@InspectionPrice", obj.InspectionPrice);
            prm[3] = new SqlParameter("@RadiationPrice", obj.RatiaionPrice);
            prm[4] = new SqlParameter("@PortPrice", obj.PortPrice);
            prm[5] = new SqlParameter("@MiscPrice", obj.MiscPrice);
            prm[6] = new SqlParameter("@uid", obj.uid);
            prm[7] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("ManagePortPrice", prm);
        }

        public int updatePortPrice(entPortPrice obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[10];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@CountryFromId", obj.CountryFromId);
            prm[2] = new SqlParameter("@CountryToId", obj.CountryToId);
            prm[3] = new SqlParameter("@InspectionPrice", obj.InspectionPrice);
            prm[4] = new SqlParameter("@RadiationPrice", obj.RatiaionPrice);
            prm[5] = new SqlParameter("@PortPrice", obj.PortPrice);
            prm[6] = new SqlParameter("@MiscPrice", obj.MiscPrice);
            prm[7] = new SqlParameter("@Archive", obj.Archive);
            prm[8] = new SqlParameter("@uid", obj.uid);
            prm[9] = new SqlParameter("@Action", "UPDATE");
            return da.executeDMLQuery("ManagePortPrice", prm);
        }

        public DataSet SelectPortPrice()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManagePortPrice", prm);
        }

        public int DeletePortPrice(entPortPrice obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("ManagePortPrice", prm);
        }

        public DataSet SelectPortPriceById(entPortPrice obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("ManagePortPrice", prm);
        }
        #endregion


        #region Rohit 17072025
        public int InsertMaker(entmaker obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@MakerName", obj.MakerName);
            prm[1] = new SqlParameter("@MakerLogo", obj.MakerLogo);
            prm[2] = new SqlParameter("@Uid", obj.uid);
            prm[3] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("MakerMasterDML", prm);
        }

        public DataSet SelectMaker(entmaker obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("MakerMasterDML", prm);
        }
        public DataSet SelectMakerByID(entmaker obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Id", obj.Id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("MakerMasterDML", prm);
        }
        public int DeleteMaker(entmaker obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Id", obj.Id);
            prm[1] = new SqlParameter("@Uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("MakerMasterDML", prm);
        }
        public int updateMaker(entmaker obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@Id", obj.Id);
            prm[1] = new SqlParameter("@MakerName", obj.MakerName);
            prm[2] = new SqlParameter("@MakerLogo", obj.MakerLogo);
            prm[3] = new SqlParameter("@Uid", obj.uid);
            prm[4] = new SqlParameter("@Action", "UPDATE");
            prm[5] = new SqlParameter("@Archive", obj.Archive);
            return da.executeDMLQuery("MakerMasterDML", prm);
        }
        #endregion

        #region Lalit 06082025
        public int InsertCategory(CategoryModel obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[7];
            prm[0] = new SqlParameter("@pid", obj.pid);
            prm[1] = new SqlParameter("@CategoryName", obj.CategoryName);
            prm[2] = new SqlParameter("@CategoryIcon", obj.CategoryIcon);
            prm[3] = new SqlParameter("@uid", obj.uid);
            prm[4] = new SqlParameter("@Archive", obj.cActive);
            prm[5] = new SqlParameter("@Action", "INSERT");
            prm[6] = new SqlParameter("ReturnValue", SqlDbType.Int);
            prm[6].Direction = ParameterDirection.ReturnValue;
            return da.executeDMLQuery("USP_CategoryDML", prm);
        }
        public int UpdateCategory(CategoryModel obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[8];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@pid", obj.pid);
            prm[2] = new SqlParameter("@CategoryName", obj.CategoryName);
            prm[3] = new SqlParameter("@CategoryIcon", obj.CategoryIcon);
            prm[4] = new SqlParameter("@uid", obj.uid);
            prm[5] = new SqlParameter("@Archive", obj.cActive);
            prm[6] = new SqlParameter("@Action", "UPDATE");
            prm[7] = new SqlParameter("ReturnValue", SqlDbType.Int);
            prm[7].Direction = ParameterDirection.ReturnValue;
            return da.executeDMLQuery("USP_CategoryDML", prm);
        }
        public DataSet SelectCategory()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("USP_CategoryDML", prm);
        }
        public DataSet SelectCategories(string pid)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@pid", pid);
            prm[1] = new SqlParameter("@Action", "SACTIVE");
            return da.GetDataSet("USP_CategoryDML", prm);
        }
        public DataSet SelectCategoryByPID(string pid)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@pid", pid);
            prm[1] = new SqlParameter("@Action", "SELECTBYPID");
            return da.GetDataSet("USP_CategoryDML", prm);
        }
        public DataSet SelectCatgeoryByID(string id)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Id", id);
            prm[1] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("USP_CategoryDML", prm);
        }
        public int DeleteCatgeory(string id, string uid)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Id", id);
            prm[1] = new SqlParameter("@uid", uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("USP_CategoryDML", prm);
        }

        #endregion

        #region Rohit 18072025

        public int InsertBodyType(entbodyType obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[5];
            prm[0] = new SqlParameter("@BodyTypeName", obj.BodyTypeName);
            prm[1] = new SqlParameter("@BodyTypeIcon", obj.BodyTypeIcon);
            prm[2] = new SqlParameter("@Uid", obj.uid);
            prm[3] = new SqlParameter("@Archive", obj.Archive);
            prm[4] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("BodyTypeMasterDML", prm);
        }

        public DataSet SelectBodyType(entbodyType obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("BodyTypeMasterDML", prm);
        }
        public DataSet SelectBodyTypeByID(entbodyType obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Id", obj.Id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("BodyTypeMasterDML", prm);
        }
        public int DeleteBodyType(entbodyType obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Id", obj.Id);
            prm[1] = new SqlParameter("@Uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("BodyTypeMasterDML", prm);
        }
        public int updateBodyType(entbodyType obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@Id", obj.Id);
            prm[1] = new SqlParameter("@BodyTypeName", obj.BodyTypeName);
            prm[2] = new SqlParameter("@BodyTypeIcon", obj.BodyTypeIcon);
            prm[3] = new SqlParameter("@Uid", obj.uid);
            prm[4] = new SqlParameter("@Action", "UPDATE");
            prm[5] = new SqlParameter("@Archive", obj.Archive);
            return da.executeDMLQuery("BodyTypeMasterDML", prm);
        }

        #endregion

        #region Rohit 21072025
        public DataSet DocumentBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageDocument", prm);
        }
        public int InsertBill(entBill obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[5];
            prm[0] = new SqlParameter("@DocumentId", obj.DocumentId);
            prm[1] = new SqlParameter("@BillDate", obj.BillDate);
            prm[2] = new SqlParameter("@UploadDocument", obj.UploadDocument);
            prm[3] = new SqlParameter("@Uid", obj.uid);
            prm[4] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("BillMasterDML", prm);
        }
        public int DeleteBill(entBill obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Id", obj.Id);
            prm[1] = new SqlParameter("@Uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("BillMasterDML", prm);
        }
        public DataSet SelectBill()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("BillMasterDML", prm);
        }
        public DataSet SelectBillByID(entBill obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Id", obj.Id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("BillMasterDML", prm);
        }
        #endregion


        #region created by Ashish 23072025
        public DataSet DepartmentBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageDepartment", prm);
        }
        public DataSet UserTypeBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageAdminUserType", prm);
        }
        public DataSet DesignationBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageDesignation", prm);
        }
        public int IsUserExists(entAdduser obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@username", obj.UserName);
            prm[1] = new SqlParameter("@Email", obj.Email);
            prm[2] = new SqlParameter("@Action", "ISEXISTS");
            prm[3] = new SqlParameter("ReturnValue", SqlDbType.Int);
            prm[3].Direction = ParameterDirection.ReturnValue;
            return da.executeDMLQuery("ManageAdminlogin", prm);
        }
        public int InsertAdminuser(entAdduser obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[18];
            prm[0] = new SqlParameter("@Fname", obj.Fname);
            prm[1] = new SqlParameter("@Lname", obj.Lname);
            prm[2] = new SqlParameter("@username", obj.UserName);
            prm[3] = new SqlParameter("@password", obj.Password);
            prm[4] = new SqlParameter("@Contact", obj.Contact);
            prm[5] = new SqlParameter("@Email", obj.Email);
            prm[6] = new SqlParameter("@CountryId", obj.CountryId);
            prm[7] = new SqlParameter("@Idtype", obj.Idtype);
            prm[8] = new SqlParameter("@IdNumber", obj.IdNumber);
            prm[9] = new SqlParameter("@DOB", obj.DOB);
            prm[10] = new SqlParameter("@DOJ", obj.DOJ);
            prm[11] = new SqlParameter("@Designation", obj.Designation);
            prm[12] = new SqlParameter("@utype", obj.UserType);
            prm[13] = new SqlParameter("@EDepartment", obj.Edepartment);
            prm[14] = new SqlParameter("@PAddress", obj.PAddress);
            prm[15] = new SqlParameter("@RAddress", obj.RAddress);
            prm[16] = new SqlParameter("@uid", obj.uid);
            prm[17] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("ManageAdminlogin", prm);
        }

        public DataSet SelectUser(entAdduser obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@Fname", obj.Fname);
            prm[1] = new SqlParameter("@designation", obj.Designation);
            prm[2] = new SqlParameter("@EDepartment", obj.Edepartment);
            prm[3] = new SqlParameter("@Pageno", obj.PageNo);
            prm[4] = new SqlParameter("@PageSize", obj.PageSize);
            prm[5] = new SqlParameter("@Action", "SELECT");          
            return da.GetDataSet("ManageAdminlogin", prm);
        }

        public int Deleteuser(entAdduser obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("ManageAdminlogin", prm);
        }

        public int IsUpdateUserExists(entAdduser obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[5];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@username", obj.UserName);
            prm[2] = new SqlParameter("@Email", obj.Email);
            prm[3] = new SqlParameter("@Action", "UPDATEISEXISTS");
            prm[4] = new SqlParameter("ReturnValue", SqlDbType.Int);
            prm[4].Direction = ParameterDirection.ReturnValue;
            return da.executeDMLQuery("ManageAdminlogin", prm);
        }
        public int updateUser(entAdduser obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[17];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@Fname", obj.Fname);
            prm[2] = new SqlParameter("@Lname", obj.Lname);
            prm[3] = new SqlParameter("@Contact", obj.Contact);
            prm[4] = new SqlParameter("@Email", obj.Email);
            prm[5] = new SqlParameter("@CountryId", obj.CountryId);
            prm[6] = new SqlParameter("@Idtype", obj.Idtype);
            prm[7] = new SqlParameter("@IdNumber", obj.IdNumber);
            prm[8] = new SqlParameter("@DOB", obj.DOB);
            prm[9] = new SqlParameter("@DOJ", obj.DOJ);
            prm[10] = new SqlParameter("@designation", obj.Designation);
            prm[11] = new SqlParameter("@utype", obj.UserType);
            prm[12] = new SqlParameter("@EDepartment", obj.Edepartment);
            prm[13] = new SqlParameter("@PAddress", obj.PAddress);
            prm[14] = new SqlParameter("@RAddress", obj.RAddress);
            prm[15] = new SqlParameter("@uid", obj.uid);
            prm[16] = new SqlParameter("@Action", "UPDATE");
            return da.executeDMLQuery("ManageAdminlogin", prm);
        }
        public int updateUserPassword(entAdduser obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[5];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@username", obj.UserName);
            prm[2] = new SqlParameter("@password", obj.Password);
            prm[3] = new SqlParameter("@uid", obj.uid);
            prm[4] = new SqlParameter("@Action", "PASSWORD");
            return da.executeDMLQuery("ManageAdminlogin", prm);
        }
        public DataSet SelectUserById(entAdduser obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("ManageAdminlogin", prm);
        }
        #endregion




        #region Added By Ramesh
        public int AddRegion(Region region, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@CID", region.CountryName);
                prm[1] = new SqlParameter("@Name", region.Regionname);
                prm[2] = new SqlParameter("@Archive", region.ActiveDeactive);
                prm[3] = new SqlParameter("@uid", Convert.ToInt32(UID));
                prm[4] = new SqlParameter("@Action", "INSERT");
                prm[5] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[5].Direction = ParameterDirection.ReturnValue;
                return da.executeDMLQuery("USP_RegionDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getAllRegionData(string cid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@CID", cid);
                prm[1] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("USP_RegionDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateRegion(Region region, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[7];
                prm[0] = new SqlParameter("@CID", region.CountryName);
                prm[1] = new SqlParameter("@Name", region.Regionname);
                prm[2] = new SqlParameter("@Archive", region.ActiveDeactive);
                prm[3] = new SqlParameter("@uid", Convert.ToInt32(UID));
                prm[4] = new SqlParameter("@ID", region.Id);
                prm[5] = new SqlParameter("@Action", "UPDATE");
                prm[6] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[6].Direction = ParameterDirection.ReturnValue;
                return da.executeDMLQuery("USP_RegionDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateRegionPort(Region region, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5]; 
                prm[0] = new SqlParameter("@ID", region.Id);
                prm[1] = new SqlParameter("@PortId", region.PortId);
                prm[2] = new SqlParameter("@uid", Convert.ToInt32(UID));
                prm[3] = new SqlParameter("@Action", "UPDATEPORT");
                prm[4] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[4].Direction = ParameterDirection.ReturnValue;
                return da.executeDMLQuery("USP_RegionDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteRegion(int Id, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                prm[1] = new SqlParameter("@UID", UID);
                prm[2] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[2].Direction = ParameterDirection.ReturnValue;
                return da.executeDMLQuery("USP_RegionDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet checkSellerLogin(string emailid, string password)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@username", emailid);
            prm[1] = new SqlParameter("@password", password);
            prm[2] = new SqlParameter("@Action", "IsValidUID");
            return da.GetDataSet("SellerLoginInfoDML", prm);
        }
        public DataSet bindSellerMenuByUtype(string utype)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@utype", utype);
            prm[1] = new SqlParameter("@Action", "MENUBYUTYPE");
            return da.GetDataSet("AssignMenusDML", prm);
        }
        public DataSet Getstate(int CID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ID", Convert.ToInt32(CID));
                return da.GetDataSet("GetRegion", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet shippingfillter()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("ShippingDetails");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetupdateshippingMaster()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_MasterUpshipping");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AddPortmaster(entPort portMaster, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[9];
                prm[0] = new SqlParameter("@CountryId", portMaster.CoutryName);
                prm[1] = new SqlParameter("@PortName", portMaster.PortName);
                prm[2] = new SqlParameter("@Address", portMaster.Address);
                prm[3] = new SqlParameter("@EmailId", portMaster.EmailId);
                prm[4] = new SqlParameter("@Contact", portMaster.ContactNo);
                prm[5] = new SqlParameter("@Archive", portMaster.cActive);
                prm[6] = new SqlParameter("@UID", UID);
                prm[7] = new SqlParameter("@FaxNo", portMaster.FaxNo);
                prm[8] = new SqlParameter("@Action", "INSERT");
                return da.executeDMLQuery("USP_PortMasterDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ViewAllPort(string countryId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@CountryId", Convert.ToInt32(countryId));
                prm[1] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("USP_PortMasterDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ViewPortById(int Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@ID", Convert.ToInt32(Id));
                prm[1] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("USP_PortMasterDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdatePortMaster(entPort portMaster, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[10];
                prm[0] = new SqlParameter("@CountryId", portMaster.CoutryName);
                prm[1] = new SqlParameter("@PortName", portMaster.PortName);
                prm[2] = new SqlParameter("@Address", portMaster.Address);
                prm[3] = new SqlParameter("@EmailId", portMaster.EmailId);
                prm[4] = new SqlParameter("@Contact", portMaster.ContactNo);
                prm[5] = new SqlParameter("@Archive", portMaster.cActive);
                prm[6] = new SqlParameter("@MUID", UID);
                prm[7] = new SqlParameter("@FaxNo", portMaster.FaxNo);
                prm[8] = new SqlParameter("@ID", portMaster.Id);
                prm[9] = new SqlParameter("@Action", "UPDATE");
                return da.executeDMLQuery("USP_PortMasterDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DeleteportMaster(int CID, int UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@UID", Convert.ToInt32(UID));
                prm[1] = new SqlParameter("@ID", Convert.ToInt32(CID));
                prm[2] = new SqlParameter("@Action", "DELETE");
                return da.GetDataSet("USP_PortMasterDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddCountry(CountryModel country, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@CountryName", country.CountryName);
                prm[1] = new SqlParameter("@Flag", country.Countryicon);
                prm[2] = new SqlParameter("@Archive", country.cActive);
                prm[3] = new SqlParameter("@ISDCode", country.CountryCode);         
                prm[4] = new SqlParameter("@UID", UID);
                prm[5] = new SqlParameter("@Action", "INSERT");
                return da.executeDMLQuery("USP_CountryMasterDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ViewAllCountry()
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("USP_CountryMasterDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCountryById(string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                prm[1] = new SqlParameter("@Action", "SELECT");
                return da.GetDataSet("USP_CountryMasterDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateCountryMaster(CountryModel countryModel, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[7];
                prm[0] = new SqlParameter("@CountryName", countryModel.CountryName);
                prm[1] = new SqlParameter("@Flag", countryModel.Countryicon);
                prm[2] = new SqlParameter("@Archive", countryModel.cActive);
                prm[3] = new SqlParameter("@ISDCode", countryModel.CountryCode);
                prm[4] = new SqlParameter("@UID", UID);
                prm[5] = new SqlParameter("@ID", countryModel.Id);
                prm[6] = new SqlParameter("@Action", "UPDATE");
                return da.executeDMLQuery("USP_CountryMasterDML", prm);              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet DeleteCountry(int ID, int UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@UID", Convert.ToInt32(UID));
                prm[1] = new SqlParameter("@ID", Convert.ToInt32(ID));
                prm[2] = new SqlParameter("@Action", "DELETE");
                return da.GetDataSet("USP_CountryMasterDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataSet BindBrandandProduct()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("ShippingDetails");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddProductMaster(ProductModel productModel, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@CategoryId", productModel.Category);
                prm[1] = new SqlParameter("@BrandId", productModel.BrandName);
                prm[2] = new SqlParameter("@ProductName", productModel.ProductName);
                prm[3] = new SqlParameter("@sActive", productModel.cActive);
                prm[4] = new SqlParameter("@UID", UID);
                return da.executeDMLQuery("USP_InsertProductMaster", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateProductMaster(ProductModel productModel, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@CategoryId", productModel.Category);
                prm[1] = new SqlParameter("@BrandId", productModel.BrandName);
                prm[2] = new SqlParameter("@ProductName", productModel.ProductName);
                prm[3] = new SqlParameter("@sActive", productModel.cActive);
                prm[4] = new SqlParameter("@MUID", UID);
                prm[5] = new SqlParameter("@Id", productModel.Id);
                return da.executeDMLQuery("USP_UpdateProductMasterById", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BindProductandBrand()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_GetCategoryandBrand");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ViewAllProduct(ProductModel obj)
        {
            try
            {
                da = new DataAccess();           
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@CategoryId", obj.Category);
                prm[1] = new SqlParameter("@BrandId", obj.BrandName);
                prm[2] = new SqlParameter("@Product", obj.ProductName);
                prm[3] = new SqlParameter("@Pageno", obj.PageNo);
                prm[4] = new SqlParameter("@PageSize", obj.PageSize);
                return da.GetDataSet("USP_GetAllProduct", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ViewAllProductbyId(int Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                return da.GetDataSet("USP_GetAllProduct", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ViewAllProductbyCId(int CId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@CID", CId);
                return da.GetDataSet("USP_GetAllProductByCID", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ViewAllProductbyCIdAndMid(int CId, int MId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@CID", CId);
                prm[1] = new SqlParameter("@MId", MId);
                return da.GetDataSet("USP_GetAllProductByCID", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DeleteProductMaster(int ID, int UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[1] = new SqlParameter("@ID", Convert.ToInt32(ID));
                return da.GetDataSet("DeleteProductMaster", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBodyTypeandProduct()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("USP_GetProductandBodyType");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddVarint(VariantModel variantModel, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[21];
                prm[0] = new SqlParameter("@ProductId", variantModel.Product);
                prm[1] = new SqlParameter("@BodytypeId", variantModel.BodyType);
                prm[2] = new SqlParameter("@VariantName", variantModel.VariantName);
                prm[3] = new SqlParameter("@ModelCode", variantModel.ModelCode);
                prm[4] = new SqlParameter("@Drive", variantModel.Drive);
                prm[5] = new SqlParameter("@Transmission", variantModel.Transmission);
                prm[6] = new SqlParameter("@FuelType", variantModel.FuelType);
                prm[7] = new SqlParameter("@SteeringSide", variantModel.SteeringSide);
                prm[8] = new SqlParameter("@CC", variantModel.CC);
                prm[9] = new SqlParameter("@Cylinders", variantModel.Cylinders);
                prm[10] = new SqlParameter("@Doors", variantModel.Doors);
                prm[11] = new SqlParameter("@Seats", variantModel.Seats);
                prm[12] = new SqlParameter("@WheelSize", variantModel.WheelSize);
                prm[13] = new SqlParameter("@Sunroof", variantModel.Sunroof);
                prm[14] = new SqlParameter("@Weight", variantModel.Weight);
                prm[15] = new SqlParameter("@Length", variantModel.Length);
                prm[16] = new SqlParameter("@Width", variantModel.Width);
                prm[17] = new SqlParameter("@Height", variantModel.Height);
                prm[18] = new SqlParameter("@PType", variantModel.PType);
                prm[19] = new SqlParameter("@MildHybrid", variantModel.MildHybrid);
                prm[20] = new SqlParameter("@UID", UID);
                return da.executeDMLQuery("USP_InsertVariantMaster", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet ViewallVariant(string ProductId, string BodytypeId, string Modelcode)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@ProductId", Convert.ToInt32(ProductId));
                prm[1] = new SqlParameter("@BodytypeId", Convert.ToInt32(BodytypeId));
                prm[2] = new SqlParameter("@ModelCode", Modelcode);
                return da.GetDataSet("GetVariantMasterById", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet ViewallVariantById(int Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Id);
                return da.GetDataSet("GetVariantMasterById", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet SelectVariantByProductID(int ProductId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ProductId", ProductId);
                return da.GetDataSet("GetVariantByPId", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet SelectVariantPBID(int ProductId, int bid)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@ProductId", ProductId);
                prm[1] = new SqlParameter("@bid", bid);
                return da.GetDataSet("GetVariantByPId", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public int updateVarint(VariantModel variantModel, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[22];
                prm[0] = new SqlParameter("@ProductId", variantModel.Product);
                prm[1] = new SqlParameter("@BodytypeId", variantModel.BodyType);
                prm[2] = new SqlParameter("@VariantName", variantModel.VariantName);
                prm[3] = new SqlParameter("@ModelCode", variantModel.ModelCode);
                prm[4] = new SqlParameter("@Drive", variantModel.Drive);
                prm[5] = new SqlParameter("@Transmission", variantModel.Transmission);
                prm[6] = new SqlParameter("@FuelType", variantModel.FuelType);
                prm[7] = new SqlParameter("@SteeringSide", variantModel.SteeringSide);
                prm[8] = new SqlParameter("@CC", variantModel.CC);
                prm[9] = new SqlParameter("@Cylinders", variantModel.Cylinders);
                prm[10] = new SqlParameter("@Doors", variantModel.Doors);
                prm[11] = new SqlParameter("@Seats", variantModel.Seats);
                prm[12] = new SqlParameter("@WheelSize", variantModel.WheelSize);
                prm[13] = new SqlParameter("@Sunroof", variantModel.Sunroof);
                prm[14] = new SqlParameter("@Weight", variantModel.Weight);
                prm[15] = new SqlParameter("@Length", variantModel.Length);
                prm[16] = new SqlParameter("@Width", variantModel.Width);
                prm[17] = new SqlParameter("@Height", variantModel.Height);
                prm[18] = new SqlParameter("@PType", variantModel.PType);
                prm[19] = new SqlParameter("@MildHybrid", variantModel.MildHybrid);
                prm[20] = new SqlParameter("@MUID", UID);
                prm[21] = new SqlParameter("@Id", variantModel.Id);
                return da.executeDMLQuery("USP_UpdateVariantMasterById", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet DeleteVariant(int ID, int UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[1] = new SqlParameter("@Id", Convert.ToInt32(ID));
                return da.GetDataSet("DeleteVariant", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getPortsByCountryId(int ID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@ID", Convert.ToInt32(ID));
                return da.GetDataSet("GetPortandCitybyCId", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int addFobType(FobType fobType, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@Countryid", fobType.Country);
                prm[1] = new SqlParameter("@StateId", fobType.CityName);
                prm[2] = new SqlParameter("@PortId", fobType.PortName);
                prm[3] = new SqlParameter("@FobType", fobType.FobTypes);
                prm[4] = new SqlParameter("@FobPrice", fobType.Price);
                prm[5] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("USP_InsertFobPrice", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet getAllFobTypeData(string CountryId, string CityId, string FobTypeId)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Countryid", Convert.ToInt32(CountryId));
            prm[1] = new SqlParameter("@StateId", Convert.ToInt32(CityId));
            prm[2] = new SqlParameter("@FobType", FobTypeId);
            return da.GetDataSet("USP_GetFobType", prm);
        }

        public DataSet getAllFobTypeDataByParameters(string Countryid, string CityId, string FobtypeId)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Countryid", Convert.ToInt32(Countryid));
            prm[1] = new SqlParameter("@StateId", Convert.ToInt32(CityId));
            prm[2] = new SqlParameter("@FobType", Convert.ToInt32(FobtypeId));
            return da.GetDataSet("USP_GetFobType");
        }

        public DataSet getFobTypeDataById(string Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Convert.ToInt32(Id));
                return da.GetDataSet("USP_GetFobTypeById", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return new DataSet();
            }
        }

        public DataSet getCityandPort()
        {
            try
            {
                da = new DataAccess();
                return da.GetDataSet("GetAllCityandPort");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateFobType(FobType fobType, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[7];
                prm[0] = new SqlParameter("@Countryid", fobType.Country ?? (object)DBNull.Value);
                prm[1] = new SqlParameter("@StateId", fobType.CityName ?? (object)DBNull.Value);
                prm[2] = new SqlParameter("@PortId", fobType.PortName ?? (object)DBNull.Value);
                prm[3] = new SqlParameter("@FobType", fobType.FobTypes ?? (object)DBNull.Value);
                prm[4] = new SqlParameter("@FobPrice", fobType.Price ?? (object)DBNull.Value);
                prm[5] = new SqlParameter("@MUID", UID ?? (object)DBNull.Value);
                prm[6] = new SqlParameter("@Id", fobType.Id);
                return da.executeDMLQuery("UpdateFobTypeById", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet DeleteFobTypeMaster(int CID, int UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[1] = new SqlParameter("@ID", Convert.ToInt32(CID));
                return da.GetDataSet("DeleteFobTypeMaster", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ChangeSellerPassword(string Id, string Oldpassword, string Password)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[5];
                prm[0] = new SqlParameter("@Id", Id);
                prm[1] = new SqlParameter("@Password", Oldpassword);
                prm[2] = new SqlParameter("@Newpwd", Password);
                prm[3] = new SqlParameter("@Action", "UPDATE");
                prm[4] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[4].Direction = ParameterDirection.ReturnValue;
                return da.executeDMLQuery("SellerLoginInfoDML", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllstate(int countryId)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Countryid", Convert.ToInt32(countryId));
                return da.GetDataSet("GetAllRegion", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateAuctionByRID(string Id, string Rate, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@RID", Convert.ToInt32(Rate));
                prm[1] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[2] = new SqlParameter("@Id", Convert.ToInt32(Id));
                return da.executeDMLQuery("UpdateAuctionByRID", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }
        
        public int AddcarStatus(string statusName, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@CarStatus", statusName);
                prm[1] = new SqlParameter("@UID", Convert.ToInt32(UID));
                return da.executeDMLQuery("AddCarStatus", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return 0;
            }
        }

        public DataSet getAllcarStatus(int Id)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Id);
                return da.GetDataSet("GetAllCarStatus", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DeleteCarStatus(int ID, int UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@ID", Convert.ToInt32(ID));
                prm[1] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                return da.GetDataSet("DeleteCarStatus", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateCarStatus(string carStatus,int Id, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@CarStatus", carStatus);
                prm[1] = new SqlParameter("@UID", Convert.ToInt32(UID));
                prm[2] = new SqlParameter("@Id", Id);
                return da.executeDMLQuery("updateCarStatus", prm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Lalit 228072025
        public int InsertFeaturesMaster(entFeaturesMaster obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[5];
            prm[0] = new SqlParameter("@id", obj.id);
            prm[1] = new SqlParameter("@categoryid", obj.categoryid);
            prm[2] = new SqlParameter("@FeatureName", obj.FeatureName);
            prm[3] = new SqlParameter("@PID", obj.PID);
            prm[4] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("ManageFeaturesMasterDML", prm);
        }

        public int UpdateFeaturesMaster(entFeaturesMaster obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[5];
            prm[0] = new SqlParameter("@id", obj.id);
            prm[1] = new SqlParameter("@categoryid", obj.categoryid);
            prm[2] = new SqlParameter("@FeatureName", obj.FeatureName);
            prm[3] = new SqlParameter("@PID", obj.PID);
            prm[4] = new SqlParameter("@Action", "UPDATE");
            return da.executeDMLQuery("ManageFeaturesMasterDML", prm);
        }

        public int DeleteFeaturesMaster(entFeaturesMaster obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@id", obj.id);
            prm[1] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("ManageFeaturesMasterDML", prm);
        }

        public DataSet bindFeatures(entFeaturesMaster obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@PID", obj.PID);
            prm[1] = new SqlParameter("@Action", "SELECTBYPID");
            prm[2] = new SqlParameter("@categoryid", obj.categoryid);
            return da.GetDataSet("ManageFeaturesMasterDML", prm);
        }

        public DataSet SelectFeatureByID(entFeaturesMaster obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@ID", obj.id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("ManageFeaturesMasterDML", prm);
        }

        public DataSet SelectFeatureByCATID(entFeaturesMaster obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@categoryid", obj.categoryid);
            prm[1] = new SqlParameter("@Action", "GETBYCATID");
            return da.GetDataSet("ManageFeaturesMasterDML", prm);
        }

        public int InsertMetaDataMaster(entMetaDataMaster obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[8];
            prm[0] = new SqlParameter("@mid", obj.mid);
            prm[1] = new SqlParameter("@titletext", obj.titletext);
            prm[2] = new SqlParameter("@keywords", obj.keywords);
            prm[3] = new SqlParameter("@description", obj.description);
            prm[4] = new SqlParameter("@pagecontent", obj.pagecontent);
            prm[5] = new SqlParameter("@pageid", obj.pageid);
            prm[6] = new SqlParameter("@uid", obj.uid);
            prm[7] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("ManageMetaDataMasterDML", prm);
        }

        public DataSet selectMetaDataMaster(entMetaDataMaster obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@mid", obj.mid);
            prm[1] = new SqlParameter("@pageid", obj.pageid);
            prm[2] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageMetaDataMasterDML", prm);
        }

        #endregion

        #region Created By Ashish
        public int InsertAuction(entAuction obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[10];
            prm[0] = new SqlParameter("@CountryId", obj.CountryId);
            prm[1] = new SqlParameter("@Name", obj.Name);
            prm[2] = new SqlParameter("@Address", obj.Address);
            prm[3] = new SqlParameter("@Email", obj.Email);
            prm[4] = new SqlParameter("@Contact", obj.Contact);
            prm[5] = new SqlParameter("@FaxNo", obj.FaxNumber);
            prm[6] = new SqlParameter("@Archive", obj.Archive);
            prm[7] = new SqlParameter("@AGroup", obj.AGroup);
            prm[8] = new SqlParameter("@uid", obj.uid);
            prm[9] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("ManageAuction", prm);
        }

        public int updateAuction(entAuction obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[11];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@CountryId", obj.CountryId);
            prm[2] = new SqlParameter("@Name", obj.Name);
            prm[3] = new SqlParameter("@Address", obj.Address);
            prm[4] = new SqlParameter("@Email", obj.Email);
            prm[5] = new SqlParameter("@Contact", obj.Contact);
            prm[6] = new SqlParameter("@FaxNo", obj.FaxNumber);
            prm[7] = new SqlParameter("@Archive", obj.Archive);
            prm[8] = new SqlParameter("@AGroup", obj.AGroup);
            prm[9] = new SqlParameter("@uid", obj.uid);
            prm[10] = new SqlParameter("@Action", "UPDATE");
            return da.executeDMLQuery("ManageAuction", prm);
        }

        public DataSet SelectAuctionById(entAuction obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("ManageAuction", prm);
        }
        public DataSet SelectAuction()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageAuction", prm);
        }

        public int DeleteAuction(entAuction obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("ManageAuction", prm);
        }

        public DataSet ClientBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "CLIENTSELECTBYID");
            return da.GetDataSet("ClientRegistrationDML", prm);
        }

        public int InsertConsignee(entConsignee obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[8];
            prm[0] = new SqlParameter("@ClientId", obj.ClientId);
            prm[1] = new SqlParameter("@CFS", obj.CFS);
            prm[2] = new SqlParameter("@ConsigneeName", obj.ConsigneeName);
            prm[3] = new SqlParameter("@Email", obj.Email);
            prm[4] = new SqlParameter("@Address", obj.Address);
            prm[5] = new SqlParameter("@Archive", obj.Archive);
            prm[6] = new SqlParameter("@uid", obj.uid);
            prm[7] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("ManageConsignee", prm);
        }

        public int updateConsignee(entConsignee obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[9];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@ClientId", obj.ClientId);
            prm[2] = new SqlParameter("@CFS", obj.CFS);
            prm[3] = new SqlParameter("@ConsigneeName", obj.ConsigneeName);
            prm[4] = new SqlParameter("@Email", obj.Email);
            prm[5] = new SqlParameter("@Address", obj.Address);
            prm[6] = new SqlParameter("@Archive", obj.Archive);
            prm[7] = new SqlParameter("@uid", obj.uid);
            prm[8] = new SqlParameter("@Action", "UPDATE");
            return da.executeDMLQuery("ManageConsignee", prm);
        }

        public DataSet SelectConsigneeById(entConsignee obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("ManageConsignee", prm);
        }

        public DataSet SelectConsignee()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageConsignee", prm);
        }
        public DataSet SelectConsigneeClientById(int id)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@ClientId", id);
            prm[1] = new SqlParameter("@Action", "SELECTBYIDCLIENT");
            return da.GetDataSet("ManageConsignee", prm);
        }
        public int DeleteConsignee(entConsignee obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@id", obj.Id);
            prm[1] = new SqlParameter("@uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("ManageConsignee", prm);
        }

       

        public int InsertTerminal(entTerminal obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[11];
            prm[0] = new SqlParameter("@PortId", obj.PortId);
            prm[1] = new SqlParameter("@Tcname", obj.Tcname);
            prm[2] = new SqlParameter("@Tname", obj.Tname);
            prm[3] = new SqlParameter("@Cperson", obj.Cperson);
            prm[4] = new SqlParameter("@EmailID", obj.Email);
            prm[5] = new SqlParameter("@ContactNo", obj.ContactNo);
            prm[6] = new SqlParameter("@Price", obj.Price);
            prm[7] = new SqlParameter("@Taddress", obj.Taddress);
            prm[8] = new SqlParameter("@Archive", obj.Archive);
            prm[9] = new SqlParameter("@UID", obj.uid);
            prm[10] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("ManageTerminal", prm);
        }

        public int updateTerminal(entTerminal obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[12];
            prm[0] = new SqlParameter("@ID", obj.Id);
            prm[1] = new SqlParameter("@PortId", obj.PortId);
            prm[2] = new SqlParameter("@Tcname", obj.Tcname);
            prm[3] = new SqlParameter("@Tname", obj.Tname);
            prm[4] = new SqlParameter("@Cperson", obj.Cperson);
            prm[5] = new SqlParameter("@EmailID", obj.Email);
            prm[6] = new SqlParameter("@ContactNo", obj.ContactNo);
            prm[7] = new SqlParameter("@Price", obj.Price);
            prm[8] = new SqlParameter("@Taddress", obj.Taddress);
            prm[9] = new SqlParameter("@Archive", obj.Archive);
            prm[10] = new SqlParameter("@UID", obj.uid);
            prm[11] = new SqlParameter("@Action", "UPDATE");
            return da.executeDMLQuery("ManageTerminal", prm);
        }

        public DataSet SelectTerminalById(entTerminal obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@ID", obj.Id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("ManageTerminal", prm);
        }
        public DataSet SelectTerminal()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageTerminal", prm);
        }

        public int DeleteTerminal(entTerminal obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@ID", obj.Id);
            prm[1] = new SqlParameter("@UID", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("ManageTerminal", prm);
        }

        public DataSet SelectTerminalPortById(int id)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@PortId", id);
            prm[1] = new SqlParameter("@Action", "SELECTBYPORT");
            return da.GetDataSet("ManageTerminal", prm);
        }

        public DataSet AuctionGroupBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECTGROUP");
            return da.GetDataSet("ManageAuction", prm);
        }
        public int InsertAuctionGroup(string Group)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Name", Group);
            prm[1] = new SqlParameter("ReturnValue", SqlDbType.Int);
            prm[1].Direction = ParameterDirection.ReturnValue;
            return da.executeDMLQuery("USP_InsertAuctionGroup", prm);

        }
        #endregion

        #region Created by Ashish 04/08/25
        public DataSet AuctionBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECTAUCTION");
            return da.GetDataSet("ManageAuction", prm);
        }

        public int InsertAuctionYard(entAuctionYard obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[13];
            prm[0] = new SqlParameter("@AuctionId", obj.AuctionId);
            prm[1] = new SqlParameter("@AuctionYard", obj.AuctionYard);
            prm[2] = new SqlParameter("@LotNoFrom", obj.LotNoFrom);
            prm[3] = new SqlParameter("@LotNoTo", obj.LotNoTo);
            prm[4] = new SqlParameter("@OutDay", obj.OutDay);
            prm[5] = new SqlParameter("@OutTime", obj.OutTime);
            prm[6] = new SqlParameter("@Address", obj.Address);
            prm[7] = new SqlParameter("@EmailId", obj.EmailId);
            prm[8] = new SqlParameter("@ContactNo", obj.ContactNo);
            prm[9] = new SqlParameter("@FaxNo", obj.FaxNo);
            prm[10] = new SqlParameter("@Archive", obj.Archive);
            prm[11] = new SqlParameter("@uid", obj.uid);
            prm[12] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("ManageAuctionYard", prm);
        }

        public int updateAuctionYard(entAuctionYard obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[14];
            prm[0] = new SqlParameter("@Id", obj.Id);
            prm[1] = new SqlParameter("@AuctionId", obj.AuctionId);
            prm[2] = new SqlParameter("@AuctionYard", obj.AuctionYard);
            prm[3] = new SqlParameter("@LotNoFrom", obj.LotNoFrom);
            prm[4] = new SqlParameter("@LotNoTo", obj.LotNoTo);
            prm[5] = new SqlParameter("@OutDay", obj.OutDay);
            prm[6] = new SqlParameter("@OutTime", obj.OutTime);
            prm[7] = new SqlParameter("@Address", obj.Address);
            prm[8] = new SqlParameter("@EmailId", obj.EmailId);
            prm[9] = new SqlParameter("@ContactNo", obj.ContactNo);
            prm[10] = new SqlParameter("@FaxNo", obj.FaxNo);
            prm[11] = new SqlParameter("@Archive", obj.Archive);
            prm[12] = new SqlParameter("@uid", obj.uid);
            prm[13] = new SqlParameter("@Action", "UPDATE");
            return da.executeDMLQuery("ManageAuctionYard", prm);
        }
        public DataSet SelectAuctionYard()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageAuctionYard", prm);
        }
        public int DeleteAuctionYard(entAuctionYard obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Id", obj.Id);
            prm[1] = new SqlParameter("@uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("ManageAuctionYard", prm);
        }
        public DataSet SelectAuctionYardAuctionById(int id)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@AuctionId", id);
            prm[1] = new SqlParameter("@Action", "SELECTBYAUCTION");
            return da.GetDataSet("ManageAuctionYard", prm);
        }
        public DataSet SelectAuctionYardById(entAuctionYard obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@ID", obj.Id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("ManageAuctionYard", prm);
        }
        #endregion

        #region Rohit05082025
        public DataSet btopicBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageTopic", prm);
        }
        public int insertBlogdata(entBlog obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[13];
            prm[0] = new SqlParameter("@blang", obj.blang);
            prm[1] = new SqlParameter("@btopicid", obj.btopicid);
            prm[2] = new SqlParameter("@btitle", obj.btitle);
            prm[3] = new SqlParameter("@burl", obj.burl);
            prm[4] = new SqlParameter("@bdate", obj.bdate);
            prm[5] = new SqlParameter("@bimage", obj.bimage);
            prm[6] = new SqlParameter("@ptitle", obj.ptitle);
            prm[7] = new SqlParameter("@keytag", obj.keytag);
            prm[8] = new SqlParameter("@desctag", obj.desctag);
            prm[9] = new SqlParameter("@sdetails", obj.sdetails);
            prm[10] = new SqlParameter("@fdetails", obj.fdetails);
            prm[11] = new SqlParameter("@uid", obj.uid);
            prm[12] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("BlogDataDML", prm);
        }
        public int updateBlogData(entBlog obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[14];
            prm[0] = new SqlParameter("@blang", obj.blang);
            prm[1] = new SqlParameter("@btopicid", obj.btopicid);
            prm[2] = new SqlParameter("@btitle", obj.btitle);
            prm[3] = new SqlParameter("@burl", obj.burl);
            prm[4] = new SqlParameter("@bdate", obj.bdate);
            prm[5] = new SqlParameter("@bimage", obj.bimage);
            prm[6] = new SqlParameter("@ptitle", obj.ptitle);
            prm[7] = new SqlParameter("@keytag", obj.keytag);
            prm[8] = new SqlParameter("@desctag", obj.desctag);
            prm[9] = new SqlParameter("@sdetails", obj.sdetails);
            prm[10] = new SqlParameter("@fdetails", obj.fdetails);
            prm[11] = new SqlParameter("@uid", obj.uid);
            prm[12] = new SqlParameter("@Action", "UPDATE");
            prm[13] = new SqlParameter("@Id", obj.id);
            return da.executeDMLQuery("BlogDataDML", prm);
        }
        public int deleteBlog(entBlog obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@id", obj.id);
            prm[1] = new SqlParameter("@uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("BlogDataDML", prm);
        }

        public DataSet ViewBlog()
        {

            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("BlogDataDML", prm);

        }

        public DataSet SelectBlogByID(entBlog obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@id", obj.id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("BlogDataDML", prm);
        }

        #endregion

        public DataSet viewallchassisno(string Cno)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Chno", Cno);
            return da.GetDataSet("USP_GetallChassis", prm);
        }
        public int insertBlogTopic(entBlogTopic obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];        
            prm[0] = new SqlParameter("@btopic", obj.btopic);          
            prm[1] = new SqlParameter("@uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("ManageBlogTopicDML", prm);
        }
        public int updateBlogTopicData(entBlogTopic obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[4];         
            prm[0] = new SqlParameter("@btopic", obj.btopic);         
            prm[1] = new SqlParameter("@uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "UPDATE");
            prm[3] = new SqlParameter("@id", obj.id);
            return da.executeDMLQuery("ManageBlogTopicDML", prm);

        }
        public DataSet ViewBlogTopic()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageBlogTopicDML", prm);
        }

        public int deleteBlogTopic(entBlogTopic obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@id", obj.id);
            prm[1] = new SqlParameter("@uid", obj.uid);
            prm[2] = new SqlParameter("@Action", "DELETE");
            return da.executeDMLQuery("ManageBlogTopicDML", prm);
        }
        public DataSet SelectBlogTopicByID(entBlogTopic obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@id", obj.id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("ManageBlogTopicDML", prm);
        }

    }
}