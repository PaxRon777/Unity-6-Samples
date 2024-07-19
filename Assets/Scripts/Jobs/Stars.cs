using UnityEngine;
using Unity.Jobs;
using Unity.Burst;
using Unity.Collections;
using UnityEngine.Jobs;

//Updating many transform positions using IJobParallelForTransform

public class Stars : MonoBehaviour
{
    [SerializeField] private Transform _transformObject;
    [SerializeField] private int _numberObjects = 100;
    [SerializeField] private float _drawWidth = 10;
    [SerializeField] private float _drawHeight = 10;
    [SerializeField] private float _minScale = 0.001f;
    [SerializeField] private float _maxScale = 0.004f;
    [SerializeField] private float _minVelocity = 0.05f;
    [SerializeField] private float _maxVelocity = 1f;

    private Transform[] _transforms;
    private TransformAccessArray _accessArray;
    private NativeArray<Vector3> _velocity;
    private StarsJob _job;

    private void Awake()
    {
        _transforms = new Transform[_numberObjects];
        _velocity = new NativeArray<Vector3>(_numberObjects, Allocator.Persistent);
    }

    void Start()
    {
        DrawStars();
        _accessArray = new TransformAccessArray(_transforms);
    }

    void Update()
    {
        DoJob();
    }

    private void OnDestroy()
    {
        _accessArray.Dispose();
        _velocity.Dispose();
    }

    private void DoJob()
    {       
        _job.deltatime = Time.deltaTime;      
        _job.Schedule(_accessArray).Complete();
    }

    private void DrawStars()
    {
        for (int i = 0; i < _numberObjects; i++)
        {
            Transform star = Instantiate(_transformObject);
            _transforms[i] = star;
            _transforms[i].position = new Vector3(Random.Range(-_drawWidth, _drawWidth), Random.Range(-_drawHeight, _drawHeight), transform.position.z);
            float size = Random.Range(_minScale, _maxScale);
            _transforms[i].localScale = new Vector3(size, size, size);
            _velocity[i] = new Vector3(0, Random.Range(_minVelocity, _maxVelocity), 0);
            _job.velocity = _velocity;
        }
    }
}

//Job
[BurstCompile]
public struct StarsJob : IJobParallelForTransform
{
    public NativeArray<Vector3> velocity;
    public float deltatime;

    public void Execute(int index, TransformAccess transform)
    {
        transform.position -= velocity[index] * deltatime;
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(transform.position.x, 6, transform.position.z);
        }
    }
}


