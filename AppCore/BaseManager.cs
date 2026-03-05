using System;

namespace Core.Managers
{
    public class BaseManager
    {
        protected void ManageException(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}