using Assets.Scripts.Core.Controller.ResoursController;
using Assets.Scripts.Core.Model.GoldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core.View.ResourseView
{
    public class GoldCountView : MonoBehaviour
    {
        
        [SerializeField] TMP_Text GoldCount;


        public void GoldCounterRefresh(GoldModel goldmodel1)
        {
            GoldCount.text = goldmodel1.GoldCount.ToString();
            
        }
    }


    


}
