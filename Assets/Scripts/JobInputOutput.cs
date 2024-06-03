using UnityEngine;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Jobs;

// Example of using input and output perameters with a job

public class JobInputOutput : MonoBehaviour
{
    private NativeArray<float> _output;

    void Update()
    {
        _output = new NativeArray<float>(1, Allocator.TempJob);
        Job3 job3 = new Job3 { Input = UnityEngine.Random.Range(1, 1000), Output = _output };
        job3.Schedule().Complete();
        print(_output[0]);
        _output.Dispose();
    }
}

//JOB
[BurstCompile]
public struct Job3 : IJob
{
    public NativeArray<float> Output;
    public float Input;

    public void Execute()
    {
        float value = 0;
        for (int i = 0; i < 100000; i++)
        {
            value = math.sqrt(i) + Input;
        }
        Output[0] = Input + value;
    }
}