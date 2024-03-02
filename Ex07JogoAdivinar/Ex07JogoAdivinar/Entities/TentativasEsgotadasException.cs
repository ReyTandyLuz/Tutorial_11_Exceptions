using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07JogoAdivinar.Entities
{
    public class TentativasEsgotadasException(string mensaje) : Exception(mensaje)
    {
    }
}
