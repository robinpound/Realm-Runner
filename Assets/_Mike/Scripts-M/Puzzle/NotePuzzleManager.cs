using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
// Created by Michael.
// Validate Order Of Notes Played method Refactored by Robin.
public class NotePuzzleManager : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Set note cubes in list in order of id 1~3. This list is used to validate the correct order has been played to solve the puzzle.")]
    [SerializeField]
    private GameObject[] noteBlocksInPuzzle; // How many note blocks in puzzle.
    private List<int> noteBlockPlayOrder = new List<int>(); // How many notes have been played in game.
    [Header("Debugs")]
    [SerializeField]
    private GameObject indicatorLight1, indicatorLight2, indicatorLight3;
    [SerializeField]
    private GameObject fragment;
    [SerializeField]
    private Transform spawnTransform;
    [SerializeField] private bool isPuzzleSolved = false;
    private int orderCheckSuccess = 0; // How many notes have been played in order.
    [SerializeField] UnityEvent resetLight;
    [SerializeField] UnityEvent lightUpStatue;



    private void Update()
    {
        // Check if all note blocks have been played
        if (noteBlocksInPuzzle.Length == noteBlockPlayOrder.Count)
        {
            Debug.Log("All notes have been played");
            ValidateOrderOfNotesPlayed();
        }

        //Debug.Log("@@@ List of added notes played " + noteBlockPlayOrder.Count);

        //Debug.Log("how many notes in order " + check);


        if (orderCheckSuccess == 3 && !isPuzzleSolved)
        {
            Debug.Log("PUZZLE SOLVED");
            // Play winning sound after coroutine.
            StartCoroutine(CountSeconds());
            isPuzzleSolved=true;
            SpawnFragment();
            lightUpStatue.Invoke();
        }


    }

    private IEnumerator CountSeconds(int seconds = 2)
    {
        for (int i = 0; i <= seconds; i++)
        {
            Debug.Log(i + " seconds have passed.");

            yield return new WaitForSeconds(.1f);
        }
        PlayTriumphSound();
        
    }


    private void PlayTriumphSound()
    {
        Debug.Log("Play Winning Sound");
        GetComponent<AudioSource>().Play();
    }

    private void SpawnFragment()
    {
        // Instantiate fragment at vector location when the puzzle is solved.
        Instantiate(fragment, spawnTransform.position, Quaternion.identity);
        
    }
    public void NoteBlockSoundHasPlayed(int noteId)
    {
        noteBlockPlayOrder.Add(noteId);
        //Debug.Log(noteId + "has been added to the list");
    }

    private void ValidateOrderOfNotesPlayed()
    {
        for (int i = 0; i < noteBlockPlayOrder.Count; i++) 
        {
            if (noteBlockPlayOrder[i] != i+1)
            {
                ResetList();
                resetLight.Invoke();
                return;
            } 
            else { orderCheckSuccess++;}
        }
    }

    private void ResetList()
    {
        noteBlockPlayOrder.Clear();
        Debug.Log("List cleared");

    }

    
}