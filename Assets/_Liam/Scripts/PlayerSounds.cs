using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSounds : MonoBehaviour
{
    public GameObject footStep1Prefab;

    [Header("Don't Touch!")]
    [Header("Audio Source & Clips")]

    [SerializeField] Animator animator;
    [SerializeField] GameObject player;
    [Tooltip("Assign Player Audio Source Component Here!")]
    [SerializeField] AudioSource audios;
    [Tooltip("Assign FootStep Clip 1 Here!")]
    [SerializeField] AudioClip footStep1;
    [Tooltip("Assign FootStep Clip 2 Here!")]
    [SerializeField] AudioClip footStep2;
    [Tooltip("Assign Jump Launch Clip Here!")]
    [SerializeField] AudioClip jumpLaunch;
    [SerializeField] AudioClip jumpLand;

    [Header("Can Touch!")]
    [Header("Bools for Movement")]

    [Tooltip("This bool is collected from the player movement script, so it is true and false when that script is")]
    [SerializeField] bool isWalking;
    [Tooltip("This bool is collected from the player movement script, so it is true and false when that script is")]
    [SerializeField] bool isJumping;
    [Tooltip("This float is so the script knows when it can start a sound for the player.")]
    public float timer;

    [Header("Sound Events")]
    [Tooltip("Add new event, assign the player, select PlayerSounds script and select StartJump or StartFootsteps functions," +
        " depending on the event obviously.")]
    [SerializeField] private int EventToolTip;
    [SerializeField] private UnityEvent jump;
    [SerializeField] private UnityEvent footsteps;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        audios = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isWalking = player.GetComponent<ActionInputs>().isMovementPressed;
        isJumping = player.GetComponent<ActionInputs>().isJumpPressed;
        if (animator.GetBool("jump") == true)
        {
            jump.Invoke();
        }
        else if(animator.GetBool("run") == true && timer ==0)
        {
            footsteps.Invoke();
        }
        
        //if(isWalking && isJumping && timer == 0)
        //{
        //    jump.Invoke();
        //}
        //else if(isWalking && !isJumping && timer == 0)
        //{
        //    footsteps.Invoke();
        //}
    }
    private void Reset()
    {
        timer = 0;
    }
    public void StartFootstepts()
    {
        timer = 1;
        StartCoroutine(Footsteps());
        Invoke(nameof(Reset), 0.5f);
    }
    public void StartJump()
    {
        timer = 1;
        Jump();
        Invoke(nameof(Reset), 0.5f);
    }
    IEnumerator Footsteps()
    {
        audios.clip = footStep1;
        audios.Play();
        yield return new WaitForSeconds(0.257f);
        audios.clip = footStep2;
        audios.Play();
        
    }
    void Jump()
    {
        audios.clip = jumpLaunch;
        audios.Play();
    }
}
