using System;
using System.Collections.Generic;
using Assets.Scripts.Game.Controller;
using Assets.Scripts.Game.Data;

namespace Assets.Scripts.Game.Events
{
    public class LevelEvents
    {
        public event Action<Dictionary<GearController, PortController>> OnChangeLevelState;

        public event Action OnLevelStated;

        public event Action OnLastLevelReached;

        public event Action<List<BalanceData>> OnLevelFinished;

        public void StartLevel()
        {
            OnLevelStated?.Invoke();
        }

        public void FinishLevel(List<BalanceData> balanceDatas)
        {
            OnLevelFinished?.Invoke(balanceDatas);
        }

        public void ChanLevelState(Dictionary<GearController, PortController> levelState)
        {
            OnChangeLevelState?.Invoke(levelState);
        }

        public void LastLevelReached()
        {
            OnLastLevelReached?.Invoke();
        }
    }
}