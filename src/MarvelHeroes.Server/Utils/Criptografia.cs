using System;
using System.Text;

namespace MarvelHeroes.Server.Utils
{
    public static class Criptografia
    {
        public static string ToBase64(this string valor)
        {
            var bytes = Encoding.UTF8.GetBytes(valor);
            return Convert.ToBase64String(bytes);
        }
    }
}
