using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examples : MonoBehaviour
{
    public int myNumber = 4;

    private void Start()
    {
        Debug.Log($"¿Es {myNumber} par o impar?");

        if(myNumber % 2 == 0)
        {
            Debug.Log($"El número {myNumber} es par.");
        }
        else
        {
            Debug.Log($"El número {myNumber} es impar.");
        }

        Debug.Log($"¿Es {myNumber} mayor, menor o igual a 0?");

        if(myNumber > 0)
        {
            Debug.Log($"El número {myNumber} es mayor a 0.");
        }
        else if(myNumber < 0)
        {
            Debug.Log($"El número {myNumber} es menor a 0.");
        }
        else
        {
            Debug.Log($"El número {myNumber} es igual a 0.");
        }
    }
}
