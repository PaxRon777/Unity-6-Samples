using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Add key/value pairs to a Dictionary, get a specific value against a key if it exists

public class Dictionary : MonoBehaviour
{
    private enum AnimalType
    {
        Cat,
        Dog,
        Lion,
    }
    private Dictionary<AnimalType, int> animals = new Dictionary<AnimalType, int>();
    private int _animalNumber;


    void Start()
    {
        AddAnimal(AnimalType.Cat, 10);
        AddAnimal(AnimalType.Dog, 5);
        AddAnimal(AnimalType.Lion, 2);

        foreach (var animal in animals)
        {
            print("There are " + animal.Value + " " + animal.Key + "s");
        }

        if (animals.TryGetValue(AnimalType.Dog, out _animalNumber))
        {
            print("How many dogs are there? " + _animalNumber);
        }
    }

    private void AddAnimal(AnimalType animal, int amount)
    {
        animals.Add(animal, amount);
    }
}
