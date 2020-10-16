using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStates;

public class ShootSystem : MonoBehaviour
{
    public WeaponStructs.WeaponStats weaponStats;
    public WeaponStructs.WeaponPrefabs weaponPrefabs;
    [SerializeField] private float firstShotTime;
    [SerializeField] private Transform bulletSpawner;
    [SerializeField] private PlayerStateMachine playerStates;

    private float time;
    
    
    public void Shoot()
    {
        if(playerStates.GetState() == PlayerStates.playerStates.Shooting)
        {
            if(time < CalculateTimeBetweenShots(weaponStats.fireRate))
            {
                time += Time.deltaTime;
            }
            else
            {
                time = 0;
                GameObject bullet = (GameObject)Instantiate(weaponPrefabs.projectilePrefab, bulletSpawner.position , bulletSpawner.rotation);
            
                bullet.GetComponent<Bullet>().SetStats(weaponStats.damage, weaponStats.bulletSpeed, weaponStats.range);
                //pSounds.PlayGunShotSound();
            }
        }
        else
        {
            time = CalculateTimeBetweenShots(weaponStats.fireRate) - firstShotTime;
        }
        
    }

    private float CalculateTimeBetweenShots(float rate)
    {
        return 60 / rate;
    }
}
