namespace AlymSoftGo.Domain.Exceptions
{
    public class SPUnexpectedException : Exception
    {
        public string ErrorTitle { get; }
        public string ErrorDescription { get; }
        public string? TechnicalDetails { get; }

        public SPUnexpectedException(string errorTitle, string errorDescription, string? technicalDetails = null)
            : base($"{errorTitle}: {errorDescription}")
        {
            ErrorTitle = errorTitle;
            ErrorDescription = errorDescription;
            TechnicalDetails = technicalDetails;
        }
    }
}
