using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TransformInfomation
{
    public Vector3 position;
    public Quaternion rotation;
}

public class ProceduralGenerationPlant : MonoBehaviour
{
    private const string axiom = "YYY";
    private string theString = string.Empty;
    private Stack<TransformInfomation> transformStack;
    private Dictionary<char, string> rules;

    [Tooltip("You must fill all the parameters in the inspector")]
    [Header("Settings:")]
    [SerializeField] float length;
    [SerializeField] int angle;
    [SerializeField] int angleRandomRange;
    [SerializeField] int iterations;
    [SerializeField] GameObject branch;
    [SerializeField] GameObject leaf1, leaf2;

    void Start()
    {
        transformStack = new Stack<TransformInfomation>();
        DefineRules();
        GeneratePlant();
        RenderPlant();
    }

    private void DefineRules()
    {
        string alphebet = "XYF";
        string threeLetters1 = "";
        string threeLetters2 = "";

        for (int i = 0; i < 3; i++)
        {
            threeLetters1 += (alphebet[Random.Range(0, alphebet.Length)]);
            threeLetters2 += (alphebet[Random.Range(0, alphebet.Length)]);
        }

        string rule1 = "X[-" + threeLetters1 + "][+" + threeLetters2 + "]FX";
        string rule2 = "YFX[+Y][-Y]";

        rules = new Dictionary<char, string>
        {
            {'X', rule1},
            {'Y', rule2}
        };
    }

    private void GeneratePlant()
    {
        theString = axiom;
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < iterations; i++)
        {
            foreach (char c in theString)
            {
                sb.Append(rules.ContainsKey(c) ? rules[c] : c.ToString());
            }
            theString = sb.ToString();

            sb = new StringBuilder();
        }
    }

    private void RenderPlant()
    {
        foreach (char c in theString)
        {
            switch (c)
            {
                case 'F': // Straight Line
                    Vector3 initialPosition = transform.position;
                    transform.Translate(Vector3.up * length);
                    GameObject treeSegment = Instantiate(branch);

                    treeSegment.GetComponent<LineRenderer>().SetPosition(0, initialPosition);
                    treeSegment.GetComponent<LineRenderer>().SetPosition(1, transform.position);
                    break;

                case 'X': // Branch tips
                    SpawnLeaf();
                    break;

                case '+': // Clockwise
                    RandomRotate(-1);
                    break;


                case '-': // Anti-clockwise
                    RandomRotate(1);
                    break;

                case '[': // Push
                    transformStack.Push(new TransformInfomation()
                    {
                        position = transform.position,
                        rotation = transform.rotation
                    });
                    break;

                case ']': // Pop
                    TransformInfomation transformInfo = transformStack.Pop();
                    transform.position = transformInfo.position;
                    transform.rotation = transformInfo.rotation;
                    break;

                case 'Y': // Branch forks 
                    SpawnLeaf();
                    break;

                default:
                    throw new InvalidOperationException("L-System is Invalid");
            }
        }
    }

    private void RandomRotate(int i)
    {
        transform.Rotate(new Vector3(Random.Range(-angleRandomRange, angleRandomRange),
                                     Random.Range(-angleRandomRange, angleRandomRange), i) *
                            (angle + Random.Range(-angleRandomRange, angleRandomRange)));
    }

    private void SpawnLeaf()
    {
        GameObject leafObject = (Random.Range(0, 2) == 0) ? leaf1 : leaf2;
        Instantiate(leafObject, transform.position, transform.rotation);
    }
}
