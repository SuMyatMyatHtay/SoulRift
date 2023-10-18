using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrabItems : MonoBehaviour
{

    [Header("Inventory Items")]
    public GameObject book;
    public GameObject bookRef; 
    public GameObject redShoes;
    public GameObject redShoesRef;
    public GameObject goldenGoose;
    public GameObject goldenGooseRef;

    // Start is called before the first frame update
    void Start()
    {
        DisableEveryObject(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableEveryObject()
    {
        book.SetActive(false);
        bookRef.SetActive(false); 
        redShoes.SetActive(false);
        redShoesRef.SetActive(false);
        goldenGoose.SetActive(false);
        goldenGooseRef.SetActive(false); 

    }

    public void BookRepositioning()
    {
        DisableEveryObject(); 
        book.transform.position = bookRef.transform.position;
        book.SetActive(true); 
        
    }

    public void RedShoesRepositioning()
    {
        DisableEveryObject(); 
        redShoes.transform.position = redShoesRef.transform.position;
        redShoes.SetActive(true); 
    }

    public void GoldenGooseRepositioning()
    {
        DisableEveryObject();
        goldenGoose.transform.position = goldenGooseRef.transform.position;
        goldenGoose.SetActive(true); 
    }
}
