namespace Auth.Common.Exceptions
{
    /// <summary> Exception throw when entity not found </summary>
    public class EntityNotFoundException : AppException
    {
        /// <summary> Exception throw when entity not found </summary>
        public EntityNotFoundException(string message) : base(message) { }
    }
}
