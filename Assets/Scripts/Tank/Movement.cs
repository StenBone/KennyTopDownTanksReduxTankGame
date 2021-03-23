using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField]
    private float movementSpeed = 1f;

    private Vector2 _inputMovement = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * movementSpeed * _inputMovement);
    }

    public void onMove(InputAction.CallbackContext value)
    {
        _inputMovement = value.ReadValue<Vector2>();
    }
    
}
