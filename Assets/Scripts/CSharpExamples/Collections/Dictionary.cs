using System.Collections.Generic;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    private enum AnimalType
    {
        Cat,
        Dog,
        Lion,
    }

    private Dictionary<AnimalType, int> animals = new Dictionary<AnimalType, int>();

    void Start()
    {
        AddAnimal(AnimalType.Cat, 10);
        AddAnimal(AnimalType.Dog, 5);
        AddAnimal(AnimalType.Lion, 2);

        foreach (var animal in animals)
        {
            print("There are " + animal.Value + " " + animal.Key + "s");
        }
    }

    private void AddAnimal(AnimalType animal, int amount)
    {
        animals.Add(animal, amount);
    }
}
