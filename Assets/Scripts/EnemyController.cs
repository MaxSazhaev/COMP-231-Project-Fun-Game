using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public int movespeed;
    public Vector3 userDirection = Vector3.back;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            userDirection = Vector3.forward;
        }
        if (other.gameObject.CompareTag("Wall2"))
        {
            userDirection = Vector3.back;
        }
        if (other.gameObject.CompareTag("Wall Left"))
        {
            userDirection = Vector3.right;
        }
        if (other.gameObject.CompareTag("Wall Right"))
        {
            userDirection = Vector3.left;
        }
        if (other.gameObject.CompareTag("LockedDoor"))
        {
            userDirection = Vector3.left;
        }
    }
        void Update () {
        transform.Translate(userDirection * movespeed * Time.deltaTime);
    }
}
