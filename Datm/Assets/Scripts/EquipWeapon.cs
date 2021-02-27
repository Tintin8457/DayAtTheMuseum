using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipWeapon : MonoBehaviour
{
    private Player weaponUpdate;
    public GameObject [] weapons;

    [Header("Slot Bools")]
    public bool slot1Selected;
    public bool slot2Selected;
    public bool slot3Selected;

    [Header("Buttons")]
    public Button button1;
    public Button button2;
    public Button button3;

    // Start is called before the first frame update
    void Start()
    {
        //Find player
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        //Get player
        if (player != null)
        {
            weaponUpdate = player.GetComponent<Player>();
        }

        slot1Selected = false;
        slot2Selected = false;
        slot3Selected = false;
    }

    ////////////////Equip Weapon////////////////
    ////////////////Slot 1////////////////
    public void Slot1()
    {
        //Equipped
        if (slot1Selected == false)
        {
            //Club
            if (weaponUpdate.weap1.sprite == weaponUpdate.weaponImages[0])
            {
                weapons[0].SetActive(true);
                slot1Selected = true;

                button2.interactable = false;
                button3.interactable = false;
            }

            //Sword
            else if (weaponUpdate.weap1.sprite == weaponUpdate.weaponImages[1])
            {
                weapons[1].SetActive(true);
                slot1Selected = true;

                button2.interactable = false;
                button3.interactable = false;
            }

            //Gun
            else if (weaponUpdate.weap1.sprite == weaponUpdate.weaponImages[2])
            {
                weapons[2].SetActive(true);
                slot1Selected = true;

                button2.interactable = false;
                button3.interactable = false;
            }
        }

        //Unequipped
        else if (slot1Selected == true)
        {
            //Club
            if (weaponUpdate.weap1.sprite == weaponUpdate.weaponImages[0])
            {
                weapons[0].SetActive(false);
                slot1Selected = false;

                button2.interactable = true;
                button3.interactable = true;
            }

            //Sword
            else if (weaponUpdate.weap1.sprite == weaponUpdate.weaponImages[1])
            {
                weapons[1].SetActive(false);
                slot1Selected = false;

                button2.interactable = true;
                button3.interactable = true;
            }

            //Gun
            else if (weaponUpdate.weap1.sprite == weaponUpdate.weaponImages[2])
            {
                weapons[2].SetActive(false);
                slot1Selected = false;

                button2.interactable = true;
                button3.interactable = true;
            }
        }
    }

    ////////////////Slot 2////////////////
    public void Slot2()
    {
        //Equipped
        if (slot2Selected == false)
        {
            //Club
            if (weaponUpdate.weap2.sprite == weaponUpdate.weaponImages[0])
            {
                weapons[0].SetActive(true);
                slot2Selected = true;

                button1.interactable = false;
                button3.interactable = false;
            }

            //Sword
            else if (weaponUpdate.weap2.sprite == weaponUpdate.weaponImages[1])
            {
                weapons[1].SetActive(true);
                slot2Selected = true;

                button1.interactable = false;
                button3.interactable = false;
            }
        
            //Gun
            else if (weaponUpdate.weap2.sprite == weaponUpdate.weaponImages[2])
            {
                weapons[2].SetActive(true);
                slot2Selected = true;

                button1.interactable = false;
                button3.interactable = false;
            }
        }

        //Unequipped
        else if (slot2Selected == true)
        {
            //Club
            if (weaponUpdate.weap2.sprite == weaponUpdate.weaponImages[0])
            {
                weapons[0].SetActive(false);
                slot2Selected = false;

                button1.interactable = true;
                button3.interactable = true;
            }

            //Sword
            else if (weaponUpdate.weap2.sprite == weaponUpdate.weaponImages[1])
            {
                weapons[1].SetActive(false);
                slot2Selected = false;

                button1.interactable = true;
                button3.interactable = true;
            }
        
            //Gun
            else if (weaponUpdate.weap2.sprite == weaponUpdate.weaponImages[2])
            {
                weapons[2].SetActive(false);
                slot2Selected = false;

                button1.interactable = true;
                button3.interactable = true;
            }
        }
    }

    ////////////////Slot 3////////////////
    public void Slot3()
    {
        //Equipped
        if (slot3Selected == false)
        {
            //Club
            if (weaponUpdate.weap3.sprite == weaponUpdate.weaponImages[0])
            {
                weapons[0].SetActive(true);
                slot3Selected = true;

                button1.interactable = false;
                button2.interactable = false;
            }

            //Sword
            else if (weaponUpdate.weap3.sprite == weaponUpdate.weaponImages[1])
            {
                weapons[1].SetActive(true);
                slot3Selected = true;

                button1.interactable = false;
                button2.interactable = false;
            }
        
            //Gun
            else if (weaponUpdate.weap3.sprite == weaponUpdate.weaponImages[2])
            {   
                weapons[2].SetActive(true);
                slot3Selected = true;

                button1.interactable = false;
                button2.interactable = false;
            }
        }

        //Unequipped
        else if (slot3Selected == true)
        {
            //Club
            if (weaponUpdate.weap3.sprite == weaponUpdate.weaponImages[0])
            {
                weapons[0].SetActive(false);
                slot3Selected = false;

                button1.interactable = true;
                button2.interactable = true;
            }

            //Sword
            else if (weaponUpdate.weap3.sprite == weaponUpdate.weaponImages[1])
            {
                weapons[1].SetActive(false);
                slot3Selected = false;

                button1.interactable = true;
                button2.interactable = true;
            }
        
            //Gun
            else if (weaponUpdate.weap3.sprite == weaponUpdate.weaponImages[2])
            {   
                weapons[2].SetActive(false);
                slot3Selected = false;

                button1.interactable = true;
                button2.interactable = true;
            }
        }
    }
}
