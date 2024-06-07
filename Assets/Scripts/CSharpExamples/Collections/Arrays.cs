using UnityEngine;

public class Arrays : MonoBehaviour
{
    private string[] _animals = new string[10];
    private int[] _ages = new int[3] { 56, 12, 1 };

    private void Start()
    {
        _animals[0] = "Cat";
        _animals[1] = "Dog";
        _animals[2] = "Tiger";
        _animals[3] = "Zebra";
        _animals[4] = "Hippo";

        foreach (var animal in _animals)
        {
            if (animal != null)
                print(animal);
        }
    }
}
