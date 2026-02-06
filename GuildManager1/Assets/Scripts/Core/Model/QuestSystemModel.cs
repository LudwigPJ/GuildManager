using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assets.Scripts.Core.Model
{
    [Serializable]
    public class QuestSystemModel
    {
        public List<QuestModel> QuestModels = new List<QuestModel>();


        public List<QuestModel> QuestModels1 { get { return QuestModels; } }
    }
}
