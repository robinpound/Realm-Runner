using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //This header will show the references in the editor
    [Header("Camera follow references")]
    //Will apply transform to player
    [SerializeField] private Transform _playerTransform;
    public float smoothSpeed = 0.125f;
    public Vector3 offSet;

    private Player _player;

    private void Awake()
    {
        offSet.z=-7.17f;
        offSet.y = 1.84f;
        //Getting the player to our transform component
        _player = _playerTransform.gameObject.GetComponent<Player>();
        transform.position = _playerTransform.position;
        StopCoroutine(PlayerMove());
    }
    void FixedUpdate()
    {
        StartCoroutine(PlayerMove());
    }
    private IEnumerator PlayerMove()
    {
        if (_player != null)
        {
            Vector3 targetPosition = _player.transform.position + offSet;
            Vector3 movedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            transform.position = movedPosition;
            yield return new WaitForSeconds(.5f);
        }
    }
}
