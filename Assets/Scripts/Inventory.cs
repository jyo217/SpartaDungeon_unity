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
        //������� ���Կ� �߰��� �������� ������ ������ �ѵ��� ������ ����Ʈ�� �ѵ� ������ �� ���� �߰��Ѵ�.
        for(; i < items.Count && i < slots.Length ; i++)
        {
            slots[i].Item = items[i];
        }
        //�κ��丮�� ������ ���� ���Ҵٸ� �� ĭ���� ä���.
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
