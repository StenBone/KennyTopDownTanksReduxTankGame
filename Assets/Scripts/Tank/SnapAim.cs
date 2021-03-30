using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class SnapAim : MonoBehaviour
{
    // todo move this to a utility class, game manager thing?
    [SerializeField] 
    private Camera gameCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(gameCamera != null);
    }

    // FixedUpdate since the barrel will have a collider and might hit a wall
    void FixedUpdate()
    {
        var mouse = Mouse.current;
        // mouse?.position.ReadValue(); // todo null conditional operator

        if (mouse != null)
        {
            var worldMousePos = gameCamera.ScreenToWorldPoint(mouse.position.ReadValue());
            //Debug.DrawLine(worldMousePos, worldMousePos + new Vector3(1, 0, 0), Color.green, 1f); // not showing up in Game View
            //Debug.DrawLine(worldMousePos, worldMousePos + new Vector3(0, 1, 0), Color.green);

            worldMousePos.z = transform.position.z; // ensure they are on the same plane
            Vector3 directionToFace = worldMousePos - transform.position;
            //Debug.DrawLine(transform.position, directionToFace, Color.red);
            
            transform.rotation = Quaternion.LookRotation(directionToFace); // todo bug rotation causes z axis to be forward, what is the forward axis?
        }
    }
}
