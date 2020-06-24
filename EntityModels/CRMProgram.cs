using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataServices.Migrations.EntityModels
{
    [Table("CRMProgram")]
    public class CRMProgram : TrackableEntry
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Hours { get; set; }

        #region Foreign key

        public string ConfirmationCode { get; set; }
        public int CompanyId { get; set; }
        public string EmployeeId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Confirmation Confirmation { get; set; }
        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

        #endregion
    }
}