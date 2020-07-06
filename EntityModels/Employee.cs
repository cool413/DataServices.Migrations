using System.Collections.Generic;

namespace DataServices.Migrations.EntityModels
{
    public class Employee : TrackableEntry
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        #region Navigation Properties

        public virtual ICollection<CRMProgram> CRMPrograms { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }

        #endregion
    }
}