using System.Collections.Generic;
using UnityEngine;

// Adding items to a que, first in first out (FIFO)

public class Queue : MonoBehaviour
{
    private Queue<string> _animals = new Queue<string>();

    void Start()
    {
        //Add to que
        _animals.Enqueue("cat");
        _animals.Enqueue("Lizard");
        _animals.Enqueue("dog");
        _animals.Enqueue("cow");       
        _animals.Enqueue("Monkey");

        int numberItems = _animals.Count;

        for (int i = 0; i < numberItems; i++)
        {
            print(_animals.Dequeue());
        }    
    }
}
