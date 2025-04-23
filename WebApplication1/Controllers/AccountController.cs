using System.Web.Mvc;
using WebApplication1.Models.ViewModel;
using WebApplication1.Models;
using System.Linq;
using System.Data.Entity.Validation;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tên đăng nhập đã tồn tại chưa
                var existingUser = db.Users.SingleOrDefault(u => u.Username == model.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Username", "Tên đăng nhập này đã tồn tại!");
                    return View(model);
                }

                // Nếu chưa tồn tại thì tạo bản ghi thông tin tài khoản trong bảng User
                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password, // Lưu ý: nên mã hóa mật khẩu trước khi lưu
                    UserRole = "C"
                };

                db.Users.Add(user);

                // Sau đó thêm thông tin khách hàng trong bảng Customer
                var customer = new Customer
                {
                    CustomerName = model.CustomerName,
                    CustomerPhone = model.CustomerPhone,
                    CustomerEmail = model.CustomerEmail,
                    CustomerAddress = model.CustomerAddress,
                    Username = model.Username
                };

                db.Customers.Add(customer);

                // Lưu thay đổi (tạo tài khoản và thông tin khách hàng vào CSDL)
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                    throw; // ném lại lỗi để dừng chương trình, hoặc bạn có thể xử lý khác
                }

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = db.Users.SingleOrDefault(u =>
                u.Username == model.Username &&
                u.Password == model.Password &&
                u.UserRole == "Customer"
            );

            if (user != null)
            {
                // Lưu trạng thái đăng nhập vào session
                Session["Username"] = user.Username;
                Session["UserRole"] = user.UserRole;

                // Lưu thông tin xác thực người dùng vào cookie
                FormsAuthentication.SetAuthCookie(user.Username, false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                return View(model);
            }
        }
    }
}