using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Import.Presentation.Model
{
    public class ImportModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public FileInfo File { get; set; }

        public string OriginalFileName { get; set; }
    }
}