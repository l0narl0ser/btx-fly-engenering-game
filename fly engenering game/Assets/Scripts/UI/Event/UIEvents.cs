using System;

namespace Assets.Scripts.UI.Event
{
    public class UIEvents
    {
        public event Action OnStartButtonClickEvent;

        public event Action OnContinueButtonClickEvent;

        public event Action OnPauseButtonClickEvent;


        public void StartButtonClick()
        {
            OnStartButtonClickEvent?.Invoke();
        }

        public void ContinueButtonClickEvent()
        {
            //if(OnContinueButtonClickEvent == null)
            //{
            // OnContinueButtonClickEvent.Invoke();
            //}
            OnContinueButtonClickEvent?.Invoke();
        }

        public void PauseButtonClickEvent()
        {
            OnPauseButtonClickEvent?.Invoke();
        }
    }
}
