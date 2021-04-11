using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankManager : MonoBehaviour
{
    // todo make singleton to game object and all children game objects. There can be multiple tanks but only one manager per tank.
    // todo hold one instance of player input that other components can use
    public PlayerInput TankPlayerInput { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
