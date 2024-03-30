using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Inventário")]
    [SerializeField] private GameObject inventoryHolder;
    [SerializeField] private int inventorySize;
    [SerializeField] private List<Item> inventory;
    [SerializeField] private List<Image> holders;
    [SerializeField] private GameObject itemOnGroundPrefab;
    
    [Header("Timer")] 
    [SerializeField] private float totalTime;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private bool timerIsPaused;
    [SerializeField] private float remainingTime;
    
    [Header("Interações")]
    [SerializeField] private GameObject textHolder;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject documentHolder;
    [SerializeField] private TMP_Text documentText;
    [SerializeField] private bool isChoosingItem;
    [SerializeField] private bool isFirstClose;
    private UseItemInteraction uii;

    [Header("Fim de Jogo")]
    [SerializeField] private string BadEndingScene;
    [SerializeField] private string NormalEndingScene;
    [SerializeField] private string GoodEndingScene;
    
    // Room Loader
    [Tooltip("Inicializar com o noma da sala inicial")]
    [SerializeField] public string currentRoom;
    private List<DropedItem> dropedItems;
    [SerializeField] public string nextRoom;
    
    // Misc
    private bool inputDetected = false;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Start") == 1)
        {
            Destroy(gameObject);
        }
        else
        {
            PlayerPrefs.SetInt("Start",1);
            PlayerPrefs.SetInt("Reator",0);
        }
    
        dropedItems = new System.Collections.Generic.List<DropedItem>();
        DontDestroyOnLoad(this.gameObject);

        remainingTime = totalTime * 60;
        StartCoroutine(TimerCoroutine());
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Start",0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryHolder.SetActive(!inventoryHolder.activeSelf);
            isFirstClose = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && inventoryHolder.activeSelf)
        {
            if (!isFirstClose)
            {
                inventoryHolder.SetActive(false);
                isChoosingItem = false;
            }

            isFirstClose = false;
        }
    }
    
    // Room Loader
    public void SetNextRoom(string room)
    {
        nextRoom = room;
    }
    
    public void LoadRoom(RoomLoader rl)
    {
        string pastRoom = currentRoom;
        currentRoom = rl.roomName;
       /* if (rl.roomName == "Lab")
        {
            DeixarLabFoda();
        }*/
        List<DropedItem> itemList = FilterItems((rl.roomName));

        if (itemList.Count == 0)
        {
            rl.Load(pastRoom);
        }
        else
        {
            rl.Load(itemList,pastRoom);
        }
    }

   /* public void DeixarLabFoda()
    {
       GameObject.Find("LuzAAA").GetComponent<Light>().color = Color.blue;
       GameObject.Find("LuzAAA").GetComponent<Light>().color = Color.blue;
       GameObject.Find("LuzEmergencia").GetComponent<Spin>().rotationSpeed = 125;
    }*/

    private List<DropedItem> FilterItems(string roomname)
    {
        List<DropedItem> filtredList = new List<DropedItem>();
        if (dropedItems == null || dropedItems.Count == 0)
        {
            return filtredList;
        }
        foreach (var x in dropedItems)
        {
            if (x.Room == roomname)
            {
                filtredList.Add(x);
            }
        }
        
        return filtredList;
    }
    
    // Inventário
    public bool AddItem(Item item)
    {
        if (inventory.Count < inventorySize)
        {
            inventory.Add(item);
            holders[inventory.Count - 1].sprite = item.sprite;
            if (item.isFeminine)
            {
                ShowText("Você pega uma " + item.itemName);
            }
            else
            {
                ShowText("Você pega um " + item.itemName);
            }
            return true;
        }
        else
        {
            if (item.isFeminine)
            {
                ShowText("Você ve uma " + item.itemName + " mas não tem espaço para carrega-la");
            }
            else
            {
                ShowText("Você ve um " + item.itemName + " mas não tem espaço para carrega-lo");
            }

            return false;
        }
    }

    public void GetPressedItem(int slot)
    {
        Debug.Log("Prescionado: " + slot + " EscolhendoItem = " + isChoosingItem);
        if (slot < inventory.Count && inventory[slot] != null)
        {
            if (isChoosingItem)
            {
                Debug.Log("Escolhendo Item");
                ReturnChosenItem(inventory[slot]);
            }
            else
            {
                DropItem(slot);
            }
        }
    }
    
    public void DropItem(int slot)
    {
        Debug.Log("Soltando o item");
        GameObject itemA = Instantiate(itemOnGroundPrefab,transform); 
        ItemInteraction itemInfos = itemA.GetComponent<ItemInteraction>();
        itemInfos.item = inventory[slot];
        itemInfos.isOnGround = true;
        inventory.Remove(inventory[slot]);
        holders[slot].sprite = null;
    }
    
    // Timer
    IEnumerator TimerCoroutine()
    {
        while (remainingTime > 0f)
        {
            // Verifica se o timer está pausado
            while (timerIsPaused)
            {
                yield return null; // Aguarda até que o timer não esteja pausado
            }

            // Decrementa o tempo restante
            remainingTime -= Time.deltaTime;
            timerText.text = FormatTimer(remainingTime);

            // Aguarda até o próximo frame
            yield return null;
        }

        // O tempo acabou
        TimeisOver();
    }

    private string FormatTimer(float time)
    {
        int timeInInt = (int)time;
        int minutes = timeInInt / 60;
        int seconds = timeInInt % 60;

        string formatedTime = " ";

        if (seconds < 10)
        {
            formatedTime = minutes + ":" + "0" + seconds;
        }

        if (minutes < 10)
        {
            formatedTime = minutes + ":" + seconds;
            formatedTime = "0" + formatedTime;
        }

        return formatedTime;
    }
    
    private void SoftPause()
    {
        timerIsPaused = !timerIsPaused;
    }

    private void TimeisOver()
    {
        Debug.Log("O tempo acabou");
        SceneManager.LoadScene(BadEndingScene);
    }
    
    // Interações
    public void ChooseItem(UseItemInteraction UII)
    {
        if (inventory.IndexOf(UII.necessaryItem) != -1)
        {
            int a = inventory.IndexOf(UII.necessaryItem);
            inventory.Remove(UII.necessaryItem);
            holders[a].sprite = null;
            UII.CorrectItem();
        }
        else
        {
            UII.WrongItem();
        }
        /*
        uii = UII;
        isChoosingItem = true;
        inventoryHolder.SetActive(true);
        */
    }

    private void ReturnChosenItem(Item chosenItem)
    {
        isChoosingItem = false;
        inventoryHolder.SetActive(false);
        if (chosenItem == uii.necessaryItem)
        {
            uii.CorrectItem();
        }
        else
        {
            uii.WrongItem();
        }
    }
    
    public void ShowText(string newtext)
    {
        text.text = newtext;
        textHolder.SetActive(true);
        StartCoroutine(WaitForInputCoroutine(textHolder));
    }

    public void ShowDocument(string newText)
    {
        documentText.text = newText;
        documentHolder.SetActive(true);
        StartCoroutine(WaitForInputCoroutine(documentHolder));
    }

    IEnumerator WaitForInputCoroutine(GameObject theGameObject)
    {
        SoftPause();
        Debug.Log("Aguardando entrada do jogador...");

        // Loop até que um input seja detectado
        while (!inputDetected)
        {
            // Espera pelo próximo frame
            yield return null;

            // Verifica se algum input foi detectado
            if (Input.anyKeyDown)
            {
                // Define a flag indicando que um input foi detectado
                theGameObject.SetActive(false);
                inputDetected = true;
            }
        }

        // Resetar a flag para permitir que o processo seja executado novamente se necessário
        inputDetected = false;

        // Agora que um input foi detectado, continue com o resto da função
        Debug.Log("Input do jogador detectado!");
        SoftPause();
    }
}
