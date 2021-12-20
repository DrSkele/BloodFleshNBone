using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Movable
{
    protected virtual void Forward(Rigidbody body, int amount, int limit = 0)
    {
        if(limit != 0)
        {
            if (body.velocity.magnitude < limit)
                body.AddForce(Vector3.right * amount);
        }
    }

    protected virtual void KnockBack(Rigidbody body, int amount)
    {

    }
}
