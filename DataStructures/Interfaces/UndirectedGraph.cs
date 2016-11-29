using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.HelperClasses;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// The public interface of undirected graphs. This includes methods
    /// that cannot be performed on directed graphs. The directed graph
    /// methods are all inherited through this interface's parent interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface UndirectedGraph<T> : DirectedGraph<T> where T: class 
    {
        bool isConnected();
        List<List<T>> getComponents();
        int getComponentCount();

        UndirectedGraph<T> kruskals();
    }
}
