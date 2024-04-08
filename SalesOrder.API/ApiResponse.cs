namespace SalesOrder.API
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public static ApiResponse<T> SuccessResponse(T data)
        {
            return new ApiResponse<T> { Success = true, Data = data };
        }

        public static ApiResponse<T> ErrorResponse(string errorMessage)
        {
            return new ApiResponse<T> { Success = false, ErrorMessage = errorMessage };
        }
    }

}
