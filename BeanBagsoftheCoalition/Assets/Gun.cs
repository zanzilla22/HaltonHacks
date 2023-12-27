using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Sprite icon;
    public float headShotMultiplier = 1.5f;
    public float Range = 10;
    public GameObject muzzleFlash;
    private GameObject audioListener;
    public AudioClip ShotSound;
    public AudioClip ReloadSound;
    public int startingAmmo = 100;
    [HideInInspector]
    public int leftAmmo;
    public int magSize;
    public int ammoCount;

    public AmmoCounter ammoCounter;
    public Animator recoil;
    public Transform gunHolderTransform;
    public bool hasScope;
    public GameObject weaponCamera;
    public GameObject uiCamera;
    public GameObject scopeOverlay;
    public int noShots = 1;
    public GameObject player;
    public int bulletVelocity = 2000;
    public float bulletSpread = 0;
    public GameObject muzzle;
    public GameObject bullet;
    public Camera playerCamera;
    public float RPM = 600;
    private float fireDelay;
    private float fireTimer = 0;

    public bool automatic = false;
    public float SemiCockSpeed = 1f;
    public bool magFed = false;
    public int ammoSize = 5;

    public float reloadSeconds = 1;
    public float minDamage = 5f;
    public float maxDamage = 10;
    private bool triggerDown = false;
    public float recoilAmount = 10f;
    bool blockReload = false;
    private List<GameObject> splatter;

    [HideInInspector]
    public float curRecoil = 0;
    private Quaternion muzzleRot;
    public int refillPerKill;

    bool semiCoolDown = false;
    void Start()
    {
        recoil.SetFloat("SemiCockSpeed", SemiCockSpeed);
        if (refillPerKill == 0)
            refillPerKill = ammoSize;
        muzzleFlash.SetActive(false);
        leftAmmo = startingAmmo;
        ammoCount = ammoSize;
        magSize = ammoSize;
        fireDelay = 60 / RPM;
        ammoCounter.SetLeftAmmo(startingAmmo);
        GameObject[] sounds = GameObject.FindGameObjectsWithTag("sound");
        audioListener = sounds[0];
        muzzleRot = muzzle.transform.rotation;
    }
    void Update()
    {
        if (!player.GetComponent<fpsController>().dead && !player.GetComponent<fpsController>().pauseMenu.activeInHierarchy)
        {
            ammoCounter.SetMagCount(ammoCount);
            triggerDown = (player.GetComponent<fpsController>().isFire > 0.5f);
            //Debug.Log(triggerDown + " - " +  player.GetComponent<fpsController>().isFire);
            if (!(fireTimer <= 0))
            {
                fireTimer -= Time.deltaTime;
            }


            //firing

            //Debug.Log(semiCoolDown);
            if (automatic)
            {
                if (triggerDown && fireTimer <= 0 && ammoCount > 0)
                {
                    PlaySound(ShotSound);
                    muzzleFlash.SetActive(true);
                    GetComponent<AudioSource>().loop = true;
                    for (int i = 0; i < noShots; i++)
                    {
                        StartCoroutine("Fire");
                        fireTimer = fireDelay;
                    }
                    ammoCount--;
                    recoil.SetFloat("AutoRecoilSecs", RPM / 60);
                    recoil.SetBool("AutoFiring", true);
                    curRecoil = recoilAmount;
                    GetComponent<AudioSource>().loop = false;
                }
            }
            else if (triggerDown && fireTimer <= 0 && ammoCount > 0 && !semiCoolDown)
            {
                //semi
                PlaySound(ShotSound);
                muzzleFlash.SetActive(true);
                for (int i = 0; i < noShots; i++)
                {
                    StartCoroutine("Fire");
                    fireTimer = fireDelay;
                }
                ammoCount--;
                recoil.SetTrigger("SemiShot");
                recoil.SetFloat("AutoRecoilSecs", (RPM / 60) * 2);
                semiCoolDown = true;
            }


            if (!triggerDown || ammoCount <= 0 || semiCoolDown)
            {
                recoil.SetBool("AutoFiring", false);
                curRecoil = 0;

                muzzleFlash.SetActive(false);
            }
            if (!triggerDown)
                semiCoolDown = false;
            if (player.GetComponent<fpsController>().Reload > 0.5f && !blockReload)
                StartCoroutine("Reload");

            if (player.GetComponent<fpsController>().isADS > 0.5f && hasScope)
                StartCoroutine(OnScoped());
            else if(scopeOverlay!= null)
            {
                scopeOverlay.SetActive(false);
                weaponCamera.SetActive(true);
                //uiCamera.SetActive(false);
                //uiCamera.SetActive(true);
                player.GetComponent<fpsController>().camAnim.SetBool("3xZoom", false);
            }
            //Debug.Log(splatter.Count);
        }
        //bool isHit = Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, Mathf.Infinity);
        //Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward, Color.red);
    }
    IEnumerator OnScoped()
    {
        if (!player.GetComponent<fpsController>().pauseMenu.activeInHierarchy)
        {
            player.GetComponent<fpsController>().camAnim.SetBool("3xZoom", true);
            yield return new WaitForSeconds(0.25f);
            scopeOverlay.SetActive(true);
            weaponCamera.SetActive(false);
            //Debug.Log("datbooltrue");
        }
    }
    public IEnumerator Fire()
    {
        if (!player.GetComponent<fpsController>().pauseMenu.activeInHierarchy)
        {
            player.GetComponent<fpsController>().Recoil(recoilAmount);



            GameObject shot = Instantiate(bullet, muzzle.transform.position, Quaternion.Euler(playerCamera.transform.localEulerAngles.x + 90, player.transform.localEulerAngles.y - 10, 0));
            //Instantiate(muzzleFlash, muzzle.transform.position, Quaternion.Euler(playerCamera.transform.localEulerAngles.x + 90, player.transform.localEulerAngles.y - 10, 90));
            shot.GetComponent<bulletScript>().gun = this;
            //shot.transform.parent = playerCamera.transform;
            //Debug.Log("Shot Rotation = " + shot.transform.rotation + " --- CamRot = " + playerCamera.transform.rotation);
            float SpreadMult = 1;
            if (player.GetComponent<fpsController>().isADS > 0.5f)
                SpreadMult = 0.25f;
            //shot.transform.rotation = Quaternion.Euler (0, player.transform.rotation.y - 10, 0);
            //Debug.Log(player.transform.rotation.y);
            //shot.transform.Rotate(90, 0,0);

            //muzzleRot = muzzle.transform.rotation;
            //muzzle.transform.rotation = muzzleRot;
            //Debug.Log(muzzle.transform.localEulerAngles);
            //shot.GetComponent<Rigidbody>().AddForce(bulletVelocity * (muzzle.transform.forward + new Vector3(Random.Range(-bulletSpread * SpreadMult, bulletSpread * SpreadMult), Random.Range(-bulletSpread * SpreadMult, bulletSpread * SpreadMult), Random.Range(-bulletSpread * SpreadMult, bulletSpread * SpreadMult))));

            muzzleRot = muzzle.transform.rotation;
            RaycastHit hit;
            bool isHit = Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, Mathf.Infinity);
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward, Color.red);
            //Debug.Log(isHit + " - " + hit.transform.position);
            muzzle.transform.LookAt(hit.point);
            shot.transform.LookAt(hit.point);
            shot.transform.rotation = Quaternion.Euler(shot.transform.localEulerAngles.x + 90, shot.transform.localEulerAngles.y, shot.transform.localEulerAngles.z);
            shot.GetComponent<Rigidbody>().AddForce((bulletVelocity) * (muzzle.transform.forward + new Vector3(Random.Range(-bulletSpread * SpreadMult, bulletSpread * SpreadMult), Random.Range(-bulletSpread * SpreadMult, bulletSpread * SpreadMult), Random.Range(-bulletSpread * SpreadMult, bulletSpread * SpreadMult))));
            muzzle.transform.rotation = muzzleRot;

            //playerCamera.transform.Rotate(new Vector3(-recoilAmount, 0, 0));
            yield return new WaitForSeconds(15);
            Destroy(shot);
        }
    }
    public IEnumerator Reload()
    {
        if (!player.GetComponent<fpsController>().pauseMenu.activeInHierarchy)
        {
            blockReload = true;
            if (ammoCount != ammoSize)
            {

                player.GetComponent<fpsController>().anim.SetFloat("reloadMult", 1 / reloadSeconds);
                if (!magFed)
                {
                    while (ammoCount != ammoSize)
                    {
                        PlaySound(ReloadSound);
                        player.GetComponent<fpsController>().anim.SetTrigger("SingleReload");
                        yield return new WaitForSeconds(reloadSeconds * .9f);
                        ammoCount++;
                        leftAmmo--;
                        ammoCounter.SetLeftAmmo(leftAmmo);
                    }
                }
                else
                {
                    if (leftAmmo > 0)
                    {
                        PlaySound(ReloadSound);
                        player.GetComponent<fpsController>().anim.SetTrigger("MagReload");
                        //Debug.Log("magReloadOnce");
                        yield return new WaitForSeconds(reloadSeconds * .9f);
                        int prevAmCount = ammoCount;
                        ammoCount += Mathf.Clamp(magSize - ammoCount, 0, leftAmmo);
                        leftAmmo = Mathf.Clamp(leftAmmo - (magSize - prevAmCount), 0, startingAmmo);
                        //Debug.Log("AccValue: " + Mathf.Clamp(magSize - prevAmCount, 0, startingAmmo) + " Display Value: " + Mathf.Clamp(leftAmmo, 0, startingAmmo));
                        ammoCounter.SetLeftAmmo(leftAmmo);
                    }
                }

            }
            yield return new WaitForSeconds(.9f);
            blockReload = false;
        }
    }
    public void deleteSplatFunc(GameObject splat)
    {
        StartCoroutine(deleteSplat(splat));
    }
    public IEnumerator deleteSplat(GameObject splat)
    {
        yield return new WaitForSeconds(3f);
        Destroy(splat);
    }
    public void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, audioListener.transform.position);
    }
    public void ResetAmmo()
    {
        leftAmmo = startingAmmo;
        ammoCount = ammoSize;
        ammoCounter.SetLeftAmmo(leftAmmo);
        ammoCounter.SetMagCount(ammoCount);
        Debug.Log("leftAmmo: " + leftAmmo + "   ammoCount: " + ammoCount);
    }
}
