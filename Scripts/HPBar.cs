using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float fillAmount = currentHealth / maxHealth;
        healthBar.fillAmount = fillAmount;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Change "Enemy" to the tag of the object causing damage
        {
            TakeDamage(10f); // Adjust the amount of damage as needed
        }
    }

    //particle effect when taking hp damage
    void TakeDamage(float damageAmount)
{
    currentHealth -= damageAmount;
    currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

    UpdateHealthBar();

    if (currentHealth <= 0f)
    {
        // Implement game over logic or respawn the player as needed
        Debug.Log("Game Over!");
    }
}


}
