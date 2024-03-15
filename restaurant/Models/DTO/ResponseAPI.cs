namespace restaurant.Models.DTO
{
    public class ResponseAPI<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
