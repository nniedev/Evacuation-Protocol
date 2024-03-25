using UnityEngine;

abstract public class Interaction : MonoBehaviour
{
    protected GameManager gameManager;
    
    private void Start()
    {
        Debug.Log("Achou?");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    abstract public void Interact();
}
