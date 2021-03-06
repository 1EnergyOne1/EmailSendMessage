using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailSendMessage
{
    class Program
    {
        private static async Task SendEmailAsync()
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("energyone.tony@yandex.ru", "AntonEnergy");
            // кому отправляем
            MailAddress to = new MailAddress("energyone.tony@mail.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Если получится - пойду спать";
            // текст письма
            m.Body = "<h2>Осталось совсем чуть-чуть и всё заработает...</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 465);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("energyone.tony@yandex.ru", "Veo48764511");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
            Console.WriteLine("Всё получилось!");
        }
        public static void Main(string[] args)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("energyone.tony@mail.ru", "AntonEnergy");
            // кому отправляем
            MailAddress to = new MailAddress("energyone.tony@mail.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Если получится - пойду спать";
            // текст письма
            m.Body = "<h2>Осталось совсем чуть-чуть и всё заработает...</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("*", "*");
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.WriteLine("Всё получилось!");
            Console.ReadKey();
        }
    }
}
