using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class GetBackpack : MonoBehaviour
{
    public InputActionProperty Left_sec;

    [Header("Iventory Backpack")]
    public GameObject InventoryBackpack;
    public bool isOpen;
    public GameObject InventoryManager; 
    


    void Start()
    {
        InventoryBackpack.SetActive(false); 
        isOpen = false; 
    }

    void Update()
    {
        if (Left_sec.action.WasPressedThisFrame()){
            print("press theleft secondary key");
            InventoryManager.GetComponent<InventoryManager>().ListItems();
            if (isOpen == true)
            {
                InventoryBackpack.SetActive(false);
                isOpen = false;
                Time.timeScale = 1;
                //InventoryManager.GetComponent<InventoryManager>().ListItems(); 

            }
            else
            {
                InventoryBackpack.SetActive(true); 
                isOpen = true;
                Time.timeScale = 0;
                InventoryManager.GetComponent<InventoryGrabItems>().DisableEveryObject(); 
            }           
        }
        
    }
}
