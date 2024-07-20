using UnityEngine;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Burst;
using TMPro;
using Unity.Jobs.LowLevel.Unsafe;

// GPU Instancing with jobs and burst

public class GPUInstJobs : MonoBehaviour
{
    [SerializeField] private int _gridSize = 30;
    [SerializeField] private TextMeshProUGUI _text;

    [Header("Instanced Object")]
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Material _material;

    private NativeArray<Matrix4x4> _matrices;
    private NativeArray<float3> _pos;
    private RenderParams _rp;   
    private int _instances;
    private MatricesJob _job;   

    private void Start()
    {
        _instances = _gridSize * _gridSize * _gridSize;
        _matrices = new NativeArray<Matrix4x4>(_instances, Allocator.Persistent);
        _pos = new NativeArray<float3>(_instances, Allocator.Persistent);
        _rp = new RenderParams(_material);
        _job = new MatricesJob();

        //Instantiate grid of GameObjects
        int i = 0;
        for (int x = 0; x < _gridSize; x++)
        {
            for (int y = 0; y < _gridSize; y++)
            {
                for (int z = 0; z < _gridSize; z++)
                {
                    _pos[i] = new Vector3(x * 2, y * 2 + Mathf.Sin(Time.time + x + z), z * 2);
                    i++;
                }
            }
        }
    }

    void Update()
    {
        _job.Matrices = _matrices;
        _job.Pos = _pos;
        _job.Time = Time.time;
        _job.Schedule(_matrices.Length, JobsUtility.MaxJobThreadCount).Complete();

        Graphics.RenderMeshInstanced(_rp, _mesh, 0, _matrices);

        _text.text = _matrices.Length.ToString();
    }

    private void OnDisable()
    {
        _matrices.Dispose();
        _pos.Dispose();
    }
}


//JOB
[BurstCompile]
public struct MatricesJob : Unity.Jobs.IJobParallelFor
{
    public NativeArray<Matrix4x4> Matrices;
    public float Time;
    public NativeArray<float3> Pos;

    public void Execute(int index)
    {
        Matrices[index] = Matrix4x4.TRS(new Vector3(Pos[index].x + math.cos(Time + Pos[index].x + Pos[index].z), Pos[index].y + math.sin(Time + Pos[index].x + Pos[index].z), Pos[index].z), Quaternion.identity, Vector3.one);
    }
}
