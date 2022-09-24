using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShaftManager : Singleton<ShaftManager>
{
    public static ShaftManager Instance;
    
    [SerializeField] private Shaft shaftPrefab;
    [SerializeField] private float newShaftYPosition;
    [SerializeField] private float newShaftCost = 5000;
    [SerializeField] private float newShaftCostMultiplier = 10;
    [SerializeField] private List<Shaft> shafts;

    public float ShaftCost { get; set; }
    
    private int _currentShaftIndex;

    private void Start()
    {
        ShaftCost = newShaftCost;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            AddShaft();
        }
    }

    public void AddShaft()
    {
        Transform lastShaft = shafts[_currentShaftIndex].transform;
        Vector3 newShaftPos = new Vector3(lastShaft.position.x,lastShaft.position.y - newShaftYPosition);
        Shaft newShaft = Instantiate(shaftPrefab, newShaftPos,quaternion.identity);

        _currentShaftIndex++;
        ShaftCost *= newShaftCostMultiplier;
        newShaft.ShaftUI.SetShaftUI(_currentShaftIndex);
        newShaft.ShaftUI.SetNewShaftCost(ShaftCost);
        shafts.Add(newShaft);
    }
}
