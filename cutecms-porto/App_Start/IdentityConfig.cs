using cutecms_porto.Areas.Config.Models.DBModel;
using cutecms_porto.Areas.Identity.Models;
using cutecms_porto.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace cutecms_porto
{
    public class EmailService : IIdentityMessageService
    {
        #region Methods
        public Task SendAsync(IdentityMessage message)
        {
            var db = new ConfigEntities();
            var notification = db.Notifications.Include("SMTPSetting").Where(c => c.NotificationCode.Code.Trim().Equals("IDENTITY")).FirstOrDefault();
            if (notification != null)
            {
                string ToAddress = notification.SMTPSetting.RecipientEmail;
                string FromAddress = notification.SMTPSetting.SenderEmail;
                string FromAddressPasswordHash = notification.SMTPSetting.SenderPasswordHash;
                // Send: Configure the client:
                using (var client = new SmtpClient(notification.SMTPSetting.SMTP))
                {
                    client.Port = notification.SMTPSetting.Port;
                    client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    // Create the credentials:
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(FromAddress, FromAddressPasswordHash);
                    client.EnableSsl = true;
                    client.Credentials = credentials;
                    // Create the message:
                    var mail = new System.Net.Mail.MailMessage(FromAddress, message.Destination);
                    mail.Subject = message.Subject;
                    mail.Body = message.Body;
                    mail.IsBodyHtml = true;
                    try
                    {
                        client.Send(mail);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return Task.FromResult(0);
        }
        #endregion Methods
    }

    public class SmsService : IIdentityMessageService
    {
        #region Methods
        public Task SendAsync(IdentityMessage message)
        {
            //string AccountSid = "ACf6bfbd2f69fa96abd2ad9ce0dfc9f5a1";
            //string AuthToken = "74a219e8406afc5adb5dcd883551edcc";
            //string twilioPhoneNumber = "2013807236";
            //var twilio = new TwilioRestClient(AccountSid, AuthToken);
            //twilio.SendMessage(twilioPhoneNumber, message.Destination, message.Body);
            // Twilio does not return an async Task, so we need this:
            return Task.FromResult(0);
        }
        #endregion Methods
    }

    // Configure the application user manager used in this application. UserManager is defined in
    // ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        #region Constructors
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
        #endregion Constructors

        #region Methods
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new CustomUserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails
            // as a step of receiving a code for verifying the user You can write your own provider
            // and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
        #endregion Methods
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        #region Constructors
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
        #endregion Constructors

        #region Methods
        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }
        #endregion Methods
    }
}