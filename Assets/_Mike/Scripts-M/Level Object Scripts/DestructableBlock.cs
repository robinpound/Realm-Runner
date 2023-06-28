using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableBlock : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Alter the amount of pieces the block will break into.")]
    [SerializeField]
    private GameObject breakablePiece;
    [SerializeField]
    private int numberOfBreakablePieces;
    [SerializeField]
    private int maxHealth = 1;
    private int health;
    [SerializeField]
    [Tooltip("Point where the pieces will spawn from.")]
    private Transform spawnPosition;
    private bool isDestroyed = false;
    private List<GameObject> spawnedPieces = new List<GameObject>();

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {


        //Debug
        Debug.Log("breakable block's Healht " + health);
        Debug.Log(spawnedPieces.Count);
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            
            int damage = 1;
            TakeDamage(damage);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            DeSpawnPieces();
        }

    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0 && !isDestroyed)
        {
            Destroy();
            isDestroyed = true;
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
        Debug.Log("Block broken into " + numberOfBreakablePieces + "Pieces");
        // Instantiate small pieces that will fly in different directions
        for (int i = 0; i < numberOfBreakablePieces; ++i)
        {
            GameObject piece = Instantiate(breakablePiece, spawnPosition.position, Quaternion.identity);
            spawnedPieces.Add(piece);
        }
        //DeSpawnPieces();
    }
    // Not working atm
    private void DeSpawnPieces()
    {
        for (int i = 0; i <spawnedPieces.Count; ++i)
        {
            Destroy(spawnedPieces[i]);
        }

    }

}
