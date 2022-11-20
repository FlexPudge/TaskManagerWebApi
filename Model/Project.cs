using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerWebApi.Model
{
    public partial class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public byte[]? Image { get; set; }
        public string? Description { get; set; }
        
    }
}
