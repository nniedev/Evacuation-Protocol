using UnityEngine;

public class DropedItem : MonoBehaviour
{
    public Item item;
    public string Room;
    private Transform transformA;

    public DropedItem(Item dropedItem, Transform itemTransform, string itemRoom)
    {
        item = dropedItem;
        transformA = itemTransform;
        Room = itemRoom;
    }
        
    public Vector3 Position
    {
        get
        {
            return transformA.position;
        }
    }
    public Quaternion Rotation
    {
        get
        {
            return transformA.rotation;
        }
    }
}
