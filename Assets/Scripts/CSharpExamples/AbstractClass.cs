using UnityEngine;

//Abstract classes are a combination of a MonoBehaviour and an Interface.
//Abstract class are thefore Not instantiated in a scene but also force the inheriting MonoBehaviours to implement its abstract methods.

public class AbstractClass : Monster
{    
    void Start()
    {
        Bite();
        Growl();
    }

    protected override void Growl()
    {
        print("I am growling!");
    }
}

//Base class
public abstract class Monster : MonoBehaviour
{
    protected void Bite()
    {
        print("I am a big monster");
    }

    protected abstract void Growl();   
}
