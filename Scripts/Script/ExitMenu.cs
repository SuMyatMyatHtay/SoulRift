using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExitMenu : MonoBehaviour
{
    [Header("Exit Screen")]
    public InputActionProperty Left_menu;
    public bool isOpen;    
    public GameObject ExitScreen;
    public GameObject eyeCoverPS;

    // Start is called before the first frame update
    void Start()
    {
        ExitScreen.SetActive(false);
        isOpen = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Left_menu.action.WasPressedThisFrame())
        {

            if (isOpen == true)
            {
                ExitScreen.SetActive(false);
                isOpen = false;
                Time.timeScale = 1;

            }
            else
            {
                ExitScreen.SetActive(true);
                isOpen = true;
                Time.timeScale = 0;
            }
        }
    }

    private System.Collections.IEnumerator GoBackMenu()
    {
        yield return new WaitForSeconds(3f);

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameMenu");
    }

    public void YesButton()
    {
        isOpen = false;
        Time.timeScale = 1; 
        eyeCoverPS.SetActive(true);
        StartCoroutine(GoBackMenu());
    }

    public void NoButton()
    {
        ExitScreen.SetActive(false);
        isOpen = false;
        Time.timeScale = 1; 
    }
}
