using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float playerSpeed = 3.0f;
    public GameObject weaponHold;
    //public bool canInteract;
    public LayerMask pickupMask;
    Animator playerAnim;

    [Header("Health")]
    public int lives = 3;
    public TextMeshProUGUI livesText;

    [Header("Weapons")]
    public Sprite [] weaponImages;

    [Header("Weapon Inventory")]
    public Image weap1;
    public Image weap2;

    // Start is called before the first frame update
    void Start()
    {
        //canInteract = false;
        livesText.text = "Lives: " + lives.ToString();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Idle anim
        //playerAnim.SetBool("notMove", false);

        ////////////////Player Movement////////////////
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * playerSpeed);

        //Run animation
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            playerAnim.SetBool("run", true);
        }

        else
        {
            playerAnim.SetBool("run", false);
        }

        ////////////////Project a raycast to hit a pickup item////////////////
        Vector3 dir = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, dir, out hit, pickupMask))
        {
            Debug.DrawRay(transform.position, dir * hit.distance, Color.red);

            ////////////////Press E to pickup objects when a raycast has hit a pickup item////////////////
            if (Input.GetKey(KeyCode.E))
            {
                //Add the weapon to the inventory
                hit.collider.gameObject.transform.parent = weaponHold.gameObject.transform;
                hit.collider.gameObject.SetActive(false);

                ////////////////Update inventory with collected weapons to images////////////////
                //Sword to inventory
                if (hit.collider.gameObject.tag == "Sword")
                {
                    if (weap1.sprite == null)
                    {
                        weap1.sprite = weaponImages[0];
                    }

                    else if (weap2.sprite == null)
                    {
                        weap2.sprite = weaponImages[0];
                    }
                }

                //Gun to inventory
                if (hit.collider.gameObject.tag == "Gun")
                {
                    if (weap1.sprite == null)
                    {
                        weap1.sprite = weaponImages[1];
                    }

                    else if (weap2.sprite == null)
                    {
                        weap2.sprite = weaponImages[1];
                    }
                }
            }
        }
    }

    ////////////////Will use this temporarily for enemy collision////////////////
    void OnCollisionEnter(Collision enem)
    {
        //Lose lives
        if (enem.gameObject.tag == "Enemy")
        {
            if (lives > 0)
            {
                lives -= 1;
                livesText.text = "Lives: " + lives.ToString();
            }

            //Stop health decreasing after 0
            else if (lives <= 0)
            {
                lives = 0;
                livesText.text = "Lives: " + lives.ToString();
            }
        }
    }
}
