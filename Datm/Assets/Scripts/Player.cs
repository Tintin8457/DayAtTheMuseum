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

    [Header("Health")]
    public int lives = 3;
    public TextMeshProUGUI livesText;

    [Header("Weapons")]
    public Sprite [] weaponImages;

    [Header("Weapon Inventory")]
    public Image weap1;
    public Image weap2;
    public Image weap3;
    // public Image weap4;
    // public Image weap5;

    // [Header("Collected Weapons")]
    // public bool hasClub;
    // public bool hasSword;  
    // public bool hasGun;  
    // public bool hasLauncher;
    // public bool hasGrenade;

    // [Header("Equip Weapons")]
    // public bool equipClub;
    // public bool equipSword;  
    // public bool equipGun;  
    // public bool equipLauncher;
    // public bool equipGrenade;

    // Start is called before the first frame update
    void Start()
    {
        //canInteract = false;
        livesText.text = "Lives: " + lives.ToString();

        // hasClub = false;
        // hasSword = false;
        // hasGun = false;
        // hasLauncher = false;
        // hasGrenade = false;

        // equipClub = false;
        // equipSword = false;
        // equipGun = false;
        // equipLauncher = false;
        // equipGrenade = false;
    }

    // Update is called once per frame
    void Update()
    {
        ////////////////Player Movement////////////////
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * playerSpeed);

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
                //Club to inventory
                if (hit.collider.gameObject.tag == "Club")
                {
                    if (weap1.sprite == null)
                    {
                        weap1.sprite = weaponImages[0];
                        //hasClub = true;
                    }

                    else if (weap2.sprite == null)
                    {
                        weap2.sprite = weaponImages[0];
                        //hasClub = true;
                    }

                    else if (weap3.sprite == null)
                    {
                        weap3.sprite = weaponImages[0];
                        //hasClub = true;
                    }

                    // else if (weap4.sprite == null)
                    // {
                    //     weap4.sprite = weaponImages[0];
                    //     //hasClub = true;
                    // }

                    // else if (weap5.sprite == null)
                    // {
                    //     weap5.sprite = weaponImages[0];
                    //     //hasClub = true;
                    // }
                }

                //Sword to inventory
                if (hit.collider.gameObject.tag == "Sword")
                {
                    if (weap1.sprite == null)
                    {
                        weap1.sprite = weaponImages[1];
                        //hasSword = true;
                    }

                    else if (weap2.sprite == null)
                    {
                        weap2.sprite = weaponImages[1];
                        //hasSword = true;
                    }

                    else if (weap3.sprite == null)
                    {
                        weap3.sprite = weaponImages[1];
                        //hasSword = true;
                    }

                    // else if (weap4.sprite == null)
                    // {
                    //     weap4.sprite = weaponImages[1];
                    //     //hasSword = true;
                    // }

                    // else if (weap5.sprite == null)
                    // {
                    //     weap5.sprite = weaponImages[1];
                    //     //hasSword = true;
                    // }
                }

                //Gun to inventory
                if (hit.collider.gameObject.tag == "Gun")
                {
                    if (weap1.sprite == null)
                    {
                        weap1.sprite = weaponImages[2];
                        //hasGun = true;
                    }

                    else if (weap2.sprite == null)
                    {
                        weap2.sprite = weaponImages[2];
                        //hasGun = true;
                    }

                    else if (weap3.sprite == null)
                    {
                        weap3.sprite = weaponImages[2];
                        //hasGun = true;
                    }

                    // else if (weap4.sprite == null)
                    // {
                    //     weap4.sprite = weaponImages[2];
                    //     //hasGun = true;
                    // }

                    // else if (weap5.sprite == null)
                    // {
                    //     weap5.sprite = weaponImages[2];
                    //     //hasGun = true;
                    // }
                }

                //Rocket Launcher to inventory
                // if (hit.collider.gameObject.tag == "RocketLauncher")
                // {
                //     if (weap1.sprite == null)
                //     {
                //         weap1.sprite = weaponImages[3];
                //         //hasLauncher = true;
                //     }

                //     else if (weap2.sprite == null)
                //     {
                //         weap2.sprite = weaponImages[3];
                //         //hasLauncher = true;
                //     }

                //     else if (weap3.sprite == null)
                //     {
                //         weap3.sprite = weaponImages[3];
                //         //hasLauncher = true;
                //     }

                //     else if (weap4.sprite == null)
                //     {
                //         weap4.sprite = weaponImages[3];
                //         //hasLauncher = true;
                //     }

                //     else if (weap5.sprite == null)
                //     {
                //         weap5.sprite = weaponImages[3];
                //         //hasLauncher = true;
                //     }
                // }

                //Grenade to inventory
                // if (hit.collider.gameObject.tag == "Grenade")
                // {
                //     if (weap1.sprite == null)
                //     {
                //         weap1.sprite = weaponImages[4];
                //         //hasGrenade = true;
                //     }

                //     else if (weap2.sprite == null)
                //     {
                //         weap2.sprite = weaponImages[4];
                //         //hasGrenade = true;
                //     }

                //     else if (weap3.sprite == null)
                //     {
                //         weap3.sprite = weaponImages[4];
                //         //hasGrenade = true;
                //     }

                //     else if (weap4.sprite == null)
                //     {
                //         weap4.sprite = weaponImages[4];
                //         //hasGrenade = true;
                //     }

                //     else if (weap5.sprite == null)
                //     {
                //         weap5.sprite = weaponImages[4];
                //         //hasGrenade = true;
                //     }
                // }
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
