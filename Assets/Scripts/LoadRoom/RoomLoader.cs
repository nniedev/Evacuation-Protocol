using System.Collections.Generic;
using UnityEngine;

public class RoomLoader : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject dropedItemPrefab;
    [SerializeField] public string roomName;
    [Tooltip("Sala para qual essa porta leva")] 
    [SerializeField] public List<string> roomDoor;
    [SerializeField] public List<Transform> spawnPosition;
    [SerializeField] public List<GameObject> initialCamera;
    protected GameManager gameManager;

    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.LoadRoom(this);
    }
    
    // Chamada pelo Game Manager
    public void Load(List<DropedItem> items, string pastRoom)
    {
        SpawnPlayer(roomDoor.IndexOf(pastRoom));
        SpawnItems(items);
        DoOnLoad();
    }
    
    public void Load(string pastRoom)
    {
        SpawnPlayer(roomDoor.IndexOf(pastRoom));
        DoOnLoad();
    }

    private void SpawnPlayer(int index)
    {
        Instantiate(playerPrefab,
            spawnPosition[index].position,
            spawnPosition[index].rotation);
        initialCamera[index].SetActive(true);
    }

    private void SpawnItems(List<DropedItem> items)
    {
        foreach (var x in items)
        {
            GameObject itemA = Instantiate(dropedItemPrefab, x.Position, x.Rotation);
            ItemInteraction itemInfos = itemA.GetComponent<ItemInteraction>();
            itemInfos.item = x.item;
            itemInfos.isOnGround = true;
        }
    }

    protected void DoOnLoad()
    {
        
    }
}
