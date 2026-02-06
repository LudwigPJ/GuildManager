using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Model.GoldModel
{
    [Serializable] 
    public class GoldModel
    {   
        public GoldModel(int _goldCount) 
        {
            GoldCount = _goldCount;
        }

        public int GoldCount;

        
    }
}
