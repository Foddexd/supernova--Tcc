using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ControladorCamera : MonoBehaviour
{

    [SerializeField] private AxisState xAxis;
    [SerializeField] private AxisState yAxis;
    

    [SerializeField] private Transform lookat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);

        lookat.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, xAxis.Value, 0), 5 * Time.deltaTime);

    }
}
