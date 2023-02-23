using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ship : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public GameObject projectilePrefab;
    public GameObject projectileSpawnPoint;
    public GameObject explosionPrefab;
    public float acceleration;
    public float maxSpeed;
    public int maxArmor;
    public float fireRate;
    public float projectileSpeed;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public int currentArmor;
    protected bool canFire;

    private void Awake()
    {
        currentArmor = maxArmor;
        canFire = true;
    }

    IEnumerator FireRateBuffer()
    {
        canFire = false; 
        yield return new WaitForSeconds(fireRate); 
        canFire = true; 
    }


    public void Thrust()
    {
        myRigidbody2D.AddForce(transform.up * acceleration); 
    }

    private void Update()
    {
        if (myRigidbody2D.velocity.magnitude > maxSpeed) 
        {
            myRigidbody2D.velocity = myRigidbody2D.velocity.normalized * maxSpeed; 
        }
    }

    public void FireProjectile()
    {
        if (canFire)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.transform.position, transform.rotation); 

           // projectile.GetComponent<Projectile>().SetFiringShip(gameObject); 

            projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed); 

            StartCoroutine(FireRateBuffer()); 

            Destroy(projectile, 4); 
        }
       
    } 

    public void TakeDamage(int damageToTake)
    {
        currentArmor = currentArmor - damageToTake;
        if (currentArmor <= 0)
        {
            Expload();
        }
    }

    public void Expload()
    {
        //Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }

}
