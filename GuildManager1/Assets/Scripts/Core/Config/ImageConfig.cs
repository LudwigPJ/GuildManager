using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



namespace Assets.Scripts.Core.Config
{
    [CreateAssetMenu(fileName = "ConfigImage", menuName = "config/ConfigImage")]
    


    public class ImageConfig : ScriptableObject
    {
        [SerializeField] private List<string> ImageIdList;
        [SerializeField] private List<Sprite> SpriteList;
       
        private Dictionary<string, Sprite> SpriteDictionary;
        
        
        public Sprite GetSpriteByID (string imageID)
        {
            if (SpriteDictionary == null)
            {
                SpriteDictionary = ImageIdList.Zip(SpriteList, (key, value) => new { Key = key, Value = value }).ToDictionary(x => x.Key, x => x.Value);

            }
            return SpriteDictionary[imageID];
        }
        
        
    }
}
