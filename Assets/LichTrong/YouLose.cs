using UnityEngine;

public class YouLose : MonoBehaviour
{
    public GameObject youLose; // UI hiển thị khi thua
    [SerializeField] private PlayerHealth playerHealth;

    void Update()
    {
        if (playerHealth == true)
        {
            youLose.SetActive(true);
            Time.timeScale = 0;
        }
    }
}