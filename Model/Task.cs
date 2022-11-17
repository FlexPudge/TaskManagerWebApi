using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerWebApi.Model
{
    public partial class Task
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? Creator { get; set; }
        public int? Executor { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Finito { get; set; }
        public string? Comment { get; set; }
    }
}
