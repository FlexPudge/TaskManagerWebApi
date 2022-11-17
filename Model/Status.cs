using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerWebApi.Model
{
    public partial class Status
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}
