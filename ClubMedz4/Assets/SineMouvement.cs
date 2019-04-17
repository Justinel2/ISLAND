using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMouvement : MonoBehaviour
{
    GameObject water;
    //Material m_Material;
    //public int n;
    public AnimationCurve myCurve;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(myCurve.Evaluate((Time.time % myCurve.length))*20, transform.position.y, myCurve.Evaluate((Time.time % myCurve.length / 2)) * 20);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Shark")
        {

        }
    }
}

