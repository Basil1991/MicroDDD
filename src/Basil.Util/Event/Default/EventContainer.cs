using Basil.Util.Event.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Event.Default {
    //internal static class EventHandlerContainer<T> {
    internal static class EventHandlerContainer {
        //private static List<T> list = new List<T>();

        //internal static List<T> GetAll(string name = null) {
        //    return list;
        //}

        //internal static void Add(T t) {
        //    list.Add(t);
        //}
        private static Dictionary<Type, object> list = new Dictionary<Type, object>();

        internal static Dictionary<Type, object> GetAll(string name = null) {
            return list;
        }

        internal static void Add(Type key, object obj) {
            list.Add(key, obj);
        }
    }
}
