using UnityEngine;
using UnityEngine.SceneManagement;
public class Bird : MonoBehaviour
{
    private bool _birdlaunced;
    Vector3 _initialPosition;
    private float _timerest;

    [SerializeField] private float speed = 500f;
    
    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        if (_birdlaunced && GetComponent<Rigidbody2D>().velocity.magnitude < 0.1)
            _timerest += Time.deltaTime;

        string currentLevelName = SceneManager.GetActiveScene().name;
        if (transform.position.y > 2.4 || transform.position.x > 14 || transform.position.x < -20 || _timerest > 2)
            SceneManager.LoadScene(currentLevelName);
    }
    
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    { 
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 dirToinitial = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(dirToinitial * speed);
        GetComponent<Rigidbody2D>().gravityScale = 0.75f;
        _birdlaunced = true;
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }

}
