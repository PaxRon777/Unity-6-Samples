using UnityEngine;

//Passing generic types to fields, classes and funtions

public class Generics : MonoBehaviour
{
    void Start()
    {
        MyGenericClass<int> myIntInstance = new MyGenericClass<int>();
        myIntInstance.value = 100;
        print("Int:" + myIntInstance.value);

        MyGenericClass<bool> myBoolInstance = new MyGenericClass<bool>();
        myBoolInstance.value = true;
        print("Bool:" + myBoolInstance.value);

        AnyTypeFunction("A String");
        AnyTypeFunction(100);
        AnyTypeFunction(true);
    }

    private class MyGenericClass<T>
    {
        public T value;
    }

    private void AnyTypeFunction<T>(T value)
    {
        print(value);
    }
}
