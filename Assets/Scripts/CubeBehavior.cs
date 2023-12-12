using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public enum CubeType { Blue, Brown, Pink };
    public CubeType cubeType;

    GameObject playerObject; // "Player" burada oyuncu nesnesinin ismi olmal�

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
                Debug.Log("Blue Yere �arpt�");
                // Mavi k�p yere d��t���nde h�z�n� azalt
                DecreasePlayerSpeed();
                // �rne�in: playerMovementComponent.IncreaseSpeed(speedIncreaseAmount);

                break;

            case CubeType.Brown:
                Debug.Log("Brown Yere �arpt�");
                // Kahverengi k�p yere d��t���nde oyuncunun z�plama h�z�n� azalt
                DecreasePlayerJump();
                // �rne�in: playerMovementComponent.DecreaseSpeed(speedDecreaseAmount);
                break;

            case CubeType.Pink:
                Debug.Log("pink Yere �arpt�");
                DecreasePlayerHealth();

                // Pembe k�p yere d��t���nde oyuncunun can�n� azalt
                // �rne�in: playerMovementComponent.DecreaseHealth(healthDecreaseAmount);
                break;
        }

        // K�p yere d��t�kten sonra yok edilebilir
        Destroy(gameObject);
    }
    void HandlePlayerCollision()
    {
        // K�p player a d��t�kten sonra yok edilebilir
        Destroy(gameObject);
    }
    void DecreasePlayerHealth()
    {
        // Oyuncu nesnesine referans al
        

        if (playerObject != null)
        {
            // Oyuncu nesnesindeki PlayerMovement bile�enini al
            PlayerMovement playerMovementComponent = playerObject.GetComponent<PlayerMovement>();

            if (playerMovementComponent != null)
            {
                // DecreaseHealth fonksiyonunu �a��r
                playerMovementComponent.DecreaseHealth(healthDecreaseAmount);
            }
        }

        // K�p yere d��t�kten sonra yok edilebilir
        Destroy(gameObject);
    }
    void DecreasePlayerJump()
    {
        // Oyuncu nesnesine referans al


        if (playerObject != null)
        {
            // Oyuncu nesnesindeki PlayerMovement bile�enini al
            PlayerMovement playerMovementComponent = playerObject.GetComponent<PlayerMovement>();

            if (playerMovementComponent != null)
            {
                // DecreaseHealth fonksiyonunu �a��r
                playerMovementComponent.DecreaseJump(jumpDecreaseAmount);
            }
        }

        // K�p yere d��t�kten sonra yok edilebilir
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
