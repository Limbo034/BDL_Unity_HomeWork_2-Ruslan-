using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public PlayerMovement playerMovement;
    private bool isDisappeared = false;
    private bool hasTriggered = false;

    private void Update()
    {
        if (isDisappeared && !hasTriggered)
        {
            if (playerMovement != null)
            {
                playerMovement.Trigger();
                hasTriggered = true;
            }
        }
    }

    public void TakeHit(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            isDisappeared = true;
        }
    }

    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
