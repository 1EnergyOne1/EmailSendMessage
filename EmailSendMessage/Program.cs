using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailSendMessage
{
    class Program
    {
        static bool mailSent = false;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }
        public static void Main(string[] args)
        {
            // Аргументом командной строки должен быть SMTP-узел.
            SmtpClient client = new SmtpClient(args[0]);
            
            // Укажите отправителя электронной почты            
            MailAddress from = new MailAddress("energyone.tony@mail.ru", "Anton Energy");
            
            // Укажите получателя электронной почты
            MailAddress to = new MailAddress("energyone.tony@mail.ru");

            // Задайте сообщениe электронной почты
            MailMessage message = new MailMessage(from, to);
            message.Body = "Отправка тестового email";

            // Включите некоторые символы, отличные от ASCII, в текст и тему.
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            message.Body += Environment.NewLine + someArrows;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "test message 1" + someArrows;
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            // Установите метод, который вызывается при завершении операции отправки.
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

            // UserState может быть любым объектом, который разрешает ваш обратный вызов
            // UserState может быть любым объектом, который позволяет вашему методу обратного вызова идентифицировать эту операцию отправки.            
            string userState = "test message1";
            client.SendAsync(message, userState);
            Console.WriteLine("Отправка сообщения... нажмите c для отмены отправки сообщения. Нажмите любую кнопку для выхода.");
            string answer = Console.ReadLine();

            // Если пользователь отменил отправку, а письмо еще не было отправлено, отмените отложенную операцию.            
            if (answer.StartsWith("c") && mailSent == false)
            {
                client.SendAsyncCancel();
            }
            // Очистка
            message.Dispose();
            Console.WriteLine("До свидания!");
        }
    }
}
