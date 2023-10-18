using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShoeCheck : MonoBehaviour
{
    public GameObject _GirlObject;
    public GameObject InventoryManager;
    public string targetTag = "RedShoe";
    public AudioSource crying;
    public Item RedShoeItem; 
    // Start is called before the first frame update
    void Start()
    {
        _GirlObject = GameObject.Find("Girl"); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag(targetTag))
        {
            InventoryManager.GetComponent<InventoryManager>().Remove(RedShoeItem);
            crying.Stop();
            // The colliding GameObject has the desired tag.
            //Debug.Log("Collided with object with tag: " + targetTag);
            _GirlObject.GetComponent<GirlMain>()._state = GirlMain.Girl_state.jump;


            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("RedShoe");

            foreach (GameObject obj in objectsWithTag)
            {
                obj.SetActive(false); 
            }
        }
        else
        {
            Debug.Log("This is not red shoe ");
        }
    }
}
