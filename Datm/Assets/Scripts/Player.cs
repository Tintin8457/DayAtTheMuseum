using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float playerSpeed = 3.0f;
    public GameObject weaponHold;
    public LayerMask pickupMask;
    public Transform direction;
    Animator playerAnim;

    [Header("Health")]
    public int lives = 3;
    public TextMeshProUGUI livesText;

    [Header("Weapons")]
    public Sprite [] weaponImages;

    [Header("Weapon Inventory")]
    public Image weap1;
    public Image weap2;

    [Header("Equipped Weapons")]
    public bool equippedSword;
    public bool equippedGun;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives.ToString();
        playerAnim = GetComponent<Animator>();
        equippedSword = false;
        equippedGun = false;
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

        ////////////////Animations////////////////
        //Run with WASD
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            playerAnim.SetBool("run", true);
            playerAnim.SetBool("EquippedGun", false);
            playerAnim.SetBool("EquippedSword", false);
        }

        //Return to default state (idle) when not moving
        else
        {
            playerAnim.SetBool("run", false);
            playerAnim.SetBool("EquippedGun", false);
            playerAnim.SetBool("EquippedSword", false);
        }

        ////////////////Project a raycast to hit a pickup item////////////////
        Vector3 dir = direction.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(direction.transform.position, dir, out hit, 0.7f, pickupMask))
        {
            Debug.DrawRay(direction.transform.position, dir * hit.distance, Color.yellow);

            ////////////////Press E to pickup objects when a raycast has hit a pickup item////////////////
            if (Input.GetKey(KeyCode.E))
            {
                //Add the weapon to the inventory
                hit.collider.gameObject.transform.position = weaponHold.gameObject.transform.position;
                hit.collider.gameObject.transform.parent = weaponHold.gameObject.transform;
                //weaponHold.gameObject.transform.position = new Vector3(0.311f, 0.904f, -0.065f);
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
                    //weaponHold.gameObject.transform.position = new Vector3(0.311f, 0.904f, -0.065f);
                    if (weap1.sprite == null)
                    {
                        weap1.sprite = weaponImages[1];
                        //hit.collider.gameObject.transform.position = new Vector3(-0.015f, -0.01f, 0.0122f);
                    }

                    else if (weap2.sprite == null)
                    {
                        weap2.sprite = weaponImages[1];
                    }
                }
            }
        }

        ////////////////Left click to attack with the equipped weapon////////////////
            if (Input.GetMouseButton(0))
            {
                //Check if the player has equipped a sword
                if (equippedSword == true)
                {
                    playerAnim.SetBool("EquippedSword", true);
                }

                //Check if the player has equipped a gun
                else if (equippedGun == true)
                {
                    playerAnim.SetBool("EquippedGun", true);
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
                SceneManager.LoadScene("LoseScreen");
            }
        }
    }
}
