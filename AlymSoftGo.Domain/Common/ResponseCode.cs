namespace AlymSoftGo.Domain.Common
{
    public enum ResponseCode
    {
        Ok = 1,
        UnexpectedError = 2,
        ValidationFailed = 3,
        NotFound = 4,
        Unauthorized = 5,
        Forbidden = 6,
        DuplicateRecord = 7,
        DatabaseError = 8,
        InvalidCredentials = 9,
        UserAlreadyExists = 10,
        UserNotFound = 11,
        ProductNotFound = 12,
        CategoryNotFound = 13,
        CompanyNotFound = 14,
        BranchNotFound = 15,
        OrderNotFound = 16,
        InsufficientStock = 17,
        InvalidPhone = 18,
        InvalidRefreshToken = 19,
        EmailAlreadyExists = 20
    }
}
