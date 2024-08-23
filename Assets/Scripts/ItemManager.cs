using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<ItemData> allItems; // List of all ScriptableObjects
    public List<Item> itemPanels; // List of Item script instances on the UI panels

    private void Start()
    {
        AssignRandomItemsToPanels();
    }

    // Assigns random unique items to the item panels
    private void AssignRandomItemsToPanels()
    {
        // Shuffle the list to randomize the selection
        List<ItemData> shuffledItems = new List<ItemData>(allItems);
        ShuffleList(shuffledItems);

        // Select the first 4 unique items
        for (int i = 0; i < itemPanels.Count; i++)
        {
            itemPanels[i].itemData = shuffledItems[i];
            itemPanels[i].Initialize(); // Call a function to update the UI
        }
    }

    // Shuffles a list using Fisher-Yates algorithm
    private void ShuffleList(List<ItemData> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            ItemData temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
