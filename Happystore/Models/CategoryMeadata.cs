using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Happystore.Models
{
    [MetadataType(typeof(Category.MetaData))]
    public partial class Category
    {
        sealed class MetaData
        {
            [Required(ErrorMessage ="ادخل الاسم")]
            [MaxLength(100)]
            [Display(Name="القسم الرئيسى")]
            public string Name { get; set; }
            [Required(ErrorMessage = "ادخل الترتيب")]
            [Display(Name = "ترتيب الاقسام")]
            public int Orde_num { get; set; }
            public int Fac_id { get; set; }

            
        }
    }
}