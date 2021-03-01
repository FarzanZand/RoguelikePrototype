using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : CharacterComponents
{

    // Inherits from CharacterComponents
    // Each Weapon hold the default weapon logic 
    // This class works more like the controller 
    [Header("Weapon Settings")]
    [SerializeField] private Weapon weaponToUse;
    [SerializeField] private Transform weaponHolderPosition;

    public Weapon CurrentWeapon { get; set; }
    public WeaponAim WeaponAim { get; set; }
    protected override void Start()
    {
        base.Start();
        EquipWeapon(weaponToUse, weaponHolderPosition); 
    }

    protected override void HandleInput()
    {
        if(Input.GetMouseButton(0))
        {
            Shoot();
        }

        if(Input.GetMouseButtonUp(0))
        {
            StopWeapon(); 
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload(); 
        }
    }


    public void Shoot() 
    {
        if(CurrentWeapon == null)
        {
            return; 
        }

        CurrentWeapon.TriggerShot();
        UpdateWeaponUI();
    }

    public void StopWeapon()
    {
        if(CurrentWeapon == null)
        {
            return;
        }
        CurrentWeapon.StopWeapon();
    }

    // Reload Weapon
    public void Reload()
    {
        if (CurrentWeapon == null)
        {
            return;
        }

        CurrentWeapon.Reload();
        UpdateWeaponUI();
    }

    // Equip the weapon we Specify
    public void EquipWeapon(Weapon weapon, Transform weaponPosition)
    {
        CurrentWeapon = Instantiate(weapon, weaponPosition.position, weaponPosition.rotation);
        CurrentWeapon.transform.parent = weaponPosition;
        CurrentWeapon.SetOwner(character);
        WeaponAim = CurrentWeapon.GetComponent<WeaponAim>();
        UpdateWeaponUI();
    }

    // Update Ammo count on weapon UI
    public void UpdateWeaponUI()
    {
        if (character.CharacterType == Character.CharacterTypes.Player)
        {
            UIManager.Instance.UpdateAmmo(CurrentWeapon.CurrentAmmo, CurrentWeapon.MagazineSize); // New weapon updates ammo in UI
        }
    }
}
