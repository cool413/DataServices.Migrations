using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataServices.Migrations.EntityModel
{
    public class Confirmation
    {
        [Key] public string Code { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public int? SystemVersion { get; set; }

        [Required] public string Creator;

        public DateTime? CreateDate { get; set; }
        public DateTime? ModiDate { get; set; }

        #region Foreign key

        [Required] public int? CompanyId { get; set; }

        #endregion


        #region Navigation Properties

        public virtual Company Company { get; set; }
        public virtual ICollection<CRMProgram> Programs { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

        #endregion
    }
}