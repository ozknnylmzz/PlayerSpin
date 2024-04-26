using System;
using Player.Enum;

namespace Player.Spin.Strategy
{
    public class SpinTypeStrategyFactory
    {
        public static ISpinTypeStrategy CreateStrategy(SpinType spinType, SpinCreatorData data)
        {
            switch (spinType)
            {
                case SpinType.Bronze:
                    return new BronzeSpinTypeStrategy(data);
                case SpinType.Silver:
                    return new SilverSpinTypeStrategy(data);
                case SpinType.Golden:
                    return new GoldenSpinTypeStrategy(data);
                default:
                    throw new ArgumentOutOfRangeException(nameof(spinType),
                        $"Not expected spin type value: {spinType}");
            }
        }
    }
}