using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField]
    private float _FowardBackwardSpeed = 1f;

    private float _verticalAxis = 0;
    private float _horizontalAxis = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yDelta = (Time.deltaTime * _FowardBackwardSpeed * _verticalAxis);
        transform.Translate(0, yDelta, 0, Space.Self);

        if (Keyboard.current.dKey.isPressed)
        {
            float newZRot = transform.rotation.eulerAngles.z + (-1 * 45 * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newZRot);
        }
        
    }

    // todo can I just make these attributes?
    // todo would it be better to read directly from input if I am using them this way?
    public void setVerticalAxis(InputAction.CallbackContext value)
    {
        _verticalAxis = value.ReadValue<float>();
    }

    public void setHorizontalAxis(InputAction.CallbackContext value)
    {
        _horizontalAxis = value.ReadValue<float>();
    }
    
}
