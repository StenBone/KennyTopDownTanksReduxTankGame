using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mouse = Mouse.current;
        // mouse?.position.ReadValue(); // todo null conditional operator

        if (mouse != null)
        {
            var worldMousePos = Camera.current.ScreenToWorldPoint(mouse.position.ReadValue());
            Debug.DrawLine(worldMousePos, worldMousePos + new Vector3(20, 0, 0), Color.green);
            Debug.DrawLine(worldMousePos, worldMousePos + new Vector3(0, 20, 0), Color.green);
            
        }
    }
}
