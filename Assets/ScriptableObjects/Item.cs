using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public bool isFeminine;
    public Sprite sprite;
    [TextArea] public string description;
}
