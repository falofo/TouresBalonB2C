using Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Bussines
{
    public class AccountService : ServiceUtil
    {

        public static Usuario loginUser(Login userLogin)
        {
            try
            {
                ServiceResponse srLogin = consumirServicio("POST", Constants.URL_CLIENTES + "clientes/login", userLogin);
                if (srLogin.code.Equals(HttpStatusCode.OK))
                {
                    JObject jUser = JObject.Parse(srLogin.content);
                    Usuario user;
                    user = jUser.ToObject<Usuario>();

                    return user;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
        }

        public static Boolean registerUser(Registro model)
        {

            if (model.Nombre == null || model.Nombre.Trim().Equals(""))
            {
                throw new Exception("Ingrese un nombre correcto");
            }
            if (model.Apellido == null || model.Apellido.Trim().Equals(""))
            {
                throw new Exception("Ingrese un Apellido correcto");
            }
            if (model.Email == null || model.Email.Trim().Equals(""))
            {
                throw new Exception("Ingrese un Email correcto");
            }
            if (model.Password == null || model.Password.Trim().Equals(""))
            {
                throw new Exception("Ingrese un Password correcto");
            }

            Usuario user = new Usuario();
            user.fname = model.Nombre;
            user.lname = model.Apellido;
            user.email = model.Email;
            user.phonenumber = model.Telefono;
            user.password = model.Password;
            user.creditcardnumber = model.CreditCardNumber.ToString();
            user.creditcardtype = model.CreditCardType;
            user.status = "Plateado";
            ServiceResponse srRegister = consumirServicio("POST", Constants.URL_CLIENTES + "clientes/crear", user);
            if (srRegister.code.Equals(HttpStatusCode.OK))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static Boolean updateUser(Usuario user, Update model)
        {
            try
            {
                user.fname = model.Nombre;
                user.lname = model.Apellido;
                user.email = model.Email;
                user.phonenumber = model.Telefono;
                user.creditcardnumber = model.CreditCardNumber.ToString();
                user.creditcardtype = model.CreditCardType;

                ServiceResponse srUpdate = consumirServicio("POST", Constants.URL_CLIENTES+"clientes/modificar", user);
                if (srUpdate.code.Equals(HttpStatusCode.OK))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
