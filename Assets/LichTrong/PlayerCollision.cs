//using UnityEngine;
//using UnityEngine.UI;

//public class PlayerCollision : MonoBehaviour
//{
//    public float maxHealth = 100f;  // Máu tối đa của nhân vật
//    private float currentHealth;
//    private Slider healthSlider;  // Thanh máu UI
//    private HealthSystem healthSystem;

//    void Start()
//    {
//        currentHealth = maxHealth;

//        // Tìm đối tượng có tag "HealthBar" và lấy component Slider
//        GameObject healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
//        if (healthBarObject != null)
//        {
//            healthSlider = healthBarObject.GetComponent<Slider>();
//            if (healthSlider != null)
//            {
//                healthSlider.maxValue = maxHealth;
//                healthSlider.value = maxHealth;  // Khởi tạo giá trị thanh máu
//            }
//        }

//        // Tìm đối tượng HealthSystem (có thể đặt trên cùng một GameObject với script này)
//        healthSystem = GetComponent<HealthSystem>();
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        // Kiểm tra xem đối tượng va chạm có tag "Enemy"
//        if (collision.gameObject.CompareTag("enemy"))
//        {
//            if (healthSystem != null)
//            {
//                // Giảm máu của nhân vật mỗi lần va chạm
//                healthSystem.TakeDamage(5f);
//                // UpdateHealthSlider();
//            }
//        }
//    }

//    // Cập nhật giá trị thanh máu
//    //private void UpdateHealthSlider()
//    //{
//    //    if (healthSlider != null)
//    //    {
//    //        //healthSlider.value = healthSystem.GetCurrentHealth();
//    //    }
//    //}
//}