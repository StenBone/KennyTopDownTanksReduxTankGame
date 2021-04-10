using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    public void LaunchBullet(InputAction.CallbackContext value) {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
