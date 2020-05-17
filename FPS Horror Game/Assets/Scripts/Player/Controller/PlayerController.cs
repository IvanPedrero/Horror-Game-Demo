using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Gun currentGun;

    public PlayerShotingAnimatorManager shootingAnimatorManager;

    public bool canShoot = false;
    public float shootingTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        shootingAnimatorManager.animator = currentGun.gunAnimator;
    }

    // Update is called once per frame
    void Update()
    {
        shootingTimer += Time.deltaTime;
        if (shootingTimer >= currentGun.shootingTime)
        {
            canShoot = true;
        }


        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Hit();
        }
    }


    void Shoot()
    {
        // Check if already shooting.
        if (!canShoot || !shootingAnimatorManager.isInIdleAnimation())
        {
            return;
        }


        canShoot = false;
        shootingTimer = 0;

        // Check if bullets left.
        if (!currentGun.GunHasBulletsLeft())
        {
            currentGun.audioSource.clip = currentGun.emptyShootAudioClip;
            currentGun.audioSource.Play();

            return;
        }

        shootingAnimatorManager.PlayShootAnimation();
        CreateShoot();
    }

    public void CreateShoot()
    {
        GameObject bullet = Instantiate(currentGun.bulletPrefab,
                                        currentGun.bulletPosition.position,
                                        currentGun.bulletPosition.rotation);

        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * currentGun.bulletForce, ForceMode.Acceleration);

        currentGun.muzzleFlash.Play();

        currentGun.audioSource.clip = currentGun.shootAudioClip;
        currentGun.audioSource.Play();

        currentGun.RemoveBullets(1);
    }

    void Reload()
    {
        // Check if the gun is completely reloaded.
        if (currentGun.GunHasAllBullets() || !shootingAnimatorManager.isInIdleAnimation())
        {
            return;
        }

        currentGun.audioSource.clip = currentGun.reloadAudioClip;
        currentGun.audioSource.Play();

        currentGun.ReloadBullets();
        shootingAnimatorManager.PlayReloadAnimation();
    }

    void Hit()
    {
        shootingAnimatorManager.PlayHitAnimation();
    }
}
