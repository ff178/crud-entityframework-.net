using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_EntityFramework.Models.ViewModels
{
    public class TablaViewModels
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Product")]
        public string Product { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Modified Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode= true)]
        public DateTime Modified_Date { get; set; }
    }
}