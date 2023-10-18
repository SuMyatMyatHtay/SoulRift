using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CBScript : MonoBehaviour
{
    public int CurrentInt;

    public Animator _ani;
    public Animator _aniLower;
    public Animator _aniHigher;

    public List<GameObject> PositionBox;
    public List<GameObject> AnimationBoxes;
    public List<bool> CharacterCheck;
    public List<GameObject> HavePositionBox;
    public List<GameObject> HaveAnimationBoxes;
    //public List<bool> CharacterCheck = new List<bool> { true, false, false, false, true, true, true, true, true};


    public GameObject LeftCornerRef;
    public GameObject RightCornerRef;
    public GameObject CenterRef; 
    
    public Button LeftButton;
    public Button RightButton; 

    // Start is called before the first frame update
    void Start()
    {
        //List<bool> CharacterCheck = new List<bool>();
        //List<bool> CharacterCheck = new List<bool> { true, false, false, false, true, true, true, true, true };


        //Checking with appManager 
        CharacterCheck.Add(AppManager.me.Player); //should be always true;        
        CharacterCheck.Add(AppManager.me.Girl);
        CharacterCheck.Add(AppManager.me.Vampire);
        CharacterCheck.Add(AppManager.me.Goblin); 
        CharacterCheck.Add(AppManager.me.CH30);
        CharacterCheck.Add(AppManager.me.JLayGo);
        CharacterCheck.Add(AppManager.me.Pumpkin);
        CharacterCheck.Add(AppManager.me.Parasite);
        CharacterCheck.Add(AppManager.me.Brute);
        CharacterCheck.Add(AppManager.me.Skeleton);
        
        for(var i = 0; i < CharacterCheck.Count; i++)
        {
            if(CharacterCheck[i]== true)
            {
                HavePositionBox.Add(PositionBox[i]);
                HaveAnimationBoxes.Add(AnimationBoxes[i]);
            }
        }

        //This is the main script
        Debug.Log("Does it run this script");
        CurrentInt = 0;

        LeftButton.interactable = false;
        RightButton.interactable = false;
        LeftCornerRef.SetActive(false);
        RightCornerRef.SetActive(false);
        CenterRef.SetActive(false); 

        /*
        for (var i = 0; i < AnimationBoxes.Count; i++)
        {
            AnimationBoxes[i].SetActive(false);
        }
        */

        HavePositionBox[0].transform.position = CenterRef.transform.position;
        HaveAnimationBoxes[0].SetActive(true); 
        _ani = HaveAnimationBoxes[0].GetComponent<Animator>();
        
        if(CharacterCheck[CurrentInt + 1] == true)
        {
            
            HaveAnimationBoxes[CurrentInt + 1].SetActive(true);
        }
        if (CurrentInt + 1 != HaveAnimationBoxes.Count)
        {
            HavePositionBox[CurrentInt + 1].transform.position = RightCornerRef.transform.position;
            _aniHigher = HaveAnimationBoxes[CurrentInt + 1].GetComponent<Animator>();
            RightButton.interactable = true; 
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private System.Collections.IEnumerator WaitFor1Second(int UpdatedIndex)
    {
        yield return new WaitForSeconds(1.8f);

        CurrentInt = UpdatedIndex;
        print("UpdatedIndex" + UpdatedIndex);

        _ani = HaveAnimationBoxes[CurrentInt].GetComponent<Animator>();
        HavePositionBox[CurrentInt].transform.position = CenterRef.transform.position;

        if(CharacterCheck[CurrentInt] == true)
        {
            HaveAnimationBoxes[CurrentInt].SetActive(true);
        }
        


        if (CurrentInt + 1 != HaveAnimationBoxes.Count)
        {
            _aniHigher = HaveAnimationBoxes[CurrentInt + 1].GetComponent<Animator>();
            HavePositionBox[CurrentInt + 1].transform.position = RightCornerRef.transform.position;
            if(CharacterCheck[CurrentInt + 1] == true)
            {
                HaveAnimationBoxes[CurrentInt + 1].SetActive(true);
            }
            
        }

        if (CurrentInt != 0)
        {
            _aniLower = HaveAnimationBoxes[CurrentInt - 1].GetComponent<Animator>();
            HavePositionBox[CurrentInt - 1].transform.position = LeftCornerRef.transform.position;
            if (CharacterCheck[CurrentInt - 1] == true)
            {
                HaveAnimationBoxes[CurrentInt - 1].SetActive(true);
            }
        }

    }

    /*
    public void gettingComponent(int UpdatedIndex)
    {
        CurrentInt = UpdatedIndex;

        print("UpdatedIndex" + UpdatedIndex);

        _ani = AnimationBoxes[CurrentInt].GetComponent<Animator>();
        PositionBox[UpdatedIndex].transform.position = CenterRef.transform.position;
        AnimationBoxes[UpdatedIndex].SetActive(true);


        if (CurrentInt + 1 != AnimationBoxes.Count)
        {
            _aniHigher = AnimationBoxes[CurrentInt + 1].GetComponent<Animator>();
            PositionBox[CurrentInt + 1].transform.position = RightCornerRef.transform.position;
            AnimationBoxes[CurrentInt + 1].SetActive(true);
        }

        if (CurrentInt != 0)
        {
            _aniLower = AnimationBoxes[CurrentInt - 1].GetComponent<Animator>();
            PositionBox[CurrentInt - 1].transform.position = LeftCornerRef.transform.position;
            AnimationBoxes[CurrentInt - 1].SetActive(true);
        }

        
        PositionBox[0].transform.position = CenterRef.transform.position;
        AnimationBoxes[0].SetActive(true);
        _ani = AnimationBoxes[0].GetComponent<Animator>();
        PositionBox[1].transform.position = RightCornerRef.transform.position;
        AnimationBoxes[1].SetActive(true);
        _aniHigher = AnimationBoxes[1].GetComponent<Animator>();
        
    }
    */

    public void LeftButtonF()
    {
        if (CurrentInt == 1)
        {
            LeftButton.interactable = false; 
        }
        RightButton.interactable = true;

        _ani.SetTrigger("moveRight");
        _aniLower.SetTrigger("moveRight");
        StartCoroutine(WaitFor1Second(CurrentInt - 1));
        

    }

    public void RightButtonF()
    {
        Debug.Log("RightButtonisClicked"); 
        if (CurrentInt + 2 == HaveAnimationBoxes.Count)
        {
            RightButton.interactable = false; 

        }
        LeftButton.interactable = true; 

        _ani.SetTrigger("moveLeft"); 
        _aniHigher.SetTrigger("moveLeft");
        StartCoroutine(WaitFor1Second(CurrentInt + 1));

        /*
        if (CurrentInt + 2 == AnimationBoxes.Count)
        {
            //Debug.Log("this is true");
            RightButton.SetActive(false);
            _aniHigher = AnimationBoxes[CurrentInt + 1].GetComponent<Animator>();
            PositionBox[CurrentInt + 1].transform.position = RightCornerRef.transform.position;
        }
        
        AnimationBoxes[CurrentInt + 1].SetActive(true);
        PositionBox[CurrentInt + 1].transform.position = LeftCornerRef.transform.position;
        
        
        //_aniHigher.SetTrigger("moveRight");
        _ani.SetTrigger("moveRight");

        LeftButton.SetActive(true);
        //AnimationBoxes[CurrentInt].SetActive(false);
        //CurrentInt += 1;
        //AnimationBoxes[CurrentInt].SetActive(true);

        CurrentInt += 1;
        _ani = AnimationBoxes[CurrentInt].GetComponent<Animator>();
        
        _aniLower = AnimationBoxes[CurrentInt - 1].GetComponent<Animator>();
        PositionBox[CurrentInt - 1].transform.position = LeftCornerRef.transform.position;
        */

    }

    public void BackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameMenu");
    }

}
