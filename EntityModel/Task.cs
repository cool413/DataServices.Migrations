using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataServices.Migrations.EntityModel
{
    public class Task
    {
        [Key] public int Id { get; set; }
        [Column(TypeName = "varchar(20)")] public string Tag { get; set; }

        [Required]
        [Column(TypeName = "varchar(1)")]
        public string Priority { get; set; }

        [Required]
        [Column(TypeName = "varchar(1)")]
        public string Status { get; set; }

        [Required]
        [Column(TypeName = "decimal(4,1)")]
        public decimal Hours { get; set; }

        [Required]
        [Column(TypeName = "varchar(8)")]
        public string StarDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(8)")]
        public string EndDate { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ModiDate { get; set; }

        #region Foreign key

        [Required] public string ConfirmationCode { get; set; }
        [Required] public string CRMProgramCode { get; set; }
        [Required] public int EmployeeId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Confirmation Confirmation { get; set; }
        public virtual CRMProgram CRMProgram { get; set; }
        public virtual Employee Employee { get; set; }

        #endregion
    }
}