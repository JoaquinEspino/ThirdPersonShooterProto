using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    [SerializeField]
    [Range(0.2f, 1.5f)]
    private float fireRate = 1;
    private float timer;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                throwBullet();
            }
        }
    }

    public void throwBullet()
    {
        if (Input.GetButton("Fire1"))
        {
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = transform.position;
            bulletObject.transform.forward = transform.forward;
        }
    }
}
