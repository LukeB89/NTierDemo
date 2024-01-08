
namespace NTierDemo.BusinessLogic;
public static class Delegates
{
    // Delegate with no parameters
    public delegate TResult DynamicDelegate<TResult>();

    // Delegates with generic parameters
    public delegate TResult DynamicDelegate<TParam1, TResult>(TParam1 param1);
    public delegate TResult DynamicDelegate<TParam1, TParam2, TResult>(TParam1 param1, TParam2 param2);
    public delegate TResult DynamicDelegate<TParam1, TParam2, TParam3, TResult>(TParam1 param1, TParam2 param2, TParam3 param3);
    public delegate TResult DynamicDelegate<TParam1, TParam2, TParam3, TParam4, TResult>(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4);
    public delegate TResult DynamicDelegate<TParam1, TParam2, TParam3, TParam4, TParam5, TResult>(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);
    public delegate TResult DynamicDelegate<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult>(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);
    public delegate TResult DynamicDelegate<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult>(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);
    public delegate TResult DynamicDelegate<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult>(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);
}
