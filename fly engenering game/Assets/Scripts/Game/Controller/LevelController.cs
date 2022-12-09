using Assets.Scripts.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.Controller
{

    public class LevelController : MonoBehaviour
    {
        [SerializeField]
        private List<PortToGearAccordance> _portToGearAccordances = new List<PortToGearAccordance>();

        [SerializeField]
        private List<Data.BalanceData> _levelBalance;

        [Serializable]
        private class PortToGearAccordance
        {
            [SerializeField]
            public PortController PortController;
            [SerializeField]
            public GearController GearController;
        }

        private MessageSystem _messageSystem;

        private void Awake()
        {
            _messageSystem = Context.Inctance.GetMessageSystem();
            _messageSystem.LevelEvents.OnChangeLevelState += OnChangeLevelState;
        }

        private void OnDestroy()
        {
            _messageSystem.LevelEvents.OnChangeLevelState -= OnChangeLevelState;
        }

        private void OnChangeLevelState(Dictionary<GearController, PortController> portToGearAccordance)
        {
            if (portToGearAccordance.Count != _portToGearAccordances.Count)
            {
                return;
            }
            foreach (PortToGearAccordance item in _portToGearAccordances)
            {
                PortController selectePortController = portToGearAccordance[item.GearController];

                if (selectePortController != item.PortController)
                {
                    return;
                }
            }


            Debug.Log("You are wone");
            _messageSystem.LevelEvents.FinishLevel(_levelBalance);
            Destroy(gameObject);
        }
    }
}