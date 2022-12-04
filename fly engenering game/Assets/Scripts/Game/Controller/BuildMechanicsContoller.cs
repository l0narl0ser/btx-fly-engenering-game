using Assets.Scripts.Core;
using Assets.Scripts.Game.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class BuildMechanicsContoller : MonoBehaviour 
    {
        private MessageSystem _messageSystem;
        private BuildStateMechanics _currentState;
        private GearController _currentGearController;

        private Dictionary<GearController, PortController> _accordancePortToGear = new Dictionary<GearController, PortController>();


        private void Awake()
        {
            _messageSystem = Context.Inctance.GetMessageSystem();
            _messageSystem.LevelEvents.OnLevelStated += OnLevelStarted;
            _messageSystem.InputEvents.OnUserInput += OnUserInput; //падписка


        }

        private void OnLevelStarted()
        {
            _accordancePortToGear.Clear();
        }

        private void OnDestroy()
        {
            _messageSystem.InputEvents.OnUserInput -= OnUserInput; //атписка
            _messageSystem.LevelEvents.OnLevelStated -= OnLevelStarted;
        }

        private void OnUserInput(Vector2 vector2)
        {

            Vector3 postionRaycecast = Camera.main.ScreenToWorldPoint(vector2);
            RaycastHit2D hit = Physics2D.Raycast(postionRaycecast, Vector2.zero);
            if (hit.collider != null)
            {
                SelectObjectBehaviour(hit.collider.gameObject);
            }
        }

        private void SelectObjectBehaviour(GameObject gameObject)
        {
            PortController selectedPortController = gameObject.GetComponent<PortController>();
            GearController selectedGearController = gameObject.GetComponent<GearController>();
            BuildStateMechanics newState = BuildStateMechanics.NONE;

            if(selectedPortController != null)
            {
                newState = BuildStateMechanics.SELECT_PORT;
            }
            else
            {
                newState = BuildStateMechanics.SELECT_GEAR;
                _currentGearController = selectedGearController;
            }

            if (newState == BuildStateMechanics.SELECT_GEAR && selectedGearController.Inserted)
            {
                selectedGearController.ReturnToInitPostion();
                PortController removingPort = _accordancePortToGear[selectedGearController];
                removingPort.Occupied = false;
                _accordancePortToGear.Remove(selectedGearController);
                _currentState = BuildStateMechanics.NONE;
                _messageSystem.LevelEvents.ChanLevelState(_accordancePortToGear);
                return;
            }

            if(_currentState == BuildStateMechanics.SELECT_GEAR && newState == BuildStateMechanics.SELECT_PORT)
            {
                //TODO:Перенести шестеренку на порт
                _currentState = BuildStateMechanics.NONE;
                _currentGearController.gameObject.transform.position = selectedPortController.transform.position;
                _currentGearController.Inserted = true;
                selectedPortController.Occupied = true;
                _accordancePortToGear.Add(_currentGearController, selectedPortController);
                _messageSystem.LevelEvents.ChanLevelState(_accordancePortToGear);
                return;
            }

            if(_currentState == BuildStateMechanics.NONE && newState == BuildStateMechanics.SELECT_GEAR)
            {
                _currentState = newState;
                //TODO:: СДелать выбранную шестренку больше или изменить цвет цветом
                return;
            }

            //вернуть шестеренку назад

        }
    }
}