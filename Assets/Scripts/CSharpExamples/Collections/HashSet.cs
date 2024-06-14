using System.Collections.Generic;
using UnityEngine;

// Adding items to 2 HashSets and combining them, Hashsets take only unique values

public class HashSet : MonoBehaviour
{
    private HashSet<string> _animals = new HashSet<string>();
    private HashSet<string> _bugs = new HashSet<string>();

    void Start()
    {
        _animals.Add("cat");
        _animals.Add("dog");
        _animals.Add("cow");
        _animals.Add("dog");
        _animals.Add("ant");

        _bugs.Add("spider");
        _bugs.Add("beetle");
        _bugs.Add("roach");
        _bugs.Add("ant");
        _bugs.Add("flee");

        _animals.UnionWith(_bugs);

        print("Number of animals = " + _animals.Count);

        foreach (var item in _animals)
        {
            print(item);
        }

        print("Do we have a dog in the set? " + _animals.Contains("dog"));
    }
}

