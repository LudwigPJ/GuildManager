using Assets.Scripts.Core.Model.GoldModel;
using Assets.Scripts.Core.Storages;
using Assets.Scripts.Core.View.ResourseView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.Controller.ResoursController
{
    public class GoldController
    {
        private GoldCountView _GoldcountView;
        private GoldStorage GoldStorage;
       


        public GoldController(GoldCountView goldCountView, GoldStorage _goldStorage)
        {
            
            _GoldcountView = goldCountView;
            GoldStorage = _goldStorage;
            

            _GoldcountView.GoldCounterRefresh(GoldStorage.Goldmodel);
        }
       
        public void GoldPlus(int count)
        {

            GoldStorage.Goldmodel.GoldCount += count;
            _GoldcountView.GoldCounterRefresh(GoldStorage.Goldmodel);
            
        }

        public bool GoldMinus(int count)
        {
            if (GoldStorage.Goldmodel.GoldCount >= count)
            {
                GoldStorage.Goldmodel.GoldCount -= count;
                _GoldcountView.GoldCounterRefresh(GoldStorage.Goldmodel);
                return true;
            }
            
            return false;

        }

        public int GetGoldCount()
        {
            return GoldStorage.Goldmodel.GoldCount;
        }
    }
}
