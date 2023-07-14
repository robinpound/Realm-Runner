using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSounds : MonoBehaviour
{
    public GameObject player;
    public AudioSource audios;
    public AudioClip footStep1;
    public AudioClip footStep2;
    public AudioClip jumpLaunch;
    public AudioClip jumpLand;

    [SerializeField] bool isWalking;
    [SerializeField] bool isJumping;
    public float timer;

    [SerializeField] private UnityEvent loop;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isWalking = player.GetComponent<ActionInputs>().isMovementPressed;
    }

    // Update is called once per frame
    void Update()
    {
        isWalking = player.GetComponent<ActionInputs>().isMovementPressed;
        if(isWalking && timer == 0)
        {
            timer = 1;
            loop.Invoke();
            Invoke(nameof(Reset), 0.8f);
        }
        else if (!isWalking)
        {
            timer = 0;
        }
    }
    private void Reset()
    {
        timer = 0;
    }
    public void StartCo()
    {
        StartCoroutine(Footsteps());
    }

    public IEnumerator Footsteps()
    {
        audios.clip = footStep1;
        audios.Play();
        yield return new WaitForSeconds(0.5f);
        audios.clip = footStep2;
        audios.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isWalking)
        {
            //loop.Invoke();
        }
    }
}
