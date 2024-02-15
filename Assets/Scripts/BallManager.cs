using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject lightBallPrefab;
    [SerializeField] GameObject bombBallPrefab;

    private Ball m_SelectedBall = null;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bombBallPrefab, RandomPosition(), Quaternion.identity);

        for (int i = 0; i < 10; i++)
        {
            Instantiate(lightBallPrefab, RandomPosition(), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleAction();
        }
    }

    private Vector3 RandomPosition() // ABSTRACTION
    {
        float x = Random.Range(-4.0f, 4.0f);
        float z = Random.Range(-4.0f, 4.0f);

        Vector3 position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        return position;
    }

    private void HandleAction() // ABSTRACTION
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var ball = hit.collider.GetComponent<Ball>();
            m_SelectedBall = ball;

            if (ball != null)
            {
                ball.Clicked();
            }
        }
    }
}
