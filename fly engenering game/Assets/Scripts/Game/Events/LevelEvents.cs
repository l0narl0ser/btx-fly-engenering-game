using Assets.Scripts.Game.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.Events
{

    public class LevelEvents { 
  
        public event Action<Dictionary<GearController, PortController>> OnChangeLevelState;

        public event Action OnLevelStated;

        public event Action OnLevelFinished;

        public void StartLevel()
        {
            OnLevelStated?.Invoke();
        }

        public void FinishLevel()
        {
            OnLevelFinished?.Invoke();
        }

        public void ChanLevelState(Dictionary<GearController, PortController> levelState)
        {
            OnChangeLevelState?.Invoke(levelState);
            
        }
    }
}
