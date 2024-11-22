
using DG.Tweening;
using Player.Data;
using Player.Enum;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Spin
{
    public class WheelItem : MonoBehaviour
    {
        [SerializeField]  Image _wheelItemImage;
        [SerializeField]  Image _wheelItemBackground;
        
        [SerializeField]  Image _wheelGlow;
        [SerializeField]  TextMeshProUGUI _itemAmountText;
       
        
        private Vector3 _itemImageScale;
        
        public void SetWheelItemProp(Sprite wheelItemImage,Sprite backgroundImage,Sprite wheelGlow,int amount)
        {
            _wheelItemImage.sprite=wheelItemImage;
            _itemAmountText.text = "x" +amount;
            _wheelItemBackground.sprite=backgroundImage;
            _wheelGlow.sprite=wheelGlow;
        }

        public Sequence PlayAnimation()
        {
            // Öncelikle ışıltıyı (glow) aktif hale getir
            _wheelGlow.transform.gameObject.SetActive(true);
    
            // Başlangıç ölçeklerini kaydet
            Vector3 originalScaleImage = _wheelItemImage.transform.localScale;
            Vector3 originalScaleBackground = _wheelItemBackground.transform.localScale;
            Vector3 originalScaleGlow = _wheelGlow.transform.localScale;

            // Tween sıralaması oluştur
            Sequence sequence = DOTween.Sequence();
    
            // İlk animasyon: öğeleri büyütme
            sequence.Append(_wheelItemImage.transform.DOScale(
                Vector3.one * DataManager.Instance.WheelData.AnimationScale,
                DataManager.Instance.WheelData.AnimationTime));
            sequence.Join(_wheelItemBackground.transform.DOScale(
                Vector3.one * DataManager.Instance.WheelData.AnimationScale,
                DataManager.Instance.WheelData.AnimationTime));
            sequence.Join(_wheelGlow.transform.DOScale(
                Vector3.one * DataManager.Instance.WheelData.AnimationScale,
                DataManager.Instance.WheelData.AnimationTime));
    
            // İkinci animasyon: öğeleri eski hallerine geri döndürme
            sequence.Append(_wheelItemImage.transform.DOScale(
                originalScaleImage,
                DataManager.Instance.WheelData.AnimationTime));
            sequence.Join(_wheelItemBackground.transform.DOScale(
                originalScaleBackground,
                DataManager.Instance.WheelData.AnimationTime));
            sequence.Join(_wheelGlow.transform.DOScale(
                originalScaleGlow,
                DataManager.Instance.WheelData.AnimationTime));
    
            // İkinci animasyon tamamlandığında ışıltıyı (glow) kapat
            sequence.OnComplete(() => _wheelGlow.transform.gameObject.SetActive(false));
            
            return sequence;
        }
    }
}

