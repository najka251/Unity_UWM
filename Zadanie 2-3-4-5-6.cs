using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KodZadanie2i3 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float force = 3.0f;
    public float sensitivity = 10f;
    private float rotY = 0.0f;

    private void Start()
    {
        // zakładamy, że komponent CharacterController jest już podpięty pod obiekt
        controller = GetComponent<CharacterController>();
    }



    void Update()
    {
        // wyciągamy wartości, aby możliwe było ich efektywniejsze wykorzystanie w funkcji
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // zmieniamy sposób poruszania się postaci
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // transform.right odpowiada za ruch wzdłuż osi x (pamiętajmy, że wartości będą zarówno dodatnie
        // jak i ujemne, a punkt (0,0) jest na środku ekranu) a transform.forward za ruch wzdłóż osi z.
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // to już nam potrzebne nie będzie
        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            // wzór na siłę 
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // prędkość swobodnego opadania zgodnie ze wzorem y = (1/2 * g) * t-kwadrat 
        // okazuje się, że jest to zbyt wolne opadanie, więc zastosowano g * t-kwadrat
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        //Ograniczenie obrotu kamery do -90 i 90 góra/dół
        var c = Camera.main.transform;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -90f, 90f);
        c.transform.eulerAngles = new Vector3(rotY, 0, 0);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.name == "plytanaciskowa")
        {
            playerVelocity.y = force * Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            playerVelocity.y += gravityValue * Time.deltaTime;
        }
        if (hit.gameObject.CompareTag("Przeszkoda"))
        {
            Debug.Log("Player zderzył się z przeszkoda.");
        }
    }
}
