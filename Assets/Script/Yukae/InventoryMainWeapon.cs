using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMainWeapon : MonoBehaviour
{
    [Header("Inventory")]
    public GameObject inventory;
    [SerializeField] Image inventoryImage;

    [SerializeField] RotateToMouse camMove;
    [SerializeField] WeaponBase[] weaponBases;

    bool isState = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetMouseButtonDown(2)) ViewInventory();
    }

    void ViewInventory() 
    {
        if (inventory.activeSelf == isState)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            inventory.SetActive(!isState);

            camMove.rotCamXAxisSpeed = 5;
            camMove.rotCamYAxisSpeed = 5;
        }
        else if (inventory.activeSelf == !isState)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            inventory.SetActive(isState);

            camMove.rotCamXAxisSpeed = 0;
            camMove.rotCamYAxisSpeed = 0;
        }
    }
}
