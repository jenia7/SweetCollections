namespace SweetCollections.Trees
{    
    public class FindInEmptyTreeException : Exception
    {
        public FindInEmptyTreeException() { }
        public FindInEmptyTreeException(string message) : base(message) { }        
        public FindInEmptyTreeException(string message, Exception inner) : base(message, inner) { }        
    }
}
