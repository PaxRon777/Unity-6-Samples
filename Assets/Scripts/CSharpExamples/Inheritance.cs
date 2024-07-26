using UnityEngine;

//Each character can inherit the properties from a base class Character

// Inherits from the base class
public class Inheritance : Character
{
    private void Start()
    {
        Health = 200;
        print(CharacterName + " has a health of " + TakeDamage(20));
    }
}

// Inherits from the base class
public class Batman : Character
{
    private void Start()
    {
        Health = 120;
        CharacterName = "Batman";
        print(CharacterName + " has a health of " + TakeDamage(50));
    }
}

//Base Class
public class Character : MonoBehaviour
{
    protected int Health = 100; //protected is not shown in the inspector but can be used in a inheriting class
    public string CharacterName; //shown in the inspector of a inheriting class

    protected int TakeDamage(int damage) //protected method can be used by inheriting classes only
    {
        Health -= damage;
        return Health;
    }
}
