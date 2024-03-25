using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryHolder;
    [SerializeField] private int ineventorySize;
    [SerializeField] private List<Item> items;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryHolder.SetActive(!inventoryHolder.activeSelf);
        }
    }

    public void AddItem(Item item)
    {
    }
    
    public void DropItem(int slot)
    {
        Debug.Log("Drop " + slot);
    }
    
    
}
