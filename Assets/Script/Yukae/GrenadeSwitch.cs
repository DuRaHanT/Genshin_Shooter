using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeSwitch : MonoBehaviour
{
    [SerializeField] Button[] grenadeAbilityButton;
    [HideInInspector] public Grenade grenade;

    [SerializeField] Image imageGrenadeIcon;
    [SerializeField] Sprite[] spriteGrenadeIcon;

    private void Awake()
    {
        grenade = GetComponent<Grenade>(); 

        //for (int i = 0; i < grenadeAbilityButton.Length; i++) grenadeAbilityButton[i].onClick.AddListener(() => GrenadeChange(grenadeAbilityButton[i].gameObject.name)); 오류 발생
    }

    public void GrenadeChange(string buttonName)
    {
        if (buttonName == GrenadeType.None.ToString())
        {
            grenade.grenadeType = GrenadeType.None;
            imageGrenadeIcon.sprite = spriteGrenadeIcon[(int)GrenadeType.None];
        }
        else if (buttonName == GrenadeType.Air.ToString())
        {
            grenade.grenadeType = GrenadeType.Air;
            imageGrenadeIcon.sprite = spriteGrenadeIcon[(int)GrenadeType.Air];
        }
        else if (buttonName == GrenadeType.Water.ToString())
        {
            grenade.grenadeType = GrenadeType.Water;
            imageGrenadeIcon.sprite = spriteGrenadeIcon[(int)GrenadeType.Water];
        }
    }
}
