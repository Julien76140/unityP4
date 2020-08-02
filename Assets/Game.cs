using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public GameObject caseVide;
    public GameObject pionJ1;
    public GameObject pionJ2;

    private int[, ] grille = { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };
    private int ligne;
    private int joueur = 1;
    private int J1 = 1;
    private int J2 = 2;
    private int colone;
    private bool input;
    private int pion = -1;
    private int stack = 0;
    private int reset;
    private bool partie;
    private string[] myObjectsNames;


    private float positionX = -250f;
    private float positionY = 250f;

    // Start is called before the first frame update
    void Start () {
        partie = true;


        for (int k = 0; k <= 5; k++) {

            for (int i = 0; i <= 6; i++) {

                Instantiate (caseVide, new Vector3 (positionX + (i * 100f), 0, positionY + (k * (-100f))), Quaternion.identity);

            }
        }

    }

    // Update is called once per frame
    void Update () {

        input = false;
        ligne = -1;

        if (partie) {

            if (Input.GetKeyDown (KeyCode.Keypad1)) {

                for (int i = 0; i <= 5; i++) {

                    if (grille[i, 0] == 0) {
                        ligne++;

                    }

                }
                colone = 0;
                input = true;
            }
            if (Input.GetKeyDown (KeyCode.Keypad2)) {

                for (int i = 0; i <= 5; i++) {

                    if (grille[i, 1] == 0) {
                        ligne++;

                    }

                }
                colone = 1;
                input = true;
            }
            if (Input.GetKeyDown (KeyCode.Keypad3)) {

                for (int i = 0; i <= 5; i++) {

                    if (grille[i, 2] == 0) {
                        ligne++;

                    }

                }
                colone = 2;
                input = true;
            }
            if (Input.GetKeyDown (KeyCode.Keypad4)) {

                for (int i = 0; i <= 5; i++) {

                    if (grille[i, 3] == 0) {
                        ligne++;

                    }

                }
                colone = 3;
                input = true;
            }
            if (Input.GetKeyDown (KeyCode.Keypad5)) {

                for (int i = 0; i <= 5; i++) {

                    if (grille[i, 4] == 0) {
                        ligne++;

                    }

                }
                colone = 4;
                input = true;
            }
            if (Input.GetKeyDown (KeyCode.Keypad6)) {

                for (int i = 0; i <= 5; i++) {

                    if (grille[i, 5] == 0) {
                        ligne++;

                    }

                }
                colone = 5;
                input = true;
            }
            if (Input.GetKeyDown (KeyCode.Keypad7)) {

                for (int i = 0; i <= 5; i++) {

                    if (grille[i, 6] == 0) {
                        ligne++;

                    }

                }
                colone = 6;
                input = true;
            }

            if (input == true) {
                if (ligne < 0) {
                    coloneEstPleine ();

                } else if (ligne >= 0) {
                    pionPlace ();
                    pionDesJoueurs ();
                    joueur++;
                }
                victoire ();

            }
        }

     if(Input.GetKeyDown (KeyCode.Keypad0) ){
            
          reset=1;

        }

        if(reset==1){
        restartGame();

        }

    }

    void pionPlace () {

        if (joueur % 2 == 0) {

            grille[ligne, colone] = J1;
            pion = J1;
        }
        if (joueur % 2 == 1) {

            grille[ligne, colone] = J2;
            pion = J2;
        }

    }

    void pionDesJoueurs () {

        for (int k = 0; k <= 5; k++) {

            for (int i = 0; i <= 6; i++) {

                if (grille[k, i] == 1) {

               Instantiate (pionJ1, new Vector3 (positionX + (i * 100f), 1f, positionY + (k * (-100f))), Quaternion.identity);

                }

                if (grille[k, i] == 2) {

              Instantiate (pionJ2, new Vector3 (positionX + (i * 100f), 1f, positionY + (k * (-100f))), Quaternion.identity);

                }

            }
        }

    }

    void coloneEstPleine () {

        if (input == true) {

            if (grille[0, colone] != 0) {

                joueur = joueur;

            }
        }
    }

    void victoire () {
        for (int h = 0; h <= 6; h++) {
            for (int g = 0; g <= 5; g++) {

                if (grille[g, h] == pion && grille[g, h + 1] == pion && grille[g, h + 2] == pion && grille[g, h + 3] == pion) {
                        endGame();

                    Debug.Log ("Victoire ligne");

                }

                if (grille[g, h] == 1 || grille[g, h] == 2) {
                    stack++;

                    if (stack == 42) {
                        endGame();
                        Debug.Log ("Egalite");

                    }
                  stack=0;

                }

            }
        }

        for (int i = 5; i >= 3; i--) {

            for (int h = 0; h <= 6; h++) {

                //Victoire par un alignement sur une colone ;

                if (grille[i, h] == pion && grille[i - 1, h] == pion && grille[i - 2, h] == pion && grille[i - 3, h] == pion) {
                        endGame();

                    Debug.Log ("Victoire colone");

                }
            }

        }

        for (int i = 5; i >= 3; i--) {

            for (int h = 0; h <= 6; h++) {  

        //Victoire par un alignement en diagonale ;

                if (grille[i, h] == pion && grille[i - 1, h + 1] == pion && grille[i - 2, h + 2] == pion && grille[i - 3, h + 3] == pion || grille[i, h] == pion && grille[i - 1, h - 1] == pion && grille[i - 2, h - 2] == pion && grille[i - 3, h - 3] == pion) {
                        endGame();

                    Debug.Log ("Victoire diagonale");

                }
            }
 }


    }

    void endGame () {

        partie = false;
    }

    void restartGame () {

    myObjectsNames= new string[]{"Pion1(Clone)","Pion2(Clone)"};



     int[,] grille = { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };
             foreach (string name in myObjectsNames) {
                 GameObject go = GameObject.Find (name);
                 if (go)
                     Destroy (go.gameObject);
             }
                 reset=0;


    }

  
    }
    

