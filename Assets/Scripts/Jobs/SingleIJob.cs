using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

//Single job script assigned to multiple GameObjects, 1M math operations per job, using burst

public class SingleIJob : MonoBehaviour
{
    void Update()
    {
        Job1 job = new Job1();
        job.Schedule().Complete();    
    }
}

//JOB
[BurstCompile]
public struct Job1 : IJob
{
    public void Execute()
    {
        float value = 0;
        for (int i = 0; i < 1000000; i++)
        {
            value = math.exp10(math.sqrt(i));
        }       
    }
}