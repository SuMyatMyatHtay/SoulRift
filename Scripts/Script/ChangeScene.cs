using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene1");
    }

    public void goCardCollection()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CollectionBook");
       
    }
}
