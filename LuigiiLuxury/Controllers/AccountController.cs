using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Services;
using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IOrdersService _ordersService;
        private readonly IOrderDetailsService _orderDetailsService;

        public AccountController(IUsersService usersService, IOrdersService ordersService, IOrderDetailsService orderDetailsService)
        {
            _usersService = usersService;
            _ordersService = ordersService;
            _orderDetailsService = orderDetailsService;
        }

        public ActionResult Index()
        {
            if (Session["CurrentUserId"] == null)
                return RedirectToAction("Login", "Account");
            else
            {
                int id = Convert.ToInt32(Session["CurrentUserId"]);
                var user = _usersService.Get(id);

                return View(user);
            }
        }

        #region Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginForm)
        {
            if (ModelState.IsValid)
            {
                // kiểm tra email đã được đăng ký chưa?
                if (_usersService.IsEmailRegistered(loginForm.Email))
                {
                    // nếu được đăng ký rồi thì kiểm tra password
                    if (_usersService.IsValidPassword(loginForm.Email, loginForm.Password))
                    {
                        var user = _usersService.GetByEmail(loginForm.Email);

                        if (_usersService.IsAdmin(user))
                        {
                            Session["Admin"] = user;

                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            Session["CurrentUserId"] = user.Id;
                            Session["CurrentFullName"] = _usersService.GetFullName(user.Id);

                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else // ngược lại thông báo lỗi
                    {
                        ModelState.AddModelError("ErrorPassword", "invalid password");

                        return View(loginForm);
                    }
                }
                else // nếu chưa thì thông báo
                {
                    ModelState.AddModelError("NotFindEmail", "your email is not registered.");

                    return View(loginForm);
                }
            }
            else
            {
                ModelState.AddModelError("CustomError", "Invalid data");

                return View(loginForm);
            }
        }
        #endregion

        #region Reggister
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel registerForm)
        {
            if (ModelState.IsValid)
            {
                if (_usersService.IsEmailRegistered(registerForm.Email))
                {
                    ModelState.AddModelError("InvalidEmail", "email is already registered");

                    return View(registerForm);
                }
                else
                {
                    _usersService.Register(registerForm);

                    int id = _usersService.GetByEmail(registerForm.Email).Id;

                    Session["CurrentUserId"] = id;
                    Session["CurrentFullName"] = _usersService.GetFullName(id);

                    return RedirectToAction("Index", "Account");
                }
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");

                return View(registerForm);
            }
        }
        #endregion

        #region Update
        public ActionResult ChangePassword()
        {
            int id = Convert.ToInt32(Session["CurrentUserId"]);
            var user = _usersService.Get(id);

            var form = new ChangePasswordFormViewModel()
            {
                Id = user.Id,
                Email = user.Email
            };

            return View(form);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordFormViewModel changePasswordForm)
        {
            if (ModelState.IsValid)
            {
                if (_usersService.IsValidPassword(changePasswordForm.Email, changePasswordForm.CurrentPassword))
                {
                    _usersService.ChangePassword(changePasswordForm);

                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("ExistingError", "invalid current password !");

                    return View(changePasswordForm);
                }
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");

                return View(changePasswordForm);
            }
        }

        public ActionResult Update()
        {
            int id = Convert.ToInt32(Session["CurrentUserId"]);
            var user = _usersService.Get(id);

            var form = new UserFormViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                City = user.City,
            };

            return View(form);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UserFormViewModel userForm)
        {
            if (ModelState.IsValid)
            {
                _usersService.Update(userForm.Id, userForm);

                Session["CurrentFullName"] = _usersService.GetFullName(userForm.Id);
                Session["CurrentUserId"] = userForm.Id;

                return RedirectToAction("Index", "Account");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");

                return View(userForm);
            }
        }
        #endregion  

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("CurrentUserId");
            HttpContext.Session.Remove("CurrentFullName");

            if (Session["Admin"] != null)
                HttpContext.Session.Remove("Admin");

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Orders()
        {
            if (Session["CurrentUserId"] != null)
            {
                int id = Convert.ToInt32(Session["CurrentUserId"]);

                return View(id);
            }
            else
                return HttpNotFound();

        }

        public ActionResult Details(int orderId)
        {
            return View(orderId);
        }
    }
}