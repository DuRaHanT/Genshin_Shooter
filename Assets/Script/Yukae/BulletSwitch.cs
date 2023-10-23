using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BulletSwitch : MonoBehaviour
{
    [SerializeField] Button[] bulletAbilityButton;
    [HideInInspector] public MainWeapon mainWeapon;

    [SerializeField] Image imageBulletIcon;
    [SerializeField] Sprite[] spriteBulletIcon;

    private void Awake()
    {
        mainWeapon = GetComponent<MainWeapon>();

        //for (int i = 0; i < bulletAbilityButton.Length; i++) bulletAbilityButton[i].onClick.AddListener(() => BulletChange(bulletAbilityButton[i].gameObject.name)); 오류 발생
    }

    public void BulletChange(string buttonName)
    {
        if (buttonName == BulletType.Nomal.ToString())
        {
            mainWeapon.BulletType = BulletType.Nomal;
            imageBulletIcon.sprite = spriteBulletIcon[(int)BulletType.Nomal];
        }
        else if (buttonName == BulletType.Burn.ToString())
        {
            mainWeapon.BulletType = BulletType.Burn;
            imageBulletIcon.sprite = spriteBulletIcon[(int)BulletType.Burn];
        }
        else if (buttonName == BulletType.Lightning.ToString())
        {
            mainWeapon.BulletType = BulletType.Lightning;
            imageBulletIcon.sprite = spriteBulletIcon[(int)BulletType.Lightning];
        }
        else if (buttonName == BulletType.Freezing.ToString())
        {
            mainWeapon.BulletType = BulletType.Freezing;
            imageBulletIcon.sprite = spriteBulletIcon[(int)BulletType.Freezing];
        }
    }
}
