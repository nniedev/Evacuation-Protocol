using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : Interaction
{
    [SerializeField] private string doorSceneName;
    [SerializeField] private string nextRoomSceneName;
    public override void Interact()
    {
        gameManager.SetNextRoom(nextRoomSceneName);
        SceneManager.LoadScene(doorSceneName);
    }
}
