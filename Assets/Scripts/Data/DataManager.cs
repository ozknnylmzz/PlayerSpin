using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Data
{
    public class DataManager : PersistenceSingleton<DataManager>
    {
        private InventoryData _inventoryData;
        
        public const int BronzeRound = 5;
        public const int GoldenRound = 30;

        public int CurrentRound;
        
        public void IncreaseRound()
        {
            CurrentRound++;
        }

        public void ResetData()
        {
            CurrentRound = 1;
        }

        public bool  CheckBronzeRoundData()
        {
            if (CurrentRound==BronzeRound)
            {
                return   true;
            }

            return false;
        }
        public bool  CheckGoldenRoundData()
        {
            if (CurrentRound==GoldenRound)
            {
                return   true;
            }

            return false;
        }

    }
}