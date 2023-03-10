namespace WebCRM.Common
{
    public class CRMConstants
    {
        public static readonly List<Type> CRMBaseTypes = new()
        { 
            typeof(DateTime),
            typeof(DateTime?),
            typeof(string),
            typeof(int),
            typeof(int?),
            typeof(decimal),
            typeof(decimal?),
            typeof(double),
            typeof(double?),
            typeof(float),
            typeof(float?),
            typeof(long),
            typeof(long?),
            typeof(short),
            typeof(short?),
            typeof(byte),
            typeof(byte?),
            typeof(bool),
            typeof(bool?),
        };

        public static readonly string SuccessfullySavedChanges = "Successfully saved changes";

        public static readonly string NoChangesToSave = "No changes to save";

        public static readonly string NoMatchingDataFound = "No matching data found";

        public static readonly string FailedToSaveChanges = "Failed to save changes";

        public static readonly string DatabaseError = "A database error has occurred";

        public static readonly string NullDataSent = "Null data sent";
    }
}
