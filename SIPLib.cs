using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Xml;

//github.com    репозиторий
//rfc4317       SDP
//pjsip.org библиотека

namespace SIPLib
{
    public delegate void Del(string str);
    public delegate bool DelRequest(string str);
    


    public class Session    //сама сессия
    {
        Del DelOutput;
        string ToIP;        //IP клиента
        string ToUser;      //имя клиента
        string MyName;    //наше имя
        System.Net.IPAddress myIP;  //наш IP
        int n = 0;  //порядок запроса
        int port;   //порт
        bool SessionConfirmed = false; //флаг подтверждённости сессии (на наш запрос ответили)
        string SessionID;
        Thread WaitForAnswer;


        //==============конструктор==================
        public Session(System.Net.IPAddress myIP, int myPort, string ToIP, string ToUser, string FromUser, Del d, string ID)    //конструктор при звонке
        {
            DelOutput = d;
            this.ToIP = ToIP;
            this.ToUser = ToUser;
            this.MyName = FromUser;
            this.myIP = myIP;
            this.port = myPort;
            this.SessionID = ID;
            n++;
        }

        //==============внешние функции==============
        public string _ToUser
        {
            get
            {
                return ToUser;
            }
        }

        public void CloseSession()
        {


        }

        public bool _SessionConfirmed   
        {
            get
            {
                return SessionConfirmed;
            }
        }

        public string _SessionID
        {
            get
            {
                return this.SessionID;
            }
        }

        /*public bool CheckSessionByFrom(string name,string ip)   //функция проверки по имени и IP 
        {
            if (this.ToUser == name )
            {
                return true;
            }
            return false;
        }*/

        public bool CheckSessionByID(string ID)
        {
            if (this.SessionID == ID) return true;
            else return false;
        }

        public bool WatchInfo(string Info)
        {
            //DelOutput(Info);

            if (Info.Contains("200 OK"))    //ответ
            {
                DelOutput("Получен ACK");
                this.ACKDecompile();
                return true;
            }

            if (Info.Contains("BYE"))    //пока
            {

                return true;
            }

            if (Info.Contains("CANCEL"))    //отмена
            {

                return true;
            }

            if (Info.Contains("REGISTER"))    //регистрация
            {

                return true;
            }

            if (Info.Contains("OPTIONS"))    //запрос свойств
            {

                return true;
            }


            return false;
        }

        //==============внутренние функции==============


        void WaitForAnswerFunc()    //функция проверки активности сессии
        {
            for (int i = 0; i < 40; i++)    //проверяем в течение 4х секунд
            {
                Thread.Sleep(100);
                if (_SessionConfirmed == true) return;// return true;
            }
            

            //вызвать закрытие сессии !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //return false;
            
        }

