using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePuzzleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] noteBlocksInPuzzle;
    private List<int> noteBlockPlayOrder = new List<int>();

    private int check = 0; // how many notes have been played in order

    

    private void Update()
    {
        // Check if all note blocks have been played
        if (noteBlocksInPuzzle.Length == noteBlockPlayOrder.Count)
        {
            Debug.Log("All notes have been played");
            ValidateOrderOfNotesPlayed();
        }

        Debug.Log("List of added notes played " + noteBlockPlayOrder.Count);

        Debug.Log("how many notes in order " + check);


        if (check == 3) Debug.Log("PUZZLE SOLVED");
        
       
    }

    public void NoteBlockSoundHasPlayed(int noteId)
    {
        noteBlockPlayOrder.Add(noteId);
        Debug.Log(noteId + "has been added to the list");
    }

    private void ValidateOrderOfNotesPlayed()
    {
        for (int i = 0; i < noteBlockPlayOrder.Count; i++) 
        {
            if (check == 0 && i == 0 && noteBlockPlayOrder[i] == 1)
            {
                check++;
            }
            else
            {
                noteBlockPlayOrder.Clear();
                
                return;
            }

            if (check == 1 && i == 1 && noteBlockPlayOrder[i] == 2)
            {
                check++;
            }
            else
            {
                noteBlockPlayOrder.Clear();
               
                return;
            }

            if (check == 2 && i == 2 && noteBlockPlayOrder[i] == 3)
            {
                check++;
            }
            else
            {
                noteBlockPlayOrder.Clear();
                return;
            }
        }

    }
}
