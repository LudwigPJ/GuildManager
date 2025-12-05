using Assets.Scripts.Core.Model.ItemsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core.View.ItemView
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] TMP_Text Demage;
        [SerializeField] TMP_Text Hp;
        [SerializeField] TMP_Text Speed;
        [SerializeField] Image Item;
        [SerializeField] TMP_Text Name;
        [SerializeField] Button SelectItem;
        [SerializeField] TMP_Text Price;
        [SerializeField] Image Galochka;

        

        public event Action OnSelectItem;


        private void Start()
        {
            SelectItem.onClick.AddListener(()=> OnSelectItem?.Invoke());
            SelectGalochka(false);
        }


        public void RefreshItem(ItemModel itemModel)
        {
            Item.sprite = itemModel.Item;
            Demage.text = itemModel.Demage.ToString();
            Hp.text = itemModel.Hp.ToString();
            Speed.text = itemModel.Speed.ToString();
            Name.text = itemModel.Name;
            if (Price != null)
            {
                Price.text = itemModel.Price.ToString();
            }

        }

        public void SelectGalochka(bool State)
        {
            if (Galochka != null)
            {
                Galochka.gameObject.SetActive(State);
            }
        }

        private void OnDestroy()
        {
            SelectItem.onClick.RemoveAllListeners();

            OnSelectItem=null;
        }



    }
}
