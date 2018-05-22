using System.IO;
using System.Net;
using System.Text;

namespace WebJobCopyFileFtp
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeRequest(WebRequestMethods.Ftp.DownloadFile, "ftp://192.168.56.1/file.txt", "marlonm_prest", "mgm!!1988", "testfile.txt");
        }

        private static byte[] MakeRequest(
    string method,
    string uri,
    string username,
    string password,
    string pathFile)
        {
            //Cria requisição ftp a partir do caminho ftp informado
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            request.Credentials = new NetworkCredential(username, password);
            request.Method = method;

            if (!string.IsNullOrEmpty(pathFile))
            {
                //Recupera a resposta da requisição ftp
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                //Cria um array de bytes a partir do arquivo retornado
                byte[] buffer;
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream)) {
                    buffer = Encoding.UTF8.GetBytes(reader.ReadToEnd());
                }

                //Cria um arquivo no caminho informado e escreve nele com o conteúdo do arquivo recuperado na requisição ftp
                using (FileStream fs = new FileStream(pathFile, FileMode.Create))
                {
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();

                    return File.ReadAllBytes(pathFile);
                }
            }
            
            //Caso não informem um caminho de arquivo para criação, é retornado o conteúdo do arquivo da requisção ftp
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (MemoryStream responseBody = new MemoryStream())
            {
                response.GetResponseStream().CopyTo(responseBody);
                return responseBody.ToArray();
            }
        }
    }
}
