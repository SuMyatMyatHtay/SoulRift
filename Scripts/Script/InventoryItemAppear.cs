using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemAppear : MonoBehaviour
{
    public GameObject cam_obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _pos = cam_obj.transform.position + cam_obj.transform.forward * 4f;
        _pos = new Vector3(_pos.x, cam_obj.transform.position.y, _pos.z);
        transform.position = _pos;
        transform.LookAt(cam_obj.transform.position);
    }
}
