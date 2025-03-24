using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        healthBar = FindObjectOfType<HealthBar>(); // Tự động tìm HealthBar trong scene
        if (healthBar == null)
        {
            Debug.LogError("Không tìm thấy HealthBar trong scene!");
        }
    
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")) // Đảm bảo Enemy có tag "Enemy"
        {
            Debug.Log("Player chạm vào Enemy!");
            TakeDamage(10); // Trừ 10 máu khi chạm quái
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.UpdateBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player đã chết!");
        // Xử lý chết (respawn, load màn mới, v.v.)
    }
}