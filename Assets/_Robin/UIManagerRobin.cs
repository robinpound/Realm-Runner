using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerRobin : MonoBehaviour
{
    [SerializeField] TMP_Text coinNumberText;
    [SerializeField] TMP_Text FragmentNumberText;

    private void Start() {
        GameManager.Instance.GetFragments();
        GameManager.Instance.GetCoins();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ExitGame() => Application.Quit();


}
