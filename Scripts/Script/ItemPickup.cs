using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item; 

    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject); 
        //gameObject.SetActive(false);
    }

    public void OnMouseDownFunction()
    {
        Pickup(); 
    }

}
