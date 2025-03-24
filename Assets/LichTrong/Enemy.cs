using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            // Hủy đạn
            Destroy(collision.gameObject);
            // Hủy kẻ thù
            Destroy(gameObject);
        }
    }
}
