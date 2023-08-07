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
    [SerializeField] private GameObject[] noteBlocksInPuzzle; // How many note blocks in puzzle.
    [SerializeField] private List<int> noteBlockPlayOrder = new List<int>(); // How many notes have been played in the game.
    [SerializeField] private bool isPuzzleSolved = false; 
    private int orderCheckSuccess = 0; 
    
    [Header("Debugs")]
    [SerializeField] private GameObject indicatorLight1, indicatorLight2, indicatorLight3;
    [SerializeField] private GameObject fragment;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] UnityEvent resetLight;
    [SerializeField] UnityEvent lightUpStatue;

    private void Update()
    {
   
        if (noteBlocksInPuzzle.Length == noteBlockPlayOrder.Count)
        {
            Debug.Log("All notes have been played");
            ValidateOrderOfNotesPlayed();
        }

        if (orderCheckSuccess == 3 && !isPuzzleSolved)
        {
            Debug.Log("PUZZLE SOLVED");
            StartCoroutine(CountSeconds());
            isPuzzleSolved = true;
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
        Instantiate(fragment, spawnTransform.position, Quaternion.identity);
    }

    public void NoteBlockSoundHasPlayed(int noteId)
    {
        noteBlockPlayOrder.Add(noteId);
    }

    private void ValidateOrderOfNotesPlayed()
    {
        for (int i = 0; i < noteBlockPlayOrder.Count; i++) 
        {
            if (noteBlockPlayOrder[i] != i + 1)
            {
                ResetList();
                resetLight.Invoke();
                orderCheckSuccess = 0; 
                return;
            } 
            else
            {
                orderCheckSuccess++;
            }
        }
    }

    private void ResetList()
    {
        noteBlockPlayOrder.Clear();
        orderCheckSuccess = 0; 
        resetLight.Invoke(); 
        Debug.Log("List cleared");
    }


    public void ResetPuzzle()
    {
        noteBlockPlayOrder.Clear();
        orderCheckSuccess = 0; 
        isPuzzleSolved = false; 
        resetLight.Invoke();
    }
}