using UnityEngine;
using UnityEngine.AI;

public class AI_GetToTarget : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private Transform _target;
   
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        _agent.destination = _target.position;
    }
}
