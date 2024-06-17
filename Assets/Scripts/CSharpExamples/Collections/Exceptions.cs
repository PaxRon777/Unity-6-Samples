using System;
using UnityEditor.PackageManager;
using UnityEngine;

//Catching exceptions

public class Exceptions : MonoBehaviour
{
    void Start()
    {
        try
        {
            int a = 0;
            int b = 1 / a; //division by zero exception
            print("Programe never reaches here");
        }
        catch (DivideByZeroException) //Look for a specific error
        {
            print("DivideByZeroException");            
        }
        catch (Exception error) //Look for all errors
        {
            print(error.Message);
            print(error.StackTrace);
        }
        finally
        {
            print("This will run with an error or not...");
        }
    }
}
