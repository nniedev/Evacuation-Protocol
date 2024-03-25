using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private Transform point;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Physics.Raycast(point.position, transform.forward, out hit, distance);
            if (hit.collider != null && VerifyTag(hit))
            {
                hit.collider.GetComponent<Interaction>().Interact();
            }
            else
            {
                Debug.Log("Sem interação");
            }
        }
    }
    
    private bool VerifyTag(RaycastHit collision)
    {
        List<string> possibleTags = new List<string>()
        {
            "Door", "Text",
            "Document", "Item",
            "Interactable"
        };

        if (possibleTags.Contains(collision.collider.tag))
        {
            return true;
        }

        return false;
    }
}
