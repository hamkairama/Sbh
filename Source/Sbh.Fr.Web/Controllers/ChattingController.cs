using Sbh.Fr.CommonFunction;
using Sbh.Fr.Facade.Interface;
using Sbh.Fr.Facade.Repository;
using Sbh.Fr.Model;
using Sbh.Fr.Model.ClsGlobal;
using Sbh.Fr.Model.Custom;
using Sbh.Fr.Model.DbCtx;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sbh.Fr.Web.Controllers
{
    public class ChattingController : Controller
    {
        ResultStatus rs = new ResultStatus();
        //INews repo;
        public ChattingController()
        {
            //repo = new NewsRepo();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult CreateChatMessage(int senderId, int receiverId, string message)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            DateTime date = DateTime.Now;
            string date3 = date.ToString("yyyy-MM-dd");
            string time = date.ToString("HH:mm:ss");

            try
            {
                conn.Open();
                string query = "insert into SBH_TM_CHATBOX values('" + senderId + "','" + receiverId + "','" + message + "','" + date3 + "','" + time + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i >= 1)
                {
                    rs.SetSuccessStatus();
                }

            }
            catch (Exception ex)
            {
                rs.SetErrorStatus(ex.Message);
                conn.Close();
            }


            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetListChatBox(int senderId, int receiverId)
        {
            List<ChatBox> result = new List<ChatBox>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            DateTime date = DateTime.Now;
            string date3 = date.ToString("yyyy-MM-dd");

            try
            {
                //string agent = Session["Admin"].ToString();
                conn.Open();
                string str = "SELECT ID, SENDER_ID, RECEIVER_ID, dbo.FS_GET_USER_NAME(SENDER_ID) AS SENDER_NAME, dbo.FS_GET_USER_NAME(RECEIVER_ID) AS RECEIVER_NAME, MESSAGE, DATE, TIME FROM SBH_TM_CHATBOX WHERE ( SENDER_ID = " + senderId + " AND RECEIVER_ID = " + receiverId +  "AND DATE = '" + date3 +  "') OR ( SENDER_ID = " + receiverId + " AND RECEIVER_ID = " + senderId + " AND DATE = '" + date3 + "') ORDER BY ID";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChatBox cht = new ChatBox();
                    cht.ID = (int)dt.Rows[i]["ID"];
                    cht.SENDER_ID = (int)dt.Rows[i]["SENDER_ID"];
                    cht.RECEIVER_ID = (int)dt.Rows[i]["RECEIVER_ID"];
                    cht.SENDER_NAME = (string)dt.Rows[i]["SENDER_NAME"];
                    cht.RECEIVER_NAME = (string)dt.Rows[i]["RECEIVER_NAME"];
                    cht.MESSAGE = (string)dt.Rows[i]["MESSAGE"];
                    cht.DATE = (DateTime)dt.Rows[i]["DATE"];

                    TimeSpan ts = (TimeSpan)dt.Rows[i]["TIME"];
                    cht.TIME = ts.ToString(@"hh\:mm");

                    result.Add(cht);
                }
                conn.Close();
            }
            catch (Exception)
            {
                conn.Close();
            }
           
            return Json(result, JsonRequestBehavior.AllowGet);
        }     


    }

}