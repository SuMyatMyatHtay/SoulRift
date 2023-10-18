using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public Toggle EnableRemove;

    //public List<InventoryItemController> InventoryItems = new List<InventoryItemController>(); 

    private void Awake()
    {
        Instance = this; 
    }

    public void Add(Item item)
    {
        Items.Add(item); 
    }

    public void Remove (Item item)
    {
        Items.Remove(item); 
    }

    public void ListItems()
    {
        //Time.timeScale = 0;
        //cleaning not to duplicate 

        foreach ( Transform item in ItemContent)
        {
            
            Destroy(item.gameObject); 
        }
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("Image").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
            
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            obj.GetComponent<InventoryItemController>().item = item; 
            obj.GetComponent<InventoryItemController>().ItemID = item.id;
            obj.GetComponent<InventoryItemController>().RemoveButton = removeButton; 

            if (EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true); 
            }
            //_GirlObject.GetComponent<GirlMain>()
            
        }
        print(Items.Count+ " prior count"); 
        //SetInventoryItems(); 
    }

    public void EnableItemsRemove()
    {
        if(EnableRemove.isOn)
        {
            foreach(Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true); 
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false); 
            }
        }
    }


    /*
    public void SetInventoryItems()
    {
        //InventoryItems = null;

        //InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
        //InventoryItems.Add()
        GameObject[] inventoryTestings = GameObject.FindGameObjectsWithTag("InventoryTesting");
        foreach(GameObject inventoryTesting in inventoryTestings)
        {

        }

        //print(InventoryItems.Length);
        print(Items.Count + "Items.Count");
        for (int i = 0; i < Items.Count; i++)
        {
            
            //print(InventoryItems[i] + " InventoryItems[i]");
            //print("Items[i]" + Items[i]); 
            //InventoryItems[i].AddItem(Items[i]);
            //print(Items[i] + " Items[i]");
        }
        //print(InventoryItems.Length + " finalCount");

    }
    */
}
