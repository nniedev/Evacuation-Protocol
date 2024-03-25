using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : Interaction
{
    [SerializeField] private string doorSceneName;
    public override void Interact()
    {
        SceneManager.LoadScene(doorSceneName);
    }
}
