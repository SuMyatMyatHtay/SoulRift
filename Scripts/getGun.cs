using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.InputSystem;

public class getGun : MonoBehaviour

{

    public GameObject Selected_gun;

    public GameObject Ungrabbed_gun;

    public InputActionProperty Left_pri;

    // Update is called once per frame 

    private void Start()

    {

        Selected_gun = GameObject.FindWithTag("Selected_Weapon");

        Ungrabbed_gun = GameObject.FindWithTag("Ungrabbed_Weapon");

        Selected_gun.SetActive(false);

    }

    void Update()

    {

        if (Left_pri.action.WasPressedThisFrame())

        {

            if (Selected_gun.activeSelf == false)

            {

                Selected_gun.SetActive(true);

                Ungrabbed_gun.SetActive(false);

            }

            else

            {


                Selected_gun.SetActive(false);

                Ungrabbed_gun.SetActive(true);

            }

        }

    }

}