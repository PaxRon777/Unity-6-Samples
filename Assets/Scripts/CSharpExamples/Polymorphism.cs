using UnityEngine;
using System.Collections.Generic;

// Polymorphism example where different classes are added to a single list using the <Vehicle> type.

public class Polymorphism : MonoBehaviour
{   
    private Bus _bus = new Bus();
    private Truck _truck = new Truck();
    private Boat _boat = new Boat();
    private List<Vehicle> _vehicles = new List<Vehicle>();

    private void Start()
    {
        _vehicles.Add(_bus);
        _vehicles.Add(_truck);
        _vehicles.Add(_boat);

        foreach (var vehicle in _vehicles)
        {
           vehicle.Move();
        }
    }
}

//Base class
public class Vehicle
{
    public virtual void Move()
    {       
    }
}

public class Bus : Vehicle
{
    public override void Move()
    {
        Debug.Log("The bus is moving");
    }    
}

public class Truck : Vehicle
{
    public override void Move()
    {
        Debug.Log("The truck is moving");
    }
}

public class Boat : Vehicle
{
    public override void Move()
    {
        Debug.Log("The boat is moving");
    }
}
