using Minipong.Managers;
using UnityEngine;

namespace Minipong.Controllers
{

    public class BallController : MonoBehaviour
    {
        #region Serialized Properties

        [SerializeField] private GameManager m_gameManager;
        [SerializeField] private string m_verticalWallTag, m_horizontalWallTag, m_paddleTag;
        [SerializeField] private float m_initialBallSpeed = 7f;

        #endregion

        #region Private Properties

        private float m_speed;
        private Vector2 m_direction;

        #endregion

        #region Unity Lifecycle

        void Start()
        {
            m_direction = new Vector2(1, 1);
            m_speed = m_initialBallSpeed;
        }

        void Update()
        {
            transform.Translate(m_direction * m_speed * Time.deltaTime);
        }

        #endregion

        #region Collision Handling

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == m_verticalWallTag)
            {
                m_direction = new Vector2(m_direction.x, -m_direction.y);
            }
            if (collision.gameObject.tag == m_horizontalWallTag)
            {
                m_direction = new Vector2(-m_direction.x, m_direction.y);
                AddPoint();
            }
            if (collision.gameObject.tag == m_paddleTag)
            {
                m_direction = new Vector2(-m_direction.x, m_direction.y);
            }
        }

        #endregion

        #region Game State

        private void AddPoint()
        {
            m_gameManager.AddPointAndVerifyWinner(transform.position.x);
            m_gameManager.ResetBall();
        }

        #endregion
    }

}