using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Data
{
    public class DataManager : PersistenceSingleton<DataManager>
    { 
        public Inventory Inventory;
        public WheelData WheelData;
        public int CurrentRound;
        
        public void IncreaseRound()
        {
            CurrentRound++;
        }

        public void ResetData()
        {
            CurrentRound = 1;
        }

        public bool  CheckSilverRoundData()
        {
            if (CurrentRound%Constants.SilverRound==0)
            {
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

    }
}