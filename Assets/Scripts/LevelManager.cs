using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private GameObject CurrentPlayer;
    public Object PlayerPreFab;
    private Transform Cam;
    public GameObject SpawnPoint;
    private Vector3 distance;
    private Rigidbody PlayerRB;
    public float Playerforce = 5.0f;
    public GameObject reference;
    public static int coins = 0;
    public Text text;
    public GameObject PauseMenu;
    private int active = 1;


    void Start()
    {

        Cam = Camera.main.transform;
        SpawnPlayer();
        distance = Cam.position - CurrentPlayer.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerRB)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(PlayerRB.velocity.y) < 0.5f)
            {
                PlayerRB.AddForce(0, Playerforce, 0, ForceMode.Impulse);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            togglePause();
        }

        if (CurrentPlayer && Cam && reference) 
        {
            Cam.position = CurrentPlayer.transform.position + new Vector3(0, 5, -5);
        }

        if (CurrentPlayer == null && Input.GetKeyDown(KeyCode.Return)) 
        {
            SpawnPlayer();
        }
        
    }

    private void LateUpdate()
    {
        if (CurrentPlayer) {
            distance = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2 * active, Vector3.up) * distance;
            Cam.position = CurrentPlayer.transform.position + distance;
            Cam.LookAt(CurrentPlayer.transform.position + new Vector3(0, 3, 0));
            Vector3 rotation = new Vector3(0, Cam.eulerAngles.y, 0);
            reference.transform.eulerAngles = rotation;
        }
        
    }

    private void FixedUpdate()
    {
        if (PlayerRB) {
            PlayerRB.AddForce(Input.GetAxis("Vertical") * Playerforce * reference.transform.forward);
            PlayerRB.AddForce(Input.GetAxis("Horizontal") * Playerforce * reference.transform.right);
        }
        
    }

    private void SpawnPlayer()
    {
        if (PlayerPreFab && SpawnPoint && CurrentPlayer == null)
        {
            CurrentPlayer = Instantiate(PlayerPreFab, SpawnPoint.transform.position, Quaternion.identity) as GameObject;
            PlayerRB = CurrentPlayer.GetComponent<Rigidbody>();
        }
    }

    public void addCoins() {
        coins++;
        text.text = coins.ToString();

    }

    public void togglePause() {
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        Time.timeScale = PauseMenu.activeSelf ? 0.0f : 1.0f;
        active = PauseMenu.activeSelf ? 0 : 1;
    }

    public void salir() {
        SceneManager.LoadScene("Menu");
    }

    public void reiniciar() {
        SceneManager.LoadScene("Principal");
        togglePause();
    }
}
