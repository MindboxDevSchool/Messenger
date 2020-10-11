using System;

namespace Messenger
{
    public class NotFoundException : Exception
    {
    }

    public class MemberNotFoundException : NotFoundException
    {
        
    }

    public class RemovingCreatorException : Exception
    {
        
    }
    public class InvalidTextException : Exception // invalid
    {
    }
    
    public class InvalidAccessException : Exception //invalid
    {
    }
    
}