using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemData itemData;  // Assigned ScriptableObject
    public Image itemSprite;
    public TextMeshProUGUI itemName;

    // Updates the UI elements with data from the ScriptableObject
    public void Initialize()
    {
        itemName.text = itemData.itemName;
        itemSprite.sprite = itemData.itemSprite;
    }
}
