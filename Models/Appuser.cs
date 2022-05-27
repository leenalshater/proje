using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

    public class UygulamaKullanicisi : IdentityUser
    {
        public string Ad { get; set; }
        
        public string Soyad { get; set; }
    }