namespace AppSQlite.Interfaces
{
    public interface IMessage
    {
        void LongAlert(string message);

        void ShortAlert(string message);
    }
}