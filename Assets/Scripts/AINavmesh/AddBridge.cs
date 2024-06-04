using Unity.AI.Navigation;
using UnityEngine;

public class AddBridge : MonoBehaviour
{
    [SerializeField] private NavMeshSurface _navmeshSurface;
    [SerializeField] private GameObject _bridge;

    private void Start()
    {
        _bridge.SetActive(false);
    }

    public void EnableBridge()
    {
        _bridge.SetActive(true);
        _navmeshSurface.BuildNavMesh();
        gameObject.SetActive(false);
    }
}
