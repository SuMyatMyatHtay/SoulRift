using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScreen : MonoBehaviour
{
    public GameObject cam_obj;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 _pos = cam_obj.transform.position + cam_obj.transform.forward * 6f;
        _pos = new Vector3(_pos.x, cam_obj.transform.position.y, _pos.z);
        transform.position = _pos;
        transform.LookAt(cam_obj.transform.position);
    }
}
