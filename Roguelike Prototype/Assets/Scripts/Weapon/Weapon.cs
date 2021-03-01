using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private float timeBtwShots = 0.5f;

    [Header("Weapon")]
    [SerializeField] private bool useMagazine = true;
    [SerializeField] private int magazineSize = 30;
    [SerializeField] private bool autoReload = true;

    [Header("Recoil")]
    [SerializeField] private bool useRecoil = true;
    [SerializeField] private int recoilForce = 5;

    // Reference of the Character that controls this weapon
    public Character WeaponOwner { get; set; }

    public WeaponAmmo WeaponAmmo { get; set; }

    public int CurrentAmmo { get; set; }

    public bool UseMagazine => useMagazine; // Lambda, short way of get{return useMagazine;}

    public int MagazineSize => magazineSize;

    public bool CanShoot { get; set; }

    private float nextShotTime;
    private CharacterControls controller;




    void Awake()
    {
        CurrentAmmo = magazineSize;
        WeaponAmmo = GetComponent<WeaponAmmo>();
    }

    private void Update()
    {
        WeaponCanShoot();
        RotateWeapon();
    }

    // Trigger our weapon in order to use it
    public void TriggerShot()
    {
        StartShooting();
    }

    public void StopWeapon() 
    {
        if(useRecoil)
        {
            controller.ApplyRecoil(Vector2.one, 0f); 
        }
    }

    // Makes our weapon start shooting
    // If using magazine, check for ammo. If no ammo, don't shoot. 
    // If weapon doesn't use ammo at all, go nuts. Shoot. 
    private void StartShooting()
    {
        if (useMagazine)
        {
            if (WeaponAmmo != null)
            {
                if (WeaponAmmo.CanUseWeapon()) // If ammo > 0.
                {
                    RequestShot();
                }
                else // If no ammo
                {
                    if (autoReload)
                    {
                        Reload();
                    }
                }
            }
        }
        else
        {
            RequestShot();
        }
    }

    private void RequestShot()
    {
        if(!CanShoot)
        {
            return;
        }

        if(useRecoil)
        {
            Recoil();
        }

        WeaponAmmo.ConsumeAmmo();
        CanShoot = false;

    }

    private void Recoil()
    {
        if (WeaponOwner != null)
        {
            if(WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
            {
                controller.ApplyRecoil(Vector2.left, recoilForce); 
            }
            else
            {

                controller.ApplyRecoil(Vector2.right, recoilForce);
            }
        }
    }

    private void WeaponCanShoot()
    {
        if (Time.time > nextShotTime)
        {
            CanShoot = true;
            nextShotTime = Time.time + timeBtwShots;
        }
    }

    // Reference the owner of this weapon, called in CharacterWeapon.EquipWeapon
    public void SetOwner(Character owner)
    {
        WeaponOwner = owner;
        controller = WeaponOwner.GetComponent<CharacterControls>();
    }

    // Reloads the weaapon
    public void Reload()
    {
        if (WeaponAmmo != null)
        {
            if (useMagazine)
            {
                WeaponAmmo.RefillAmmo();
            }
        }
    }

    private void RotateWeapon()
    {
        if(WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1); 
        }
    }
}
