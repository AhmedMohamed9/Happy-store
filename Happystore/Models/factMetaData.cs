using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Happystore.Models
{
    [MetadataType(typeof(fact.Metadata))]
    public partial class fact
    {
        sealed class Metadata
        {
            [Display(Name="اسم المصنع")]
            [Required(ErrorMessage ="ادخل اسم المصنع")]
            [MaxLength(100)]
            public string name { get; set; }
            [Display(Name = "العنوان")]
            [Required(ErrorMessage = "ادخل عنوان المصنع")]
            public string address { get; set; }
            [Display(Name = "رقم التليفون")]
            [Required(ErrorMessage = "ادخل رقم هاتف المصنع")]
            [MaxLength(12)]
            [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "ادخل رقم تليفون صحيح")]
            public string phone { get; set; }
        }
    }
}