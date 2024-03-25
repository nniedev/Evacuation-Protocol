using UnityEngine;

public class DocumentInteraction : Interaction
{
    [TextArea][SerializeField] private string documentText;

    public override void Interact()
    {
        gameManager.ShowDocument(documentText);
    }
}
