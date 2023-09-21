using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] PlayerSO player;
    [SerializeField] Text equipText;
    [SerializeField] GameObject popup;

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
        if (item.isEquiped)
        {
            popup.transform.GetChild(0).GetComponent<Text>().text = "��� �����Ͻðڽ��ϱ�?";
        }
        else
        {
            popup.transform.GetChild(0).GetComponent<Text>().text = "��� �����Ͻðڽ��ϱ�?";
        }

        popup.SetActive(true);
    }
    
    public void OnClickYes()
    {
        if (item.isEquiped)
        {
            popup.SetActive(false);
            player.atk -= item.atk;
            player.def -= item.def;
            player.con -= item.con;
            item.isEquiped = false;
        }
        else
        {
            popup.SetActive(false);
            player.atk += item.atk;
            player.def += item.def;
            player.con += item.con;
            item.isEquiped = true;
        }
    }

    public void OnClickNo()
    {
        popup.SetActive(false);
    }
}
