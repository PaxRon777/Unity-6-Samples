using UnityEngine;

// Simple 2D sprite mouse drag example, camera is orthographic

public class Drag2D : MonoBehaviour
{
    private bool isDrag;
   
    void Update()
    {
        if (isDrag)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDown()
    {
        isDrag = true;
    }

    private void OnMouseUp()
    {
        isDrag = false; 
    }
}
