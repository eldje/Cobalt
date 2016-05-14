using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Cobalt.Infrastructure.Collections
{
    /// <summary>
    ///     Represents a dynamic data collection that provides notifications when a property is
    ///     changed within the collection and provides information if the collection contents has been modified.
    /// </summary>
    /// <remarks>
    ///     Written by Clemens and Cerebrate of StackOverflow.
    ///     http://stackoverflow.com/questions/13936551/detecting-if-an-observablecollection-has-been-modified
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public class DirtyCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        public DirtyCollection()
        {
        }

        public DirtyCollection(List<T> collection) : base(collection)
        {
        }

        public bool IsDirty { get; private set; }

        public void Clean()
        {
            IsDirty = false;
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            IsDirty = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddPropertyChanged(e.NewItems);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    RemovePropertyChanged(e.OldItems);
                    break;

                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Reset:
                    RemovePropertyChanged(e.OldItems);
                    AddPropertyChanged(e.NewItems);
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            base.OnCollectionChanged(e);
        }

        private void AddPropertyChanged(IEnumerable items)
        {
            if (items == null) return;
            foreach (var obj in items.OfType<INotifyPropertyChanged>())
            {
                obj.PropertyChanged += OnItemPropertyChanged;
            }
        }

        private void RemovePropertyChanged(IEnumerable items)
        {
            if (items == null) return;
            foreach (var obj in items.OfType<INotifyPropertyChanged>())
            {
                obj.PropertyChanged -= OnItemPropertyChanged;
            }
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IsDirty = true;
        }
    }
}