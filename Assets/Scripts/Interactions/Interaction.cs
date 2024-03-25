using UnityEngine;

abstract public class Interaction : MonoBehaviour
{
    protected GameManager gameManager;
    
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    abstract public void Interact();
}
