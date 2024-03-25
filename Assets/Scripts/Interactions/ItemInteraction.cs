using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : Interaction
{
    [SerializeField] private Item item;
    [SerializeField] private GameManager gameManager;
    
    private void Star()
    {
    
    }
    public override void Interact()
    {
        gameManager.AddItem(item);
    }
}
