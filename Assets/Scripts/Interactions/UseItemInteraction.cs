using UnityEngine;

abstract public class UseItemInteraction : Interaction
{
    [SerializeField] public Item necessaryItem;

    public override void Interact()
    {
        gameManager.ChooseItem(this);
    }
    
    abstract public void CorrectItem();

    public void WrongItem()
    {
        gameManager.ShowText("Nada acontece");
    }
}
