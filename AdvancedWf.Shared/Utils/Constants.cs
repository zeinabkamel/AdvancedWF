namespace AdvancedWf.Shared.Utils
{
    public static class Constants
    {
        public const string USER_VIEWED_INTRO = "UserViewedIntro";
        public static readonly string[] ForbiddenCharcters = { "<", ">", ":", "\"", "/", "\\", "|", "?", "*" };

        public static readonly string[] ArabicNumbers = { "٠", "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩" };
        public static readonly string[] EnglishNumbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };


        public const string EMAIL_SENDER_ADDRESS = "";
        public const string EMAIL_SENDER_PASSWORD = "";

        /// <summary>
        /// Regular Expression for number only ( Engligh and arabic Numbers )
        /// </summary>
        public const string OnlyNumberRegex = "^[0-9\u0660-\u0669]*$";
        public struct UserSetting
        {
            public const string Password = "P@ssw0rd";
        }
        /// <summary>
        /// 
        /// </summary>
        public struct HijriSetting
        {
            //  0  which  means  that  egypt is  equal saudi
            // 1  which  means  that  egypt  not  equal suadi  so  must  be  substracation
            public const int DayCount = 0;
        }
        public struct FilesExtentions
        {
            public const string PNG = "png";
            public const string MP4 = "mp4";
            public const string PDF = "pdf";

        }

        public struct UserRoles
        {
            public const string ADMIN = "Admin";
            public const string EDITOR = "Editor";
           
            public const string VIEWER = "viewer";


            

        }

        /// <summary>
        /// used for controllers success / error messages 
        /// </summary>
        public struct ResponseMessages
        {
            public const string SuccessMessage = "SuccessMessage";
            public const string ErrorMessage = "ErrorMessage";
            public const string SwalError = "error";
            public const string SwalSuccess = "success";
        }
   
        public struct DataTableParams
        {
            public const string draw = "draw";
            public const string search = "search[value]";
            public const string start = "start";
            public const string length = "length";
            public const string order = "order[0][column]";
            public const string orderDir = "order[0][dir]";
            public const string ExtraSearch = "ExtraSearch";

        }


        public struct ConfigProps
        {
            public const float ReportsTableWidth = 560f;
            public const float ReportsTableWidthLandscape = 760f;

        }

    }
}
