using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class popupWarning : MonoBehaviour
{

    public TextMeshProUGUI TextComponent;
    public GameObject cam_obj;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        TextComponent.text = "You need to find golden goose first!";
        Vector3 _pos = cam_obj.transform.position + cam_obj.transform.forward * 6f;
        _pos = new Vector3(_pos.x, cam_obj.transform.position.y + 2f, _pos.z);
        transform.position = _pos;
        transform.LookAt(cam_obj.transform.position);
    }

    public void openPopUp()
    {
        gameObject.SetActive(true);
        StartCoroutine(WaitForPopUpToClose());
    }

    private System.Collections.IEnumerator WaitForPopUpToClose()
    {
        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
    }

}
