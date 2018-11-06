using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities
{
    public class ModeloCuentasUs
    {
    }

    public class Login
    {
        [Required]
        [DisplayName("Email")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        public string password { get; set; }

        [DisplayName("¿Recordar usuario?")]
        public bool rememberMe { get; set; }

        public Login() { }

        public Login(string email, string password) {
            this.email = email;
            this.password = password;
        }
    }

    public class Registro
    {
        [Required(ErrorMessage = "Proporcione el nombre.")]
        [DisplayName("Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Proporcione el apellido.")]
        [DisplayName("Apellido")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [DisplayName("Teléfono")]
        [StringLength(20)]
        public String Telefono { get; set; }

        [Required]
        [DisplayName("Email")]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden!")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.CreditCard)]
        [DisplayName("Numero Tarjeta de Credito")]
        public long? CreditCardNumber { get; set; }

        [DisplayName("Tipo de tarjeta")]
        public String CreditCardType { get; set; }
    }

    public class Update
    {
        [Required(ErrorMessage = "Proporcione el nombre.")]
        [DisplayName("Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Proporcione el apellido.")]
        [DisplayName("Apellido")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [DisplayName("Teléfono")]
        [StringLength(20)]
        public String Telefono { get; set; }

        [Required]
        [DisplayName("Email")]
        public String Email { get; set; }

        [DataType(DataType.CreditCard)]
        [DisplayName("Numero Tarjeta de Credito")]
        public long? CreditCardNumber { get; set; }

        [DisplayName("Tipo de tarjeta")]
        public String CreditCardType { get; set; }
    }

    public class Contrasena
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña actual")]
        public string PasswordActual { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña nueva")]
        public string PasswordNuevo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirmar Contraseña")]
        [Compare("PasswordNuevo", ErrorMessage = "La contraseña nueva y confirmación no coinciden!")]
        public string ConfirmPassword { get; set; }
    }
}