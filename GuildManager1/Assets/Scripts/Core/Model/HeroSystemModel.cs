using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.Model
{
    [Serializable]
    public class HeroSystemModel
    {
        public List<HeroModel> _HeroModels = new List<HeroModel>();
        public List<HeroModel> _HeroByeModels = new List<HeroModel>();
        public HeroModel SelectHero;


        public List<HeroModel> HeroModelsSystem { get { return _HeroModels; } }
        public List<HeroModel> HeroByeModelsSystem { get { return _HeroByeModels; } }

        public HeroModel SelectHeroSystem { get { return SelectHero; } set { SelectHero = value; } }

    }
}
