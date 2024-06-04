using UnityEngine;

public class Bullet : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        ObjectPooling._pool.Release(this.gameObject);
    }

}
