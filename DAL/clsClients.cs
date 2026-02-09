using COMMON;
using ENTITY;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace DAL
{
    public class clsClients
    {

        DataAccess da;

        public int InsertClientData(entClient obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@fname", obj.fname);
            prm[1] = new SqlParameter("@lname", obj.lname);
            prm[2] = new SqlParameter("@emailid", obj.emailid);
            prm[3] = new SqlParameter("@contact", obj.contact);
            prm[4] = new SqlParameter("@uid", obj.uid);
            prm[5] = new SqlParameter("@Action", "INSERT");
            return da.executeDMLQuery("ClientRegistrationDML", prm);
        }
        public int UpdateClientData(entClient obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[11];
            prm[0] = new SqlParameter("@fname", obj.fname);
            prm[1] = new SqlParameter("@lname", obj.lname);
            prm[2] = new SqlParameter("@emailid", obj.emailid);
            prm[3] = new SqlParameter("@pimage", obj.pimage);
            prm[4] = new SqlParameter("@contact", obj.contact);
            prm[5] = new SqlParameter("@countryid", obj.countryid);
            prm[6] = new SqlParameter("@state", obj.stateid);
            prm[7] = new SqlParameter("@address", obj.address);
            prm[8] = new SqlParameter("@refempid", obj.refempid);
            prm[9] = new SqlParameter("@id", obj.id);
            prm[10] = new SqlParameter("@Action", "UPDATE");
            return da.executeDMLQuery("ClientRegistrationDML", prm);
        }


        #region created by Rohit 28072025
        public DataSet GetPendingClients()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "PENDING");
            return da.GetDataSet("ClientRegistrationDML", prm);
        }

        public int ApproveClient(int id, string password)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@id", id);
            prm[1] = new SqlParameter("@password", password);
            prm[2] = new SqlParameter("@Action", "APPROVE");
            return da.executeDMLQuery("ClientRegistrationDML", prm);
        }
        public int DisapproveClient(int id)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@id", id);
            prm[1] = new SqlParameter("@Action", "DISAPPROVE");
            return da.executeDMLQuery("ClientRegistrationDML", prm);
        }

        public DataSet GetClientById(int id)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@id", id);
            prm[1] = new SqlParameter("@Action", "SELECTBYID");
            return da.GetDataSet("ClientRegistrationDML", prm);
        }

        public DataSet SelectClient()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECTCLIENT");
            return da.GetDataSet("ClientRegistrationDML", prm);
        }
        public bool IsEmailExists(string email)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@emailid", email);
            prm[1] = new SqlParameter("@Action", "CHECKEMAIL");
            DataSet ds = da.GetDataSet("ClientRegistrationDML", prm);
            return ds != null && ds.Tables[0].Rows.Count > 0;
        }

        public int InsertAdminClient(entClient obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[12];
            prm[0] = new SqlParameter("@fname", obj.fname);
            prm[1] = new SqlParameter("@lname", obj.lname);
            prm[2] = new SqlParameter("@emailid", obj.emailid);
            prm[3] = new SqlParameter("@pimage", obj.pimage);
            prm[4] = new SqlParameter("@contact", obj.contact);
            prm[5] = new SqlParameter("@countryid", obj.countryid);
            prm[6] = new SqlParameter("@stateid", obj.stateid);
            prm[7] = new SqlParameter("@address", obj.address);
            prm[8] = new SqlParameter("@refempid", obj.refempid);
            prm[9] = new SqlParameter("@password", obj.password);
            prm[10] = new SqlParameter("@uid", obj.uid);
            prm[11] = new SqlParameter("@Action", "INSERTADMINCLIENT");
            return da.executeDMLQuery("ClientRegistrationDML", prm);
        }

        public DataSet CountryBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "SELECT");
            return da.GetDataSet("ManageCountry", prm);
        }
        public DataSet ClientBind()
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Action", "CLIENTSELECTBYID");
            return da.GetDataSet("ClientRegistrationDML", prm);
        }
        public DataSet StateBind(int countryId)

        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@CountryId", countryId);
            prm[1] = new SqlParameter("@Action", "SELECTSTATE");
            return da.GetDataSet("GetStatesByCountry", prm);
        }
        public int IsClientExists(entClient obj)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@emailid", obj.emailid);
            prm[1] = new SqlParameter("@Action", "ISEXISTS");
            prm[2] = new SqlParameter("ReturnValue", SqlDbType.Int);
            prm[2].Direction = ParameterDirection.ReturnValue;
            return da.executeDMLQuery("ClientRegistrationDML", prm);
        }
        public DataSet SelectClientByFilter(int countryId, int clientId)
        {
            da = new DataAccess();
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@CountryId", countryId);
            prm[1] = new SqlParameter("@id", clientId);
            prm[2] = new SqlParameter("@Action", "FILTERCLIENT");
            return da.GetDataSet("ClientRegistrationDML", prm);
        }

        #endregion

        #region Added By Ramesh
        public int AddSeller(SellerModel sellerModel)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[6];
                prm[0] = new SqlParameter("@FName", sellerModel.FirstName);
                prm[1] = new SqlParameter("@LName", sellerModel.LastName);
                prm[2] = new SqlParameter("@MobileNo", sellerModel.MobileNo);
                prm[3] = new SqlParameter("@Email", sellerModel.Email);
                prm[4] = new SqlParameter("@Username", sellerModel.UserName);
                prm[5] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[5].Direction = ParameterDirection.ReturnValue;
                return da.executeDMLQuery("AddSeller", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                ExceptionLogging.SendErrorToText(ex);
                return 0;
            }
        }

        public string GetnerateOTP()
        {
            try
            {
                Random random = new Random();
                int otp = random.Next(100000, 1000000);
                return otp.ToString();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                ExceptionLogging.SendErrorToText(ex);
                return "";
            }
        }

        public int addOTP(string Email, string OTP)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Email", Email);
                prm[1] = new SqlParameter("@OTP", OTP);
                return da.executeDMLQuery("AddOTP", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                ExceptionLogging.SendErrorToText(ex);
                return 0;
            }
        }

        public bool VerifyOTP(string EmailId, string NewOTP)
        {
            try
            {
                DataAccess da = new DataAccess();

                SqlParameter[] prm = new SqlParameter[3];
                prm[0] = new SqlParameter("@EmailId", EmailId);
                prm[1] = new SqlParameter("@NewOTP", NewOTP);
                prm[2] = new SqlParameter("ReturnValue", SqlDbType.Int);
                prm[2].Direction = ParameterDirection.ReturnValue;
                object result = da.executeDMLQuery("VerifyOTP", prm);

                if (result != null && Convert.ToInt32(result) == 1)
                {
                    return true;
                }
            }
            catch(Exception ex) 
            {
                string str = ex.Message;
                ExceptionLogging.SendErrorToText(ex);

            }
            return false;
        }

        public int updateOTP(string Email)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Email", Email);
                return da.executeDMLQuery("UpdateOTP", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                ExceptionLogging.SendErrorToText(ex);
                return 0;
            }
        }

        public string GetRandomPassword(int length)
        {
            try
            {
                const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()-_=+";
                StringBuilder password = new StringBuilder();
                using (var rng = RandomNumberGenerator.Create())
                {
                    byte[] uintBuffer = new byte[sizeof(uint)];

                    while (password.Length < length)
                    {
                        rng.GetBytes(uintBuffer);
                        uint num = BitConverter.ToUInt32(uintBuffer, 0);
                        password.Append(validChars[(int)(num % (uint)validChars.Length)]);
                    }
                }
                return password.ToString();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                ExceptionLogging.SendErrorToText(ex);
                return "";
            }
        }

        public int updatePassword(string Email, string Password)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@EmailId", Email);
                prm[1] = new SqlParameter("@Password", Password);
                return da.executeDMLQuery("UpdatePassword", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                ExceptionLogging.SendErrorToText(ex);
                return 0;
            }
        }

        public DataSet GetSellerById(int Id)
        {
            try
            {

                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", Id); ;
                return da.GetDataSet("GetSellerById", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                ExceptionLogging.SendErrorToText(ex);
                return new DataSet();
            }
        }

        public int updateProFileById(SellerModel sellerModel, string UID)
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[9];
                prm[0] = new SqlParameter("@Id", sellerModel.Id);
                prm[1] = new SqlParameter("@FName", sellerModel.FirstName);
                prm[2] = new SqlParameter("@LName", sellerModel.LastName);
                prm[3] = new SqlParameter("@MobileNo", sellerModel.MobileNo);
                prm[4] = new SqlParameter("@Address", sellerModel.Address);
                prm[5] = new SqlParameter("@Nationality", sellerModel.Nationality);
                prm[6] = new SqlParameter("@DateOfBirth", sellerModel.DateOfBirth);
                prm[7] = new SqlParameter("@MUID", Convert.ToInt32(UID));
                prm[8] = new SqlParameter("@ProfilePic", sellerModel.ProfilePic);
                return da.executeDMLQuery("UpdateDataById", prm);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                ExceptionLogging.SendErrorToText(ex);
                return 0;
            }
        }
        #endregion

    }
}
