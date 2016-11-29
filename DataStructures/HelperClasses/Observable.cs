using System;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.Basic;
using DataStructures.Exceptions;

namespace DataStructures.HelperClasses
{
    /// <summary>
    /// Observable class that represents an object that can be observed. This class
    /// follows the observer/observable pattern and is meant to decouple updates 
    /// between the model and the view of applications.
    /// </summary>
    public class Observable
    {
        private bool my_changed;
        private List<Observer> my_observers;

        /// <summary>
        /// Sets up the observable object with default settings.
        /// </summary>
        public Observable()
        {
            changed = false;
            my_observers = new ArrayList<Observer>();
        }

        /// <summary>
        /// Adds an observer to the observable to watch for updates.
        /// </summary>
        /// <param name="the_observer"></param>
        public void addObserver(Observer the_observer)
        {
            Preconditions.checkNull(the_observer);

            my_observers.add(the_observer);
        }

        /// <summary>
        /// This method is used to notify observers of changes to the
        /// observable object (if any have occurred). This will not call
        /// update on observers until the changed flag has been set.
        /// </summary>
        /// <param name="the_arguments">the information to pass to watching
        /// observers.</param>
        public void notifyUpdate(object[] the_arguments)
        {
            if (changed)
            {
                changed = false;

                for (int i = 0; i < my_observers.size(); i++)
                {
                    my_observers.get(i).update(the_arguments);
                }
            }
        }

        /// <summary>
        /// Flag for marking a change in the observable.
        /// </summary>
        public bool changed
        {
            get { return my_changed; }
            set { my_changed = value; }
        }

        /// <summary>
        /// Provide a string representation of the observable.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Changed: ");
            builder.Append(changed);
            builder.Append(", ");
            Helpers.printElementIfNull(builder, "Observers", observers);

            return builder.ToString();
        }

        /// <summary>
        /// A list of observers that are watching the observable.
        /// </summary>
        public List<Observer> observers
        {
            get { return my_observers; }
            set { my_observers = value; }
        }
    }
}
