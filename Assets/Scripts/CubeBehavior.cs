using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public enum CubeType { Blue, Brown, Pink };
    public CubeType cubeType;

    GameObject playerObject; // "Player" burada oyuncu nesnesinin ismi olmalý

    public int jumpDecreaseAmount = 1;
    public int speedDecreaseAmount = 1;
    public int healthDecreaseAmount = 1;

    private void Start()
    {
        playerObject = GameObject.Find("Player");

    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerCollision();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            HandleGroundCollision();
        }
               
    }

    void HandleGroundCollision()
    {
        switch (cubeType)
        {
            case CubeType.Blue:
                Debug.Log("Blue Yere Çarptý");
                // Mavi küp yere düþtüðünde hýzýný azalt
                DecreasePlayerSpeed();
                // Örneðin: playerMovementComponent.IncreaseSpeed(speedIncreaseAmount);

                break;

            case CubeType.Brown:
                Debug.Log("Brown Yere Çarptý");
                // Kahverengi küp yere düþtüðünde oyuncunun zýplama hýzýný azalt
                DecreasePlayerJump();
                // Örneðin: playerMovementComponent.DecreaseSpeed(speedDecreaseAmount);
                break;

            case CubeType.Pink:
                Debug.Log("pink Yere Çarptý");
                DecreasePlayerHealth();

                // Pembe küp yere düþtüðünde oyuncunun canýný azalt
                // Örneðin: playerMovementComponent.DecreaseHealth(healthDecreaseAmount);
                break;
        }

        // Küp yere düþtükten sonra yok edilebilir
        Destroy(gameObject);
    }
    void HandlePlayerCollision()
    {
        // Küp player a düþtükten sonra yok edilebilir
        Destroy(gameObject);
    }
    void DecreasePlayerHealth()
    {
        // Oyuncu nesnesine referans al
        

        if (playerObject != null)
        {
            // Oyuncu nesnesindeki PlayerMovement bileþenini al
            PlayerMovement playerMovementComponent = playerObject.GetComponent<PlayerMovement>();

            if (playerMovementComponent != null)
            {
                // DecreaseHealth fonksiyonunu çaðýr
                playerMovementComponent.DecreaseHealth(healthDecreaseAmount);
            }
        }

        // Küp yere düþtükten sonra yok edilebilir
        Destroy(gameObject);
    }
    void DecreasePlayerJump()
    {
        // Oyuncu nesnesine referans al


        if (playerObject != null)
        {
            // Oyuncu nesnesindeki PlayerMovement bileþenini al
            PlayerMovement playerMovementComponent = playerObject.GetComponent<PlayerMovement>();

            if (playerMovementComponent != null)
            {
                // DecreaseHealth fonksiyonunu çaðýr
                playerMovementComponent.DecreaseJump(jumpDecreaseAmount);
            }
        }

        // Küp yere düþtükten sonra yok edilebilir
        Destroy(gameObject);
    }
    void DecreasePlayerSpeed()
    {
        if (playerObject != null)
        {
            
            PlayerMovement playerMovementComponent = playerObject.GetComponent<PlayerMovement>();

            if (playerMovementComponent != null)
            {
               
                playerMovementComponent.DecreaseSpeed(speedDecreaseAmount);
            }
        }

    }
}
