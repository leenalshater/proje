using System.ComponentModel.DataAnnotations;

public class kayit
{

    [Display(Name = "Adınız")]
    [Required(ErrorMessage = "Ad Alanı Gereklidir.")]
    public string Ad{ get; set; }=null!;

    [Display(Name = "SoyAdınız")]
    [Required(ErrorMessage = "SoyAd Alanı Gereklidir.")]
    public string Soyad { get; set; }=null!;

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email Alanı Gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçerli Bir Email Adresi Giriniz")]
    public string Email { get; set; }

    [Display(Name = "Şifre")]
    [MaxLength(16, ErrorMessage = "Şifre en fazla 16 karakter girilmeli.")]
    [MinLength(6, ErrorMessage = "Şifren az 6 karakter girilmeli")]
    [Required(ErrorMessage = "Şifre Alanı Gereklidir.")]
    [DataType(DataType.Password)]
    public string Sifre { get; set; }

    [Display(Name = "Şifre Tekrarı")]
    [Required(ErrorMessage = "Şifre Tekrarı Alanı Gereklidir.")]
    [Compare("Sifre")]
    [DataType(DataType.Password)]
    public string SifreTekrari { get; set; }

}