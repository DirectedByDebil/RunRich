using System;
using UnityEngine;

namespace GameEconomics
{

    [Serializable]
    public struct StateThreshold
    {

        public MoneyState State;


        [Range (-10, 100)]
        public int Threshold;
    }
}
