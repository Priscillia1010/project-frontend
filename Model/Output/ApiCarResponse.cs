namespace CarRent_Frontend.Model.Output
{
    public class ApiCarResponse<T>
    {
        public int StatusCode {  get; set; }
        public string RequestMethod {  get; set; }
        public T Data { get; set; }
    }
}
