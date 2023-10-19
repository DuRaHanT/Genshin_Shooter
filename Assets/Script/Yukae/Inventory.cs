using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    [Header("Inventory")]
    [SerializeField] GameObject inventory;
    [SerializeField] Image inventoryImage;

    bool isState = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetMouseButtonDown(2)) ViewInventory();
    }

    void ViewInventory() 
    {
        if (inventory.activeSelf == isState)
        {
            Cursor.lockState = CursorLockMode.Locked;
            inventory.SetActive(!isState);
        }
        else if (inventory.activeSelf == !isState)
        {
            // ķ ���� + ���� ���� �߰�
            Cursor.lockState = CursorLockMode.None;
            inventory.SetActive(isState);
        }
    }
}
