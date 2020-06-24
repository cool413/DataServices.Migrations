using System;
using DataServices.Migrations.Interfaces;

namespace DataServices.Migrations.EntityModels
{
    public abstract class TrackableEntry : ITrack
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}