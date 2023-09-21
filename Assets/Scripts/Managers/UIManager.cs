using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private PlayerSO playerInfo;

    [SerializeField] private GameObject statUI;
    [SerializeField] private GameObject inventoryUI;
    
    [SerializeField] private Text goldText;
    [SerializeField] private Text playerNameText;
    [SerializeField] private Text atkText;
    [SerializeField] private Text defText;
    [SerializeField] private Text conText;

    [SerializeField] private Button statBtn;
    [SerializeField] private Button inventoryBtn;
    [SerializeField] private Button closeBtn;

    [SerializeField] private Button item1_btn;
    [SerializeField] private Button item2_btn;
    [SerializeField] private Button item3_btn;

    public enum Menu
    {
        STATUS,
        INVENTORY,
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Equip()
    {

    }

    private void Unequip()
    {

    }

    private void UpdatePlayerStatus()
    {
        goldText.text = playerInfo.gold.ToString();
        playerNameText.text = playerInfo.playerName;
        atkText.text = playerInfo.atk.ToString();
        defText.text = playerInfo.def.ToString();
        conText.text = playerInfo.con.ToString();
    }
    private void StartSetting()
    {
        inventoryUI.SetActive(false);
        statUI.SetActive(false);
        closeBtn.gameObject.SetActive(false);
        UpdatePlayerStatus();
    }

    private void SetBase(Menu menu)
    {
        switch (menu)
        {
            case Menu.STATUS:
                {
                    statUI.SetActive(true);
                    break;
                }
            case Menu.INVENTORY:
                {
                    inventoryUI.SetActive(true);
                    break;
                }
            default:
                {
                    break;
                }
        }
        statBtn.gameObject.SetActive(false);
        inventoryBtn.gameObject.SetActive(false);
        closeBtn.gameObject.SetActive(true);
    }

    public void OnClickedStatusBtn()
    {
        SetBase(Menu.STATUS);
    }
    public void OnClickedInventoryBtn()
    {
        SetBase(Menu.INVENTORY);
    }

    public void OnClickedCloseBtn()
    {
        statBtn.gameObject.SetActive(true);
        inventoryBtn.gameObject.SetActive(true);
        StartSetting();
    }

    public void OnClickedItemBtn()
    {

    }
}
