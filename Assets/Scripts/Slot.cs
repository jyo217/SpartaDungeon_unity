using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] PlayerSO player;
    [SerializeField] Text equipText;

    private ItemSO item;

    public ItemSO Item
    {
        get { return item; }
        set
        {
            item = value;

            //�� ������ �ƴ϶�� �̹��� ǥ��
            if(item != null)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1,1,1,1);
            }
            //�� �����̶�� �̹����� ǥ������ ����
            else
            {
                image.color = new Color(1,1,1,0);
            }
        }
    }

    private void Update()
    {
        if(item != null)
        {
            //���� ���� �������̾��ٸ�
            if (item.isEquiped)
            {
                equipText.gameObject.SetActive(true);
            }
            else
            {
                equipText.gameObject.SetActive(false);
            }
        }
    }

    public void OnClickSlot()
    {
        if(item != null)
        {
            string popupText = "";
            string popupLable = GetLableText();

            if (item.isEquiped)
            {
                popupText = "��� �����Ͻðڽ��ϱ�?";
                
                Inventory.instance.ShowPopup(() => Dequip(), popupText, popupLable);
            }
            else
            {
                popupText = "��� �����Ͻðڽ��ϱ�?";
                Inventory.instance.ShowPopup(() => Equip(), popupText, popupLable);
            }
        }
    }

    private void Equip()
    {
        player.atk += item.atk;
        player.def += item.def;
        player.con += item.con;
        item.isEquiped = true;
    }

    private void Dequip()
    {
        player.atk -= item.atk;
        player.def -= item.def;
        player.con -= item.con;
        item.isEquiped = false;
    }

    private string GetLableText()
    {
        string popupLable = "";

        if (item.atk != 0)
        {
            if (item.atk > 0)
            {
                popupLable += "+ ";
            }
            popupLable += $"{item.atk} ATK";
        }
        if (item.def != 0)
        {
            if (item.def > 0)
            {
                popupLable += "+ ";
            }
            popupLable += $"{item.def} DEF";
        }
        if (item.con != 0)
        {
            if (item.con > 0)
            {
                popupLable += "+ ";
            }
            popupLable += $"{item.con} CON";
        }

        return popupLable;
    }
}
