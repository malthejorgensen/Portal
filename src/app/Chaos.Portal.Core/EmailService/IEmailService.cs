﻿using System.Collections.Generic;
using System.Xml.Linq;

namespace Chaos.Portal.Core.EmailService
{
	public interface IEmailService
	{
		void Send(string from, string to, string subject, string body);
		void Send(string from, IEnumerable<string> to, string subject, string body);

		void SendTemplate(string from, string to, string subject, XElement bodyTemplate, XElement bodyData);
		void SendTemplate(string from, IEnumerable<string> to, string subject, XElement bodyTemplate, XElement bodyData);

		void SendTemplate(string from, string to, string subject, XElement bodyTemplate, IList<XElement> bodyDatas);
		void SendTemplate(string from, IEnumerable<string> to, string subject, XElement bodyTemplate, IList<XElement> bodyDatas);
	}
}