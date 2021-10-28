using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeiaNoAr
{
  public class Thing : IDamage
  {
    public const int HEALTH_INI = 2000;
    
    public int Health { get; set; } = HEALTH_INI;
    public bool Destroyed { get; set; } = false;
  }
}
