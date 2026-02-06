using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.Model
{
    [Serializable]
    public class TavernModel
    {
        private QuestModel _QuestModelSystem;

        public QuestModel QuestModelSystem { get { return _QuestModelSystem; }set { _QuestModelSystem = value; } }
    }
}
