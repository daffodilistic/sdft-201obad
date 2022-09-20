using PhishyBank.Models;

namespace PhishyBank.Server.State
{
    public class StateContainer
    {
        private User? user = null;

        public void SetUser(User loggedInUser)
        {
            user = loggedInUser;
            NotifyStateChanged();
        }

        public User? GetUser()
        {
            return user;
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }

}