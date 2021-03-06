using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotWeapon : Weapon
{

    [SerializeField] private Vector3 projectileSpawnPosition;
    [SerializeField] private Vector3 projectileSpread; 

    public Vector3 ProjectileSpawnPosition { get; set; }
    public ObjectPooler Pooler { get; set; }

    private Vector3 projectileSpawnValue;
    private Vector3 randomProjectileSpread; 

    protected override void Awake()
    {
        base.Awake();
        projectileSpawnValue = projectileSpawnPosition;
        projectileSpawnValue.y = -projectileSpawnPosition.y;

        Pooler = GetComponent<ObjectPooler>(); 

    }

    protected override void RequestShot()
    {
        base.RequestShot(); // Fire

        // CanShoot taken from Weapon parent
        if(CanShoot)
        {
            EvaluateProjectileSpawnPosition(); 
            SpawnProjectile(ProjectileSpawnPosition);
        }
    }

    private void SpawnProjectile(Vector2 spawnPosition)
    {
        // Store the gameobject from pool
        GameObject projectilePooled = Pooler.GetObjectFromPool();
        projectilePooled.transform.position = spawnPosition;
        projectilePooled.SetActive(true);

        Projectile projectile = projectilePooled.GetComponent<Projectile>();

        // Spread logic
        randomProjectileSpread.z = Random.Range(-projectileSpread.z, projectileSpread.z);
        Quaternion spread = Quaternion.Euler(randomProjectileSpread); 

        // Shorter if/else. If FacingRight = true, Vector2.right (?), else (:) Vector2.Left
        Vector2 newDirection = WeaponOwner.GetComponent<CharacterFlip>().FacingRight ? spread * transform.right : spread * transform.right * -1;
        projectile.SetDirection(newDirection, transform.rotation, WeaponOwner.GetComponent<CharacterFlip>().FacingRight);

        CanShoot = false; // Resets to true in Weapon after cooldown
    }

    private void EvaluateProjectileSpawnPosition()
    {
        if(WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
        {
        ProjectileSpawnPosition = transform.position + transform.rotation * projectileSpawnPosition;
        }
        else
        {
            ProjectileSpawnPosition = transform.position - transform.rotation * projectileSpawnValue; 
        }
    }

    private void OnDrawGizmosSelected() 
    {
        EvaluateProjectileSpawnPosition();
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(ProjectileSpawnPosition, 0.1f);
    }
}
