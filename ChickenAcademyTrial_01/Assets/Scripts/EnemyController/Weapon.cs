using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapons")]
    public GameObject pistol;
    public GameObject kalasnikof;
    public GameObject bazooka;

    //public int selectedWeapon = 0;
    void Start()
    {
        pistol.SetActive(true);
        kalasnikof.SetActive(false);
        bazooka.SetActive(false);
       // selectedWeapon = 0;
    }

    //public void SelectWeapon()
    //{
    //    int previousSelectedWeapon = selectedWeapon;

    //    selectedWeapon = 1;
    //    ////if(firstupgradehassold)
    //    ////if(secondupg....

    //    ////if (Input.GetKeyDown(KeyCode.Alpha1))
    //    ////{
    //    ////    selectedWeapon = 0;
    //    ////}
    //    //if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
    //    //{
    //    //    selectedWeapon = 1;
    //    //}
    //    ////if (Input.GetKeyDown(KeyCode.Alpha3)&& transform.childCount >=2)
    //    ////{
    //    ////    selectedWeapon = 2;
    //    ////}
    //    //if (previousSelectedWeapon != selectedWeapon)
    //    //{
    //    //    SelectWeapon();
    //    //}
    //}

    void Update()
    {
        WeaponChange();
        //SelectWeapon();
        //int i = 0;
        //foreach (Transform weapon in transform)
        //{
        //    if (i == selectedWeapon)
        //        weapon.gameObject.SetActive(true);
        //    else
        //        weapon.gameObject.SetActive(false);
        //    i++;
        //}
    }
    public void WeaponChange()
    {
        if (UIManager.Instance.ak47Activated)
        {
            pistol.SetActive(false);
            bazooka.SetActive(false);
            kalasnikof.SetActive(true);
        }
        if (UIManager.Instance.bazookaActivated)
        {

            pistol.SetActive(false);
            bazooka.SetActive(true);
            kalasnikof.SetActive(false);
        }
    }

}


