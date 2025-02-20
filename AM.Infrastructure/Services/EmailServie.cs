using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Interfaces;

namespace AM.Infrastructure.Services
{
    public class EmailServie : IEmailService
    {
        public async Task<bool> SendEmailAsync(string email, string subject, string body)
        {

            {
                try
                {
                    var smtpClient = new SmtpClient("smtp.gmail.com")  // Gmail SMTP server
                    {
                        Port = 587,  // Port 587 is commonly used for TLS
                        Credentials = new NetworkCredential("hashim104243@gmail.com", "ripq ocvl svqj odsg"),  // Use App Password if using 2FA
                        EnableSsl = true,  // Enable SSL for secure connection
                    };

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("hashim104243@gmail.com"),  // Sender's email address
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = false,  // Set to true if you're sending HTML content
                    };

                     mailMessage.To.Add(email);  // Add recipient's email address


                    await smtpClient.SendMailAsync(mailMessage);
                   
                    return true;// Send the email asynchronously
                }
                catch (Exception ex)
                {
                    // Log error if sending fails
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                return false;
            }
        }
    }

}
