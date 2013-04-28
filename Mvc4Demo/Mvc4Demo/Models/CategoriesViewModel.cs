
namespace Mvc4Demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CategoriesViewModel
    {
        [DisplayName("ID")]
        [ScaffoldColumn(false)]
        public int CategoryID 
        { 
            get; 
            set; 
        }

        [Required]
        [DisplayName("Category")]
        public string CategoryName 
        { 
            get; 
            set; 
        }

        [Required]
        public string Description 
        { 
            get; 
            set; 
        }
    }
}