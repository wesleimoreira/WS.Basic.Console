using WS.Console.Services.Setting;

namespace WS.Console.Services
{
    public class WriteLog : GetSetting
    {
        public void WriteErrorLog(string text) => RecordingFile($"{GetMainRoute}\\{GetErrorLog}", text);
        public void WriteWarningLog(string text) => RecordingFile($"{GetMainRoute}\\{GetWarningLog}", text);
        public void WriteSuccessLog(string text) => RecordingFile($"{GetMainRoute}\\{GetSuccessLog}", text);

        private static void RecordingFile(string route, string text)
        {
            try
            {
                if (string.IsNullOrEmpty(route) || string.IsNullOrWhiteSpace(route)) System.Console.WriteLine("Não foi encontrado a rota informada!");

                if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text)) System.Console.WriteLine("Não foi encontrado texto para ser escrito!");

                if (text.Length >= 500) System.Console.WriteLine($"[{DateTime.Now}] O texto informado e maior que 500 caracteres!");

                bool diretoryExists = ValidateRoute.ThisDiretoryExists(GetMainRoute);

                if (!diretoryExists) System.Console.WriteLine($"[{DateTime.Now}] O diretório para log foi removido ou não existe!");

                using StreamWriter streamWriter = new(route, true, System.Text.Encoding.UTF8);

                var response = streamWriter.WriteLineAsync($"[{DateTime.Now}] {text}");

                var isFileName = route[route.LastIndexOf("\\")..].Replace("\\", "").Replace(".txt", "");

                if (response.IsCompletedSuccessfully) System.Console.WriteLine($"[{DateTime.Now}] O texto de log de {isFileName} foi escrito com sucesso!");

                if (response.IsFaulted) System.Console.WriteLine($"[{DateTime.Now}] {response?.Exception?.Message}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[{DateTime.Now}] {ex.Message}");
            }
        }
    }
}