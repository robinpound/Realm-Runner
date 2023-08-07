using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Breakablerock : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Alter the amount of pieces the block will break into.")]
    [SerializeField]
    private GameObject breakablePiece;
    [SerializeField]
    private int numberOfBreakablePieces;
    [Tooltip("Choose which rock to destroy on hit")]
    [SerializeField]
    private GameObject rockToDestroy;
    
    [SerializeField]

    private int maxHealth = 1;
    private int health;
    [SerializeField]
    [Tooltip("Point where the pieces will spawn from.")]
    private Transform spawnPosition;
    private bool isDestroyed = false;
    private List<GameObject> spawnedPieces = new List<GameObject>();
    private AudioManager audioManager;

    [Header("Event to show VCam3")]
    [SerializeField] private UnityEvent showVCam3;
    [SerializeField] private bool isThroneRoomDoor = false;
    private const string ARROWTAG = "Arrow";

    private void Start()
    {
        health = maxHealth;
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0 && !isDestroyed)
        {
            ShowCameraToThroneRoom();
            Destroy();
            isDestroyed = true;
        }
    }

    public void ShowCameraToThroneRoom()
    {
        if (isThroneRoomDoor)
        {
            showVCam3.Invoke();
        }
    }

    private void Destroy()
    {
        Destroy(rockToDestroy);
        Destroy(gameObject);
        //Debug.Log("Block broken into " + numberOfBreakablePieces + "Pieces");
        for (int i = 0; i < numberOfBreakablePieces; ++i)
        {
            GameObject piece = Instantiate(breakablePiece, spawnPosition.position, Quaternion.identity);
            spawnedPieces.Add(piece);
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(ARROWTAG))
        {
            int damage = 1;
            TakeDamage(damage);
            PlaySounds();
        }
        
    }

    private void PlaySounds()
    {
        FindObjectOfType<AudioManager>().PlaySound("RockBlowUp");
    }

}
