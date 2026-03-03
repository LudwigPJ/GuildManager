using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.Controller
{
    [Serializable]
    public class SaveModel
    {
        public List<object> savemodel = new List<object>();
        public string Version = "1.0.0";
    }
}
