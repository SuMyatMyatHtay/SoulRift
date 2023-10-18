using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InventoryItemController : MonoBehaviour
{
    public Item item;
    public int ItemID; 
    public Button RemoveButton;
    //public GameObject testingGO; 

    

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        //Destroy(gameObject); 
    }

    public void AddItem(Item newItem)
    {
        print(newItem + " newItem"); 
        item = newItem;
        print(item + " item");
    }

    public void UseItem()
    {
        print(item);

        if(item.id == 3)
        {
            InventoryManager.Instance.GetComponent<InventoryGrabItems>().BookRepositioning(); 
            //testing.transform.localPosition = new Vector3(0.147f, 0.038f, 0.255f);
            InventoryManager.Instance.GetComponent<InventoryGrabItems>().book.SetActive(true); 
        }

        if (item.id == 10)
        {
            InventoryManager.Instance.GetComponent<InventoryGrabItems>().RedShoesRepositioning();
            InventoryManager.Instance.GetComponent<InventoryGrabItems>().redShoes.SetActive(true);
        }

        if (item.id == 11)
        {
            InventoryManager.Instance.GetComponent<InventoryGrabItems>().GoldenGooseRepositioning();
            InventoryManager.Instance.GetComponent<InventoryGrabItems>().goldenGoose.SetActive(true);
        }

        /*
         switch (item.itemType)
        {
            case Item.ItemType.Potion:
                print("this is potion");
                break;
            case Item.ItemType.Book:
                print("this is book");
                break; 
        }
        RemoveItem(); 
        */

    }
}
