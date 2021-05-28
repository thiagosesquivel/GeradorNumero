using System;

namespace GeradorNumero.Models{
    public class CardNumber{
        public int Id {get;set;}
        public long Number {get;set;}
        public int IdUser {get;set;}
        public User User {get;set;}

        public DateTime Data {get;set;} = DateTime.Now;
    
    }
}