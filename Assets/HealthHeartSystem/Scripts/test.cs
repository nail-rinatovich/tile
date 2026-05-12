using UnityEngine;

public class test : MonoBehaviour
{
    private Animator            m_animator;
    [SerializeField] bool       m_noBlood = false;
    // Make sure one of the objects has a Rigidbody2D and the other has
    // a Collider2D with 'is Trigger' checked in the Inspector.
    void Start()
    {
        m_animator = GetComponent<Animator>();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Coin"))
        {
            //if the game object has a pickup tag, set active status to false
            other.gameObject.SetActive(false);
            
           
        }
        if (other.gameObject.CompareTag("DeadBlock"))
    {
        m_animator.SetBool("noBlood", m_noBlood);
        m_animator.SetTrigger("Death");
    }
        
    }
}
