using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializeableLinkedList<T> : LinkedList<T>, ISerializationCallbackReceiver
{
    
    public List<T> _list = new List<T>();

    //public List<int> _keys = new List<int> { 3, 4, 5 };
    //public List<string> _values = new List<string> { "I", "Love", "Unity" };

    //Unity doesn't know how to serialize a Dictionary
    //public Dictionary<int, string> _myDictionary = new Dictionary<int, string>();

    public void OnBeforeSerialize()
    {
        _list.Clear();

        foreach (T Elem in this)
        {
            _list.Add(Elem);

        }
    }

    public void OnAfterDeserialize()
    {
        //_myDictionary = new Dictionary<int, string>();
        
        Clear();

        for (int i = 0; i < _list.Count; i++)
            AddLast(_list[i]);
    }

    void OnGUI()
    {
        foreach (T Elem in this)
            GUILayout.Label($"Elem: " + Elem );
    }
}
