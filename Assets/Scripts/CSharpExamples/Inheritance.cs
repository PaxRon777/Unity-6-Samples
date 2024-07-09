using UnityEngine;

//Each character can inherit the properties from a base class in this case called Character

public class Inheritance : Character
{
    private void Start()
    {
        Health = 200;
        print(CharacterName + " has a health of " + TakeDamage(20));
    }
}

public class Character : MonoBehaviour
{
    protected int Health = 100; //protected is not shown in the inspector but can be used in a inheriting class
    public string CharacterName; //shown in the inspector of a inheriting class

    public int TakeDamage(int damage)
    {
        Health -= damage;
        return Health;
    }
}

public class Batman : Character
{
    private void Start()
    {
        Health = 120;
        CharacterName = "Batman";
        print(CharacterName + " has a health of " + TakeDamage(50));
    }
}
