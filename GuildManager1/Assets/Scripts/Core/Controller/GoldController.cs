using Assets.Scripts.Core.Model.GoldModel;
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
        private GoldModel _Goldmodel;
       


        public GoldController(GoldCountView goldCountView)
        {
            
            _GoldcountView = goldCountView;

            _Goldmodel = new GoldModel(0);

            _GoldcountView.GoldCounterRefresh(_Goldmodel);
        }
       
        public void GoldPlus(int count)
        {

            _Goldmodel.GoldCount += count;
            _GoldcountView.GoldCounterRefresh(_Goldmodel);
        }

        public bool GoldMinus(int count)
        {
            if (_Goldmodel.GoldCount >= count)
            {
                _Goldmodel.GoldCount -= count;
                _GoldcountView.GoldCounterRefresh(_Goldmodel);
                return true;
            }
            return false;
        }

        public int GetGoldCount()
        {
            return _Goldmodel.GoldCount;
        }
    }
}
