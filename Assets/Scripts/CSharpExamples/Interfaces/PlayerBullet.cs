using UnityEngine;

public class PlayerBullet : MonoBehaviour
{   

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage(10);
        }
    }

}
