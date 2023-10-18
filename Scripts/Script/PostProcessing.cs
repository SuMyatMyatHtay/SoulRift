using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    public GameObject cam_obj;
    public float distance; 
    private void Start()
    {
        distance = 1.2f; 
    }

    

    public void UpdateVignetteIntensity(float _health)
    {
        if(_health <= 10)
        {
            distance = 0.5f; 
        }
        else if (_health <= 30)
        {
            distance = 0.6f; 
        }
        else if (_health <= 50)
        {
            distance = 0.7f; 
        }
        else if (_health <= 100)
        {
            distance = 0.8f; 
        }
        else if (_health <= 150)
        {
            distance = 0.9f; 
        }
        else if (_health <= 200)
        {
            distance = 1.0f; 
        }
        else if (_health <= 300)
        {
            distance = 1.1f; 
        }
        else if(_health <= 400)
        {
            distance = 1.2f; 
        }
        else
        {
            distance = 1.3f; 
        }
    
        Vector3 _pos = cam_obj.transform.localPosition + cam_obj.transform.forward * distance;
        _pos = new Vector3(_pos.x, cam_obj.transform.localPosition.y, _pos.z);
        transform.localPosition = _pos;
        transform.LookAt(cam_obj.transform.localPosition);
    }
}
