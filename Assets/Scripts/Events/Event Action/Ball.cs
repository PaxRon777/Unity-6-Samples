using System;
using UnityEngine;


public class Ball : MonoBehaviour
{
    public static event Action<int> OnScore;

    private int _score;

    void Start()
    {
        MoveBall();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _score++;
        OnScore?.Invoke(_score); //Fire the even to update the score text that is subscribed to this event
        transform.position = Vector3.zero;
        MoveBall();
    }

    private void MoveBall()
    {
        GetComponent<Rigidbody>().linearVelocity = Vector3.right * 10;
    }
}


