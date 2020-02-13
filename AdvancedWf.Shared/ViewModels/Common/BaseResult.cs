namespace AdvancedWf.Shared.ViewModels.Common
{
    public class BaseResult
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public long Id { get; set; }
        public object ReturnObject { get; set; }
    }
}
