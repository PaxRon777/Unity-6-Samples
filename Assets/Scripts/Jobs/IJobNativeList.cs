using UnityEngine;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Burst;

// Multiple jobs added to a NativeList

public class IJobNativeList : MonoBehaviour
{
    private int _cpuCount; //number of logical processors
    [SerializeField] private bool _isJob;
    [SerializeField] private int _calculationLoops = 250000;

    private void Start()
    {    
        print(_cpuCount);
    }

    void Update()
    {
        if (_isJob)
        {
            NativeList<JobHandle> jobHandles = new NativeList<JobHandle>(Allocator.Temp);
            for (int i = 0; i < 10; i++)
            {
                Job2 job2 = new Job2 { CalculationLoops = _calculationLoops };
                JobHandle handle = job2.Schedule();
                jobHandles.Add(handle);
            }
            JobHandle.CompleteAll(jobHandles.ToArray(Allocator.Temp));
            jobHandles.Dispose();
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                for (int t = 0; t < _calculationLoops; t++)
                {
                    float value = 0;
                    value = math.exp10(math.sqrt(t));
                }
            }
        }
    }

}

//JOB
[BurstCompile]
public struct Job2 : IJob
{
    public int CalculationLoops;

    public void Execute()
    {
        for (int i = 0; i < CalculationLoops; i++)
        {
            float value = 0;
            value = math.exp10(math.sqrt(i));
        }
    }
}
