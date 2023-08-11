using WS.Console.Services;

var writer = new WriteLog();

writer.WriteErrorLog("Teste de log de erro.");
writer.WriteWarningLog("Teste de log de alerta.");
writer.WriteSuccessLog("Teste de log de sucesso.");

Console.WriteLine("");

var read = new ReadLog();

read.ReadErroLog();
read.ReadWarningLog();
read.ReadSuccessLog();
