using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInventory : MonoBehaviour
{
    private int activeSlot = 0;

    private PlayerControls plc;

    private void Awake()
    {
        plc = new PlayerControls();
    }

    private void Start()
    {
        plc.Inventory.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());
    }

    private void OnEnable()
    {
        plc.Enable();
    }

    private void ToggleActiveSlot(int numValue)
    {
        ToggleActiveHighLight(numValue - 1);
    }

    private void ToggleActiveHighLight(int indexnum)
    {
        activeSlot = indexnum; 

        foreach (Transform inventoryslot in this.transform)
        {
            inventoryslot.GetChild(0).gameObject.SetActive(false);
        }

        this.transform.GetChild(indexnum).GetChild(0).gameObject.SetActive(true);
    }
}
