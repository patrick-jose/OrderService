namespace OrderService.CrossCutting
{
    public interface ISend
    {
        public void SendMessage(string message);
    }
}