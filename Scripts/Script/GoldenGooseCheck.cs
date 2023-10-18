using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenGooseCheck : MonoBehaviour
{
    public GameObject ScriptGO;
    public bool GooseIsHere;
    public GameObject popUpScreen;
    public GameObject InventoryManager;
    public Item GooseItem; 
    // Start is called before the first frame update
    void Start()
    {
        GooseIsHere = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("GoldenGoose"))
        {
            GooseIsHere = true;
            //ScriptGO.GetComponent<gateOpen>().toNextScene(); 
            //UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene2");
            Destroy(col.gameObject);
            InventoryManager.GetComponent<InventoryManager>().Remove(GooseItem); 
        }
        else
        {
            Debug.Log("This is not golden goose ");
            popUpScreen.GetComponent<popupWarning>().openPopUp(); 
        }
    }
}