        bool SendInfo(string Info)
        {
            System.Net.IPAddress ipAddress;         //IP того, кому посылаем
            UdpClient udpClient = new UdpClient();  //создаём UDP клиент

            Byte[] sendBytes = Encoding.ASCII.GetBytes(Info);       //преобразуем строку запроса

            if (System.Net.IPAddress.TryParse(ToIP, out ipAddress))    //получаем адрес компа. out - возвращаем по ссылке
            {
                System.Net.IPEndPoint ipEndPoint = new System.Net.IPEndPoint(ipAddress, port); //создаём точку назначения

                try
                {
                    udpClient.Send(sendBytes, sendBytes.Length, ipEndPoint); //посылаем информацию
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                IPAddress[] ips;
                ips = Dns.GetHostAddresses(ToIP);   //если для сервера и тп
                foreach (IPAddress ip in ips)
                {
                    System.Net.IPEndPoint ipEndPoint = new System.Net.IPEndPoint(ip, port); //создаём точку назначения

                    try
                    {
                        udpClient.Send(sendBytes, sendBytes.Length, ipEndPoint); //посылаем информацию
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                if (ips.Length == 0) return false;
            };

            return true;
        }


                //==создание и разбор внутринностей запросов==
        public void Invite()
        {
            string Request = "";

            Request += "INVITE sip:" + this.ToUser + "@" + this.ToIP + " SIP/2.0 " + "\n";
            Request += "Record-Route: <sip:" + this.ToUser + "@" + this.myIP.ToString() + ";lr>" + "\n";
            Request += "From: " + "\"" + this.MyName + "\"" + "<sip: " + this.MyName + "@" + this.myIP.ToString() + "> " + "\n";
            Request += "To: " + "<sip: " + this.ToUser + "@" + this.ToIP + "> " + "\n";
            Request += "Call-ID: " + SessionID + "@" + this.myIP + "\n";
            Request += "CSeq:" + (++this.n).ToString() + " INVITE" + "\n";

            Request += "Date: " + DateTime.Now.ToString() + "\n";   //дата и время
            Request += "Allow: INVITE, ACK, CANCEL, BYE" + "\n";

            Request += "\n" + SDP();

            SendInfo(Request);
            WaitForAnswer = new Thread(WaitForAnswerFunc);
            WaitForAnswer.Start();

        }

        string InviteDeCompile(string FromIP, string ToIP, string ToUser, string FromUser)
        {
            string Request = "";
            return Request;
        }

        public void ACK()
        {
            string Request = "";
            Request += "SIP/2.0 200 OK" + "\n";
            Request += "From: " + this.MyName + " <sip:" + this.MyName + "@" + this.myIP.ToString() + ">" + "\n";
            Request += "To: <sip: " + this.ToUser + "@" + this.ToIP + ">" + "\n";
            Request += this.SessionID.ToString() + "\n";
            Request += "Cseq: " + (++this.n).ToString() + " OK" + "\n";
            Request += "Date: " + DateTime.Now.ToString() + "\n";
            //????????
            Request += "\n" + SDP();

            SendInfo(Request);
            DelOutput(Request);
            SessionConfirmed = true;

        }
        int ACKDecompile() { return 0; }
        string BYECompile()
        {
            string Request = "";
            Request += "BYE sip:" + ToUser + " SIP/2.0 " + "\n";


            return Request;
        }
        int BYEDecompile() { return 0; }
        string REGISTERCompile() { return null; }
        int REGISTERDecompile() { return 0; }

        string SDP()    //<============================================= обязательно реализовать
        {
            return null;
        }
    }



    //=======================================================================================================================
    //=======================================================================================================================
    //=======================================================================================================================


    public class Listener   //прослушиватель
    {
        
        //==============переменные==============
        static Del DelOutput;   //делегат на вывод пришедшей информации
        static DelRequest DelRequest1;  //делегат на запрос принятия приглашения
        String host = System.Net.Dns.GetHostName();
        System.Net.IPAddress myIP;  //наш IP

        static System.Threading.Mutex Mut = new Mutex();
        Thread ThreadListen;    //поток для прослушки
        static int port;        //номер используемого порта

        static double LastSessionID = 0;
        static string myName;   //имя пользователя

        static List<Session> Sessions = new List<Session>();
        //==============конструкторы==============
        public Listener(int newport, Del d,DelRequest d1, string name) 
        {
            DelOutput = d;
            DelRequest1 = d1;

            myName = name;

            myIP = System.Net.Dns.GetHostByName(host).AddressList[0];    //получаем свой IP
            port = newport;   //устанавливаем номер порта
            ThreadListen = new Thread(ListenSockets);   //настраиваем поток на функцию прослушки
            ThreadListen.Start();
        }

        

        //==============внешние функции==============
        public void MakeCall( string ToIP, string ToUser, string FromUser)
        {
            Sessions.Add(new Session(myIP, port, ToIP, ToUser, FromUser, DelOutput, (LastSessionID++).ToString()));
            Sessions.Last().Invite();
        }

        public bool CheckSessionExistance(string str)
        {
            foreach (Session s in Sessions)
            {
                if (str == s._ToUser) return true;
            }
            return false;
        }

        //==============внутренние функции==============
        public void StopPhone()
        {
            ThreadListen.Abort();
            SendSocket("127.0.0.1", port, "quit");
        }
        static void ListenSockets()  //прослушиваем входящие запросы
        {
            UdpClient receivingUdpClient = new UdpClient(port);    //создаём клиент и задаём порт

            try
            {
                System.Net.IPEndPoint RemoteIpEndPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0);    //принимаем информацию со всех IP по заданному нашему порту

                while (true)
                {
                    Byte[] receiveBytes = receivingUdpClient.Receive(ref RemoteIpEndPoint);
                    WatchInfo(receiveBytes);
                }
            }
            catch (Exception)
            {
                return;
            }

        }
        static bool WatchInfo(Byte[] receiveBytes)  //определяем тип полученной информации и передаём её в нужную функцию разбора
        {
            Mut.WaitOne();  //<=====будет использоваться при многоканальной связи
            string Info = Encoding.ASCII.GetString(receiveBytes);

            string From = Info.Substring(Info.IndexOf("From: "), Info.IndexOf('\n', Info.IndexOf("From: ")) - Info.IndexOf("From: "));    //выделяем строку From
            string tmp, tmp1, tmp2, tmp3;

            if (From.Length <= 0)
            {
                return false;   //если ошибочный запрос (не содержит From)
            }

            From = From.Remove(0, From.IndexOf("sip: ") + "sip: ".Length);
            From = From.Remove(From.IndexOf('>'));

            tmp = Info.Remove(0, Info.IndexOf("To"));
            tmp = tmp.Remove(tmp.IndexOf('@'));
            tmp = tmp.Remove(0, tmp.IndexOf("sip: ") + "sip: ".Length);

            //DelOutput("Получили запрос для: " + tmp);

            if (tmp == myName)  //проверяем: нам ли адресовано
            {
                if (Info.Contains("INVITE "))   //при приходе инвайта
                {
                    if (DelRequest1(From))  //спрашиваем об открытии новой сессии
                    {
                        tmp = Info.Remove(0, Info.IndexOf("To: <sip: ") + "To: <sip: ".Length);
                        tmp = tmp.Remove(tmp.IndexOf('>'));
                        tmp = tmp.Remove(0, tmp.IndexOf('@') + 1);
                       // DelOutput("1"+tmp+"1"); //ToIp
                        tmp2 = Info.Remove(0, Info.IndexOf("To: <sip: ") + "To: <sip: ".Length);
                        tmp2 = tmp2.Remove(tmp2.IndexOf('>'));
                        tmp2 = tmp2.Remove(tmp2.IndexOf('@'));
                        //DelOutput("1" + tmp2 + "1"); //ToUser
                        //DelOutput(From.Remove(From.IndexOf('@'))); //FromUser
                        //DelOutput(From.Remove(0,From.IndexOf('@')+1));  //FromIp

                        tmp3 = Info.Remove(0, Info.IndexOf("Call-ID"));
                        tmp3 = tmp3.Remove(tmp3.IndexOf('\n'));

                        Sessions.Add(new Session(System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0], port, tmp, tmp2, From.Remove(From.IndexOf('@')), DelOutput, tmp3));
                        Sessions.Last().ACK();  //вызов подтверждения
                    }
                    else
                    {
                        return false;
                    }

                    //послать утвердительный ответ из новосозданной сесии <=============================!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    //иначе отрицательный и забыть про всё


                }
                else    //иначе проверяем принадлежность и запускаем разборку запроса в нужной сессии
                {
                    tmp = Info.Remove(0, Info.IndexOf("Call-ID"));
                    tmp = tmp.Remove(tmp.IndexOf('\n'));

                    //DelOutput("ПРИШЁЛ ОТВЕТ");

                    //DelOutput("Число сессий:" + Sessions.Count.ToString() + "\n" + "1" + From + "1");
                    foreach (Session s in Sessions)
                    {
                        //if (s.CheckSessionByFrom(tmp, From.Remove(0, From.IndexOf('@') + 1))) s.WatchInfo(Info);  //проверка по From (имя и IP) и запуск разбора запроса
                        if (s.CheckSessionByID(tmp))
                        {
                            s.WatchInfo(Info);
                            //DelOutput("Ответ дошёл до адресата: " + tmp);
                        }
                    }
                }
            }

            Mut.ReleaseMutex();
            return true;
        }
        bool SendSocket(string ToIP, int port, string Info)  //функция отправки по такому IP, в такой порт, такой инфы
        {
            System.Net.IPAddress ipAddress;         //IP того, кому посылаем
            UdpClient udpClient = new UdpClient();  //создаём UDP клиент
            Byte[] sendBytes = Encoding.ASCII.GetBytes(Info);       //преобразуем строку запроса

            if (!System.Net.IPAddress.TryParse(ToIP, out ipAddress))    //получаем адрес компа. out - возвращаем по ссылке
            {
                return false;
            };

            System.Net.IPEndPoint ipEndPoint = new System.Net.IPEndPoint(ipAddress, port); //создаём точку назначения

            try
            {
                udpClient.Send(sendBytes, sendBytes.Length, ipEndPoint); //посылаем информацию
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }
}
