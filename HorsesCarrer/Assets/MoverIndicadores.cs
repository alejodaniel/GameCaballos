using UnityEngine;

public class MoverIndicadores : MonoBehaviour {

    public Transform[] waypoints;

    [SerializeField]
    private float movJug = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool movPermitido = false;

	// usar para iniciar
	private void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	
	private void Update () {
        if (movPermitido)
            Mover();
	}

    private void Mover()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            movJug * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}
