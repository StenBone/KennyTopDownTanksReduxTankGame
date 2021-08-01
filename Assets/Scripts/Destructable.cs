using System;
using UnityEditor.UIElements;
using UnityEngine;

/// <summary>
/// Can be destroyed
/// todo require collison
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class Destructable : MonoBehaviour
{
    [SerializeField] private int hp = 100;

    private void Start()
    {
        Debug.Assert(gameObject.CompareTag("CanDamage"));
    }

    public void Damage(int inHP)
    {
        hp -= inHP;
        if (hp < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
