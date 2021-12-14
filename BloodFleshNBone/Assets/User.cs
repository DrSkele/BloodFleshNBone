using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : Unit
{
    enum Move { Forward}

    Dictionary<Move, int> UnitMove;

    bool isKnockedBack;
    Vector3 knockBackPosition;

    public User(int healthAmount) : base(healthAmount) { }

    private void Update()
    {
        if(!isKnockedBack)
        {
            _body.velocity = Vector3.right * 3;
        }
        else
        {
            int knockBackDistance = 10;
            
            if(_body.velocity.x < 0.5)
            {
                _body.velocity = _body.velocity * (1 - (Mathf.Abs(_body.transform.position.x - knockBackPosition.x) / knockBackDistance));
            }
            else
            {
                if ((knockBackPosition - this.transform.position).magnitude > knockBackDistance)
                {
                    isKnockedBack = false;
                }
            }
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Enemy>())
        {
            isKnockedBack = true;
            knockBackPosition = this.transform.position;
            _body.AddExplosionForce(300, collision.transform.position, 100);
        }
    }

    protected override void OnCollisionExit(Collision collision)
    {
        
    }

    protected override void OnCollisionStay(Collision collision)
    {
        
    }

    public override void Damage(params Damage[] damages)
    {
        base.Damage();
    }
}
