using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Animator animator;
    public Vector3 moveInput;


    private TextMeshProUGUI scoreText; // Tham chiếu đến TextMeshPro để hiển thị điểm số
    private int score = 0; // Biến để lưu trữ điểm số

    private void Awake()
    {
        animator = GetComponent<Animator>();

        // Tự động tìm TextMeshPro trong scene với tên là "ScoreText"
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();

        if (scoreText == null)
        {
            Debug.LogError("ScoreText không được tìm thấy trong scene. Đảm bảo rằng có một đối tượng TextMeshPro trong canvas và tên của nó là ScoreText.");
        }
    }

    private void Start()
    {
        UpdateScoreText(); // Cập nhật điểm số ban đầu trên UI Text
    }

    private void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
        if (moveInput.x != 0)
        {
            float rotationAngle = (moveInput.x > 0) ? 0f : 180f;
            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("loot1"))
        {
            Destroy(collision.gameObject);
            score += 10; // Tăng điểm số thêm 10
            UpdateScoreText(); // Cập nhật UI Text để hiển thị điểm số mới
        }
        else if (collision.CompareTag("loot2") || collision.CompareTag("loot3"))
        {
            Destroy(collision.gameObject); // Tiêu diệt đối tượng loot2 hoặc loot3
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Cập nhật UI Text để hiển thị điểm số
        }
    }
}
