using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selector_collision : MonoBehaviour
{
    [SerializeField]
    public float mouseX;
    public float temp_mousePosX;
    public List<GameObject> hexs;

    private float speed = 200f;
    void Start()
    {

        temp_mousePosX = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
        RotateSelector();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "hex")
        {
            hexs.Add(coll.gameObject);
            print("değdi");
            increaseZ();
        }
    }

    private void RotateSelector() {
        if (mouseX > temp_mousePosX)
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
            hexs[0].transform.RotateAround(transform.position, new Vector3(0f, 0f, 1f), speed * Time.deltaTime);
            hexs[1].transform.RotateAround(transform.position, new Vector3(0f, 0f, 1f), speed * Time.deltaTime);
            hexs[2].transform.RotateAround(transform.position, new Vector3(0f, 0f, 1f), speed * Time.deltaTime);
        }
        if (mouseX < temp_mousePosX) {
            transform.Rotate(Vector3.forward * -speed * Time.deltaTime);
            hexs[0].transform.RotateAround(transform.position, new Vector3(0f, 0f, 1f), -speed * Time.deltaTime);
            hexs[1].transform.RotateAround(transform.position, new Vector3(0f, 0f, 1f), -speed * Time.deltaTime);
            hexs[2].transform.RotateAround(transform.position, new Vector3(0f, 0f, 1f), -speed * Time.deltaTime);
        }
    }
    private void increaseZ() {
        
        hexs[0].transform.position = new Vector3(hexs[0].transform.position.x, hexs[0].transform.position.y, 1);
        hexs[0].transform.position = new Vector3(hexs[0].transform.position.x, hexs[0].transform.position.y, 1);
        hexs[0].transform.position = new Vector3(hexs[0].transform.position.x, hexs[0].transform.position.y, 1);
    }
}
