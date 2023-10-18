using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateOpen : MonoBehaviour
{
    public GameObject Player;
    public GameObject eyeCoverPS;
    public GameObject GateButton;
    public GameObject ExitButton; 
    public GameObject Goblin;
    public GameObject ToGoblinGateRef; 
    public GameObject afterEnterGateRef;
    public GameObject GoldenGooseTrigger;
    public GameObject PopupScreen;
    public GameObject GirlMain;

    // Start is called before the first frame update
    void Start()
    {
        //eyeCoverPS.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {

    }


    private System.Collections.IEnumerator WaitAndRunFunction1(int exit)
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(4f);

        // Call function1 after waiting for 5 seconds
        cloudDisappear();

        if(exit == 1)
        {
            print("change scene");
            Goblin.GetComponent<Goblin>()._state = global::Goblin.Goblin_state.mascot;
            AppManager.me.Goblin = true;
            Player.transform.localPosition = ToGoblinGateRef.transform.localPosition;  
            //UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene2"); 
        }
    }

    private System.Collections.IEnumerator TransformFunction1()
    {
        yield return new WaitForSeconds(3f);

        // Call function1 after waiting for 5 seconds
        //Vector3 targetPosition = new Vector3(0f, 0.75f, 12f);
        //Player.transform.position = targetPosition;
        Player.transform.position = afterEnterGateRef.transform.position; 
    }



    

    public void buttonIsClicked()
    {
        Debug.Log("checking BIS");
        //eyeCoverPS = GameObject.Find("CoverPlayerEyes");
        eyeCoverPS.SetActive(true);
        GateButton.SetActive(false);
        StartCoroutine(WaitAndRunFunction1(0));
        StartCoroutine(TransformFunction1());
    }

    public void exitButton()
    {
        if (GoldenGooseTrigger.GetComponent<GoldenGooseCheck>().GooseIsHere == true)
        {
            //toNextScene(); 
            UnityEngine.SceneManagement.SceneManager.LoadScene("MinRuiPart2");
        }
        else
        {
            PopupScreen.GetComponent<popupWarning>().openPopUp(); 
        }
    }

    private void cloudDisappear ()
    {
        eyeCoverPS.SetActive(false);
        GateButton.SetActive(true); 
        Debug.Log("Function1 called after waiting for 5 seconds.");
    }
    // up to this part is of about entering into this game 

    //starting from here if is about checking component and others for the exit. 

    public void toNextScene()
    {
        GirlMain.GetComponent<GirlMain>()._state = global::GirlMain.Girl_state.done;
        eyeCoverPS.SetActive(true);
        ExitButton.SetActive(false);
        StartCoroutine(WaitAndRunFunction1(1));
    }

    public void popUpClose()
    {
        PopupScreen.SetActive(false);
    }
}
