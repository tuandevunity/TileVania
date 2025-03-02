using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    private BulletPool bulletPool;

    private void Start()
    {
        bulletPool = GetComponent<BulletPool>();
    }

    public void Shoot()
    {
        GameObject bullet = bulletPool.GetBullet();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.SetActive(true);
    }
}
