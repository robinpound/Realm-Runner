using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSounds : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public AudioSource audios;
    public AudioClip footStep1;
    public AudioClip footStep2;
    public AudioClip jumpLaunch;
    public AudioClip jumpLand;

    [SerializeField] bool isWalking;
    [SerializeField] bool isJumping;
    public float timer;

    [SerializeField] private UnityEvent jump;
    [SerializeField] private UnityEvent footsteps;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        isWalking = player.GetComponent<ActionInputs>().isMovementPressed;
    }

    // Update is called once per frame
    void Update()
    {
        isWalking = player.GetComponent<ActionInputs>().isMovementPressed;
        isJumping = player.GetComponent<ActionInputs>().isJumpPressed;
        if (animator.GetBool("jump") == true && timer == 0)
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
