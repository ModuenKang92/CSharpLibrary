namespace CSharpLibrary.SampleObjects
{
    public interface IReturner
    {
        int ReturnInt1();
        int ReturnInt2();
        float ReturnFloat1();
        float ReturnFloat2();
        string ReturnString1();
        string ReturnString2();
        T ReturnTemplate<T>();
    }
}
