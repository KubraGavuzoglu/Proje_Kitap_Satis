using System.ComponentModel.DataAnnotations;

namespace Kitap.Entities
{
    public class Brand : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez!"), StringLength(50), Display(Name = "Yazar Adı")]
        public string Name { get; set; }

        [Display(Name = "Yazar Açıklaması")]
        public string? Description { get; set; }

        [StringLength(150), Display(Name = "Yazar Resmi")]
        public string? Logo { get; set; } = ""; // property e varsayılan değer atama

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }



        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)] //   ScaffoldColumn(false) demek  viewlar oluşturulurken bu alan ekranda gözükmesin demektir.
        public DateTime? CreateDate { get; set; } = DateTime.Now; // eğer bu alan boş geçilirse eklenme zamanını sistemden otomatik al


        public virtual ICollection<Product>? Products { get; set; } // Marka ile Ürünler arasında 1 e çok ilişki kurduk

    }
}
