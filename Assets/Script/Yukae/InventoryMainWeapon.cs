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

    bool isState = true;

    public void ViewInventory() 
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
