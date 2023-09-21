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

            //빈 슬롯이 아니라면 이미지 표시
            if(item != null)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1,1,1,1);
            }
            //빈 슬롯이라면 이미지를 표시하지 않음
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
            //장착 중인 아이템이었다면
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

            if (item.isEquiped)
            {
                popupText = "장비를 해제하시겠습니까?";
                Inventory.instance.ShowPopup(() => Dequip(), popupText);
            }
            else
            {
                popupText = "장비를 장착하시겠습니까?";
                Inventory.instance.ShowPopup(() => Equip(), popupText);
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
}
