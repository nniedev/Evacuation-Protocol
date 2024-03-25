using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentInteraction : Interaction
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private string documentText;
    
    public override void Interact()
    {
        gameManager.ShowDocument(documentText);
    }
}
