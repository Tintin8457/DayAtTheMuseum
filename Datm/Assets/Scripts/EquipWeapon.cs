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
    //public bool slot3Selected;

    [Header("Buttons")]
    public Button button1;
    public Button button2;

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
    }

    ////////////////Equip Weapon////////////////
    ////////////////Slot 1////////////////
    public void Slot1()
    {
        //Equipped
        if (slot1Selected == false)
        {
            //Sword
            if (weaponUpdate.weap1.sprite == weaponUpdate.weaponImages[0])
            {
                weapons[0].SetActive(true);
                slot1Selected = true;

                button2.interactable = false;
            }

            //Gun
            else if (weaponUpdate.weap1.sprite == weaponUpdate.weaponImages[1])
            {
                weapons[1].SetActive(true);
                slot1Selected = true;

                button2.interactable = false;
            }
        }

        //Unequipped
        else if (slot1Selected == true)
        {
            //Sword
            if (weaponUpdate.weap1.sprite == weaponUpdate.weaponImages[0])
            {
                weapons[0].SetActive(false);
                slot1Selected = false;

                button2.interactable = true;
            }

            //Gun
            else if (weaponUpdate.weap1.sprite == weaponUpdate.weaponImages[1])
            {
                weapons[1].SetActive(false);
                slot1Selected = false;

                button2.interactable = true;
            }
        }
    }

    ////////////////Slot 2////////////////
    public void Slot2()
    {
        //Equipped
        if (slot2Selected == false)
        {
            //Sword
            if (weaponUpdate.weap2.sprite == weaponUpdate.weaponImages[0])
            {
                weapons[0].SetActive(true);
                slot2Selected = true;

                button1.interactable = false;
            }

            //Gun
            else if (weaponUpdate.weap2.sprite == weaponUpdate.weaponImages[1])
            {
                weapons[1].SetActive(true);
                slot2Selected = true;

                button1.interactable = false;
            }
        }

        //Unequipped
        else if (slot2Selected == true)
        {
            //Sword
            if (weaponUpdate.weap2.sprite == weaponUpdate.weaponImages[0])
            {
                weapons[0].SetActive(false);
                slot2Selected = false;

                button1.interactable = true;
            }

            //Gun
            else if (weaponUpdate.weap2.sprite == weaponUpdate.weaponImages[1])
            {
                weapons[1].SetActive(false);
                slot2Selected = false;

                button1.interactable = true;
            }
        }
    }
}
