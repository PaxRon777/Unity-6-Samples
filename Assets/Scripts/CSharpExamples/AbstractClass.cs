using UnityEngine;

//Abstract classes are a combination of a MonoBehaviour and an Instance.
//Abstract class are thefore not instantiated in a scene but also force the inheriting MonoBehaviours to implement its abstract methods.

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

public abstract class Monster : MonoBehaviour
{
    protected void Bite()
    {
        print("I am a big monster");
    }

    protected abstract void Growl();
   
}
