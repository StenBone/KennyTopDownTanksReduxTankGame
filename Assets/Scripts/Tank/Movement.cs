using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField]
    private float _forwardBackwardSpeed = 1f;

    [SerializeField] 
    private float _turnSpeed = 45f;

    private float _verticalAxis = 0;
    private float _horizontalAxis = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yDelta = (Time.deltaTime * _forwardBackwardSpeed * _verticalAxis);
        transform.Translate(0, yDelta, 0, Space.Self);

        float zRotDelta = transform.rotation.eulerAngles.z + (_horizontalAxis * _turnSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, zRotDelta);
        
    }

    // todo can I just make these attributes?
    // todo would it be better to read directly from input if I am using them this way?
    public void SetVerticalAxis(InputAction.CallbackContext value)
    {
        _verticalAxis = value.ReadValue<float>();
    }

    public void SetHorizontalAxis(InputAction.CallbackContext value)
    {
        _horizontalAxis = value.ReadValue<float>();
    }
    
}
