using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/ItemData")]
public class ItemData : ScriptableObject
{
    public Sprite itemSprite;  // This should be of type Sprite
    public string itemName;
    public int modifyingAmount;
}
