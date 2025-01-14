
using System;
using UnityEngine;

namespace Player.Data
{
    public class DataManager : PersistenceSingleton<DataManager>
    { 
        public Inventory Inventory;
        public WheelData WheelData;
        public int CurrentRound;

        private void Start()
        {
            SetCoin(Constants.StartCoin);
        }

        public void IncreaseRound()
        {
            CurrentRound++;
        }

        public void ResetData()
        {
            CurrentRound = 1;
            Inventory.ResetItems();
        }

        public bool  CheckSilverRoundData()
        {
            if (CurrentRound%Constants.SilverRound==0)
            {
                Debug.Log("CurrentRound");
                return   true;
            }

            return false;
        }
        public bool  CheckGoldenRoundData()
        {
            if (CurrentRound%Constants.GoldenRound==0)
            {
                return   true;
            }

            return false;
        }

        public void SetCoin(int amount)
        {
            DataSaver.SetData(Constants.Coin,amount);
        }

        public void IncreaseCoin(int amount)
        {
          int value= GetCoin()-amount;
          SetCoin(value);
        }
        public void DecreaseCoin(int amount)
        {
            int value= GetCoin()-amount;
            SetCoin(value);
        }

        public int GetCoin()
        {
            return DataSaver.GetData(Constants.Coin,Constants.StartCoin);
        }
        
        public void SetMoney(int amount)
        {
            DataSaver.SetData(Constants.Money,amount);
        }
        
        public int GetMoney()
        {
            return DataSaver.GetData(Constants.Money,Constants.StartMoney);
        }

        private void OnApplicationQuit()
        {
            Inventory.ResetItems();
        }
    }
}