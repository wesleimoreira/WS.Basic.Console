using WS.Console.Services.Setting;

namespace WS.Console.Services
{
    public class ReadLog : GetSetting
    {
        public void ReadErroLog() => ReadFile($"{GetMainRoute}\\{GetErrorLog}");
        public void ReadWarningLog() => ReadFile($"{GetMainRoute}\\{GetWarningLog}");
        public void ReadSuccessLog() => ReadFile($"{GetMainRoute}\\{GetSuccessLog}");

        private static void ReadFile(string route)
        {
            try
            {
                if (string.IsNullOrEmpty(route) || string.IsNullOrWhiteSpace(route)) System.Console.WriteLine("Não foi encontrado a rota informada!");

                bool diretoryExists = ValidateRoute.ThisDiretoryExists(GetMainRoute);

                if (!diretoryExists) System.Console.WriteLine($"[{DateTime.Now}] O diretório para log foi removido ou não existe!");

                using StreamReader streamReader = new(route, System.Text.Encoding.UTF8);

                var response = streamReader.ReadToEndAsync();

                if (response.IsCompletedSuccessfully) System.Console.WriteLine($"[{DateTime.Now}] O arquivo foi lido com sucesso.");

                if (response.IsFaulted) System.Console.WriteLine($"[{DateTime.Now}] {response?.Exception?.Message}");

                System.Console.WriteLine(response?.Result);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}