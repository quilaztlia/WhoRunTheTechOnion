namespace Domain;

//why abstract ?
public abstract class BadRequestException : Exception
{
    protected BadRequestException(string message)
    :base(message)
    {        
    }
}
