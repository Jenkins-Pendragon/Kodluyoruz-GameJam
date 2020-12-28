using PathCreation;
using UnityEngine;

public class GenerateConveyorBeltArrow : MonoBehaviour
{
    public GameObject arrow;
    public PathCreator pathCreator;
    public int frequency;
    private float spacing;
    private float speed = -1;
    private float Speed
    {
        get
        {
            if (speed == -1)
            {
                //0.45f static value that provide synchronization with roads
                speed = 0.45f * LevelManager.Instance.CurrentLevel.conveyorBeltSpeed;
            }
            return speed;
        }       
    }    

    void Start()
    {     
        //Space that between two arrow
        spacing = pathCreator.path.length / frequency;
        
        for (int i = 0; i < frequency; i++)
        {
            GameObject arrowGo = Instantiate(arrow, Vector3.zero, Quaternion.identity);            
            arrowGo.AddComponent<CustomPathFollower>().Initialize(pathCreator, Speed, spacing*i);            
        }
    }    
}
