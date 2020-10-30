using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Happystore.Models
{
    [MetadataType(typeof(Product.metadata))]
    public partial class Product
    {
        sealed class metadata
        {
            [Required]
            [Display(Name ="اسم المنتج")]
            [MaxLength(70)]
            public string name { get; set; }
            [Required]
            [Display(Name = "وصف المنتج")]
            [AllowHtml]
            public string Discription { get; set; }
            [Required]
            [Display(Name = "السعر")]
            [MaxLength(5)]
            public string Price { get; set; }
            
            [Display(Name = "صورة المنتج")]
            public string Image { get; set; }
            [Required]
            [Display(Name = "فديو المنتج")]
            [AllowHtml]
            public string Video { get; set; }
            public int Sub_Categorie_id { get; set; }
            [Required]
            [Display(Name = "محتاج صورة من العميل")]
            public bool Need_image { get; set; }
            [Required]
            [Display(Name = "محتاج اسم من العميل")]
            public bool Need_Name { get; set; }
        }
    }
}