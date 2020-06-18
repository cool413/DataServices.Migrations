using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataServices.Migrations.EntityModel
{
    public class Company
    {
        [Key] public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(4)")]
        public string Code { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? ModiDate { get; set; }

        #region Navigation Properties

        public virtual ICollection<Confirmation> Confirmations { get; set; }

        #endregion
    }
}