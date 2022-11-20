using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerWebApi.Model
{
    public partial class ProjectTask
    {
        public int Id { get; set; }
        public int? IdProject { get; set; }
        public int? IdTask { get; set; }
    }
}
