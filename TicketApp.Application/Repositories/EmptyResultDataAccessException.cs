namespace TicketApp.Application.Repositories
{
    [System.Serializable]
    public class EmptyResultDataAccessException : System.Exception
    {
        public EmptyResultDataAccessException() { }
        public EmptyResultDataAccessException(string message) : base(message) { }
        public EmptyResultDataAccessException(string message, System.Exception inner) : base(message, inner) { }
        protected EmptyResultDataAccessException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}