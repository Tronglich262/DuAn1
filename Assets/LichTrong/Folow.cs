using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;  
    public float speed = 5f;   
    public float stoppingDistance = 2f;  
    public int health = 10;   
    void Start()
    {
        player = GameObject.Find("player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            // Tính toán khoảng cách giữa quái vật và nhân vật chính
            float distance = Vector3.Distance(transform.position, player.position);

            // Nếu khoảng cách lớn hơn khoảng cách dừng lại, di chuyển quái vật về phía nhân vật chính
            if (distance > stoppingDistance)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }

   
}
