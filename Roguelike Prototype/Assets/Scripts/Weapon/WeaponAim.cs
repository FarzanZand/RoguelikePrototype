using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{

    // Places a reticle on mouse location
    // Reticle is instantiated, get mouse position on screen. 
    // Clamped mouse position to 5, so mouse is never outside of camera. 

    [SerializeField] private GameObject reticlePrefab;

    public float CurrentAimAngleAbsolute { get; set; }
    public float CurrentAimAngle { get; set; }

    private Camera mainCamera;
    private GameObject reticle;
    private Weapon weapon; 

    private Vector3 direction;
    private Vector3 mousePosition;
    private Vector3 reticlePosition;
    private Vector3 currentAim = Vector3.zero;
    private Vector3 currentAimAbsolute = Vector3.zero;
    private Quaternion initialRotation;
    private Quaternion lookRotation; 

    void Start()
    {
        Cursor.visible = false;
        weapon = GetComponent<Weapon>();
        initialRotation = transform.rotation;  // Sets Default rotation when game starts

        mainCamera = Camera.main;
        reticle = Instantiate(reticlePrefab);
    }

    void Update()
    {
        GetMousePosition();
        MoveReticle();
        RotateWeapon(); 
    }

    // Get the exact mouse position in order to aim
    private void GetMousePosition()
    {
        // Get Mouse Position
        mousePosition = Input.mousePosition;
        mousePosition.z = 5f;

        // Get World space Position
        direction = mainCamera.ScreenToWorldPoint(mousePosition);
        direction.z = transform.position.z;
        reticlePosition = direction;

        currentAimAbsolute = direction - transform.position;
        if (weapon.WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
        {
            currentAim = direction - transform.position; 
        }
        else
        {
            currentAim = transform.position - direction; 
        }
    }

    private void RotateWeapon()
    {
        if(currentAim != Vector3.zero && direction != Vector3.zero)
        {
            // Get Angle
            CurrentAimAngle = Mathf.Atan2(currentAim.y, currentAim.x) * Mathf.Rad2Deg;
            CurrentAimAngleAbsolute = Mathf.Atan2(currentAimAbsolute.y, currentAimAbsolute.x) * Mathf.Rad2Deg; 

            // Clamp Angle
            if(weapon.WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
            {
                CurrentAimAngle = Mathf.Clamp(CurrentAimAngle, -180, 180); // Clamps angle between min-max
            }
            else
            {
                CurrentAimAngle = Mathf.Clamp(CurrentAimAngle, -180, 180); // Clamps angle between min-max
            }

            // Apply that angle
            lookRotation = Quaternion.Euler(CurrentAimAngle * Vector3.forward);
            transform.rotation = lookRotation; 
        }
        else
        {
            CurrentAimAngle = 0f;
            transform.rotation = initialRotation; 
        }
    }

    // Moves our reticle towards our Mouse Position
    private void MoveReticle()
    {
        reticle.transform.rotation = Quaternion.identity;
        reticle.transform.position = reticlePosition; 
    }
}
