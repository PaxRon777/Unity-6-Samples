using UnityEngine;

// Remove/release bullet when it hits an object

public class Bullet : MonoBehaviour
{  
    private void OnTriggerEnter(Collider other)
    {
        ObjectPooling.PoolBullets.Release(this.gameObject);
    }
}
