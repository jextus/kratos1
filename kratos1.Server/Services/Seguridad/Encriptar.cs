﻿using System.Security.Cryptography;
using System.Text;

namespace krat1.Server.Services.Seguridad;
public class Encriptar
{
        public static string EncriptarClave(string password)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(password));

                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
}