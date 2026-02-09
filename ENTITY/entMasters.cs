using System.Collections.Generic;

namespace ENTITY
{
    public class entMasters
    {

    }
    public class entLogin
    {
        public string ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string utype { get; set; }
    }

    #region Rohit15102025
    public class entUploadConsignee
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeContact { get; set; }
        public string PassportImg1 { get; set; }
        public string PassportImg2 { get; set; }
        public string PassportImg3 { get; set; }
        public string DocSnils { get; set; }
        public string DocInn { get; set; }
        public string DocPayment { get; set; }
        public string ConsigneeAddress { get; set; }
        public int uid { get; set; }
        public string action { get; set; }
    }

    #endregion
    public class entmanu
    {
        public int ID { get; set; }
        public string MenuTitle { get; set; }
        public string MenuURL { get; set; }
        public int PID { get; set; }
        public string uid { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }
        public string utype { get; set; }

    }
    public class MainmenuList
    {
        public int parentId { get; set; }
        public string Cname { get; set; }
        public string URL { get; set; }
        public List<MenuChildren> Smenu { get; set; }
    }
    public class MenuChildren
    {
        public int ID { get; set; }
        public string Sname { get; set; }
        public string URL { get; set; }
    }
    #region Ashsih 17072025
    public class entLocation
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string LocationName { get; set; }
        public int uid { get; set; }
        public bool Archive { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }
    }
    #endregion

    #region Created by Ashsih 18072025
    public class entTransport
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string TransportName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string FaxNumber { get; set; }
        public int uid { get; set; }
        public bool Archive { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }
    }

    public class entShipping
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string ShippingName { get; set; }
        public string ShippingRate { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public int uid { get; set; }
        public int Archive { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }
    }


    public class entPortPrice
    {
        public int Id { get; set; }
        public int CountryFromId { get; set; }
        public int CountryToId { get; set; }
        public decimal InspectionPrice { get; set; }
        public decimal RatiaionPrice { get; set; }
        public decimal PortPrice { get; set; }
        public decimal MiscPrice { get; set; }
        public int uid { get; set; }
        public bool Archive { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }
    }
    #endregion

    #region Rohit 17072025
    public class entmaker
    {
        public int Id { get; set; }
        public string MakerName { get; set; }
        public string MakerLogo { get; set; }
        public string uid { get; set; }
        public bool Archive { get; set; }
    }
    #endregion

    #region Rohit 18072025
    public class entbodyType
    {
        public int Id { get; set; }
        public string BodyTypeName { get; set; }
        public string BodyTypeIcon { get; set; }
        public string uid { get; set; }
        public bool Archive { get; set; }
    }
    #endregion

    #region Rohit 21072025
    public class entBill
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string BillDate { get; set; }
        public string UploadDocument { get; set; }
        public string uid { get; set; }

    }
    #endregion

    #region created by Ashish
    public class entAdduser
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public string Idtype { get; set; }
        public string IdNumber { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public int Designation { get; set; }
        public int UserType { get; set; }
        public int Edepartment { get; set; }
        public string PAddress { get; set; }
        public string RAddress { get; set; }
        public int uid { get; set; }
        public bool Archive { get; set; }

        public string PageNo { get; set; }
        public string PageSize { get; set; }
    }
    #endregion


    #region Lalit 28072025
    public class entFeaturesMaster
    {
        public int id { get; set; }
        public int? categoryid { get; set; }
        public string FeatureName { get; set; }
        public int? PID { get; set; }
        public List<entFeaturesMaster> SubFeatures { get; set; }
    }
    public class entMetaDataMaster
    {
        public int mid { get; set; }
        public string titletext { get; set; }
        public string keywords { get; set; }
        public string description { get; set; }
        public string pagecontent { get; set; }
        public int? pageid { get; set; }
        public int? uid { get; set; }
    }
    #endregion
    #region created by Ashish

    public class entAuction
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public decimal FaxNumber { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }
        public int uid { get; set; }
        public bool Archive { get; set; }

        public int AGroup { get; set; }
    }
    public class entConsignee
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string CFS { get; set; }
        public string ConsigneeName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }
        public int uid { get; set; }
        public bool Archive { get; set; }
    }

    public class entTerminal
    {
        public int Id { get; set; }
        public int PortId { get; set; }
        public string Tcname { get; set; }
        public string Tname { get; set; }
        public string Cperson { get; set; }
        public string ContactNo { get; set; }
        public decimal Price { get; set; }
        public string Email { get; set; }
        public string Taddress { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }
        public int uid { get; set; }
        public bool Archive { get; set; }
    }


    #endregion
    #region Created by Ashish 04/08/25
    public class entAuctionYard
    {
        public int Id { get; set; }
        public int AuctionId { get; set; }
        public string AuctionYard { get; set; }
        public string LotNoFrom { get; set; }
        public string LotNoTo { get; set; }
        public string OutDay { get; set; }
        public string OutTime { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public string FaxNo { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }
        public int uid { get; set; }
        public bool Archive { get; set; }

    }
    #endregion


    #region Rohit 05082025
  
    public class ChassisSearch
    {
        public string Cno { get; set; }
    }
    #endregion

    public class entAuctionBuying
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int uid { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }

    }

    public class entBlog
    {
        public int id { get; set; }
        public string blang { get; set; }
        public int btopicid { get; set; }
        public string btitle { get; set; }
        public string burl { get; set; }
        public string bdate { get; set; }
        public string bimage { get; set; }
        public string ptitle { get; set; }
        public string keytag { get; set; }
        public string desctag { get; set; }
        public string sdetails { get; set; }
        public string fdetails { get; set; }
        public bool archive { get; set; }
        public int uid { get; set; }
    }
    public class entOtherTypeBuy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int uid { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }

    }
    public class entBlogTopic
    {
        public int id { get; set; }        
        public string btopic { get; set; }      
        public bool archive { get; set; }
        public int uid { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }
    }

}
