using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SampleService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/CreateNewUser/{name}/{mobile}/{email}/{address}/{password}")]
        List<clsListdata> CreateNewUser(string name, string mobile, string email, string address, string password);

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/LoginUser/{UseridmobileEmail}/{password}")]
        List<logindata> LoginUsers(string UseridmobileEmail, string password); ///both name after slash and methpd paramter shuld be same

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/UpdateNewUser")]
        List<clsLeadDataSuccess> UpdateNewUser(updatenewuserdetail p1);
    }

    [DataContract]
    public class clsListdata
    {
        [DataMember(Name = "SuccessOrError", Order = 0)]
        public string SuccessOrError { get; set; }
        [DataMember(Name = "SuccessMessage", Order = 1)]
        public string SuccessMessage { get; set; }
        [DataMember(Name = "ErrorMessage", Order = 2)]
        public string ErrorMessage { get; set; }
    }

    [DataContract]
    public class logindata
    {


        [DataMember(Name = "SuccessError", Order = 0)]
        public string SuccessOrError { get; set; }

        [DataMember(Name = "EMessage", Order = 1)]
        public string ErrorMessage { get; set; }


        [DataMember(Name = "UserID", Order = 2)]
        public string UserID { get; set; }

        
        [DataMember(Name = "UserName", Order = 3)]
        public string UserName { get; set; }

        [DataMember(Name = "LoggedIn", Order = 4)]
        public string LoggedIn { get; set; }


        [DataMember(Name = "SessionID", Order = 5)]
        public string SessionID { get; set; }


        [DataMember(Name = "LastLoginDate", Order = 6)]
        public string LastLoginDate { get; set; }


    }


    [DataContract]
    public class clsLeadDataSuccess
    {
        [DataMember(Name = "SuccessOrError", Order = 0)]
        public string SuccessOrError { get; set; }
        [DataMember(Name = "SuccessMessage", Order = 1)]
        public string SuccessMessage { get; set; }
        [DataMember(Name = "ErrorMessage", Order = 2)]
        public string ErrorMessage { get; set; }
    }


    [DataContract]
    public class updatenewuserdetail
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string mobile { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string address { get; set; }

        [DataMember]
        public string password { get; set; }
    }


    }
