using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float Speed;    
    public AudioClip soundPickUp;
    public Text countText, winText;
    private Rigidbody rb;
    private int count;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";

    }

    // 計算物理性前即執行
    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * Speed);
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(soundPickUp, transform.position);
            count++;
            setCountText();
        }
    }

    void setCountText() {
        countText.text = "Count: " + count.ToString();
        if (count == 12){
            winText.text = "You Win!";
        }
    }
}
