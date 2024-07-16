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
            if (_gameObjectCube != null)
            {
                _gameObject.ReleaseInstance(_gameObjectCube); // Removes/releases the cube
            }
        }
    }

    //Instantiate Cube
    private void LoadAsset(AsyncOperationHandle<GameObject> gameObject)
    {
        if (gameObject.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(gameObject.Result);
        }
        else
        {
            Debug.Log("Asset load error!");
        }
    }


    //Instantiate bullet
    private void LoadLabelReference(AsyncOperationHandle<GameObject> gameObject)
    {
        if (gameObject.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(gameObject.Result);
        }
        else
        {
            Debug.Log("Asset Reference load error!");
        }
    }

    //Assign the instantiated cube to the GameObject, delete/release the cube by pressing SPACE key
    private void LoadCube(AsyncOperationHandle<GameObject> gameObject)
    {
        if (gameObject.Status == AsyncOperationStatus.Succeeded)
        {
            _gameObjectCube = gameObject.Result;
        }
        else
        {
            Debug.Log("Asset Reference load error!");
        }
    }
}
