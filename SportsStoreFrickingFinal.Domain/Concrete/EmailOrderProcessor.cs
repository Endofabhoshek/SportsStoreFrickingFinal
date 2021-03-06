﻿using SportsStoreFrickingFinal.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStoreFrickingFinal.Domain.Entities;
using System.Net.Mail;
using System.Net;

namespace SportsStoreFrickingFinal.Domain.Concrete
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }


        public void ProcessOrder(Cart cart, ShippingDetails shippingDetaiils)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);
                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod
                    = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder().AppendLine("A new order has been submitted").AppendLine("---").AppendLine("Items: ");
                foreach (var line in cart.Lines)
                {
                    var subTotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity, line.Product.Name, subTotal);

                    body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue()).AppendLine("---").AppendLine("Ship to:")
                        .AppendLine(shippingDetaiils.Name).AppendLine(shippingDetaiils.Line1).AppendLine(shippingDetaiils.Line2 ?? "")
                        .AppendLine(shippingDetaiils.Line3 ?? "").AppendLine(shippingDetaiils.City).AppendLine(shippingDetaiils.State ?? "")
                        .AppendLine(shippingDetaiils.Country).AppendLine(shippingDetaiils.Zip).AppendLine("---")
                        .AppendFormat("Gift wrap: {0}", shippingDetaiils.GiftWrap ? "Yes" : "No");

                    MailMessage mailMessage = new MailMessage(emailSettings.MailFromAddress, emailSettings.MailToAddress, "New Order Sumnitted", body.ToString());

                    if (emailSettings.WriteAsFile)
                    {
                        mailMessage.BodyEncoding = Encoding.ASCII;
                    }
                    smtpClient.Send(mailMessage);
                }
            }
        }
    }

    public class EmailSettings
    {
        public string MailToAddress = "orders@example.com";
        public string MailFromAddress = "sportsstore@example.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"c:\sports_store_emails";

    }
}
