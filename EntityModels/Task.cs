using System.ComponentModel.DataAnnotations.Schema;

namespace DataServices.Migrations.EntityModels
{
    [Table("Task")]
    public class Task : TrackableEntry
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public decimal Hours { get; set; }
        public string StarDate { get; set; }
        public string EndDate { get; set; }

        #region Foreign key

        public string ConfirmationCode { get; set; }
        public string CRMProgramCode { get; set; }
        public string EmployeeId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Confirmation Confirmation { get; set; }
        public virtual CRMProgram CRMProgram { get; set; }
        public virtual Employee Employee { get; set; }

        #endregion
    }
}