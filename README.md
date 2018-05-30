# _copyfileftp

## Etapas para criação de um WebJob no Azure a partir de uma Console Application com C#
1.	Crie um novo recurso web no Azure, informando o nome do app, a inscrição e o grupo de recurso.
2.	Crie um arquivo .bat contendo o seguinte conteúdo, “ECHO OFF dotnet WebJobCopyFileFtp.dll %1”, onde “WebJobCopyFileFtp.dll” é a dll principal do projeto e “%1” informa ao webjob do Azure que ele aceite uma entrada, pois o webjob do Azure não pode executar o método MAIN da dll, ele precisa do ponto de entrada.
3.	Compacte os arquivos compilados (dll, pdb, ...) após ser executado o build da aplicação junto ao arquivo .bat criado.
4.	Selecione o recurso criado e navegue até a opção WebJobs no menu que irá ser exibido.
5.	Informe o nome do webjob, o arquivo compactado e o tipo de de job que você quer executar (manual ou agendado), clique em Ok.
6.	Caso informe manual, clique em “Run” no webjob criado e em seguida em “Logs” para verificar a saída.
7.	Caso informe agendado, aguarde a próxima execução no horário agendado e veja a saída em “Logs”.
8.	Para mais detalhes da criação, consulte o seguinte link, http://www.intstrings.com/ramivemula/articles/azure-webjob-with-net-core-console-application/
