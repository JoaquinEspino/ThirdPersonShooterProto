using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    [Range(0.2f, 1.5f)]
    private float fireRate = 1;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public ParticleSystem deathParticles;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red, 2f);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100))
        {

            var health = hitInfo.collider.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            Instantiate(deathParticles, hitInfo.point, Quaternion.identity);

        }
    }
}
