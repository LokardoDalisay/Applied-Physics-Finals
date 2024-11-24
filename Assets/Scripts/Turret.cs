using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]private GameObject bullet;
    [SerializeField]private Transform bulletPos;
    [SerializeField]private GameObject _Target;
    [SerializeField]private GameObject _Detector;
    [SerializeField] private float _detectionAngle = 30f;
    [SerializeField] private float _detectionRange = 2f;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        _Target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDetected();   
        
    }

    void PlayerDetected()
    {
        var dot = Vector2.Dot(this.transform.up, _Target.transform.position);
        var detectionCone = dot * Mathf.Rad2Deg;
        var distance = _Target.transform.position - this.transform.position;
        
        // Vector2 targetPos = _TurretTarget.transform.position;
        // Direction = targetPos - (Vector2)transform.position;

        if (Mathf.Abs(detectionCone) <= _detectionAngle && distance.magnitude <= _detectionRange)
        {
            Debug.Log("Alert");
           _Detector.GetComponent<SpriteRenderer>().color = Color.red;
            timer += Time.deltaTime;
            if(timer > 1)
            {
                timer = 0;
                shoot();
            }
        }
        else
        {
            _Detector.GetComponent<SpriteRenderer>().color = Color.green;
        }

                 
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.DrawSphere(transform.position, _detectionRange);
    }
}
