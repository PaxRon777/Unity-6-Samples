using UnityEngine;
using UnityEngine.Pool;

//AudioSource pooling

public class AudioSourcePooling : MonoBehaviour
{
    [Header("Pool")]
    [SerializeField] private int _defaultSize = 15;
    [SerializeField] private int _maxSize = 20;
   
    public static ObjectPool<AudioSource> AudioSourcePool;   
   

    void Start()
    {
        AudioSourcePool = new ObjectPool<AudioSource>(Create, Get, Return, Destroy, true, _defaultSize, _maxSize);       
    }

    private AudioSource Create()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();   
        return audioSource;
    }

    private void Get(AudioSource audioSource)
    {
        audioSource.enabled = true;
    }

    private void Return(AudioSource audioSource)
    {    
        audioSource.enabled = false;
    }

    private void Destroy(AudioSource audioSource)
    {      
        Destroy(audioSource);
    }  

}
