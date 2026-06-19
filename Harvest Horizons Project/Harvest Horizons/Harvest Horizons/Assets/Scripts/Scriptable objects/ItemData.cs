using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public ItemType itemType;
    public GameObject cropPrefab;
    public int sellValue;

}
public enum ItemType
{
    Hoe,
    Seed,
    WateringCan,
    None

}