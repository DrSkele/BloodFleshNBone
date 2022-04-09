using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : Unit
{
    enum Move { Forward}

    Dictionary<Move, int> UnitMove;

    bool isKnockedBack;
    Vector3 knockBackPosition;

    [SerializeField] AnimationCurve curve;

    public User(int healthAmount) : base(healthAmount) { }

    private void Update()
    {
        if(!isKnockedBack)
        {
            _body.velocity = Vector3.right * 3;
        }
    }

    Coroutine coroutine;
    protected override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Enemy>())
        {
            Debug.Log("what?");
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = StartCoroutine(KnockBack(30, 0.5f));
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


    private IEnumerator KnockBack(float distance, float duration)
    {
        float timeElapsed = 0;

        float distanceMoved = 0;

        isKnockedBack = true;
        _body.velocity = Vector3.zero;
        while(timeElapsed < duration)
        {
            distanceMoved += distance * (timeElapsed / duration);
            _body.transform.position += Vector3.left * distance * (Time.deltaTime * duration);
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        isKnockedBack = false;
    }
}
