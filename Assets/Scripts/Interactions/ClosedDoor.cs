using UnityEngine;

public class ClosedDoor : UseItemInteraction
{
    [SerializeField] private GameObject doorObject;

    public override void CorrectItem()
    {
        doorObject.SetActive(true);
        Destroy(gameObject);
    }
}
