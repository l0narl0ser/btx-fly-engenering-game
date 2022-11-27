using Assets.Scripts.Core;
using Assets.Scripts.Game.Controller;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class BuildMechanicsContoller : MonoBehaviour
    {
        private MessageSystem _messageSystem;
        private BuildStateMechanics _currentState;

        private GearController _currentGearController;

        private void Awake()
        {
            _messageSystem = Context.Inctance.GetMessageSystem();
            _messageSystem.InputEvents.OnUserInput += OnUserInput; //падписка

        }
        private void OnDestroy()
        {
            _messageSystem.InputEvents.OnUserInput -= OnUserInput; //атписка
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
            }

            if(_currentState == BuildStateMechanics.SELECT_GEAR && newState == BuildStateMechanics.SELECT_PORT)
            {
                //TODO:Перенести шестеренку на порт
                _currentState = BuildStateMechanics.NONE;
                _currentGearController.gameObject.transform.position = selectedPortController.transform.position;
                return;
            }

            if(_currentState == BuildStateMechanics.NONE && newState == BuildStateMechanics.SELECT_GEAR)
            {
                _currentState = newState;
                _currentGearController = selectedGearController;
                //TODO:: СДелать выбранную шестренку больше или изменить цвет цветом
                return;
            }

            if (_currentState == BuildStateMechanics.NONE && newState == BuildStateMechanics.SELECT_PORT)
            {
                _currentState = newState;
                //TODO:: Cделать вибрацию или увелечение чего-то
                return;
            }
            //вернуть шестеренку назад
        }
    }
}