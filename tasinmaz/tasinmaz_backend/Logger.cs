using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using tasinmaz_backend.Models;
namespace tasinmaz_backend
{
    public class Logger
    {
        public static string LocalIpAddress()
        {
            Func<IPAddress, bool> localIpPredicate = ip =>
                ip.AddressFamily == AddressFamily.InterNetwork &&
                ip.ToString().StartsWith("192.168");
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList.LastOrDefault(localIpPredicate).ToString();
        }

public static Log Loglayıcı(string durum,string islemtipi,string aciklama){

Log log=new Log();

 log.durum=durum;
 log.islemtipi=islemtipi;
 log.Acikklama=aciklama;
 log.tarihsaat=DateTime.Now;
 log.Ip=LocalIpAddress();
return(log);

}




    }
}