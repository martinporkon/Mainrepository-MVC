using System;
using System.Threading.Tasks;

namespace Nupp.Views.Home
{
    public class ViewState
    {
        public string SelectedColor { get; private set; }

        public event Func<Task> Notify;

        public event Action OnChange;
        
        public void SetColor(string color)
        {
            SelectedColor = color;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}