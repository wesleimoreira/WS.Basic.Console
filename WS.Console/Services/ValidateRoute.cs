namespace WS.Console.Services
{
    public static class ValidateRoute
    {
        public static Boolean ThisFileExists(string route)
        {
            if (string.IsNullOrEmpty(route) is true || string.IsNullOrWhiteSpace(route) is true) return false;

            if (File.Exists(route) is true) return true;

            return false;
        }

        public static Boolean ThisDiretoryExists(string route)
        {
            try
            {
                if (string.IsNullOrEmpty(route) is true || string.IsNullOrWhiteSpace(route) is true) return false;

                if (Directory.Exists(route) is true) return true;

                if (Directory.CreateDirectory(route).Exists is true) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException(ex.Message);
            }
        }
    }
}