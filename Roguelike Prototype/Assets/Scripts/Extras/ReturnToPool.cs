using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{

    [SerializeField] private float lifeTime = 2f;
    private Projectile projectile;

    private void Start() 
    {
        projectile = GetComponent<Projectile>();
    }

    private void Return() 
    {

        if(projectile != null)
        {
            projectile.ResetProjectile(); // Resets flip, otherwise doesn't keep up always and shows wrong side
        }
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        // Invoke runs the method "Return" after time lifeTime. Delayed run.
        Invoke(nameof(Return), lifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke(); 
    }
}
