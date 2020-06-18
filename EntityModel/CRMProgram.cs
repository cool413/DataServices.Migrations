using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataServices.Migrations.EntityModel
{
    public class CRMProgram
    {
        [Column(TypeName = "varchar(10)")] public string Code { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(4,1)")]
        public decimal? Hours { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? ModiDate { get; set; }

        #region Foreign key

        [Required]public string ConfirmationCode { get; set; }
        [Required]public int EmployeeId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Confirmation Confirmation { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

        #endregion
    }
}