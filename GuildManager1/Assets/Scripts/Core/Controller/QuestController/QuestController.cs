using Assets.Scripts.Core.Model.QuestModel;
using Assets.Scripts.Core.View.QuestVIew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Controller.QuestController
{
    public class QuestController
    {
        private List<QuestConfig> QuestConfigs = new List<QuestConfig>();
        private List<QuestModel> QuestModels = new List<QuestModel>();


        public QuestController( List<QuestConfig> _QuestConfigs)
        {
            
            QuestConfigs = _QuestConfigs;
            


            foreach (QuestConfig QuestCon in QuestConfigs)
            {

                QuestModels.Add(QuestCon.GetQuestModel());

            }

            

            
        }

        public List<QuestModel> _QuestModels { get { return QuestModels; } }

    }
















    }










