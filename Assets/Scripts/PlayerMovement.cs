using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 10f; // Zýplama kuvveti
    public int maxHealth = 3;

    [SerializeField] private GameObject deathScreen;
    private float currentMovementSpeed;
    private float currentJumpForce;
    private int currentHealth;
    private bool isGrounded; // Zeminde mi kontrolü için

    void Start()
    {
        deathScreen.SetActive(false);
        Time.timeScale = 1;
        currentHealth = maxHealth;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        Debug.Log("DecreaseHealth" + currentHealth);

        if (currentHealth < 0)
        {
            // Ölüm ekraný veya baþka bir iþlem burada yapýlabilir.
            Debug.Log("Oyun bitti. Ölüm ekraný gösterilebilir.");
            // DeathScreen setactive=true
            deathScreen.SetActive(true);

            Time.timeScale = 0;
        }
    }
    public void DecreaseJump(int jumpDecreaseAmount)
    {
        currentJumpForce = jumpDecreaseAmount;
        jumpForce = jumpForce - jumpDecreaseAmount;
        Debug.Log("DecreaseJump works" + currentJumpForce);
    }
    public void DecreaseSpeed(int speedDecreaseAmount)
    {
        currentMovementSpeed -= speedDecreaseAmount;
        movementSpeed = movementSpeed - speedDecreaseAmount;
        Debug.Log("DecreaseSpeed works" + currentMovementSpeed);

        
    }
    
}
