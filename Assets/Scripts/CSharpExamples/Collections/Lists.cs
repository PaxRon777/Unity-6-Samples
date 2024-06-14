using System.Collections.Generic;
using System;
using UnityEngine;

// Add items to a List, 

public class Lists : MonoBehaviour
{
    List<Animals> animals = new List<Animals>();

    private void Start()
    {
        List<Animals> animals = new List<Animals>();

        animals.Add(new Animals("Dogs", 5));
        animals.Add(new Animals("Cats", 2));
        animals.Add(new Animals("Horses", 15));
        animals.Add(new Animals("Pigs", 5));
        animals.Add(new Animals("Apes", 4));
        animals.Add(new Animals("Donkey", 4));
        animals.Sort();
        animals.RemoveAt(3); //Removes Donkey

        foreach (var animal in animals)
        {
            print(animal.Name + " = " + animal.Amount);
        }
    }
}

public class Animals : IComparable<Animals>
{
    public string Name;
    public int Amount;

    public Animals(string name, int amount)
    {
        Name = name;
        Amount = amount;
    }

    public int CompareTo(Animals other)
    {
        return this.Name.CompareTo(other.Name);
    }
}


