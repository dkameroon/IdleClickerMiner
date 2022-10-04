using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseMiner : BaseMiner
{
    public Deposit ElevatorDeposit { get; set; }
    public Vector3 ElevatorDepositLocation { get; set; }
    public Vector3 WarehouseLocation { get; set; }

    private int _walkAnimation = Animator.StringToHash("Walk");

    protected override void CollectGold()
    {
        if (!ElevatorDeposit.CanCollectGold)
        {
            RotateMiner(1);
            ChangeGoal();
            MoveMiner(WarehouseLocation);
            _animator.SetBool(_walkAnimation,false);
            return;
        }
        _animator.SetBool(_walkAnimation,false);
        float amountToCollect = ElevatorDeposit.CollectGold(this);
        float collectTime = CollectCapacity / CollectPerSecond;
        StartCoroutine(IECollect(amountToCollect, collectTime));
    }

    protected override IEnumerator IECollect(float gold, float collectTime)
    {
        yield return new WaitForSeconds(collectTime);
        CurrentGold = gold;
        ElevatorDeposit.RemoveGold(gold);
        _animator.SetBool(_walkAnimation,true);
        RotateMiner(1);
        ChangeGoal();
        MoveMiner(WarehouseLocation);
    }

    protected override void MoveMiner(Vector3 newPosition)
    {
        base.MoveMiner(newPosition);
        _animator.SetBool(_walkAnimation,true);
    }

    public override void OnClick()
    {
        RotateMiner(-1);
        MoveMiner(ElevatorDepositLocation);
    }
}
