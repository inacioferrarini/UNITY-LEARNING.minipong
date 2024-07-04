using UnityEngine;

namespace Minipong.Controllers
{

    public class PaddleController : MonoBehaviour
    {
        #region Serialized Properties

        [SerializeField] private float m_speed = 4;
        [SerializeField] private float m_verticalLimitMax = 4.5f, m_verticalLimitMin = -4.5f;
        [SerializeField] private string m_axisName;

        #endregion

        #region Unity Lifecycle

        void Update()
        {
            float move = Input.GetAxis(m_axisName) * m_speed;

            float nextPlayerPosition = transform.position.y + (move * Time.deltaTime);
            float clampedPositionY = Mathf.Clamp(nextPlayerPosition, m_verticalLimitMin, m_verticalLimitMax);

            transform.position = new Vector3(transform.position.x, clampedPositionY, transform.position.z);
        }

        #endregion
    }

}