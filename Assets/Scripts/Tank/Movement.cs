using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField]
    private float _movementSpeed = 1f;

    private float _verticalAxis = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.y = Time.deltaTime * _movementSpeed * _verticalAxis;
        transform.Translate(pos);
    }

    public void setVerticalAxis(InputAction.CallbackContext value)
    {
        _verticalAxis = value.ReadValue<float>();
    }
    
}
