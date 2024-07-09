using UnityEngine;

//Passing generic types to fields, classes and funtions

public class Generics : MonoBehaviour
{
    void Start()
    {
        MyGenericClass<int, string> myIntInstance = new MyGenericClass<int, string>();
        myIntInstance.Value = 100;
        myIntInstance.Value2 = " Cats";
        print(myIntInstance.Value + myIntInstance.Value2);

        MyGenericClass<bool, int> myBoolInstance = new MyGenericClass<bool, int>();
        myBoolInstance.Value = true;
        myBoolInstance.Value2 = 7;
        print(myBoolInstance.Value2 + " is the perfect number? = " + myBoolInstance.Value);

        AnyTypeFunction("A String");
        AnyTypeFunction(100);
        AnyTypeFunction(true);
    }

    private void AnyTypeFunction<T>(T value)
    {
        print(value);
    }
}

public class MyGenericClass<T, M>
{
    public T Value;
    public M Value2;
}
