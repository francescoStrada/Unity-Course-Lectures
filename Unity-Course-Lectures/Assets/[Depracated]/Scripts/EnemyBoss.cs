using System;
using UnityEngine;
using System.Collections;

public class EnemyBoss : EnemyEventListner
{
    public Action BossHt;

    protected void Start()
    {
        SubscribeToTargets();

    }

    // Update is called once per frame
    protected  override void Update()
    {
        base.Update();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            _targetAssigned = false;
            if (BossHt != null)
                BossHt();
        }
    }
}
