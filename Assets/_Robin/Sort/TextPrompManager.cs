using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

[System.Serializable]
public class TriggerInstruction
{
    public Collider triggerBox;
    public string theText;
}

public class TextPrompManager : MonoBehaviour
{
    
    [Header("READ TOOLTIPS")]
    [Tooltip("TMPtext is found in the Canvas, called 'Prompt'. "
            +"It's used to display the output of this manager.\n\n"
            +"If 'Prompt' doesn't exist, create a TMPro Text on the canvas, "
            +"add the enchantment font, then center on bottom middle of the screen.")]
    [SerializeField] private TMP_Text TMPtext;

    [Tooltip("This is an expandable list of: Trigger boxes & their corresponding instructional texts. e.g. 'SPACE to Jump'\n\n" 
            +"1. Create a collider directly on this manager, and turn on the isTrigger in inspector\n"
            +"2. click '+' on this list then drag and drop the collider object into this list\n"
            +"3. Type the text you want it to display\n"
            +"4. Adjust the size/shape and position")]
    [SerializeField] List<TriggerInstruction> triggerList = new List<TriggerInstruction>();

    
    public void ClearText() => DisplayText("");
    public void SetText(Collider triggerCollider)
    {
        foreach (var TriggerInstruction in triggerList)
        {
            if (TriggerInstruction.triggerBox == triggerCollider)
            {
                DisplayText(TriggerInstruction.theText);
                break;
            }
        }
    }
    private void DisplayText(string t) => TMPtext.text = t;
}