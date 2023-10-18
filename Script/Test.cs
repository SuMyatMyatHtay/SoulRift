using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update

    public InputActionProperty Left_pri;
    public InputActionProperty Left_sec;
    public InputActionProperty Left_menu;
    public InputActionProperty Right_pri;
    public InputActionProperty Right_sec;
    public InputActionProperty Right_menu;
    void Start()
    {

    }

    // Update is called once per frame
     void Update()
    {
        if (Left_pri.action.WasPressedThisFrame())
        {
            print("press the left primary key");
        }

        if (Left_sec.action.WasPressedThisFrame())
        {
            print("press the left secondary key");
        }

        if (Left_menu.action.WasPressedThisFrame())
        {
            print("press the left menu key");
        }

        if (Right_pri.action.WasPressedThisFrame())
        {
            print("press the right primary key");
        }

        if (Right_sec.action.WasPressedThisFrame())
        {
            print("press the right secondary key");
        }

        if (Right_menu.action.WasPressedThisFrame())
        {
            print("press the right menu key");
        }
    }
}
