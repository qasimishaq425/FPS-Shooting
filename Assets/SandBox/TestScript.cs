using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Transform point;
    Vector3 pos;
    float speed=0.3f;
    Vector3 vec;
    // Start is called before the first frame update
    void Start()
    {
        pos = gameObject.transform.localPosition;
        vec = pos;
    }

    // Update is called once per frame
    void Update()
    {
       // this.gameObject.transform.localPosition = Vector3.Lerp(this.gameObject.transform.localPosition, point.localPosition, 0.5f);
        //Vector3 vec = Vector3.Lerp(pos, point.localPosition,Time.time);
        //Debug.Log(Time.time);
        //gameObject.transform.localPosition = vec;
       // this.gameObject.transform.localPosition = new Vector3(x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z);
    }
    void FixedUpdate()
    {
        gameObject.transform.localPosition = vec;
        vec = Vector3.Lerp(pos, point.localPosition, Time.time-speed);
        Debug.Log(Time.time);
     
    }
}
