using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input KeyCodes")]
    KeyCode KeyCodeRun = KeyCode.LeftShift;
    KeyCode KeyCodeJump = KeyCode.Space;
    KeyCode KeyCodeReload = KeyCode.R;

    [Header("Audio Clips")]
    [SerializeField]
    AudioClip audioClipWalk;
    [SerializeField]
    AudioClip audioClipRun;

    RotateToMouse rotateToMouse;
    MovementCharacterController movement;
    Status status;
    AudioSource audioSource;
    WeaponBase weapon;
    DebuffBase debuffBase;
    public MainWeapon bullet;

    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rotateToMouse = GetComponent<RotateToMouse>();
        movement = GetComponent<MovementCharacterController>();
        status = GetComponent<Status>();
        audioSource = GetComponent<AudioSource>();
        debuffBase = GetComponent<DebuffBase>();
    }

    void Update() 
    {
        UpdateRotate();
        UpdateMove();
        UpadteJump();
        UpdateWeaponAction();
        debuffBase.UpdateReaction();
        debuffBase.Debuff();
    }
    
    void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotateToMouse.UpdateRotate(mouseX, mouseY);
    }

    void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (x != 0 || z != 0)
        {
            bool isRun = false;

            if (z > 0) isRun = Input.GetKey(KeyCodeRun);

            movement.MoveSpeed = isRun == true ? status.runSpeed : status.walkSpeed;
            audioSource.clip = isRun == true ? audioClipWalk : audioClipWalk;

            if(audioSource.isPlaying == false)
            {
                audioSource.loop = true;
                audioSource.Play();
            }
        }

        else
        {
            movement.MoveSpeed = 0;

            if (audioSource.isPlaying == true) audioSource.Stop();
        }

        movement.MoveTo(new Vector3(x, 0, z));
    }

    void UpadteJump()
    {
        if (Input.GetKeyDown(KeyCodeJump)) movement.Jump();
    }

    void UpdateWeaponAction()
    {
        if (Input.GetMouseButtonDown(0)) weapon.StartWeaponAction();
        else if (Input.GetMouseButtonUp(0)) weapon.StopWeaponAction();

        if (Input.GetMouseButtonDown(1)) weapon.StartWeaponAction(1);
        else if (Input.GetMouseButtonUp(1)) weapon.StopWeaponAction(1);

        if (Input.GetKeyDown(KeyCodeReload)) weapon.StartReload();
    }

    public void TakeDamage(int damage)
    {
        bool isDie = status.DecreaseHp(damage);

        if (isDie == true) Debug.Log("GameOver");
    }

    public void SwitchingWeapon(WeaponBase newWeapon)
    {
        weapon = newWeapon;
    }

    public void EnemyReaction(PlayType type)
    {
        switch(type)
        {
            case PlayType.Burn:
                debuffBase.debuffSetting.isBurn = true;
                break;
            case PlayType.Air:
                debuffBase.debuffSetting.isAir = true;
                break;
            case PlayType.Water:
                debuffBase.debuffSetting.isWater = true;
                break;
            case PlayType.Freezing:
                debuffBase.debuffSetting.isFreezing = true;
                break;
            case PlayType.Lightning:
                debuffBase.debuffSetting.isLightning = true;
                break;
        }
    }

    public void GrenadeReaction(GrenadeType grenade)
    {
        switch (grenade)
        {
            case GrenadeType.Air:
                debuffBase.debuffSetting.isAir = true;
                break;
            case GrenadeType.Water:
                debuffBase.debuffSetting.isWater = true;
                break;
        }
    }
}
