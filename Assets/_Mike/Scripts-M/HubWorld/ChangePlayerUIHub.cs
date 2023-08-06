using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangePlayerUIHub : MonoBehaviour
{
    [SerializeField] private GameObject oldFragmentsDisplay;
    [SerializeField] private GameObject newFragmentDisplay;
    [SerializeField] private TMP_Text fragmentCountUI;

    

    private void Start()
    {
        oldFragmentsDisplay.SetActive(false);
        newFragmentDisplay.SetActive(true);
    }

    private void Update()
    {
        fragmentCountUI.text = GameManager.Instance.GetFragments().ToString();
    }
}
