using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Model.GoldModel
{
    public class GoldModel
    {
        public GoldModel(int _goldCount) 
        {
            GoldCount = _goldCount;
        }

        public int GoldCount { get; set; }

        
    }
}
