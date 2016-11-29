using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Represents a more limited interface than the internal Edge class.
    /// </summary>
    /// <typeparam name="T">the reference type of vertex labels in the edge.</typeparam>
    public interface SimpleEdge<T> where T : class
    {
        T first_label {get; }
        T second_label {get; }
        double edge_cost {get; }
    }
}
