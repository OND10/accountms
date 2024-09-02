
namespace AccountingManagementSystem.Domain.Common.Exceptions
{
    public class ModelNullException : ArgumentNullException
    {
        public ModelNullException(string paramName, string message):base(paramName, message)
        {

        }
    }
}
