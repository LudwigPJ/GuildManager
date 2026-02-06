using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.Model
{
    [Serializable]
    public class TreningPlaceModel
    {
        public HeroModel _SelectedHeroInTreningPlace;
        public string DateStartTime = string.Empty;
        public string Duration = string.Empty;


        public HeroModel SelectedHeroInTreningPlace {  get{ return _SelectedHeroInTreningPlace; } set { _SelectedHeroInTreningPlace = value; } }
    }
}
