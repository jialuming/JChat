using System.Windows;
using System.Windows.Interactivity;

namespace JStyleLib.Behaviors
{
    public class Behaviors
    {
        private static readonly DependencyProperty OriginalBehaviorProperty = DependencyProperty.RegisterAttached(@"OriginalBehaviorInternal", typeof(Behavior), typeof(Behaviors), new UIPropertyMetadata(null));

        public static BehaviorCollection GetBehaviorColection(DependencyObject obj)
        {
            return (BehaviorCollection)obj.GetValue(BehaviorColectionProperty);
        }

        public static void SetBehaviorColection(DependencyObject obj, BehaviorCollection value)
        {
            obj.SetValue(BehaviorColectionProperty, value);
        }

        // Using a DependencyProperty as the backing store for BehaviourColection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BehaviorColectionProperty =
            DependencyProperty.RegisterAttached(@"BehaviorColection", typeof(BehaviorCollection), typeof(Behaviors), new PropertyMetadata(null, OnBehaviorCollectionChanged));

        private static void OnBehaviorCollectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uie = d as UIElement;

            if (uie == null)
            {
                return;
            }

            System.Windows.Interactivity.BehaviorCollection itemBehaviors = Interaction.GetBehaviors(uie);

            var newBehaviors = e.NewValue as BehaviorCollection;
            var oldBehaviors = e.OldValue as BehaviorCollection;

            if (newBehaviors == oldBehaviors)
            {
                return;
            }

            if (oldBehaviors != null)
            {
                foreach (var behavior in oldBehaviors)
                {
                    int index = GetIndexOf(itemBehaviors, behavior);

                    if (index >= 0)
                    {
                        itemBehaviors.RemoveAt(index);
                    }
                }
            }

            if (newBehaviors != null)
            {
                foreach (var behavior in newBehaviors)
                {
                    int index = GetIndexOf(itemBehaviors, behavior);

                    if (index < 0)
                    {
                        var clone = (Behavior)behavior.Clone();
                        SetOriginalBehavior(clone, behavior);
                        itemBehaviors.Add(clone);
                    }
                }
            }
        }
        private static int GetIndexOf(System.Windows.Interactivity.BehaviorCollection itemBehaviors, Behavior behavior)
        {
            int index = -1;

            Behavior orignalBehavior = GetOriginalBehavior(behavior);

            for (int i = 0; i < itemBehaviors.Count; i++)
            {
                Behavior currentBehavior = itemBehaviors[i];

                if (currentBehavior == behavior
                    || currentBehavior == orignalBehavior)
                {
                    index = i;
                    break;
                }

                Behavior currentOrignalBehavior = GetOriginalBehavior(currentBehavior);

                if (currentOrignalBehavior == behavior
                    || currentOrignalBehavior == orignalBehavior)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
        private static Behavior GetOriginalBehavior(DependencyObject obj)
        {
            return obj.GetValue(OriginalBehaviorProperty) as Behavior;
        }
        private static void SetOriginalBehavior(DependencyObject obj, Behavior value)
        {
            obj.SetValue(OriginalBehaviorProperty, value);
        }
    }
}
