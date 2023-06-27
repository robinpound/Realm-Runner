using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject player;

    public Vector3 up = new Vector3(0, 10, 0);
    public Vector3 down = new Vector3(0, -10, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 100*Time.deltaTime, 0);
        //StartCoroutine(Bounce());
    }
    IEnumerator Bounce()
    {
        transform.position += Vector3.up * Time.deltaTime;
        yield return new WaitForSeconds(0.5f);
        transform.position += Vector3.down * Time.deltaTime;
        StopCoroutine(Bounce());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.GetComponent<PlayerUIHealth>().health++;
            Destroy(gameObject, 0.5f);
        }
    }
}
