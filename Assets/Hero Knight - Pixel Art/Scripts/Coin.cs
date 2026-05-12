using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Coin : MonoBehaviour
{
    private bool                m_rolling = false;
    [SerializeField] bool       m_noBlood = false;
    private Animator            m_animator;
    public Vector2 destinationCoordinates = new Vector2(3.5f, 0f); 

    public TextMeshProUGUI countText; // ref to UI text component
    public GameObject winTextObject; 
    private int count;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TeleportToPosition()
{
    // Check if the player has a Rigidbody2D component
    Rigidbody2D rb2d = GetComponent<Rigidbody2D>();

    if (rb2d != null)
    {
        // If using Rigidbody2D, use its position property for smoother physics
        rb2d.position = destinationCoordinates;
    }
    else
    {
        // Otherwise, set the transform position directly
        transform.position = new Vector3(destinationCoordinates.x, destinationCoordinates.y, transform.position.z);
    }
}
    void setCountText()
        {
            countText.text = "Count: " + count.ToString();

            if(count >= 6)
            {
                winTextObject.SetActive(true);
            }
        }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            //if the game object has a pickup tag, set active status to false
            other.gameObject.SetActive(false);
            
            //every time "coin" gets picked up add 1 to the count
            count += 1;

            setCountText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            m_animator.SetBool("noBlood", m_noBlood);
            m_animator.SetTrigger("Death");
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
             m_animator.SetTrigger("Hurt");
        }
        if (other.gameObject.CompareTag("DeadBlock"))
                {
                   Debug.Log("Player dead");
                    //Death
        if (!m_rolling)
        {
            m_animator.SetBool("noBlood", m_noBlood);
            m_animator.SetTrigger("Death");
            //Задержка
            TeleportToPosition();
            //IDLE
        }
                }
            }
}

