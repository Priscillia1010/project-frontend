using Microsoft.AspNetCore.Mvc;
using CarRent_Frontend.Service;
using CarRent_Frontend.Model.Input;
using System.Linq; // Pastikan untuk mengimpor namespace ini

namespace CarRent_Frontend.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Kembalikan tampilan Login
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Logika autentikasi pengguna (contoh)
                // Jika autentikasi berhasil:
                HttpContext.Session.SetString("Username", model.Username);

                return RedirectToAction("Index", "Home");
            }

            return View(model); // Kembali ke tampilan jika ada kesalahan
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(); // Kembalikan tampilan Register
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Logika untuk menyimpan pengguna baru ke database
                // Misalnya, panggil service untuk registrasi

                return Json(new { success = true, redirectUrl = Url.Action("Login", "Auth") });
            }

            // Mengumpulkan pesan error dari ModelState
            var errors = ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .ToDictionary(e => e.Key.Replace(".", ""), e => e.Value.Errors.Select(x => x.ErrorMessage).FirstOrDefault());

            return Json(new { success = false, errors });
        }
    }
}
