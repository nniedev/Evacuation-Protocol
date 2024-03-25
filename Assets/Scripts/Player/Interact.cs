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
            if (Physics.Raycast(point.position, transform.forward, out hit, distance))
            {
                if (hit.collider.CompareTag("Text"))
                {
                    Debug.Log("Text");
                }
                else if (hit.collider.CompareTag("Door"))
                {
                    Debug.Log("Bateu em outra coisa");
                }
                else if (hit.collider.CompareTag("Item"))
                {
                    
                }
                else if(hit.collider.CompareTag("Interactable"))
                {
                     
                }
                else if (hit.collider.CompareTag("Document"))
                {
                    
                }
                else
                {
                    Debug.Log("Nenhuma interação");
                }
            }
        }
    }
}
