using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeradorNumero.Data;
using GeradorNumero.Models;

namespace GeradorNumero.Controllers{

    [ApiController]
    [Route("v1/cardNumber")]
    public class CardNumberController : ControllerBase{
        
        
         [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<CardNumber>>>  Get(
            [FromServices] Context context,
            [FromQuery] string email
        ){
            
            var cardsNumbers = await context.CardNumbers.Include(x=>x.User).Where(x=>x.User.Email==email).ToListAsync();
            return cardsNumbers;
        }


        [HttpPost]
        public async Task<ActionResult<long>>Post(
            [FromServices] Context context,
            [FromBody] User user
        ){
           var currentUser = await context.Users.FirstOrDefaultAsync(x=>x.Email==user.Email);
           var cardNumber =  new CardNumber();
           cardNumber.Number = new Random().Next(999);
           cardNumber.User = currentUser;
           cardNumber.IdUser = currentUser.Id;
           context.CardNumbers.Add(cardNumber);
           await context.SaveChangesAsync();
           return cardNumber.Number;
        }

    }


}