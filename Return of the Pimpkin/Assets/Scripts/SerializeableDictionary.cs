//using System.Collections;
//using System.Collections.Generic;
//using System;
//using UnityEngine;

//public class SerializeableDictionary<key, value>
//{
//    List<LinkedList<KeyValuePair<key, value>>> table = new List<LinkedList<KeyValuePair<key, value>>>();

//    //don't change!  Important for performance!
//    static readonly int[] Capacities = new int[] { 53, 97, 193, 389, 769, 1543, 3079, 6151, 12289, 24593, 49157, 98317, 196613, 393241, 786433, 1572869, 3145739, 6291469, 12582917, 25165843, 50331653, 100663319, 201326611, 402653189, 805306457, 1610612741 };
//    int currentCapacityIndex = 0;

//    int count = 0;

//    public bool TryAdd(key key, value value)
//    {
//        count++;

//        if (Capacities[currentCapacityIndex] < count)
//            expandTable();

//        KeyValuePair<key, value> kvp = new KeyValuePair<key, value>(key, value);
//        return TryInsert(table, kvp);
//    }

//    bool TryInsert(List<LinkedList<KeyValuePair<key, value>>> table, KeyValuePair<key, value> kvp)
//    {
//        int index = kvp.Key.GetHashCode() % Capacities[currentCapacityIndex];
//        if (table[index] == null)
//        {
//            table[index] = new LinkedList<KeyValuePair<key, value>>();
//            table[index].AddFirst(kvp);
//        }
//        else
//        {
//            LinkedListNode<KeyValuePair<key, value>> lln = table[index].First;
//            while (lln!=null)
//            {
//                if (lln.Value.Key.Equals(kvp.Key))
//                {
//                    return false;
//                }
//                lln = lln.Next;
//            }
//            table[index].AddLast(kvp);
//        }
//        return true;
//    }

//    public value this[key key]
//    {
//        get
//        {
//            int index = key.GetHashCode() % Capacities[currentCapacityIndex];
//            LinkedListNode<KeyValuePair<key, value>> lln = table[index].First;
//            while (lln != null)
//            {
//                if (lln.Value.Key.Equals(key))
//                {
//                    return lln.Value.Value;
//                }
//                lln = lln.Next;
//            }
//            Debug.LogError(key + " not found in " + this);
//            return default;
//        }
//        set
//        {
//            int index = key.GetHashCode() % Capacities[currentCapacityIndex];
//            LinkedListNode<KeyValuePair<key, value>> lln = table[index].First;
//            while (lln != null)
//            {
//                if (lln.Value.Key.Equals(key))
//                {
//                    lln.Value= new KeyValuePair<key, value>(lln.Value.Key, value);
//                    return;
//                }
//                lln = lln.Next;
//            }
//            Debug.LogError(key + " not found in " + this);
//            return;
//        }
//    }

//    public SerializeableDictionary(int initialCapacity=0)
//    {
//        currentCapacityIndex = initialCapacity;
//        for(int i = 0; i < Capacities[currentCapacityIndex]; i++)
//            table.Add(null);
//    }

//    List<List<KeyValuePair<key, value>>> old;

//    void expandTable()
//    {
//        currentCapacityIndex++;
//        if (currentCapacityIndex > Capacities.Length)
//            Debug.LogError("BROKEN!  HASH TABLE!!!!  Too big!!!");

//        old.Clear();
//        old.Capacity = Capacities[currentCapacityIndex];
//        List<List<KeyValuePair<key, value>>> nTable = old;
//        foreach(List<KeyValuePair<key, value>> list in table)
//        {
//            if(list!=null)
//                foreach (KeyValuePair<key, value> kvp in list)
//                {
//                    TryInsert(nTable, kvp);
//                }
//        }
//        old = table;
//        table = nTable;
//    }
    
//    void clearLL(LinkedList LL)
//    {

//        LinkedListNode<KeyValuePair<key, value>> lln = LL.First;
//        while (lln != null)
//        {
//            CollectionPool.pushBack(lln);
//            LL.RemoveFirst();

//            lln = LL.First;
//        }
//    }
//}
