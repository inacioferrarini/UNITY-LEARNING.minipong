using System.Xml;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] private float m_speed;
    [SerializeField] private Vector2 m_direction;
    [SerializeField] private string m_verticalWallTag, m_horizontalWallTag, m_paddleTag;

    void Start()
    {
        m_direction = new Vector2(1, 1);
        m_speed = 10;
    }

    void Update()
    {
        transform.Translate(m_direction * m_speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == m_verticalWallTag)
        {
            m_direction = new Vector2(m_direction.x, -m_direction.y);
        }
        if (collision.gameObject.tag == m_horizontalWallTag)
        {
            m_direction = new Vector2(-m_direction.x, m_direction.y);
        }
        if (collision.gameObject.tag == m_paddleTag)
        {
            m_direction = new Vector2(-m_direction.x, m_direction.y);
        }
    }
}
