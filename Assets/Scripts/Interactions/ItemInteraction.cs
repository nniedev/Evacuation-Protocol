using UnityEngine;

public class ItemInteraction : Interaction
{
    [SerializeField] private Item item;

    public override void Interact()
    {
        gameManager.AddItem(item);
    }
}
