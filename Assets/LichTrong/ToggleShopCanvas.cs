using UnityEngine;

public class ToggleShopCanvas : MonoBehaviour
{
    // Reference to the Canvas with the "shop" tag
    private GameObject shopCanvas;

    void Start()
    {
        // Find the GameObject with the tag "shop"
        shopCanvas = GameObject.FindGameObjectWithTag("shop");
        if (shopCanvas != null)
        {
            // Ensure the canvas is initially hidden
            shopCanvas.SetActive(false);
        }
        else
        {
            Debug.LogError("No GameObject with the tag 'shop' found.");
        }
    }

    void Update()
    {
        if (shopCanvas != null)
        {
            // Show the canvas when the "Q" key is pressed
            if (Input.GetKeyDown(KeyCode.Q))
            {
                shopCanvas.SetActive(true);
            }

            // Hide the canvas when the "Q" key is released
            if (Input.GetKeyUp(KeyCode.Q))
            {
                shopCanvas.SetActive(false);
            }
        }
    }
}
