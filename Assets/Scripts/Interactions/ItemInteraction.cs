using UnityEngine;

public class ItemInteraction : Interaction
{
    [SerializeField] public Item item;
    [TextArea] [SerializeField] private string description;
    public bool isOnGround;

    public override void Interact()
    {
        if (item == null)
        {
            gameManager.ShowText(description);
        }
        else
        {
            if (gameManager.AddItem(item))
            {
                item = null;
                if (isOnGround)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
