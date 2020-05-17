using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("Gun Attributes : ")]
    public string gunName;
    public float damage;
    public float bulletForce;
    public float shootingTime;
    public GameObject bulletPrefab;
    public ParticleSystem muzzleFlash;
    public Transform bulletPosition;
    public Animator gunAnimator;
    public AudioSource audioSource;

    [Header("Bullet Management : ")]
    public int totalBullets;
    public int bulletCapacity;
    public int bulletsLeft;

    [Header("Bullet GUI : ")]
    public Text gunNameText;
    public Text bulletsLeftText;

    [Header("Audios : ")]
    public AudioClip shootAudioClip;
    public AudioClip emptyShootAudioClip;
    public AudioClip reloadAudioClip;
    public AudioClip hitAudioClip;

    public void Start()
    {
        totalBullets -= bulletCapacity;
        bulletsLeft += bulletCapacity;

        UpdateGUI();
    }

    public void GrabBullets(int count)
    {
        totalBullets += count;
        UpdateGUI();
    }

    public void RemoveBullets(int count)
    {
        bulletsLeft -= count;
        UpdateGUI();
    }

    public void ReloadBullets()
    {
        // If there are enough bullets.
        if (totalBullets >= bulletCapacity)
        {
            totalBullets -= bulletCapacity - bulletsLeft;
            bulletsLeft = bulletCapacity;

        }
        // If there aren't enough bullets.
        else
        {
            bulletsLeft += totalBullets;
            totalBullets = 0;
        }

        UpdateGUI();
    }

    private void UpdateGUI()
    {
        gunNameText.text = gunName;
        bulletsLeftText.text = bulletsLeft + "/" + totalBullets;
    }


    public bool GunHasAllBullets()
    {
        return bulletsLeft >= bulletCapacity;
    }


    public bool GunHasBulletsLeft()
    {
        return bulletsLeft >= 1;
    }
}
