using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sa_bitsion_DAL.Models
{
    public class Cliente
    {
        [Required(ErrorMessage = "El DNI es obligatorio")]
        [Range(1000000, 99999999, ErrorMessage = "El DNI debe tener entre 7 y 8 dígitos")]
        public int DNI { get; set; }

        [Required(ErrorMessage = "El Nombre Completo es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El Nombre Completo no debe tener más de 100 caracteres")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "La Edad es obligatoria")]
        [Range(18, 110, ErrorMessage = "La Edad debe estar entre 18 y 110 años")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El Género es obligatoria")]
        public string Genero { get; set; }
        public bool Estado { get; set; }
        public bool EstadoCivil { get; set; }
        public bool Maneja { get; set; }
        public bool Lentes { get; set; }
        public bool Diabetes { get; set; }

        [StringLength(100, ErrorMessage = "La Otra Enfermedad no debe tener más de 100 caracteres")]
        public string OtraEnfermedad { get; set; }

    }
}