using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class LightUpFragmentStatue : MonoBehaviour
{
    [SerializeField]
    private GameObject lightUpStatue, rockStatue;

    public void LightUpFragment()
    {
        rockStatue.SetActive(false);
        lightUpStatue.SetActive(true);
    }
}
