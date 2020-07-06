using System.Collections.Generic;

namespace DataServices.Migrations.EntityModels
{
    public class Company : TrackableEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        #region Navigation Properties

        public virtual ICollection<Confirmation> Confirmations { get; set; }

        public virtual ICollection<CRMProgram> CRMPrograms { get; set; }

        #endregion
    }
}