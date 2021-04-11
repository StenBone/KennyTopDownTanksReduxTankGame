using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// todo naming convention for behavior related classes, actions
public class TurnTurretBehavior : MonoBehaviour
{
    [SerializeField] private float turnRate = 1f;
    private float _horizontalAxis = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, Time.deltaTime * turnRate * _horizontalAxis);
    }

    public void SetHorizontalAxis(InputAction.CallbackContext value)
    {
        _horizontalAxis = value.ReadValue<float>();
    }
}
