using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

// todo inherit from snapaim
public class LerpAim : MonoBehaviour
{
    // todo move this to a utility class, game manager thing?
    [SerializeField] 
    private Camera _gameCamera;

    [SerializeField] 
    private float _rotationSpeed = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(_gameCamera != null);
    }

    // FixedUpdate since the barrel will have a collider and might hit a wall
    void FixedUpdate()
    {
        var mouse = Mouse.current; // todo cache this variable
        // mouse?.position.ReadValue(); // todo null conditional operator
        
        // todo use new input system
        
        if (mouse != null)
        {
            var worldMousePos = _gameCamera.ScreenToWorldPoint(mouse.position.ReadValue());
            //Debug.DrawLine(worldMousePos, worldMousePos + new Vector3(1, 0, 0), Color.green, 1f); // not showing up in Game View
            //Debug.DrawLine(worldMousePos, worldMousePos + new Vector3(0, 1, 0), Color.green);

            worldMousePos.z = transform.position.z; // ensure they are on the same plane
            Vector3 directionToFace = worldMousePos - transform.position;

            // todo clean up angle calculation 
            #region Angle Calculation needs to be cleaned up

            float angle = Mathf.Atan2(directionToFace.y,directionToFace.x) * Mathf.Rad2Deg;
            angle -= 90f; // to prevent it from pointing with the x axis
            Quaternion targetRot = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * _rotationSpeed);
            // transform.up = directionToFace; // this works but doesn't tell you the angle

            #endregion

        }
    }
}