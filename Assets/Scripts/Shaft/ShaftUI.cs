using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShaftUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI depositGold;
    [SerializeField] private TextMeshProUGUI shaftID;
    [SerializeField] private TextMeshProUGUI shaftLevel;
    [SerializeField] private TextMeshProUGUI newShaftCost;
    [SerializeField] private GameObject newShaftButton;
    
    private Shaft _shaft;

    private void Awake()
    {
        _shaft = GetComponent<Shaft>();
    }

    void Update()
    {
        depositGold.text = _shaft.ShaftDeposit.CurrentGold.ToString();
    }

    public void AddShaft()
    {
        ShaftManager.Instance.AddShaft();
        newShaftButton.SetActive(false);
    }

    public void SetShaftUI(int id)
    {
        _shaft.ShaftID = id;
        shaftID.text = (id + 1).ToString();
    }
    
    public void SetNewShaftCost(float newCost)
    {
        newShaftCost.text = newCost.ToString();
    }
}
