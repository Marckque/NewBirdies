using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private Text currentItemText;

    [Header("Items")]
    [SerializeField]
    private Transform itemsContainer;
    [SerializeField, Range(1, 5)]
    private int inventorySize = 1;

    private Item[] items;
    private Item currentItem;
    private int inventoryIndex;

    protected void Awake()
    {
        InitialiseItems();
        UpdateCurrentItem();
        UpdateCurrentItemText();
    }

    protected void Update()
    {
        SelectItem();
    }

    private void InitialiseItems()
    {
        items = new Item[inventorySize];

        for (int i = 0; i < items.Length - 1; i++)
        {
            Item item = itemsContainer.GetChild(i).GetComponent<Item>();

            if (item)
            {
                items[i] = item;
            }            
            else
            {
                Debug.LogError("An object is not of the Item type in the inventory!");
            }
        }
    }

    private void SelectItem()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            IncrementInventoryIndex();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            DecrementInventoryIndex();
        }
    }

    private void IncrementInventoryIndex()
    {
        if (inventoryIndex < items.Length - 1)
        {
            inventoryIndex++;
        }
        else
        {
            inventoryIndex = 0;
        }

        UpdateCurrentItem();
    }

    private void DecrementInventoryIndex()
    {
        if (inventoryIndex > 0)
        {
            inventoryIndex--;
        }
        else
        {
            inventoryIndex = items.Length - 1;
        }

        UpdateCurrentItem();
    }

    private void UpdateCurrentItem()
    {
        DeactivateAllItems();

        currentItem = items[inventoryIndex];
        UpdateCurrentItemText();

        if (currentItem)
        {
            currentItem.OnActivation();
        }
    }

    private void UpdateCurrentItemText()
    {
        if (currentItem)
        {
            currentItemText.text = currentItem.name;
        }
        else
        {
            currentItemText.text = "None";
        }
    }

    private void DeactivateAllItems()
    {
        foreach (Item item in items)
        {
            if (item)
            {
                item.OnDeactivation();
            }
        }
    }
}