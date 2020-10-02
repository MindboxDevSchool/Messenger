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
    public class EmptyTextException : Exception // invalid
    {
    }
    
    public class AccessErrorException : Exception //invalid
    {
    }
    
}