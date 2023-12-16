using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public string collisionTag = "Player";
    public int collisionDamage = 0;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Health health = coll.gameObject.GetComponent<Health>();
            health.TakeHit(collisionDamage);
        }
    }


}
