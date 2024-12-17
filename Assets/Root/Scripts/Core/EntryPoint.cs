using UnityEngine;
using GameEconomics;
using System.Collections.Generic;


namespace Core
{
    public sealed class EntryPoint : MonoBehaviour
    {

        [SerializeField] private List<LevelDataHandler> _levelsData;

        [Space, SerializeField]

        private List<StateThreshold> _stateThresholds;
        
        
        private GameMoney _money;


        private void Awake()
        {

            _money = new GameMoney(_stateThresholds);
        }


        private void OnEnable()
        {
            
            foreach(LevelDataHandler data in _levelsData)
            {

                _money.SetPickables(data.Good);

                _money.SetPickables(data.Bad);
            }
        }


        private void OnDisable()
        {

            foreach (LevelDataHandler data in _levelsData)
            {

                _money.UnsetPickables(data.Good);

                _money.UnsetPickables(data.Bad);
            }
        }

    }
}
