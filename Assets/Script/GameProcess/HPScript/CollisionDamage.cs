using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private string collisionTag = "Player";
    [SerializeField] private int collisionDamage = 0;

    private HashSet<GameObject> collectedDamage = new HashSet<GameObject>();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == collisionTag)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeHit(collisionDamage);
            collectedDamage.Add(collision.gameObject);
        }
    }

}
