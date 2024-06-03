using System.Collections.Generic;
using TMPro;
using UnityEngine;

//GPU instancing of 1000 (1 x batch) of a moving GameObjects

public class GPUInstancing : MonoBehaviour
{      
    [SerializeField] private int _gridSize = 30;
    [SerializeField] private TextMeshProUGUI _text;

    [Header("Instanced Object")]
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Material _material; 
    [SerializeField] private bool _isInstanced = true;

    [Header("Non Instanced Object")]
    [SerializeField] private Transform _object;

    private Matrix4x4[] _matrices;
    private RenderParams _rp;
    private List<Transform> _objectList = new List<Transform>();
    private int _instances;  

    private void Start()
    {
        //Instantiate grid of GameObjects if the IsInstanced bool is false
        if (!_isInstanced)
        {
            for (int x = 0; x < _gridSize; x++)
            {
                for (int y = 0; y < _gridSize; y++)
                {
                    for (int z = 0; z < _gridSize; z++)
                    {
                        _objectList.Add(Instantiate(_object, new Vector3(x * 2, y * 2, z * 2), Quaternion.identity));
                    }
                }
            }
        }
        _instances = _gridSize * _gridSize * _gridSize;
    }

    void Update()
    {        
        if (_isInstanced) // GPU Instanced
        {
            _matrices = new Matrix4x4[_instances];
            _rp = new RenderParams(_material);

            int i = 0;
            for (int x = 0; x < _gridSize; x++)
            {
                for (int y = 0; y < _gridSize; y++)
                {
                    for (int z = 0; z < _gridSize; z++)
                    {
                        _matrices[i] = Matrix4x4.TRS(new Vector3(x * 2, y * 2 + Mathf.Sin(Time.time + x + z), z * 2), Quaternion.identity, Vector3.one);
                        i++;
                    }
                }
            }
            Graphics.RenderMeshInstanced(_rp, _mesh, 0 , _matrices);
        }
        else //Not Instanced
        {
            int i = 0;
            for (int x = 0; x < _gridSize; x++)
            {
                for (int y = 0; y < _gridSize; y++)
                {
                    for (int z = 0; z < _gridSize; z++)
                    {
                        _objectList[i].position = new Vector3(x * 2, y * 2 + Mathf.Sin(Time.time + x + z), z * 2);
                        i++;
                    }
                }
            }
        }

        _text.text = _matrices.Length.ToString();
    }
}