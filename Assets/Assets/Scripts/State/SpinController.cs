using System.Threading.Tasks;
using DG.Tweening;
using Player.Data;
using Player.Enum;
using Player.Spin.Creator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Player.Spin.State
{
    public class SpinController : MonoBehaviour
    {
        [SerializeField] private RectTransform _spinObject;
        [SerializeField] private Button _spinButton;
        [SerializeField] private TextMeshProUGUI _spinBaseText;
        [SerializeField] private SpinCreator _spinCreator;
        private SpinType _spinType = SpinType.Purple;

        private void Play()
        {
            LockButtons(true);
            DataManager.Instance.IncreaseRound();
            EventManager.Execute(UIEvents.OnPlaySpin);

            // for (int i = 0; i < UPPER; i++)
            // {
            //     
            // }

            Tween spinTween = PlaySpin();

            spinTween.OnComplete(
                () => { ResultSpin(_spinObject.localEulerAngles.z); });
        }

        private Tween PlaySpin()
        {
            Sequence sequence = DOTween.Sequence();

            // SpinCreator içindeki WheelItem'ları al
            var wheelItems = _spinCreator.WheelItems;
            int totalItems = wheelItems.Count;
            int randomSpins = Random.Range(4, 6); // Rastgele spin sayısı

            int startIndex = Random.Range(0, totalItems);

            int fastSpins = randomSpins - 2; // Son 2 spin yavaşlayacak
            float initialDuration = 0.25f; // İlk tur için başlangıç süresi (yavaşça başlama)
            float finalDuration = 0.05f; // Sonraki turlar için sabit hız süresi
            float accelerationStep = 0.05f; // 1. tur boyunca hız artışı
            float slowDownStep = 0.1f; // Son tur boyunca yavaşlama artışı

            // 1. Tur: Yavaş başlayıp hızlanma
            float currentDuration = initialDuration;
            for (int i = 0; i < totalItems; i++)
            {
                // Şu anki öğeyi hesapla
                int currentIndex = (startIndex + i) % totalItems; // Döngüye uygun bir index elde et

                // Her öğeyi büyütme animasyonunu ekle
                sequence.Append(
                    wheelItems[currentIndex].transform
                        .DOScale(Vector3.one * DataManager.Instance.WheelData.AnimationScale, currentDuration)
                        .SetEase(Ease.InCubic) // Ease InCubic ile hızlanma efekti
                );

                // Geriye dönüş animasyonunu 3. öğeden sonra ekle
                if (i >= 3)
                {
                    int returnIndex = (startIndex + i - 3) % totalItems; // 3 öğe öncesini hesapla
                    sequence.Join(
                        wheelItems[returnIndex].transform.DOScale(Vector3.one, currentDuration)
                            .SetEase(Ease.OutCubic) // Ease OutCubic ile geri dönüş
                    );
                }

                // Süreyi azaltarak hızlanmayı sağla
                currentDuration = Mathf.Max(0.1f, currentDuration - accelerationStep);
            }

            // 2. Sabit Hız Turları
            currentDuration = finalDuration; // Sabit hız süresi
            for (int spin = 0; spin < fastSpins; spin++)
            {
                for (int i = 0; i < totalItems; i++)
                {
                    // Şu anki öğeyi hesapla
                    int currentIndex = (startIndex + i) % totalItems;

                    // Sabit hızda animasyonlar
                    sequence.Append(
                        wheelItems[currentIndex].transform
                            .DOScale(Vector3.one * DataManager.Instance.WheelData.AnimationScale, currentDuration)
                            .SetEase(Ease.Linear) // Linear ile sabit hızda dönüş
                    );

                    // Geriye dönüş animasyonunu 3. öğeden sonra ekle
                    if (i >= 3)
                    {
                        int returnIndex = (startIndex + i - 3) % totalItems; // 3 öğe öncesini hesapla
                        sequence.Join(
                            wheelItems[returnIndex].transform.DOScale(Vector3.one, currentDuration)
                                .SetEase(Ease.Linear) // Ease Linear ile geri dönüş
                        );
                    }
                }
            }

            // 3. Son Tur: Hızlıdan Yavaşlamaya
            currentDuration = finalDuration; // Hızlıdan başlamak için
            int targetIndex = Random.Range(0, totalItems); // Rastgele bir hedef seç

            for (int i = 0; i <= targetIndex; i++)
            {
                // Şu anki öğeyi hesapla
                int currentIndex = (startIndex + i) % totalItems;

                // Son tur boyunca hızdan yavaşlamaya geçiş
                sequence.Append(
                    wheelItems[currentIndex].transform
                        .DOScale(Vector3.one * DataManager.Instance.WheelData.AnimationScale, currentDuration)
                        .SetEase(Ease.OutCubic) // Yavaşça durmak için
                );

                // Geriye dönüş animasyonunu 3. öğeden sonra ekle
                if (i >= 3)
                {
                    int returnIndex = (startIndex + i - 3) % totalItems; // 3 öğe öncesini hesapla
                    sequence.Join(
                        wheelItems[returnIndex].transform.DOScale(Vector3.one, currentDuration)
                            .SetEase(Ease.OutCubic) // Ease OutCubic ile geri dönüş
                    );
                }

                // Yavaşlama için süreyi artır
                currentDuration += slowDownStep;
            }

            // Hedef öğeyi vurgulama
            var targetItem = wheelItems[targetIndex];
            sequence.Append(
                targetItem.transform
                    .DOScale(Vector3.one * DataManager.Instance.WheelData.AnimationScale, currentDuration)
                    .SetEase(Ease.OutQuad)
            );
            sequence.Append(
                targetItem.transform.DOScale(Vector3.one, currentDuration)
                    .SetEase(Ease.InQuad)
            );

            return sequence;
        }


        private void ResultSpin(float spinRotate)
        {
            // WheelSliceData wheelInfo = DataManager.Instance.WheelData.FindWheelSliceByAngle(spinRotate);

            // if (wheelInfo.CheckGrenadeItem())
            // {
            //     LockButtons(false);
            //     EventManager<PanelType>.Execute(UIEvents.OnOpenPanel, PanelType.FailedPanel);
            //     return;
            // }

            // DataManager.Instance.Inventory.AddReward(wheelInfo.Amount, wheelInfo.ItemImage,wheelInfo.SpinType);

            // Reward rewardItem = DataManager.Instance.Inventory.GetReward(wheelInfo.ItemImage.name);
            // EventManager<Reward>.Execute(UIEvents.OnEarnedReward, rewardItem);

            CheckSafeArea();
        }

        private void CheckSafeArea()
        {
            LockButtons(false);

            if (_spinType != SpinType.Purple)
            {
                _spinType = SpinType.Purple;
                SetBaseText(_spinType);
                return;
            }

            if (DataManager.Instance.CheckGoldenRoundData())
            {
                _spinType = SpinType.Green;
                SetBaseText(_spinType);
                // _spinState.ChangeState(_spinState.SpinGoldenState);
                return;
            }

            if (DataManager.Instance.CheckSilverRoundData())
            {
                _spinType = SpinType.Blue;
                SetBaseText(_spinType);
                // _spinState.ChangeState(_spinState.SpinSilverState);
            }
        }

        private void LockButtons(bool isLock)
        {
            EventManager<bool>.Execute(UIEvents.OnLockExitButton, !isLock);
            _spinButton.interactable = !isLock;
        }

        private void SetBaseText(SpinType spinType)
        {
            _spinBaseText.text = spinType + " Spin";
        }

        private void OnEnable()
        {
            _spinButton.onClick.AddListener(Play);
        }

        private void OnDisable()
        {
            _spinButton.onClick.RemoveListener(Play);
        }
    }
}