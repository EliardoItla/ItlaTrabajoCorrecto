using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlDelItla.Models.TableView
{
    public class AsignaturaView
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
    }
}