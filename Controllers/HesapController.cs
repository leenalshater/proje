using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using projeuyelik.Models;

namespace projeuyelik.Controllers
{
    public class HesapController : Controller
    {
        private UserManager<UygulamaKullanicisi> _usermanager;
        private SignInManager<UygulamaKullanicisi> _signInManager;
        public HesapController(
            UserManager<UygulamaKullanicisi> usermanager,
            SignInManager<UygulamaKullanicisi> signInManager)
        {
            _usermanager = usermanager;
            _signInManager = signInManager;
        }
        public IActionResult Kayit() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Kayit(kayit m)
        {
            if (ModelState.IsValid)
            {
                var kullanici = new UygulamaKullanicisi
                {
                    UserName = m.Email,
                    Ad = m.Ad,
                    Soyad = m.Soyad,
                    Email = m.Email
                };
                var sonuc = await _usermanager.CreateAsync(kullanici, m.Sifre);
                if (sonuc.Succeeded)
                {
                    ViewBag.OK = "Üye kaydınız başarıyla gerçekleşti, Lütfen giriş yapınız";
                }
                else
                {
                    ModelState.AddModelError("", sonuc.Errors.First().Description);
                }
            }
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(giris m)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(m.Email, m.Sifre, true, lockoutOnFailure: true);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "Hesap kilitli");
                    }
                    else 
                    {
                        ModelState.AddModelError("", "Giriş başarısız");
                    }

                }
            }
            return View();
        }

    }
}