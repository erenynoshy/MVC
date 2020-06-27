namespace shop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderData")]
    public partial class OrderData
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal UserID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal ProductID { get; set; }

        public DateTime? Time { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
