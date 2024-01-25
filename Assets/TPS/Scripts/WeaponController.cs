using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class WeaponController : MonoBehaviour
{
    Weapon currentWeapon;

    [SerializeField]
    GameObject normalCrosshair;

    [SerializeField]
    GameObject disabledCrosshair;

    List<Weapon> weapons;

    // Start is called before the first frame update
    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>(true).ToList();
        ChangeWeapon(0);
    }

    private void ChangeWeapon(int weaponIndex)
    {
        if(currentWeapon != null)
        {
            currentWeapon.IsPossibleToAttackChanged -= OnIsPossibleToAttackChanged;
            currentWeapon.gameObject.SetActive(false);
        }
        currentWeapon = weapons[weaponIndex];
        currentWeapon.gameObject.SetActive(true);
        currentWeapon.IsPossibleToAttackChanged += OnIsPossibleToAttackChanged;
    }

    private void OnIsPossibleToAttackChanged(bool isPossibleToAttack)
    {
        normalCrosshair.SetActive(isPossibleToAttack);
        disabledCrosshair.SetActive(!isPossibleToAttack);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWeapon.ControlPress("Fire1"))
        {
            currentWeapon.Attack();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeWeapon(2);

    }
}
