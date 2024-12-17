using System;

namespace GameEconomics
{
    public interface IPickable
    {

        public event Action<int> PickedUp;
    }
}
