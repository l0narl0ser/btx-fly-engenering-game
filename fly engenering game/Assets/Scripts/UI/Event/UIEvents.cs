using System;

namespace Assets.Scripts.UI.Event
{
    public class UIEvents
    {
        public event Action OnStartButtonClickEvent;

        public void StartButtonClick()
        {
            OnStartButtonClickEvent?.Invoke();
        }
    }
}
