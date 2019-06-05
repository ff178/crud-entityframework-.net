using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_EntityFramework.Models.ViewModels
{
    public class ListTablaViewModels
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public DateTime Modified_Date { get; set; }
    }
}