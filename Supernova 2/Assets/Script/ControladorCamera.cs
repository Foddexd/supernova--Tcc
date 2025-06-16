using UnityEngine;
using Cinemachine;

public class ControladorCamera : MonoBehaviour
{
    [SerializeField] private AxisState xAxis;
    [SerializeField] private AxisState yAxis;

    [SerializeField] private Transform lookat;

    [Header("Joystick de Câmera")]
    public FixedJoystick cameraJoystick;
    public GameObject mobileUI;

    void Update()
    {
        bool isMobile = mobileUI.activeSelf;

        if (isMobile)
        {
            // Desativa leitura automática de eixo
            xAxis.m_InputAxisName = "";
            yAxis.m_InputAxisName = "";

            // Usa valor vindo do joystick
            xAxis.m_InputAxisValue = cameraJoystick.Horizontal;
            yAxis.m_InputAxisValue = cameraJoystick.Vertical;
        }
        else
        {
            // Usa eixo do Input Manager
            xAxis.m_InputAxisName = "Mouse X";
            yAxis.m_InputAxisName = "Mouse Y";

            // Zera os valores manuais
            xAxis.m_InputAxisValue = 0f;
            yAxis.m_InputAxisValue = 0f;
        }

        // Atualiza os eixos
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);

        // Rotaciona o lookat (normalmente um "Empty" que a Cinemachine segue)
        lookat.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);

        // Rotaciona o corpo do player
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, xAxis.Value, 0), 5 * Time.deltaTime);
    }
}
