public class ResponseBase<T>
{
    public T? Dados { get; set; }
    public required string Mensagem { get; set; }
}