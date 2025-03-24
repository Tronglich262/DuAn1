using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();

    Loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach( Loot item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
             
            }
        }
        if(possibleItems.Count > 0 )
        {
            Loot dropedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return dropedItem;
        }
        Debug.Log("No loot droped");
        return null;
    }
    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot dropedItem = GetDroppedItem();
        if (dropedItem != null)
        {
            Debug.Log("Dropping loot: " + dropedItem.lootName); // Debug log

            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = dropedItem.lootSprite;

            float dropForce = 300f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
        }
        else
        {
            Debug.Log("No loot dropped"); // Debug log
        }
    }

}
