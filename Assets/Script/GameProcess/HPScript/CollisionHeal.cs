using UnityEngine;

public class CollisionHeal : MonoBehaviour
{
    public string collisionTag = "Player";
    public int collisionHeal = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject != null && other.gameObject.tag == collisionTag)
        {
            Health health = other.gameObject.GetComponent<Health>();

            if (health != null)
            {
                health.SetHealth(collisionHeal);

                if (health.health < health.maxHealth)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}