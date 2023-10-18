using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class SceneLoaderToDeath : MonoBehaviour
{

    public void Teleport()
    {
        SceneManager.LoadScene("Death");
    }
}
