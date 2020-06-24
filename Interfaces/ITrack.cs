using System;

namespace DataServices.Migrations.Interfaces
{
    public interface ITrack
    {
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}