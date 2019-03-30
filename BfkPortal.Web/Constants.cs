namespace BfkPortal.Web
{
  public static class Constants
  {
    // Environment Variables
    public const string SendGridApiKey = "SENDGRID_API_KEY";

    // Paths
    public const string WwwRoot = "wwwroot";
    public const string Dist = "dist";

    // Roles
    public const string Roles = "Roles";
    public const string Admin = "Admin";
    public const string Bfk = "Bfk";
    public const string Bwst = "Bwst";
    public const string AdminBfk = "AdminBfk";
    public const string UserBfk = "UserBfk";
    public const string AdminBwst = "AdminBwst";
    public const string UserBwst = "UserBwst";
    public const string ObserverBwst = "ObserverBwst";

    // HTTP Request Methods
    public const string Get = "GET";
    public const string Post = "POST";

    // Id Names
    public const string AppointmentId = "appointmentId";
    public const string UserId = "userId";

    // Policy
    public const string OwnerOfAppointmentPolicy = "OwnerOfAppointment";
    public const string FreeAppointmentPolicy = "FreeAppointment";
    public const string UserOfSameRoleGroupPolicy = "UserOfSameRoleGroup";

    // File System
    public const string FileStorageFolderName = "Files";
    public const string FileContentType = "application/octet-stream";
    public const int FileContentLength = 1600000000;

    // Email
    public const string SendGridMail = "mail@bfk-portal.at";

    public const string EmailTemplateFoldername = "html";

    public const string RegistrationEmailFilename = "confirmation.html";

    public const string RegistrationEmailSubject = "Neuer Account";

    public const string MarketplaceEmailFilename = "marketplace.html";

    public const string MarketplaceEmailSubject = "Neues Angebot";

    public const string OfferedEmailFilename = "offered.html";
    public const string OfferedEmailSubject = "Dienst tauschen";

    // Exceptions
    public const string AlreadyParticipantExceptionMessage = "User or organisation already participant.";
    public const string MaxPaticipantsExceptionMessage = "Maximum of participants reached.";
    public const string ExceededDeadlineExcpetionMessage = "Deadline exceeded.";
    public const string UnableToParticipateExceptionMessage = "Unable to participate at this appointment.";
    public const string InvalidCredentialsExceptionMessage = "Invalid email or password.";
    public const string InvalidEmailExceptionMessage = "This email is unknown.";
    public const string EmailAlreadyUsedExceptionMessage = "This email is already in use.";
    public const string InvalidTimeLineExceptionMessage = "From is bigger than To.";
    public const string EntityNotFoundExceptionMessage = "An entity with this key does not exist.";
    public const string InvalidMonthExceptionMessage = "Month must be between 1 and 12.";
    public const string ImpossibleDistributionExceptionMessage = "Not enough servants for shifts.";
  }
}
