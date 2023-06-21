using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class TransformInfo
{
    public Vector3 position;
    public Quaternion rotation;
}
public class LSystemScript : MonoBehaviour
{
    private const string axiom = "X"; // The OG Rule
    private string currentString = string .Empty;

    private Stack<TransformInfo> transformStack;
    private Dictionary</*type*/char,/*value*/string> rules;

    private int length;
    private int angle;
    private int iterations;
    public GameObject branch;
    // Start is called before the first frame update
    void Start()
    {
        length = 5;
        angle = 100;
        iterations = 5;
        transformStack = new Stack<TransformInfo>();

        rules = new Dictionary<char, string>
        {
            {'X', "[FX][-FX][+FX]"},
            {'F', "FF"}
        };

        Generate();
    }

    private void Generate()
    {
        currentString = axiom;

        StringBuilder sb = new StringBuilder();

        for(int i = 0; i < iterations; i++)
        {
            foreach (char c in currentString)
            {
                // *Append() adds the value to the StringBuilder
                // Term of Statement: if rules contains the key, then add value corresponding that key.
                // Otherwise, add the value itself
                sb.Append(rules.ContainsKey(c) ? rules[c] : c.ToString());
            }
            currentString = sb.ToString();

            sb = new StringBuilder();
        }
        //foreach(char c in currentString)
        //{
        //    // *Append() adds the value to the StringBuilder
        //    // Term of Statement: if rules contains the key, then add value corresponding that key.
        //    // Otherwise, add the value itself
        //    sb.Append(rules.ContainsKey(c) ? rules[c] : c.ToString());
        //}

        //currentString = sb.ToString();

        foreach(char c in currentString)
        {
            switch (c)
            {
                // F draws straight line
                case 'F':
                    // Start with storing initial position
                    Vector3 initialPosition = transform.position;
                    // Now we are going to move the treespawner
                    transform.Translate(Vector3.up * length);
                    // Using the branch we created earlier(prefab),
                    // Lets stantiate it
                    GameObject treeSegment = Instantiate(branch);
                    // Set the line renderer Values
                    treeSegment.GetComponent<LineRenderer>().SetPosition(0, initialPosition);
                    treeSegment.GetComponent<LineRenderer>().SetPosition(1, transform.position);
                    break;

                // X Generates more 'F's
                case 'X': // Atm we don't want it to do anything.
                    break;

                // + Clockwise rotation
                case '+':
                    transform.Rotate(Vector3.back * angle);
                    break;

                // _ Anti-clockwise rotation
                case '-':
                    transform.Rotate(Vector3.forward * angle);
                    break;

                // [ Save current transform info
                case '[':
                    transformStack.Push(new TransformInfo()
                    {
                        position = transform.position,
                        rotation = transform.rotation
                    });
                    break;

                //} return to the previously saved transform info
                case ']':
                    // new Variable for Transform iNFO (TI)
                    TransformInfo ti = transformStack.Pop();
                    // Set our position to the position of TI
                    transform.position = ti.position;
                    // Set our rotation to the rotation of TI
                    transform.rotation = ti.rotation;
                    break;

                default:
                    throw new InvalidOperationException("Your L-System is Invalid, Try Again!");
            }
        }
    }
}
