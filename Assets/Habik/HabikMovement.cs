using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabikMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float border;

    // Update is called once per frame
    void Update() {

        float xMove = 0;

        if(Input.GetKey(KeyCode.A)) {
            xMove = -1;
        }
        if(Input.GetKey(KeyCode.D)) {
            xMove = 1;
        }

        transform.Translate(xMove * speed * Time.deltaTime, 0, 0);
    
        if(transform.position.x < -border) {
            transform.position = new Vector3(-border, transform.position.y, transform.position.z);
        }
        if(transform.position.x > border) {
            transform.position = new Vector3(border, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision) {

        var fo = collision.gameObject.GetComponent<FallingObject>();
        //Debug.Log(fo);

        if(fo != null) {
            
            fo.Collect();
        }

        Destroy(collision.gameObject);
    }
}