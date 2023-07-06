using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Created by Michael.
// Validate Order Of Notes Played method Refactored by Robin.
public class NotePuzzleManager : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Set note cubes in list in order of id 1~3. This list is used to validate the correct order has been played to solve the puzzle.")]
    [SerializeField]
    private GameObject[] noteBlocksInPuzzle; // How many note blocks in puzzle.
    private List<int> noteBlockPlayOrder = new List<int>(); // How many notes have been played in game.

    private int orderCheckSuccess = 0; // How many notes have been played in order.

    private void Update()
    {    
        // Check if all note blocks have been played
        if (noteBlocksInPuzzle.Length == noteBlockPlayOrder.Count)
        {
            Debug.Log("All notes have been played");
            ValidateOrderOfNotesPlayed();
        }

        Debug.Log("@@@ List of added notes played " + noteBlockPlayOrder.Count);

        //Debug.Log("how many notes in order " + check);


        if (orderCheckSuccess == 3)
        {
            Debug.Log("PUZZLE SOLVED");
            // Play winning sound after coroutine.
            StartCoroutine(CountSeconds());
            
        }
        
       
    }
    
    private IEnumerator CountSeconds (int seconds = 4)
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
                noteBlockPlayOrder.Clear();
                return;
            } 
            else { orderCheckSuccess++;}
        }
    }
}