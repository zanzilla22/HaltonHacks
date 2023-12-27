using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class fpsController : MonoBehaviour
{
    [HideInInspector]
    public int kills = 0;
    public WeaponSelect weaponSelect;
    public Footsteps footstepController;

    public GameObject redicle;
    public GameObject deathScreen;
    public healthBar healthBar;
    public float  health = 250;
    public float aimSensMult = 0.5f;
    private Vector2 rotateInput;
    private Vector2 movementInput;
    public Animator anim;
    public Animator camAnim;
    public GameObject gunHolder;
    private float walkingSpeed = 7.5f;
    public float statWalkingSpeed = 7.5f;
    public float statRunningSpeed = 11.5f;
    private float runningSpeed = 11.5f;
    public float aimingSpeed = 5.5f;
    public float crouchingSpeed = 5.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    PlayerControls controls;
    public float lookSpeed = 2.0f;
    public Slider sensSlider;
    public float lookXLimit = 45.0f;

    private Transform gunHipPos;
    private Transform gunADSPos;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public float healSeconds;


    public Gun curGun;
    private Vector2 recoilRemaining;
    [HideInInspector]
    public int playerNo;
    [HideInInspector]
    public float isFire = 0f;
    float Crouching;
    float Running;//Input.GetKey(KeyCode.LeftShift);
    float Jump;
    float Options;
    [HideInInspector]
    public float Reload;
    [HideInInspector]
    public bool canMove = true;
    [HideInInspector]
    public float isADS = 0f;
    float orWalk;
    float orRun;
    private float healTimer = 0;
    [HideInInspector]
    public bool dead = false;
    [HideInInspector]
    public Vector3 recentBulletForward;
    [HideInInspector]
    public bool climbing = false;

    [HideInInspector]
    public bool isAiming = false;

    private Vector3 MapCenter;
    Vector3 orScale;
    public killCounter killCounter;
    public Transform bigBoiScaler;
    public float crouchScale = 2f;
    [HideInInspector]
    public bool isOptions = false;
    public GameObject pauseMenu;
    void Start()
    {
        sensSlider.value = lookSpeed * 20;
        orScale = this.transform.localScale;
        MapCenter = GameObject.Find("Center").transform.position;
        walkingSpeed = statWalkingSpeed;
        runningSpeed = statRunningSpeed;
        healthBar.SetMaxHealth(health);
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");
        playerNo = objects.Length -1;
        //Debug.Log(playerNo);
        controls = new PlayerControls();

        orWalk = walkingSpeed;
        orRun = runningSpeed;
        gunHipPos = gunHolder.transform;
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void Update()
    {
        movementInput = (!pauseMenu.activeInHierarchy ? movementInput : new Vector2(0, 0));
        lookSpeed = sensSlider.value / 20;
        killCounter.SetKillCount(kills);
        isOptions = Options > 0.5f;

        canMove = !pauseMenu.activeInHierarchy;
        //Debug.Log("walk: " + walkingSpeed + " -- run: " + runningSpeed);
        healTimer = Mathf.Clamp(healTimer - Time.deltaTime, 0, healSeconds);
        if (healTimer == 0 && health < 250)
            Heal(Time.deltaTime * 100);
        if (health == 0 && !dead)
        {
            dead = true;
            Die();
        }
        if (!dead && !pauseMenu.activeInHierarchy)
        {
            bool isCrouch = (Crouching > 0.5f);
            if (isCrouch)
            {
                this.transform.localScale = new Vector3(orScale.x, orScale.y / crouchScale, orScale.z);
                bigBoiScaler.localScale = new Vector3(1, crouchScale, 1);
                walkingSpeed = crouchingSpeed;
                runningSpeed = crouchingSpeed;
            }
            else
            {
                this.transform.localScale = new Vector3(orScale.x, orScale.y, orScale.z);
                bigBoiScaler.localScale = new Vector3(1, 1, 1);
            }


            bool isRunning = (Running > 0.5f);
            bool isJump = (Jump > 0.5f);
            isAiming = (isADS > 0.5f);// Input.GetButton("Fire2");
                                           //isADS = Input.GetButton("Fire2");
            if (isAiming)
            {
                walkingSpeed = aimingSpeed;
                runningSpeed = aimingSpeed;
            }
            else if (!isAiming && !isCrouch)
            {
                //Debug.Log(orRun + " - " + orWalk);
                walkingSpeed = orWalk;
                runningSpeed = orRun;
            }

            //Scrapped movespeed devrease when jumping

            //if (!(Jump > 0.5f))
            //{
            //    walkingSpeed = statWalkingSpeed;
            //    runningSpeed = statRunningSpeed;
            //}
            //else
            //{
            //    Debug.Log("Jumping");
            //    walkingSpeed = statWalkingSpeed / 3;
            //    runningSpeed = statRunningSpeed / 3;
            //}
            // We are grounded, so recalculate move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            // Press Left Shift to run

            if (isFire > 0.5f)
            {
                isRunning = false;
                anim.SetBool("Running", false);

            }

            float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * movementInput.y : 0;
            float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * movementInput.x : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);


            if (isJump && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)

            if (climbing)
            {
                Climb();
                moveDirection.x = 0;
            }

            if (isRunning)
                anim.SetBool("Running", true);
            else
                anim.SetBool("Running", false);
            // Move the controller
            
            if(movementInput != new Vector2(0,0) && (canMove && characterController.isGrounded))
                footstepController.SubFootstepTime(Time.deltaTime * ((isRunning) ? Random.Range(1.8f, 2.2f) : Random.Range(0.8f, 1.2f)));
            //Debug.Log((moveDirection.x + moveDirection.y) / 2 * Time.deltaTime);

            // Player and Camera rotation
            //Debug.Log(isFire);
            if (canMove)
            {
                //Debug.Log(recoilRemaining);
                //playerCamera.transform.Rotate(Vector3.right, -recoilRemaining.x, Space.Self);
                recoilRemaining.x *= .9f;
                //Debug.Log(rotateInput);
                float curAimMult = (isADS > 0.5f) ? aimSensMult : 1f;
                //Debug.Log(lookSpeed * curAimMult);
                //lookSpeed *= curAimMult;
                rotationX += (-rotateInput.y * (lookSpeed * curAimMult)) * Time.deltaTime * 65;
                //rotationX *= Time.deltaTime * 65;
                if (isAiming)
                    rotationX = Mathf.Clamp(rotationX, -lookXLimit * 1.75f, lookXLimit * 1.75f);
                else
                    rotationX = Mathf.Clamp(rotationX, -lookXLimit * 1.75f, lookXLimit * 1.75f);
                playerCamera.transform.localRotation = Quaternion.Euler((rotationX - recoilRemaining.x), 0, 0);
                //Horizontal
                transform.rotation *= Quaternion.Euler(0, (rotateInput.x * (lookSpeed * curAimMult)) * Time.deltaTime*65, 0);
            }
            //Debug.Log(Input.GetButton("Fire2"));
            anim.SetBool("ADS", isAiming);
            camAnim.SetBool("ADS", isAiming);
            //ScreenSplit();
            redicle.SetActive(!isAiming);
            
        }
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        if (!pauseMenu.activeInHierarchy)
            characterController.Move(moveDirection * Time.deltaTime);
        else
            characterController.SimpleMove(new Vector3(0, characterController.velocity.y, 0) * Time.deltaTime);
    }

    //world interactions
    public void Bounce()
    {
        if (canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed*3;
        }
    }
    public void Climb()
    {
        //Debug.Log("CurClimb")
        if (movementInput.y > 0)
            moveDirection.y = movementInput.y * walkingSpeed;
    }


    public void takeDamage(float damage)
    {
        healTimer = healSeconds;
        health -= (int)damage;
        health = Mathf.Clamp(health, 0, 300);
        healthBar.SetHealth(health);
    }

    public void Heal(float healAmount)
    {
        if (!dead)
        {
            //Debug.Log("Healing: " + health);
            health = Mathf.Clamp(health + healAmount, 0, 250);
            healthBar.SetHealth(health);
        }
    }

    public void Die()
    {
        this.GetComponent<Rigidbody>().isKinematic = false;
        deathScreen.SetActive(true);
        StartCoroutine(Respawn());
    }

    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5f);
        weaponSelect.UpdateWeapon();
        deathScreen.SetActive(false);
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.rotation = Quaternion.identity;
        List<GameObject> p1s = new List<GameObject>();
        List<GameObject> p2s = new List<GameObject>();
        GameObject[] ps = GameObject.FindGameObjectsWithTag("Player");
        //team one is negative x (team two is positive)
        if ((GetComponent<spawner>().teamNumber == 1 && GetComponent<spawner>().no2s > 1) || (GetComponent<spawner>().teamNumber == 2 && GetComponent<spawner>().no1s > 1))
        {
            //multuple on other team
            //Debug.Log("MultOnOtherTeam");
            if (GetComponent<spawner>().teamNumber == 1)
            {
                for (int i = 0; i < ps.Length; i++)
                {
                    if (ps[i].GetComponent<spawner>().teamNumber == 2)
                        p2s.Add(ps[i]);
                }
                Vector3 center = (p2s[0].transform.position + p2s[1].transform.position * 0.5f);
                if(center.x < MapCenter.x)
                    this.GetComponent<spawner>().Spawn(1);
                if(center.x > MapCenter.x)
                    this.GetComponent<spawner>().Spawn(2);
            }
            if (GetComponent<spawner>().teamNumber == 2)
            {
                for (int i = 0; i < ps.Length; i++)
                {
                    if (ps[i].GetComponent<spawner>().teamNumber == 2)
                        p1s.Add(ps[i]);
                }
                Vector3 center = (p1s[0].transform.position + p1s[1].transform.position) * 0.5f;
                if (center.x < MapCenter.x)
                    this.GetComponent<spawner>().Spawn(1);
                if (center.x > MapCenter.x)
                    this.GetComponent<spawner>().Spawn(2);
            }

            takeDamage(1f);
            
        }
        else
        {
            //Single on other team
            //Debug.Log("Sing on other team");
            if (GetComponent<spawner>().teamNumber == 1)
            {
                for (int i = 0; i < ps.Length; i++)
                {
                    if (ps[i].GetComponent<spawner>().teamNumber == 2)
                        p2s.Add(ps[i]);
                }
                Vector3 center = p2s[0].transform.position;
                if (center.x < MapCenter.x)
                    this.GetComponent<spawner>().Spawn(2);
                if (center.x > MapCenter.x)
                    this.GetComponent<spawner>().Spawn(1);
            }
            if (GetComponent<spawner>().teamNumber == 2)
            {
                for (int i = 0; i < ps.Length; i++)
                {
                    if (ps[i].GetComponent<spawner>().teamNumber == 1)
                        p1s.Add(ps[i]);
                }
                Vector3 center = p1s[0].transform.position;
                if (center.x < MapCenter.x)
                    this.GetComponent<spawner>().Spawn(2);
                if (center.x > MapCenter.x)
                    this.GetComponent<spawner>().Spawn(1);
            }
        }

        curGun.ResetAmmo();
        
        health = 250;
        healthBar.SetHealth(health);
        dead = false;
    }

    public void Recoil(float recoilAmount)
    {
        recoilRemaining.x = Mathf.Clamp(recoilRemaining.x, recoilAmount, lookXLimit) * recoilAmount;
        //rotateInput.y += recoilAmount;
        
        //playerCamera.transform.rotation = Quaternion.Euler(playerCamera.transform.localEulerAngles.x - recoilAmount, playerCamera.transform.localEulerAngles.y, playerCamera.transform.localEulerAngles.z);
    }

    //public void OnCollisionEnter(Collision other)
    //{
    //    Debug.Log("PlayerCollision");
    //}

    public void OnLook(InputAction.CallbackContext ctx) => rotateInput = ctx.ReadValue<Vector2>();
    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    public void OnFire(InputAction.CallbackContext ctx) => isFire = ctx.ReadValue<float>();
    public void OnADS(InputAction.CallbackContext ctx) => isADS = ctx.ReadValue<float>();
    public void OnSprint(InputAction.CallbackContext ctx) => Running = ctx.ReadValue<float>();
    public void OnReload(InputAction.CallbackContext ctx) => Reload = ctx.ReadValue<float>();
    public void OnJump(InputAction.CallbackContext ctx) => Jump = ctx.ReadValue<float>();
    public void OnCrouch(InputAction.CallbackContext ctx) => Crouching = ctx.ReadValue<float>();
    public void OnOptions(InputAction.CallbackContext ctx) => Options = ctx.ReadValue<float>();

    /*
    public void ScreenSplit()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");
        int noPlayers = objects.Length - 1;
        if(playerNo == 1)
        {
            if(noPlayers == 2)
            {
                playerCamera.rect = new Rect(0, 0, 0.5f, 1);
            }
            if(noPlayers >= 3)
            {
                playerCamera.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            }
        }
        if(playerNo == 2)
        {
            if(noPlayers == 2)
            {
                playerCamera.rect = new Rect(0.5f, 0, 0.5f, 1);
            }
            if (noPlayers >= 3)
            {
                playerCamera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            }
        }
        if (playerNo == 3)
        {
            if (noPlayers >= 3)
            {
                playerCamera.rect = new Rect(0, 0, 0.5f, 0.5f);
            }
        }
        if (playerNo == 4)
        {
            if (noPlayers >= 3)
            {
                playerCamera.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
            }
        }
    }
    */
}