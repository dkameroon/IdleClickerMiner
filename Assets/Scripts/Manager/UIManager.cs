using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalGoldText;

    // Update is called once per frame
    void Update()
    {
        totalGoldText.text = GoldManager.Instance.CurrentGold.ToString();
    }
}
