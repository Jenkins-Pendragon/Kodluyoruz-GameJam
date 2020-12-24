using PathCreation;
using UnityEngine;

public class GenerateConveyorBeltArrow : MonoBehaviour
{
    public GameObject arrow;
    public PathCreator pathCreator;
    public int frequency;
    private float spacing;
    public float speed;
    void Start()
    {        
        //Space that between two arrow
        spacing = pathCreator.path.length / frequency;
        
        for (int i = 0; i < frequency; i++)
        {
            GameObject arrowGo = Instantiate(arrow, Vector3.zero, Quaternion.identity);            
            arrowGo.AddComponent<CustomPathFollower>().Initialize(pathCreator, speed, spacing*i);            
        }
    }    
}
