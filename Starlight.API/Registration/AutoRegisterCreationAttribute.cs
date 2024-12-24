namespace Starlight.API.Registration;

[AttributeUsage(AttributeTargets.Class)]
public class AutoRegisterCreationAttribute : Attribute
{
    public AutoRegisterCreationAttribute()
    {
        Console.Out.WriteLine("AutoRegistering");    
    }
}