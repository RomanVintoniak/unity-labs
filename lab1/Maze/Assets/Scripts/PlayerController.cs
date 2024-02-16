using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI finalText;

    private Rigidbody rb;
    private int counter = 5;

    // Score at start is 5
    // There are 8 safe pickUps and 4 dangerous pickUps
    // MIN_SCORE_FOR_WIN = 9 = (5 + 8) - 4
    private const int MIN_SCORE_FOR_WIN = 9;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        finalText.text = "";
        countText.text = "Score: " + counter.ToString();
    }

    public void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float mvoeVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward  * mvoeVertical * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * moveHorizontal * turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            counter++;
            countText.text = "Score: " + counter.ToString();
        }

        if (other.gameObject.CompareTag("DangerousPickUp"))
        {
            other.gameObject.SetActive(false);
            counter--;
            countText.text = "Score: " + counter.ToString();
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            other.gameObject.SetActive(false);

            if (counter >= MIN_SCORE_FOR_WIN)
            {
                finalText.text = "You won!";
                //Application.Quit();
            }
            else
            {

                finalText.text = "You lost!\nYour score is less than " + MIN_SCORE_FOR_WIN.ToString();
                //Application.Quit();
            }
        }
    }

    void SetText(TextMeshProUGUI textReference, string text)
    {
        textReference.text = text;
    }
}