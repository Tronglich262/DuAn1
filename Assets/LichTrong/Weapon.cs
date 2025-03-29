using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float TimeBtwFire = 0.2f;
    public float bulletForce;
    private float timeBtwFire;

    public GameObject itemPrefab1;
    public GameObject itemPrefab2;
    public GameObject itemPrefab3;

    private ExpScene playerExperience; // Đổi từ ExpScene → PlayerExperience

    void Start()
    {
        playerExperience = FindObjectOfType<ExpScene>();

        if (playerExperience == null)
            Debug.LogError("Không tìm thấy ExpScene!");

    }

    void Update()
    {
        RotateGun();
        timeBtwFire -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timeBtwFire < 0)
        {
            FireBullet();
        }
    }

    void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void FireBullet()
    {
        timeBtwFire = TimeBtwFire;

        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"[OnTriggerEnter2D] Va chạm với: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("[OnTriggerEnter2D] Enemy bị tiêu diệt!");
            Destroy(collision.gameObject); // Xóa enemy
            Destroy(gameObject); // Xóa đạn

            if (playerExperience != null)
            {
                Debug.Log("[OnTriggerEnter2D] Gọi GainExp(5)");
                playerExperience.GainExp(5);
            }
            else
            {
                Debug.LogError("[OnTriggerEnter2D] playerExperience NULL! Không thể cộng EXP!");
            }

            GameObject itemToSpawn = GetRandomItem();
            if (itemToSpawn != null)
                Instantiate(itemToSpawn, collision.transform.position, Quaternion.identity);
        }
    }


    

    private GameObject GetRandomItem()
    {
        float randomValue = Random.Range(0f, 1f);

        if (randomValue < 0.4f) return itemPrefab1;
        else if (randomValue < 0.5f) return itemPrefab2;
        else if (randomValue < 0.53f) return itemPrefab3;

        return null;
    }
}
