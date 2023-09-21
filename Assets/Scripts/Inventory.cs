using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<ItemSO> items;

    [SerializeField] private Transform slotParent;
    [SerializeField] private Slot[] slots;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    private void Awake()
    {
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
}
