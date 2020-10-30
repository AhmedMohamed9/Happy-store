using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Happystore.Models
{
    [MetadataType(typeof(Sub_Category.MEtadata))]
    public partial class Sub_Category
    {
        sealed class MEtadata
        {
            [Required]
            [MaxLength(50,ErrorMessage ="عدد الحروف اكتر من 50 حرف")]
            [Display(Name="القسم الفرعى")]
            public string Name { get; set; }
        }
    }
}