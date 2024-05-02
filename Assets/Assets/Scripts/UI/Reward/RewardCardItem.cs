using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player.UI.Reward
{
    public class RewardCardItem : MonoBehaviour
    {
        [SerializeField] private Image _cardIcon;
        [SerializeField] private TextMeshProUGUI _amount;
        
        
        public void SetCardProp(Sprite cardIcon,string amount)
        {
            _cardIcon.sprite = cardIcon;
            _amount.text =  amount;
        }

    }
}

