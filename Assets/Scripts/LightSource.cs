using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour 
{
    [SerializeField] private bool IsTurnOn;
    [SerializeField] private Light Light;
    [SerializeField] private MeshRenderer SphereRenderer;
    [SerializeField] private List<LeverController> Levers;

    private Color greenColor = new Color(0, 210, 51);
    private Color redColor = new Color(255, 0, 0);

    private void Update()
    {
        switchLight();
    }

    private void switchLight()
    {
        int counter = 0;
        foreach (LeverController element in Levers)
        {
            if (element.getLeverLogicState() == true)
                counter++;
            
        }
        if (counter == Levers.Count)
        {
            Light.color = greenColor;
        }
        else
        {
            Light.color = redColor;
        }
    }
}