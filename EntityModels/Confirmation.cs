using System.Collections.Generic;

namespace DataServices.Migrations.EntityModels
{
    public class Confirmation : TrackableEntry
    {
        public string Code { get; set; }
        public string SystemVersion { get; set; }

        #region Foreign key

        public int CompanyId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Company Company { get; set; }
        public virtual ICollection<CRMProgram> CRMPrograms { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }

        #endregion
    }
}