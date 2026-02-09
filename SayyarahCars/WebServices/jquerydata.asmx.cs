using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace bizupon
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class jquerydata : System.Web.Services.WebService
    {
        clsMasters cls = new clsMasters();
        [WebMethod(EnableSession = true)]
        public string checkAdminLogin(String UID, String Password)
        {
            string User = "0";
            DataSet ds = new DataSet();
            ds = cls.checkAdminLogin(UID.Trim(), Password.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                HttpContext.Current.Session["AID"] = ds.Tables[0].Rows[0]["id"].ToString();
                HttpContext.Current.Session["utype"] = ds.Tables[0].Rows[0]["utype"].ToString();
                User = "1";
            }
            return User;
        }
        [WebMethod(EnableSession = true)]
        public string checkUserLogin(String UID, String Password)
        {
            string User = "0";
            DataSet ds = new DataSet();
            ds = cls.checkUserLogin(UID.Trim(), Password.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                HttpContext.Current.Session["CID"] = ds.Tables[0].Rows[0]["id"].ToString();
                User = "1";
            }
            return User;
        }

        [WebMethod(EnableSession = true)]
        public string checkSellerLogin(String UID, String Password)
        {
            string User = "0";
            DataSet ds = new DataSet();
            ds = cls.checkSellerLogin(UID.Trim(), Password.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                HttpContext.Current.Session["SID"] = ds.Tables[0].Rows[0]["Id"].ToString();
                User = "1";
            }
            return User;
        }

        [WebMethod(EnableSession = true)]
        public string bindadminMenu(String PID)
        {

            string UID = HttpContext.Current.Session["AID"].ToString();
            DataTable dt = new DataTable();
            List<MainmenuList> lst = new List<MainmenuList>();
            DataSet ds = new DataSet();
            ds = cls.bindAssignedMenuByUID(UID);
            dt = ds.Tables[0];
            DataView dataView = ds.Tables[1].DefaultView;
            foreach (DataRow dtrow in dt.Rows)
            {
                DataTable dt1 = new DataTable();
                dataView.RowFilter = "PID = '" + dtrow["ID"] + "'";
                dt1 = dataView.ToTable();
                List<MenuChildren> child = new List<MenuChildren>();
                foreach (DataRow row in dt1.Rows)
                {
                    child.Add(new MenuChildren()
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Sname = row["MenuTitle"].ToString(),
                        URL = row["MenuURL"].ToString().Trim(),

                    });
                }
                lst.Add(new MainmenuList()
                {
                    parentId = Convert.ToInt32(dtrow["ID"]),
                    Cname = dtrow["MenuTitle"].ToString().Trim(),
                    Smenu = child
                });
            }
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(lst);
        }
        [WebMethod(EnableSession = true)]
        public string bindUserMenu(String UTYPE)
        {
            DataTable dt = new DataTable();
            List<MainmenuList> lst = new List<MainmenuList>();
            DataSet ds = new DataSet();
            ds = cls.bindUserMenuByUtype(UTYPE);
            dt = ds.Tables[0];
            DataView dataView = ds.Tables[1].DefaultView;
            foreach (DataRow dtrow in dt.Rows)
            {
                DataTable dt1 = new DataTable();
                dataView.RowFilter = "PID = '" + dtrow["ID"] + "'";
                dt1 = dataView.ToTable();
                List<MenuChildren> child = new List<MenuChildren>();
                foreach (DataRow row in dt1.Rows)
                {
                    child.Add(new MenuChildren()
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Sname = row["MenuTitle"].ToString(),
                        URL = row["MenuURL"].ToString().Trim(),

                    });
                }
                lst.Add(new MainmenuList()
                {
                    parentId = Convert.ToInt32(dtrow["ID"]),
                    Cname = dtrow["MenuTitle"].ToString().Trim(),
                    URL = dtrow["MenuURL"].ToString().Trim(),
                    Smenu = child
                });
            }
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(lst);
        }

        [WebMethod]
        public string allchassis(String CHID)
        {

            DataTable dt = new DataTable();
            List<ChassisSearch> lst = new List<ChassisSearch>();
            DataSet ds = new DataSet();
            ds = cls.viewallchassisno(CHID.Trim());
            dt = ds.Tables[0];
            foreach (DataRow dtrow in dt.Rows)
            {
                ChassisSearch cat = new ChassisSearch();
                cat.Cno = dtrow["Chno"].ToString();
                lst.Add(cat);
            }
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(lst);
        }

        [WebMethod(EnableSession = true)]
        public string bindSellerMenu(String UTYPE)
        {
            DataTable dt = new DataTable();
            List<MainmenuList> lst = new List<MainmenuList>();
            DataSet ds = new DataSet();
            ds = cls.bindSellerMenuByUtype("3");  // 3 pass for the seller type
            dt = ds.Tables[0];
            DataView dataView = ds.Tables[1].DefaultView;
            foreach (DataRow dtrow in dt.Rows)
            {
                DataTable dt1 = new DataTable();
                dataView.RowFilter = "PID = '" + dtrow["ID"] + "'";
                dt1 = dataView.ToTable();
                List<MenuChildren> child = new List<MenuChildren>();
                foreach (DataRow row in dt1.Rows)
                {
                    child.Add(new MenuChildren()
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Sname = row["MenuTitle"].ToString(),
                        URL = row["MenuURL"].ToString().Trim(),

                    });
                }
                lst.Add(new MainmenuList()
                {
                    parentId = Convert.ToInt32(dtrow["ID"]),
                    Cname = dtrow["MenuTitle"].ToString().Trim(),
                    URL = dtrow["MenuURL"].ToString().Trim(),
                    Smenu = child
                });
            }
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(lst);
        }

        [WebMethod]
        public string GenericSearchMethod(string searchText, string procedureName)
        {
            DataTable dt = new DataTable();
            List<object> results = new List<object>();

            DataSet ds = clsUseMasters.CallSearchProcedure(procedureName, searchText);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {                 
                    results.Add(new { searchValue = row[1].ToString() });
                }
            }

            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(results);
        }
    }
}