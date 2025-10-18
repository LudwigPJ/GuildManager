using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;

public class ControllerHero
{
    private HeroView HeroView;
    private List<HeroConfig> HeroConfigs =new List<HeroConfig>(); 
    private CasarmView _CasarmView;
    private List<HeroModel> _HeroModels = new List<HeroModel>();
    private List<HeroView> _HeroViews = new List<HeroView>();


    public ControllerHero(HeroView _heroView, List<HeroConfig> _heroConfigs,CasarmView _casarmView)
    {
        HeroView = _heroView;
        HeroConfigs = _heroConfigs;
        _CasarmView = _casarmView;
        

        foreach(HeroConfig _heroCon in HeroConfigs)
        {
            
            _HeroModels.Add(_heroCon.GetHeroModel());
            
        }

        foreach(HeroModel _heroMod in _HeroModels)
        {
            _HeroViews.Add(GameObject.Instantiate(HeroView, _CasarmView._heroObjectRoot.transform));
        }

        for(int i=0; i<_HeroModels.Count; i++)
        {
            _HeroViews[i].RefreshHero(_HeroModels[i]);
        }
    }

    public List<HeroModel> HeroModels { get { return _HeroModels; } }



}
