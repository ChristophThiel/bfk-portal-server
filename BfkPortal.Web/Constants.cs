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
        public const string AdminBwst = "AdminBwst";

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

        // Exceptions
        public const string AlreadyParticipantExceptionMessage = "User or organisation already participant.";
        public const string MaxPaticipantsExceptionMessage = "Maximum of participants reached.";
        public const string ExceededDeadlineExcpetionMessage = "Deadline exceeded.";
        public const string UnableToParticipateExceptionMessage = "Unable to participate at this appointment";
        public const string InvalidCredentialsExceptionMessage = "Invalid email or password.";
        public const string EmailAlreadyUsedExceptionMessage = "This email is already in use.";
        public const string InvalidTimeLineExceptionMessage = "From is bigger than To.";
    }
}
