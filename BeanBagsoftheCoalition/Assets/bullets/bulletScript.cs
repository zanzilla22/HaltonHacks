using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public GameObject bulletImpact;
    public Gun gun;
    public AudioClip hitMarker;
    public AudioClip deathSound;
    private Vector3 initialPos;
    void Awake()
    {
        initialPos = this.transform.position;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject != gun.player || (other.gameObject.GetComponent<head>() != null ? other.gameObject.GetComponent<head>().player.gameObject : gun.player) != gun.player)
        {
            //Debug.Log("Collision: " + other.gameObject.name);
            if (other.gameObject.tag == "Head")
            {
                gun.PlaySound(hitMarker);
                //Debug.Log("HIT - " + Mathf.Clamp(this.GetComponent<Rigidbody>().velocity.magnitude, gun.minDamage, gun.maxDamage));
                GameObject splatter = Instantiate(bulletImpact, this.transform.position, Quaternion.Euler(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z - 65));
                gun.deleteSplatFunc(splatter);
                splatter.transform.parent = other.gameObject.transform;
                other.gameObject.GetComponent<head>().player.recentBulletForward = this.gameObject.transform.forward;
                
                other.gameObject.GetComponent<head>().player.takeDamage(Mathf.Round(Mathf.Clamp((gun.Range/Vector3.Distance(initialPos, this.transform.position)) * gun.headShotMultiplier, gun.minDamage, gun.maxDamage * gun.headShotMultiplier)));
                if (other.gameObject.GetComponent<head>().player.health <= 0 && !other.transform.parent.transform.parent.gameObject.GetComponent<fpsController>().dead)
                    KilledEm(gun.player.GetComponent<fpsController>());
                //Debug.Log((gun.Range / Vector3.Distance(initialPos, this.transform.position)) * gun.headShotMultiplier);
            }
            else if (other.gameObject.tag == "Player")
            {
                gun.PlaySound(hitMarker);
                //Debug.Log("HIT - " + Mathf.Clamp(this.GetComponent<Rigidbody>().velocity.magnitude, gun.minDamage, gun.maxDamage));
                GameObject splatter = Instantiate(bulletImpact, this.transform.position, Quaternion.Euler(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z - 65));
                gun.deleteSplatFunc(splatter);
                splatter.transform.parent = other.gameObject.transform;
                other.gameObject.GetComponent<fpsController>().recentBulletForward = this.gameObject.transform.forward;
                if (other.gameObject.GetComponent<fpsController>().health - Mathf.Round(Mathf.Clamp(this.GetComponent<Rigidbody>().velocity.magnitude, gun.minDamage, gun.maxDamage)) <= 0 && !(other.gameObject.GetComponent<fpsController>().health <= 0))
                    KilledEm(gun.player.GetComponent<fpsController>());
                other.gameObject.GetComponent<fpsController>().takeDamage(Mathf.Round(Mathf.Clamp((gun.Range / Vector3.Distance(initialPos, this.transform.position)) * gun.headShotMultiplier, gun.minDamage, gun.maxDamage)));
                //Debug.Log((gun.Range / Vector3.Distance(initialPos, this.transform.position)) * gun.headShotMultiplier);
            }
        }

        if(other.gameObject.name!= this.gameObject.name && other.gameObject != gun.player)
            Destroy(this.gameObject);

    }
    void KilledEm(fpsController player)
    {
        player.kills++;
        player.curGun.leftAmmo = Mathf.RoundToInt(Mathf.Clamp(player.curGun.leftAmmo + player.curGun.refillPerKill, 0, player.curGun.startingAmmo));
        player.curGun.ammoCounter.SetLeftAmmo(player.curGun.leftAmmo);
        gun.PlaySound(deathSound);
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }
    }
}
