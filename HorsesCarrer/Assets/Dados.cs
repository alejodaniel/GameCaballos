using System.Collections;
using UnityEngine;

public class Dados : MonoBehaviour {

    private Sprite[] dadosSides;
    private SpriteRenderer rend;
    private int Turno = 1;
    private bool PermitirCurrutina = true;

	// Use this for initialization
	private void Start () {
        rend = GetComponent<SpriteRenderer>();
        dadosSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = dadosSides[5];
	}

    //llama a voltear dado 
    //onmuosedown sirve para dar click a un boton 
    private void OnMouseDown()
    {
        if (!GameControl.juegoTerminado && PermitirCurrutina)
            StartCoroutine("VoltearDado");
    }
    //IE Enumerator detiene el proceso de ese instante y devuelve la parte del metodo
    private IEnumerator VoltearDado()
    {
        PermitirCurrutina = false;
        int dadoRamdom = 0;
        for (int i = 0; i <= 20; i++)
        {
            //aqui se hace que los numero sean del 0 al 6 en numeros aleatorios
            dadoRamdom = Random.Range(0, 6);
            rend.sprite = dadosSides[dadoRamdom];
            //tiempo que me dvuelve el numero aleatorio
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.dadosLanzados = dadoRamdom + 1;
        if (Turno == 1)
        {
            GameControl.MoverJugador(1);
        } else if (Turno == -1)
        {
            GameControl.MoverJugador(2);
        }
        Turno *= -1;
        PermitirCurrutina = true;
    }
}
