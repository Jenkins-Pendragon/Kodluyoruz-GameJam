using PathCreation;
using UnityEngine;

public class CustomPathFollower : MonoBehaviour
{
    public PathCreator pathCreator;    
    public float speed = 5;

    private EndOfPathInstruction endOfPathInstruction = EndOfPathInstruction.Loop;
    public float distanceTravelled;
    private void OnEnable()
    {
        EventManager.OnLevelSuccesed.AddListener(()=>speed=0);
        EventManager.OnLevelFinished.AddListener(() => speed = 0);
    }

    private void OnDisable()
    {
        EventManager.OnLevelSuccesed.RemoveListener(() => speed = 0);
        EventManager.OnLevelFinished.RemoveListener(() => speed = 0);
    }
    

    //Responsible to initliaze script with paramaters
    public void Initialize(PathCreator pathCreator, float speed, float distanceTravelled)
    {
        this.pathCreator = pathCreator;        
        this.speed = speed;
        this.distanceTravelled = distanceTravelled;
    }
    void Start()
    {
        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
    }

    void Update()
    {
        if (pathCreator != null)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }
    }

    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
}
