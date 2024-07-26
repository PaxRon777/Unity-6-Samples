using UnityEngine;

// Constant, values that should not change

public class Constants : MonoBehaviour
{
    private const int _maxHealth = 100; //set at compile time so cannot be changed at runtime

    void Start()
    {
        print(_maxHealth);
        Player player = new Player(100);      
        print(player.maxHealth);
    }

    public class Player
    {
        public readonly int maxHealth; //can be changed at runtime

        public Player(int maxHealth)
        {
            this.maxHealth = maxHealth;
        }  
    }
}



