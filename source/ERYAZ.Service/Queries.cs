using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERYAZ.Service
{
    internal static class Queries
    {
        public static string INSERT_FILM = "INSERT INTO public.film(title, year, rate) VALUES (@Title, @Year, @Rate)";
    }
}
