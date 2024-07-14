using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

//Load and instantiate a GameObject from an Addressable Asset

public class Addressables : MonoBehaviour
{
    [SerializeField] private AssetReference _assetReference;
   
    void Start()
    {
        _assetReference.LoadAssetAsync<GameObject>().Completed += LoadAsset;
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
}
