using UnityEngine;

public class PlaySound : MonoBehaviour
{    
    void Start()
    {        
        Audio.Instance.PlaySfx(Audio.SfxName.Attack1);
    }   
}
