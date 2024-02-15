using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EsimeneVeeb.Models
{
    public class ProductMetadata
    {
        [Display(Name = "Toote nimi")]
        public string ProductName { get; set; }
        [Display(Name ="Hind")]
        public Nullable<decimal> UnitPrice { get; set; }
    }

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    { }

    public class EmployeeMetadata 
    {
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public Nullable<System.DateTime> BirthDate { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public Nullable<System.DateTime> HireDate { get; set; }
    }

    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee { }


}