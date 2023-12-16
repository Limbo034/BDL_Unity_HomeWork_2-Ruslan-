using System.Collections.Generic;
using UnityEngine;

public class CollisionHeal : MonoBehaviour
{
    public string collisionTag = "Player";
    public int collisionHeal = 0;

    private HashSet<GameObject> collectedHeal = new HashSet<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject != null && other.gameObject.tag == collisionTag)
        {
            if (!collectedHeal.Contains(other.gameObject))
            {
                Health health = other.gameObject.GetComponent<Health>();

                if (health != null)
                {

                    if (health.health < health.maxHealth)
                    {
                        health.SetHealth(collisionHeal);
                        collectedHeal.Add(other.gameObject);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}