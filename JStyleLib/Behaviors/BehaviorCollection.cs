using System.Windows;
using System.Windows.Interactivity;

namespace JStyleLib.Behaviors
{
    public class BehaviorCollection : FreezableCollection<Behavior>
    {
        protected override Freezable CreateInstanceCore()
        {
            return new BehaviorCollection();
        }
    }
}
