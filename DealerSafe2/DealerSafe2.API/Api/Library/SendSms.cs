﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace DealerSafe2.API.Api.Library
{
    public class SendSms
    {
        public SendSms(String ka, String parola, String org)
        {
            start += "<smspack ka=\"" + xmlEncode(ka) + "\" pwd=\"" + xmlEncode(parola)
                    + "\" org=\"" + xmlEncode(org) + "\">";

        }

        public SendSms(String ka, String parola, String org, DateTime tarih)
        {
            start += "<smspack ka=\"" + xmlEncode(ka) + "\" pwd=\"" + xmlEncode(parola) +
                    "\" org=\"" + xmlEncode(org) + "\" tarih=\"" + tarihStr(tarih) + "\">";

        }

        public void addSMS(String mesaj, String[] numaralar)
        {
            body += "<mesaj><metin>";
            body += xmlEncode(mesaj);
            body += "</metin><nums>";
            foreach (String s in numaralar)
            {
                body += xmlEncode(s) + ",";
            }
            body += "</nums></mesaj>";
        }

        public String xml()
        {
            if (body.Length == 0)
                throw new ArgumentException("SMS paketinede sms yok!");
            return start + body + end;
        }

        public String gonder()
        {
            WebClient wc = new WebClient();

            string postData = xml();
            wc.Headers.Add("Content-Type", "text/xml; charset=UTF-8");
            // Apply ASCII Encoding to obtain the string as a byte array.
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            byte[] responseArray = wc.UploadData("https://smsgw.mutlucell.com/smsgw-ws/sndblkex", "POST", byteArray);
            String response = Encoding.UTF8.GetString(responseArray);
            return response;
        }

        /**
         * ka = kullanici adi
         * parola
         * id: gonderim sonucu donen paket ID
         * 
         */
        public static String rapor(String ka, String parola, long id)
        {
            String xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<smsrapor ka=\"" + ka + "\" pwd=\"" + parola + "\" id=\"" + id + "\" />";
            WebClient wc = new WebClient();
            //MessageBox.Show(xml);
            string postData = xml;
            wc.Headers.Add("Content-Type", "text/xml; charset=UTF-8");
            // Apply ASCII Encoding to obtain the string as a byte array.
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            byte[] responseArray = wc.UploadData("https://smsgw.mutlucell.com/smsgw-ws/gtblkrprtex", "POST", byteArray);
            String response = Encoding.UTF8.GetString(responseArray);
            return response;
        }


        private static String tarihStr(DateTime d)
        {
            return xmlEncode(d.ToString("yyyy-MM-dd HH:mm"));
        }

        private static String xmlEncode(String s)
        {
            s = s.Replace("&", "&amp;");
            s = s.Replace("<", "&lt;");
            s = s.Replace(">", "&gt;");
            s = s.Replace("'", "&apos;");
            s = s.Replace("\"", "&quot;");
            return s;
        }

        private String start = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        private String end = "</smspack>";
        private String body = "";
    }
}