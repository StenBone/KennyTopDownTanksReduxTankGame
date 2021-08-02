using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

// todo inherit from snapaim
public class Aim : MonoBehaviour
{
    // todo move this to a utility class, game manager thing?
    [SerializeField] 
    private Camera gameCamera;
    [SerializeField] 
    private Transform turretPivot;
    [SerializeField] 
    private Transform aimingGui;
    [SerializeField] 
    private float rotationSpeed = 0.5f;
    
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
            
            float angle = Mathf.Atan2(directionToFace.y,directionToFace.x) * Mathf.Rad2Deg;
            angle -= 90f; // to prevent it from pointing with the x axis
            Quaternion targetRot = Quaternion.AngleAxis(angle, Vector3.forward);
            
            aimingGui.rotation = targetRot;
            turretPivot.rotation = Quaternion.Lerp(turretPivot.rotation, targetRot, Time.deltaTime * rotationSpeed);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * _rotationSpeed);
            // transform.up = directionToFace; // this works but doesn't tell you the angle
            
            // calculate cross product
            var crossProduct = Vector3.Cross(turretPivot.eulerAngles, targetRot.eulerAngles).normalized;
            Debug.Log(crossProduct.ToString());
        }
    }
}