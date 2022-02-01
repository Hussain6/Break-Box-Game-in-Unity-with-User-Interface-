using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private GameMangerscript gm;
    public ParticleSystem expolision;
    public int pointvalue;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameMangerscript>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
        rb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10),ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4, 4), -3);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if(gm.isgameactive)
        {
            Instantiate(expolision, transform.position, expolision.transform.rotation);
            gm.update_score(pointvalue);
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gm.gameover();
        }
    }


}
