using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> content = new List<Item>();
    public int contentCurrentIndex = 0;
    public Image itemIUImage;
    public Sprite emptyItemImage;

    // update inventory
    private void Start()
    {
        UpdateIventoryUI();
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
        UpdateIventoryUI();
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
        UpdateIventoryUI();
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
        UpdateIventoryUI();
    }

    public void UpdateIventoryUI()
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

