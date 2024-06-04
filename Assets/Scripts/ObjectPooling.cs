using UnityEngine;
using UnityEngine.Pool;

//Bullet pooling using the built-in Unity Pool class

public class ObjectPooling : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] private GameObject _bullet; 
    [SerializeField] private float _spawnSpeed = 0.3f;
    [SerializeField] private int _bulletSpeed = 10;

    [Header("Pool")]
    [SerializeField] private int _defaultSize = 5;
    [SerializeField] private int _maxSize = 8;
   
    public static ObjectPool<GameObject> _pool;
    private int _bulletCount;

    void Start()
    {
        _pool = new ObjectPool<GameObject>(CreateBullet, GetBullet, ReturnBullet, DestroyBullet, true, _defaultSize, _maxSize);
        InvokeRepeating("FireBullet", 0, _spawnSpeed);
    }

    private GameObject CreateBullet()
    {
        GameObject bullet = Instantiate(_bullet, Vector3.zero, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().linearVelocity = (Vector3.up * _bulletSpeed);
        print("new bullet");
       
        return bullet;
    }

    private void GetBullet(GameObject bullet)
    {
        print("pooled bullet");
        _bulletCount++;        
        bullet.SetActive(true);
    }

    private void ReturnBullet(GameObject bullet)
    {
        print("returned bullet");
        bullet.transform.position = Vector3.zero;
        _bulletCount--;
        bullet.SetActive(false);
    }

    private void DestroyBullet(GameObject bullet)
    {
        print("destroyed bullet");
        _bulletCount--;
        Destroy(bullet);
    }

    void Update()
    {        
     
    }

    private void FireBullet()
    {
        _pool.Get(); 
        print(_bulletCount);
    }
}
