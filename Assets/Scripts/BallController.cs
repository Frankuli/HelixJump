using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;

    public float impulseForce = 3;

    private bool ignoreNextCollision;
    private Vector3 starPosition;

    [HideInInspector] public int perfectPast;
    private bool isSueperSpeedActive;
    public int perfectPastCount;
    public float superSpeed = 8;

    public GameObject splash;




    private void Start()
    {
        starPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        AddSplash(collision);

        if (ignoreNextCollision)
        {
            return;
        }

        if (isSueperSpeedActive && !collision.transform.GetComponent<GoalController>())
        {
            Destroy(collision.transform.parent.gameObject, 0.2f);
        }
        else
        {
            DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
            if (deathPart)
            {
                GameManager.singleton.RestartLevel();
            }
        }

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse );

        ignoreNextCollision = true;
        Invoke("AllowNextCollision", 0.2f);

        perfectPast = 0;
        isSueperSpeedActive = false; 
    }

    private void Update()
    {
        if (perfectPast >= perfectPastCount && !isSueperSpeedActive)
        {
            isSueperSpeedActive = true;

            rb.AddForce(Vector3.down * superSpeed, ForceMode.Impulse);

        }
    }

    private void AllowNextCollision()
    {
        ignoreNextCollision = false;
    }

    public void ResetBall()
    {
        transform.position = starPosition;
    }

    public void AddSplash(Collision collision)
    {
        GameObject newSplash;
        newSplash = Instantiate(splash);

        newSplash.transform.SetParent(collision.transform);

        newSplash.transform.position = new Vector3( this.transform.position.x, 
                                                    this.transform.position.y-0.11f,        
                                                    this.transform.position.z );

        Destroy(newSplash, 3);
    }

}
