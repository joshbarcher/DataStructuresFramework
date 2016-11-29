using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Simple interface for the observer/observable pattern. This interface, along
    /// with the Observable class are meant to decouple updates between the model
    /// and the view of applications.
    /// </summary>
    public interface Observer
    {
        void update(object[] the_arguments);
    }
}
