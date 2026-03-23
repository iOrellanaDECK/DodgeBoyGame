using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBarDisplay healthBarDisplay;
    private ScoreManager scoreManager;

    public GameObject gameOverPanel;
    public GameObject gameplayContainer;
    public TextMeshProUGUI finalScoreText;


    private Animator animator;
    private readonly int hurtID = Animator.StringToHash("Hurt");

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        healthBarDisplay.SetHealth(1f); // 
        scoreManager = FindObjectOfType<ScoreManager>();

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.collisionSFX);
        }

        // actualiza barra
        healthBarDisplay.SetHealth((float)currentHealth / maxHealth);

        if (animator != null)
            animator.SetTrigger(hurtID);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Jugador ha muerto");
        Time.timeScale = 0f;

        gameplayContainer.SetActive(false);

        AudioManager.Instance.StopMusic();
        AudioManager.Instance.StopSfx();

        finalScoreText.text = "Puntuación: " + scoreManager.GetFinalScore();

        scoreManager.StopScore();

        gameOverPanel.SetActive(true);
    }
}
