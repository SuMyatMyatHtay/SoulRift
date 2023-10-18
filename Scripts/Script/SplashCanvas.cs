using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashCanvas : MonoBehaviour
{

    public GameObject cam_obj;
    public GameObject Left_Hand;
    public GameObject Right_Hand; 
    // Start is called before the first frame update
    public float Countdown = 3.0f;
    // Start is called before the first frame update
    private void Start()
    {
        Left_Hand.SetActive(false);
        Right_Hand.SetActive(false); 
        StartCoroutine(LoadScene(Countdown));
        
    }

    IEnumerator LoadScene(float amount)
    {
        yield return new WaitForSeconds(amount);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
