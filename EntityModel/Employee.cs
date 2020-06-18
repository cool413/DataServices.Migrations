﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataServices.Migrations.EntityModel
{
    public class Employee
    {
        [Key] public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(2)")] public string Type { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? ModiDate { get; set; }

        #region Navigation Properties

        public virtual ICollection<CRMProgram> Programs { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

        #endregion
    }
}