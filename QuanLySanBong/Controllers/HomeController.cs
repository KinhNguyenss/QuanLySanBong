using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient; // 1. Bắt buộc thêm dòng này để dùng thư viện ADO.NET
using System.Configuration;  // 2. Bắt buộc thêm dòng này để đọc file Web.config

namespace QuanLySanBong.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Lấy chuỗi kết nối từ file Web.config bạn đã cấu hình
            string connectionString = ConfigurationManager.ConnectionStrings["DbSanBong"].ConnectionString;
            string ketQuaTest = "";

            // Sử dụng đối tượng kết nối SqlConnection của ADO.NET
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open(); // Tiến hành thử mở cổng kết nối xuống SQL Server ổ D
                    ketQuaTest = "Chúc mừng! Kết nối đến SQL Server THÀNH CÔNG rồi!";
                }
                catch (Exception ex)
                {
                    // Nếu lỗi (Ví dụ: sai tên Server, sai tên DB), hệ thống sẽ nhảy vào đây
                    ketQuaTest = "Kết nối THẤT BẠI. Lỗi chi tiết: " + ex.Message;
                }
            }

            // Gửi chuỗi kết quả ra màn hình giao diện
            ViewBag.ThongBao = ketQuaTest;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
