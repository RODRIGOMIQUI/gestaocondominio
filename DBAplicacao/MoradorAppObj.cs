using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBRepositorioEF;

namespace DBAplicacao
{
    public class MoradorAppObj
    {
        public static MoradorApp MoradorAppEF()
        {
            return new MoradorApp(new MoradorEF());
        }
    }
}
