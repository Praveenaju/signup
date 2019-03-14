using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.ServiceModel.Activation;

using System.Data.SqlClient;
using System.IO;
using System.Configuration;


namespace SampleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode =AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {

     

        public List<clsListdata> CreateNewUser(string name, string mobile, string email, string address, string password)
        {

            string c = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(c);


            List<clsListdata> lstdata = new List<clsListdata>();
            try
            {


                SqlCommand cmd = new SqlCommand("exec CreateNewUser @name,@mobile,@email,@address,@pwd", con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@Mobile",mobile);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@address",address);
                cmd.Parameters.AddWithValue("@pwd", password);

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                con.Open();

                
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();



                if (dt.Rows[0]["SuccessMessage"].ToString() != "")
                {
                    
                    clsListdata clsdata = new clsListdata();
                    clsdata.SuccessOrError = dt.Rows[0]["SuccessOrError"].ToString();
                    clsdata.SuccessMessage = dt.Rows[0]["SuccessMessage"].ToString();
                    clsdata.ErrorMessage = "";
                    lstdata.Add(clsdata);

                }
                else
                {
                    

                    clsListdata clsdata = new clsListdata();
                    clsdata.SuccessOrError = dt.Rows[0]["SuccessOrError"].ToString();
                    clsdata.SuccessMessage = "";
                    clsdata.ErrorMessage = dt.Rows[0]["EMessage"].ToString();
                    lstdata.Add(clsdata);

                }



            }   
            catch(Exception ex)
            {
                clsListdata clsdata = new clsListdata();
                clsdata.SuccessOrError = "";
                clsdata.SuccessMessage = "";
                clsdata.ErrorMessage = ex.Message.ToString();
                lstdata.Add(clsdata);
            }
            return lstdata;
        }


        public List<logindata> LoginUsers(string name, string pwd)
        {
            List<logindata> lgndata = new List<logindata>();
            try
            {

                string c = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                SqlConnection con = new SqlConnection(c);


                SqlCommand cmd2 = new SqlCommand("exec loginandvalidation @name,@pwd", con);
                cmd2.Parameters.AddWithValue("@name", name);
                cmd2.Parameters.AddWithValue("@pwd", pwd);

                cmd2.CommandType = CommandType.Text;
                SqlDataAdapter da2 = new SqlDataAdapter();
                da2.SelectCommand = cmd2;
                con.Open();


                DataTable dt2 = new DataTable();
                da2.Fill(dt2);

                con.Close();


                if (dt2.Rows[0]["EMessage"].ToString() == "")
                {

                    logindata logndata = new logindata();
                    logndata.SuccessOrError = dt2.Rows[0]["SuccessOrError"].ToString();
                    logndata.ErrorMessage = dt2.Rows[0]["EMessage"].ToString();
                    logndata.UserID = dt2.Rows[0]["UserID"].ToString();
                    logndata.UserName = dt2.Rows[0]["UserName"].ToString();
                    logndata.LoggedIn = dt2.Rows[0]["LoggedIn"].ToString();
                    logndata.SessionID = dt2.Rows[0]["SessionID"].ToString();
                    logndata.LastLoginDate = dt2.Rows[0]["LastLoginDate"].ToString();
                    lgndata.Add(logndata);


                }


            }
            catch (Exception ex)
            {

                logindata logndata = new logindata();
                logndata.SuccessOrError = "";
                logndata.ErrorMessage = ex.Message.ToString(); 
                logndata.UserID = "";
                logndata.UserName = "";
                logndata.LoggedIn = "";
                logndata.SessionID = "";
                logndata.LastLoginDate = "";
                lgndata.Add(logndata);
            }
            return lgndata;
        }


        public List<clsLeadDataSuccess> UpdateNewUser(updatenewuserdetail p1)
        {
            List<clsLeadDataSuccess> lst = new List<clsLeadDataSuccess>();


            try
            {

                string c = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                SqlConnection con = new SqlConnection(c);

                SqlCommand cmd3 = new SqlCommand("exec CreateNewUser @name,@mobile,@email,@address,@pwd", con);
                cmd3.Parameters.AddWithValue("@name", "name");
                cmd3.Parameters.AddWithValue("@Mobile", "9751902721");
                cmd3.Parameters.AddWithValue("@Email", "p1.email");
                cmd3.Parameters.AddWithValue("@address","hdjd");
                cmd3.Parameters.AddWithValue("@pwd", "dvd");



                cmd3.CommandType = CommandType.Text;
                SqlDataAdapter da3 = new SqlDataAdapter();
                da3.SelectCommand = cmd3;
                con.Open();


                DataTable dt3 = new DataTable();
                da3.Fill(dt3);

                con.Close();



                if (dt3.Rows[0]["SuccessMessage"].ToString() != "")
                {
                    clsLeadDataSuccess cls = new clsLeadDataSuccess();

          
                    cls.SuccessOrError = dt3.Rows[0]["SuccessOrError"].ToString();
                    cls.SuccessMessage = dt3.Rows[0]["SuccessMessage"].ToString();
                    cls.ErrorMessage = "";
                    lst.Add(cls);

                }
                else
                {
                    clsLeadDataSuccess cls = new clsLeadDataSuccess();


                    cls.SuccessOrError = dt3.Rows[0]["SuccessOrError"].ToString();
                    cls.SuccessMessage = "";
                    cls.ErrorMessage = dt3.Rows[0]["EMessage"].ToString();
                    lst.Add(cls);
                 

                }



            }
            catch (Exception ex)
            {



                clsLeadDataSuccess cls = new clsLeadDataSuccess();


                cls.SuccessOrError = "";
                cls.SuccessMessage = "";
                cls.ErrorMessage = ex.Message.ToString();
                lst.Add(cls);
            }
            return lst;
        }

        }
}
