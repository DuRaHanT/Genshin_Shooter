using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventotyGrenade : MonoBehaviour
{
    public GameObject inventory;
    [SerializeField] RotateToMouse camMove;

    GrenadeHUD grenadeHUD;

    bool isState = true;

    void Awake() => grenadeHUD = GetComponent<GrenadeHUD>();

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

            grenadeHUD.SetupAllGrenade(grenadeHUD.grenades);

            camMove.rotCamXAxisSpeed = 0;
            camMove.rotCamYAxisSpeed = 0;
        }
    }

}
