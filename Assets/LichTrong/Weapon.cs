using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float TimeBtwFire = 0.2f;
    public float bulletForce;
    private float timeBtwFire;
     public GameObject itemPrefab1; // Loại vật phẩm 1
    public GameObject itemPrefab2; // Loại vật phẩm 2
    public GameObject itemPrefab3; // Loại vật phẩm 3

    // public GameObject muzzle;


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

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            // Flip the object by rotating it 180 degrees around the x-axis
            transform.rotation = Quaternion.Euler(180f, 0f, -transform.eulerAngles.z);
        }
        else
        {
            // Ensure the object is in its normal orientation
            transform.rotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z);
        }
    }
    void FireBullet()
    {
        timeBtwFire = timeBtwFire;

        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
        //effect
        //Instantiate(muzzle, firePos.position, transform.rotation, transform);


        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy") // Kiểm tra xem đối tượng va chạm có tag là "Enemy" không
        {
            // Lấy vị trí của quái vật trước khi bị tiêu diệt
            Vector3 enemyPosition = collision.transform.position;

            // Tiêu diệt quái vật
            Destroy(collision.gameObject);

            // Tiêu diệt viên đạn
            Destroy(gameObject);

            // Chọn ngẫu nhiên một loại vật phẩm để sinh ra
            GameObject itemToSpawn = GetRandomItem();
            if (itemToSpawn != null)
            {
                Instantiate(itemToSpawn, enemyPosition, Quaternion.identity);
            }
        }
    }
    private GameObject GetRandomItem()
    {
        float randomValue = Random.Range(0f, 1f); // Sinh ra số ngẫu nhiên từ 0.0 đến 1.0

        if (randomValue < 0.4f) // Tỷ lệ 40% cho itemPrefab1
        {
            return itemPrefab1;
        }
        else if (randomValue < 0.5f) // Tỷ lệ 10% cho itemPrefab2 (0.4 đến 0.5)
        {
            return itemPrefab2;
        }
        else if (randomValue < 0.53f) // Tỷ lệ 3% cho itemPrefab3 (0.5 đến 0.53)
        {
            return itemPrefab3;
        }
        else
        {
            // Trường hợp không có gì xảy ra (có thể không sinh ra vật phẩm)
            return null;
        }
    }
}
