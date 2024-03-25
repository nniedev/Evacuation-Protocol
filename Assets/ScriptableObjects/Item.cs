using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public char sex;
    public Sprite sprite;
    [TextArea] public string description;
}
