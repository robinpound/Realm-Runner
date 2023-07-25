using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    
    [HideInInspector]
    public CharacterController controller;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    //Character controller default is grounded check
    public bool IsGrounded() => controller.isGrounded;

   
    }



