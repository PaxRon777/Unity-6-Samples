using UnityEngine;

//This is called subtyping in Unity, a type of polymorphism which is a single interface that can represent many different types.
//In this example we have 2 MonoBehaviour objects that inherit from the Vehicle base class, both Override the WheelNumber() method, but only 1 runs the base class WheelNumber() method.

public class Polymorphism : Vehicle
{   

    void Start()
    {
        print(WheelNumber()); // prints 6, a mustang GameObject would print 4 
    }

    public override int WheelNumber()
    {
        base.WheelNumber(); //The WheelNumber() method runs inside the inherited base class Vehicle, setting the Wheels variable to 4
        Wheels += 2; //Adds 2 to Wheels to become 6
        return Wheels;
    }
}


public class Vehicle : MonoBehaviour
{
    protected int Wheels;

    public virtual int WheelNumber()
    {
        Wheels = 4;
        return Wheels;
    }
}

public class Mustang : Vehicle
{
    private void Start()
    {
        print("A mustang has " + WheelNumber() + " wheels");
    }

    public override int WheelNumber()
    {
        Wheels += 4; //Wheel becomes 4
        return Wheels;
    }
}
