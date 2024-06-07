using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private int _health;

    public void Damage(int damageAmount)
    {
        _health -= damageAmount;
        print("Enemy hit, health = " + _health);
    }  
}
