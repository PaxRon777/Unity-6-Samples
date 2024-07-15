using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

//Load and instantiate a GameObject from an Addressable Asset

public class AddressablesExamples : MonoBehaviour
{
    [SerializeField] private AssetReference _assetReferenceCube;
    [SerializeField] private AssetLabelReference _labelReference;
    [SerializeField] private AssetReferenceGameObject _gameObject;

    private GameObject _gameObjectCube;

    void Start()
    {
        _assetReferenceCube.LoadAssetAsync<GameObject>().Completed += LoadAsset; //Load an asset of type GameObject
        Addressables.LoadAssetAsync<GameObject>(_labelReference).Completed += LoadLabelReference; //Load asset by its label
        _gameObject.InstantiateAsync().Completed += LoadCube;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _gameObject.ReleaseInstance(_gameObjectCube); //Removes the AssetReferenceGameObject cube
        }
    }

    private void LoadAsset(AsyncOperationHandle<GameObject> gameObject)
    {
        if (gameObject.Result != null)
        {
            Instantiate(gameObject.Result);
        }
        else
        {
            Debug.Log("Asset load error!");
        }
    }

    private void LoadLabelReference(AsyncOperationHandle<GameObject> gameObject)
    {
        if (gameObject.Result != null)
        {
            Instantiate(gameObject.Result);

        }
        else
        {
            Debug.Log("Asset Reference load error!");
        }
    }

    private void LoadCube(AsyncOperationHandle<GameObject> gameObject)
    {
        _gameObjectCube = gameObject.Result;
    }
}
