using System;
using Player.Data;
using Player.Enum;

namespace Player.Spin.Strategy
{
    public class SpinTypeStrategyFactory
    {
        public static ISpinTypeStrategy CreateStrategy(SpinType spinType, SpinCreatorData spinCreatorData,InventoryData inventoryData)
        {
            switch (spinType)
            {
                case SpinType.Bronze:
                    return new BronzeSpinTypeStrategy(spinCreatorData,inventoryData);
                case SpinType.Silver:
                    return new SilverSpinTypeStrategy(spinCreatorData,inventoryData);
                case SpinType.Golden:
                    return new GoldenSpinTypeStrategy(spinCreatorData,inventoryData);
                default:
                    throw new ArgumentOutOfRangeException(nameof(spinType),
                        $"Not expected spin type value: {spinType}");
            }
        }
    }
}