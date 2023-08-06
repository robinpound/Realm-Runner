using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowTest : MonoBehaviour
{
    InputActions input;
    public GameObject player;
    public GameObject arrow;
    public GameObject turret;
    [SerializeField] GameObject bowArrow;
    public float launchVelocity = 10f;

    [SerializeField]
    bool aiming;
    public int timer;

    [SerializeField] private bool isShot;
    private void Awake()
    {
        input = new InputActions();
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        input.PlayerActions.ArrowAiming.started += Aim;
        input.PlayerActions.ArrowAiming.performed += Aim;
        input.PlayerActions.ArrowAiming.canceled += Aim;


        input.PlayerActions.ArrowAttack.started += Shoot;
        input.PlayerActions.ArrowAttack.performed += Shoot;
        input.PlayerActions.ArrowAttack.canceled += Shoot;
    }
    void Aim(InputAction.CallbackContext context)
    {
        aiming = context.ReadValueAsButton();
        player.GetComponent<AimCameraControl>().mouse = context.ReadValueAsButton();
    }
    void Shoot(InputAction.CallbackContext context)
    {
        if (aiming)
        {
            Debug.Log("Input Works!");
            Fire();
            player.GetComponent<AimCameraControl>().shoot = context.ReadValueAsButton();
        }
    }
    void Fire()
    {
        if(timer == 0)
        {

            timer = 1;
            bowArrow.SetActive(false);
            GameObject launch = Instantiate(arrow, transform.position, transform.rotation);
            launch.transform.position = turret.transform.position;
            launch.transform.eulerAngles = new Vector3(
                launch.transform.eulerAngles.x + -90,
                launch.transform.eulerAngles.y,
                launch.transform.eulerAngles.z
            ); 
            arrow.GetComponent<ArrowNew>().IsShot();
            launch.GetComponent<Rigidbody>().AddForce(transform.forward * launchVelocity, ForceMode.Impulse);
            FindObjectOfType<AudioManager>().PlaySound("BowFling");
            FindObjectOfType<AudioManager>().PlaySound("PlayerAttack");
            Invoke(nameof(Reset), 1f);
        }
    }
    private void Reset()
    {
        bowArrow.SetActive(true);
        arrow.GetComponent<ArrowNew>().IsNotShot();
        timer = 0;
    }
    private void OnEnable()
    {
        input.PlayerActions.Enable();
    }
    private void OnDisable()
    {
        input.PlayerActions.Disable();
    }
}
