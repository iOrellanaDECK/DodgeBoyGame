using UnityEngine;

public class DebrisDamage : MonoBehaviour
{
    public int damageAmount = 20;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }

            Destroy(gameObject); // el escombro se destruye al golpear
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            AudioManager.Instance.PlayRandomDebrisGroundSFX();
            Destroy(gameObject);
        }
    }
}
