using GameEconomics;
using System;
using System.Collections.Generic;

namespace Core
{
    public sealed class GameMoney
    {

        public int CurrentMoney { get => _money; }

        public MoneyState CurrentState { get => _state; }


        public event Action<int> MoneyChanged;

        public event Action<MoneyState> StateChanged;


        public event Action GameOver;


        private MoneyState _state;
        
        private int _money;


        private readonly List<StateThreshold> _thresholds;


        public GameMoney(IReadOnlyCollection<StateThreshold> thresholds)
        {

            _thresholds = new List<StateThreshold>(thresholds);
        }



        #region Set/Unset Pickables

        public void SetPickables(IReadOnlyCollection<
            
            IPickable> pickables)
        {

            foreach(IPickable pickable in pickables)
            {

                pickable.PickedUp += OnMoneyPickedUp;
            }
        }


        public void UnsetPickables(IReadOnlyCollection<
            
            IPickable> pickables)
        {

            foreach (IPickable pickable in pickables)
            {

                pickable.PickedUp -= OnMoneyPickedUp;
            }
        }

        #endregion


        private void OnMoneyPickedUp(int cost)
        {

            _money += cost;

            MoneyChanged?.Invoke(_money);


            if(_money <= 0)
            {

                GameOver?.Invoke();
            }


            MoneyState state = GetState();

            if(state != _state)
            {

                _state = state;

                StateChanged?.Invoke(_state);
            }
        }


        private MoneyState GetState()
        {

            int index = _thresholds.FindIndex(IsBigger);


            if(index == -1)
            {

                return MoneyState.Millionare;   
            }
            else if(index == 0)
            {

                return MoneyState.Hobo;
            }
            else
            {

                return (MoneyState)(index - 1);
            }
        }


        private bool IsBigger(StateThreshold node)
        {

            return node.Threshold > _money;
        }
    }
}
