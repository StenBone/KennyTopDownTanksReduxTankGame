using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = .5f;

    private float timeSinceLastFiring = 0f;
    
    // todo reloading gui somewhere
    
    public void LaunchBullet(InputAction.CallbackContext value) {
        // todo research input system and why it triggers twice
        if (value.started && (timeSinceLastFiring + fireRate) < Time.time)
        {
            timeSinceLastFiring = Time.time;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            // todo launching multiple projectiles on press and release
        }
    }
}
