using UnityEngine;

public class GunScript: MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float sensitivity = 2f;

    public GameObject bulletPrefab;
    public Camera gunCam;
    public GameObject gun;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            ShootBullet();
        }

        void Shoot()
        {
            RaycastHit hit;
            if (Physics.Raycast(gunCam.transform.position, gunCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                EnemyHealthScript target = hit.transform.GetComponent<EnemyHealthScript>();
                if (target != null)
                {
                    target.takeDamage(damage);
                }
            }

        }
        void ShootBullet()
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
            bullet.transform.position = gun.transform.position + gun.transform.forward;
        }
    }
}
