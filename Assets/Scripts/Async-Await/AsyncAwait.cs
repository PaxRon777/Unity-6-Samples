using System.Threading.Tasks;
using UnityEngine;
using TMPro;

//Using Async/Await to spin cubes in serial and parallel

public class AsyncAwait : MonoBehaviour
{
    [SerializeField] private Transform[] _cubes;
    [SerializeField] private float _duration = 2;
    [SerializeField] private float _speed = 120f;
    [SerializeField] private TextMeshProUGUI _txtInfo;

    //Rotate cubes in parallel
    public void RotateParallel()
    {
        for (int i = 0; i < _cubes.Length; i++)
        {
            Parallel(i);
        }
    }

    //Rotate cubes in serial
    public async void RotateSerial()
    {
        for (int i = 0; i < _cubes.Length; i++)
        {
            await Serial(i);
        }
    }

    //Wait for all tasks to complete
    public async void RotateWaitAll()
    {
        Task[] tasks = new Task[_cubes.Length];

        for (int i = 0; i < _cubes.Length; i++)
        {
            tasks[i] = Serial(i);
        }

        await Task.WhenAll(tasks);
        _txtInfo.text = "ALL TASKS COMPLETED";
    }

    //Return value from an async Task
    public async void DoRandomDelay()
    {
         int delay = await RandomDelay();
        _txtInfo.text = delay.ToString() + "ms Delay";
    }


    private async void Parallel(int cubeId)
    {
        var endTime = Time.time + _duration;
        _txtInfo.text = "ROTATING IN PARALLEL";

        while (Time.time < endTime)
        {
            _cubes[cubeId].Rotate(new Vector3(1, 1) * Time.deltaTime * _speed);
            await Task.Yield();
        }
    }

    private async Task Serial(int cubeId)
    {
        var endTime = Time.time + _duration;
        _txtInfo.text = "ROTATING IN SERIAL";

        while (Time.time < endTime)
        {
            _cubes[cubeId].Rotate(new Vector3(1, 1) * Time.deltaTime * _speed);
            await Task.Yield();
        }
    }

    private async Task<int> RandomDelay()
    {
        _txtInfo.text = "RANDOM DELAY, WAIT...";
        int number = Random.Range(500, 2000);
        await Task.Delay(number);
        return number;
    }
}
