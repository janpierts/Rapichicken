using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace RapiChicken.Util
{
    public class TwilioHelper
    {	
		private string AccSid, AuthT, MyPhn;
        private SMSSettings _smsSettings = new SMSSettings();
		
       public string SendSMSMessage()
        {
			
			var Sid = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            AccSid = Sid.GetSection("Twilio:TwilioAccountSid").Value;
			
			var Token = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            AuthT = Token.GetSection("Twilio:TwilioAuthToken").Value;
			
			var Phone = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            MyPhn = Phone.GetSection("Twilio:MyPhoneNumber").Value;

        TwilioClient.Init(
			AccSid,AuthT
                    //_smsSettings.Twilio_Account_SID,
                    //_smsSettings.Twilio_Auth_TOKEN
                );
		
		
		var message = MessageResource.Create(
            body: "This is the ship that made the Kessel Run in fourteen parsecs?",
            from: new Twilio.Types.PhoneNumber(MyPhn),
            to: new Twilio.Types.PhoneNumber("+51922480608")
			);

            return message.Sid;

            /*var message = MessageResource.Create(
            body: "This is the ship that made the Kessel Run in fourteen parsecs?",
            from: new Twilio.Types.PhoneNumber("+16403446189"),
            to: new Twilio.Types.PhoneNumber("+51922480608")
			);

            return message.Sid;*/
        }
    }
}
