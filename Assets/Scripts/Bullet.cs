using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float launchForce = 50f; // todo consistent style settings
    [SerializeField] private float lifeSpanInSeconds = 5f;
    [SerializeField] private int attackPower = 101;
    
    // Start is called before the first frame update
    void Start()
    {
        var rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * launchForce, ForceMode2D.Impulse); // apply forward force
        Destroy(gameObject, lifeSpanInSeconds); // destroy gameobject after 5 seconds
    }

    // todo kinematic bullet for complete control of its behavior
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("CanDamage"))
        {
            // todo naming conventions for damage
            var damageComponent = other.gameObject.GetComponent<Destructable>();
            damageComponent.Damage(attackPower);
            
            Destroy(gameObject);
            
            // other.gameObject.GetComponent<Health>();
            // Health.Damage
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        // Physics Hit Detection
        
        /** could also use tags
        Target target = collider.GetComponent<Target>();
        if (target != null) {
            // Hit a Target
            target.Damage();
            Destroy(gameObject);
        }
        */
    }
}
