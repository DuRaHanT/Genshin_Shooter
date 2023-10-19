using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    InventoryMainWeapon inventoryMainWeapon;
    InventotyGrenade inventotyGrenade;

    [SerializeField] GameObject MainWeapon;
    [SerializeField] GameObject Grenade;

    void Awake()
    {
        inventoryMainWeapon = GetComponent<InventoryMainWeapon>();
        inventotyGrenade = GetComponent<InventotyGrenade>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetMouseButtonDown(2)) InventoryCheck();
    }

    void InventoryCheck()
    {
        if (MainWeapon.activeSelf == true) inventoryMainWeapon.ViewInventory();
        else if (Grenade.activeSelf == true) inventotyGrenade.ViewInventory();
    }
}
