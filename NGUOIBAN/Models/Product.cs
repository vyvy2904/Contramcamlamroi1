namespace NGUOIBAN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;


    public class Product
    {
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            ImagePro = "~/Content/images/bongcaixanh.png";
        }

        public int ProductID { get; set; }
        public string NamePro { get; set; }
        public string DecriptionPro { get; set; }
        public string Category { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ImagePro { get; set; }
        public Nullable<int> Quantity { get; set; }

        public virtual Category Category1 { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
