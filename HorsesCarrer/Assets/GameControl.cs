using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private static GameObject quienGanaTexto, turnojug1, turnojug2;

    private static GameObject jug1, jug2;

    public static int dadosLanzados = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool juegoTerminado = false;

    
    void Start () {

        quienGanaTexto= GameObject.Find("QuienGanaTexto");
        turnojug1 = GameObject.Find("TurnoJug1");
        turnojug2 = GameObject.Find("TurnoJug2");

        jug1 = GameObject.Find("Player1");
        jug2 = GameObject.Find("Player2");

        jug1.GetComponent<MoverIndicadores>().movPermitido = false;
        jug2.GetComponent<MoverIndicadores>().movPermitido = false;

        quienGanaTexto.gameObject.SetActive(false);
        turnojug1.gameObject.SetActive(true);
        turnojug2.gameObject.SetActive(false);
    }

   
    void Update()
    {
        if (jug1.GetComponent<MoverIndicadores>().waypointIndex > 
            player1StartWaypoint + dadosLanzados)
        {
            jug1.GetComponent<MoverIndicadores>().movPermitido = false;
            turnojug1.gameObject.SetActive(false);
            turnojug2.gameObject.SetActive(true);
            player1StartWaypoint = jug1.GetComponent<MoverIndicadores>().waypointIndex - 1;
        }

        if (jug2.GetComponent<MoverIndicadores>().waypointIndex >
            player2StartWaypoint + dadosLanzados)
        {
            jug2.GetComponent<MoverIndicadores>().movPermitido = false;
            turnojug2.gameObject.SetActive(false);
            turnojug1.gameObject.SetActive(true);
            player2StartWaypoint = jug2.GetComponent<MoverIndicadores>().waypointIndex - 1;
        }

        if (jug1.GetComponent<MoverIndicadores>().waypointIndex == 
            jug1.GetComponent<MoverIndicadores>().waypoints.Length)
        {
            quienGanaTexto.gameObject.SetActive(true);
            quienGanaTexto.GetComponent<Text>().text = "JUGADOR 1 GANA";
            juegoTerminado = true;
        }

        if (jug2.GetComponent<MoverIndicadores>().waypointIndex ==
            jug2.GetComponent<MoverIndicadores>().waypoints.Length)
        {
            quienGanaTexto.gameObject.SetActive(true);
           turnojug1.gameObject.SetActive(false);
            turnojug2.gameObject.SetActive(false);
            quienGanaTexto.GetComponent<Text>().text = "JUGADOR 2 GANA";
            juegoTerminado  = true;
        }
    }

    public static void MoverJugador(int jugMover)
    {
        switch (jugMover) { 
            case 1:
               jug1.GetComponent<MoverIndicadores>().movPermitido = true;
                break;

            case 2:
                jug2.GetComponent<MoverIndicadores>().movPermitido = true;
                break;
        }
    }
}
