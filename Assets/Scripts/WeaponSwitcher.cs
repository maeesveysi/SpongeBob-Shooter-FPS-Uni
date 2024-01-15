using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private int selectedweapon =0;
    // Start is called before the first frame update
    void Start()
    {
        Selectedweapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedweapon = selectedweapon;

         if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedweapon >= transform.childCount - 1)
            {
                selectedweapon = 0;

            }
            else 
            {
                selectedweapon += 1;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedweapon <= 0)
            {
                selectedweapon = transform.childCount -1;

            }
            else 
            {
                selectedweapon -= 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedweapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedweapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedweapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedweapon = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedweapon = 4;
        }
        if (previousSelectedweapon !=selectedweapon)
        {
            Selectedweapon();
        }
       
         
    }

    void Selectedweapon()
    {
        int i  = 0;
        foreach (Transform _weapon in transform)
        {
            if (i == selectedweapon)
            {
                _weapon.gameObject.SetActive(true);
            }
            else 
            {
                _weapon.gameObject.SetActive(false);
            }

            i++;
        }

    }
}
