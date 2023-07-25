using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScrol : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] Scrollbar scroll;
    [SerializeField] bool creditsOpen;

    [SerializeField] bool scrollUp;
    [SerializeField] bool scrollDown;

    float speed;
    private void Update()
    {
        speed = 2f;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        scrollUp = canvas.GetComponent<UiInput>().scrollUp;
        scrollDown = canvas.GetComponent<UiInput>().scrollDown;
        creditsOpen = canvas.GetComponent<MainMenu>().creditsOpen;
        ScrollDown();
        ScrollUp();
    }

    // Function to Scroll Down
    public void ScrollDown()
    {
        if (creditsOpen && scrollDown)
        {
            scroll.value -= speed * Time.deltaTime;
        }
    }
    public void ScrollUp()
    {
        if (creditsOpen && scrollUp)
        {
            scroll.value += speed * Time.deltaTime;
        }
    }

}
