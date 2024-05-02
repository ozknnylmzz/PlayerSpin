using System;
using Player.Data;
using Player.Enum;

namespace Player.Spin.Strategy
{
    public class SpinTypeStrategyFactory
    {
        public static ISpinTypeStrategy CreateStrategy(SpinType spinType, SpinBaseItemData spinBaseItemData,SpinItemData spinItemData)
        {
            switch (spinType)
            {
                case SpinType.Bronze:
                    return new BronzeSpinTypeStrategy(spinBaseItemData,spinItemData);
                case SpinType.Silver:
                    return new SilverSpinTypeStrategy(spinBaseItemData,spinItemData);
                case SpinType.Golden:
                    return new GoldenSpinTypeStrategy(spinBaseItemData,spinItemData);
                default:
                    throw new ArgumentOutOfRangeException(nameof(spinType),
                        $"Not expected spin type value: {spinType}");
            }
        }
    }
}