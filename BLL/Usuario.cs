﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Usuario
    {


        public string Email { get; set; }

        public string NombreCompleto { get; set; }

        public string Password { get; set; }

        public DateTime FechaRegistro { get; set; }

        public char Estado { get; set; }

        public bool Confirmar(string pPass)
        {
            bool correcto = false;

            if (this.Password.Equals(pPass))
            {
                correcto = true;
            }
            return correcto;
        }



    }


}
