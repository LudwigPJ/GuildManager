using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.Interfaces
{
    public interface IStorage 
    {
        public object Save();
        public void Load(object load);
        


    }
}
