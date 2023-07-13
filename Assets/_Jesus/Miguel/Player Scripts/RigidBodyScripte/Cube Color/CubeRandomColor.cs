using UnityEngine;

public class CubeRandomColor : MonoBehaviour
{
  private void Awake() {
    this.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0.0f, 1.0f, 0.75f, 1.0f, 0.5f, 1.0f);
  }
}
