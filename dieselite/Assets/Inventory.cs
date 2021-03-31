using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> content = new List<Item>();
    public int contentCurrentIndex = 0;
    public Image itemIUImage;
    public Sprite emptyItemImage;

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance de Inventory dans la scène");
            return;
        }
        instance = this;
    }

    // update inventory
    private void Start()
    {
        UpdateInventoryUI();
    }

    // item consumption
    public void ConsumeItem()
    {
        if(content.Count == 0)
        {
            return;
        }

        Item currentItem = content[0];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        content.Remove(currentItem);
        GetNexItem();
        UpdateInventoryUI();
    }

    // next item
    public void GetNexItem()
    {
        if (content.Count == 0)
        {
            return;
        }

        contentCurrentIndex++;
        if(contentCurrentIndex > content.Count -1)
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    // previous item
    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }

        contentCurrentIndex--;
        if(contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if(content.Count > 0)
        {
            itemIUImage.sprite = content[contentCurrentIndex].image;
        }
        else
        {
            itemIUImage.sprite = emptyItemImage;
        }
        
    }

}

