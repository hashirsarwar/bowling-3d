using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    public float impulseFactor;
    public float forceFactor;
    private Vector3 ballPos;

    // Start is called before the first frame update
    void Start()
    {
        ballPos = GetComponent<Transform>().position;

        PlayerPrefs.SetInt("Start", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            throwBall();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            resetBallLocation();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            resetGame();
        }
    }

    void moveRight()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.right * impulseFactor, ForceMode.Impulse);
    }

    void moveLeft()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.left * impulseFactor, ForceMode.Impulse);
    }

    void throwBall()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * forceFactor);
    }

    void resetBallLocation()
    {
        GetComponent<Transform>().position = ballPos;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void resetGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Start"));
    }
}
