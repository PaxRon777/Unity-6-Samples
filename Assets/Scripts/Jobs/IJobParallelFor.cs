using UnityEngine;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;

// Example of using IJobParallelFor to iterate through and update the positions of moving cubes

public class IJobParallelFor : MonoBehaviour
{
    [SerializeField] private Transform _objectTransform;
    [SerializeField] private int _objectNumber = 1000;

    private List<Transform> _objectList = new List<Transform>();
    private NativeArray<float3> _directions;
    private NativeArray<float> _speed;
    private NativeArray<float3> _positions;
    private JobFor _job = new JobFor();

    void Start()
    {
        _directions = new NativeArray<float3>(_objectNumber, Allocator.Persistent);
        _speed = new NativeArray<float>(_objectNumber, Allocator.Persistent);
        _positions = new NativeArray<float3>(_objectNumber, Allocator.Persistent);

        //Set random object positions, speed and direction
        for (int i = 0; i < _objectNumber; i++)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10), 20 + UnityEngine.Random.Range(0, 10));
            _objectList.Add(Instantiate(_objectTransform, position, new Quaternion()));

            _directions[i] = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
            _speed[i] = UnityEngine.Random.Range(5, 15);
        }

        //Store object positions in native array
        for (int i = 0; i < _objectNumber; i++)
        {
            _positions[i] = _objectList[i].position;
        }        
        
        _job.Positions = _positions;
        _job.Speed = _speed;
        _job.Directions = _directions;
    }

    void Update()
    {
        //Shedule the Job
        _job.DeltaTime = Time.deltaTime;
        _job.Schedule(_objectNumber, JobsUtility.MaxJobThreadCount).Complete();

        //Update transforms with new positions
        for (int i = 0; i < _objectNumber; i++)
        {
            _objectList[i].position = _positions[i];
        }
    }

    //Cleanup Native Arrays
    private void OnDestroy()
    {
        _directions.Dispose();
        _speed.Dispose();
        _positions.Dispose();
    }
}

//JOB
[BurstCompile]
public struct JobFor : Unity.Jobs.IJobParallelFor
{
    public float DeltaTime;
    public NativeArray<float3> Positions;
    public NativeArray<float3> Directions;
    public NativeArray<float> Speed;

    public void Execute(int index)
    {
        Positions[index] += Directions[index] * Speed[index] * DeltaTime;
    }
}