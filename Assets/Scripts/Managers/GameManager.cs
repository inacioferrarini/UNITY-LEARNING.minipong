using TMPro;
using UnityEngine;

namespace Minipong.Managers
{

    public class GameManager : MonoBehaviour
    {
        #region Constants

        private const string m_resetGameMethodName = "ResetGame";

        #endregion

        #region Serialized Properties

        [SerializeField] private TextMeshProUGUI m_playerLeftScoreText, m_playerRightScoreText;
        [SerializeField] private Rigidbody2D m_ball;
        [SerializeField] private Transform m_paddleLeft, m_paddleRight;
        [SerializeField] private int m_maxPoints = 10;

        #endregion

        #region Private Properties

        private int m_playerLeftScore, m_playerRightScore;

        #endregion

        #region Unity Lifecycle

        void Start()
        {
            m_ball.gameObject.SetActive(false);
            UpdateScoreInHUD();
            Invoke(m_resetGameMethodName, 3);
        }

        #endregion

        #region Game State

        public void AddPointAndVerifyWinner(float ballPositionX)
        {
            UpdatePlayerScore(ballPositionX);
            UpdateScoreInHUD();
            VerifyWinner();
        }

        public void ResetBall()
        {
            m_ball.transform.position = Vector2.zero;
        }

        private void ResetGame()
        {
            m_ball.gameObject.SetActive(true);
            ResetBall();

            m_paddleLeft.transform.position = new Vector2(m_paddleLeft.transform.position.x, 0);
            m_paddleRight.transform.position = new Vector2(m_paddleRight.transform.position.x, 0);

            m_playerLeftScore = m_playerRightScore = 0;
            UpdateScoreInHUD();
        }

        private void UpdatePlayerScore(float ballPositionX)
        {
            if (ballPositionX > 0)
            {
                m_playerLeftScore++;
            }
            else
            {
                m_playerRightScore++;
            }
        }

        private void VerifyWinner()
        {
            if (m_playerLeftScore >= m_maxPoints || m_playerRightScore >= m_maxPoints)
            {
                m_ball.gameObject.SetActive(false);
                Invoke(m_resetGameMethodName, 1);
            }
        }

        #endregion

        #region UI Logic

        private void UpdateScoreInHUD()
        {
            m_playerLeftScoreText.text = m_playerLeftScore.ToString();
            m_playerRightScoreText.text = m_playerRightScore.ToString();
        }

        #endregion
    }

}