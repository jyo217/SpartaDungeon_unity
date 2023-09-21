using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<ItemSO> items;

    [SerializeField] private EquipmentPopup popup;
    [SerializeField] private Transform slotParent;
    [SerializeField] private Slot[] slots;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        if(popup == null)
        {
            popup = GetComponent<EquipmentPopup>();
        }
        UpdateSlot();
    }

    public void UpdateSlot()
    {
        int i = 0;
        //현재까지 슬롯에 추가한 아이템의 갯수가 슬롯의 한도나 아이템 리스트의 한도 이하일 때 까지 추가한다.
        for(; i < items.Count && i < slots.Length ; i++)
        {
            slots[i].Item = items[i];
        }
        //인벤토리의 공간이 아직 남았다면 빈 칸으로 채운다.
        for (; i < slots.Length ; i++)
        {
            slots[i].Item = null;
        }
    }

    public void AddItem(ItemSO item)
    {
        if(items.Count < slots.Length)
        {
            items.Add(item);
            UpdateSlot();
        }
        else
        {
            Debug.Log("Inventory Is FULL!!!");
        }
    }

    public void ShowPopup(Action okCallback, string text)
    {
        Debug.Log("*****");
        popup.ShowPopup(okCallback, text);
    }
}
