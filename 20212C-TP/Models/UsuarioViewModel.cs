using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _20212C_TP.Models
{
    public class UsuarioViewModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PassworConfirmar { get; set; }
        [Required]
        [Range(1, 2, ErrorMessage = "Tenes que seleccionar un perfil")]
        public int Perfil { get; set; }
    }
}
