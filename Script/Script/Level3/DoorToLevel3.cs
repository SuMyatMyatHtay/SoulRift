using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToLevel3 : MonoBehaviour
{
    private Animator _ani;
    public GuardsMain[] guardsMainArray;

    private void Start()
    {
        _ani = gameObject.GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        StartCoroutine(Reveal());
    }

    private IEnumerator Reveal()
    {
        gameObject.isStatic = false;
        yield return new WaitForSeconds(5f);
        _ani.SetTrigger("Reveal");

        foreach (var guardsMainScript in guardsMainArray)
        {
            guardsMainScript.doorOpened = true;
        }
    }
}
