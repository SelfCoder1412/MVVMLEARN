using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentDetailAPI.Model;

namespace PaymentDetailAPI.Controller
{
    public class PaymentController
    {
        private readonly PaymentDetailContext _contexto;

        public PaymentController(PaymentDetailContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<IActionResult> Index()
        {
            return null; //View(await _contexto.PaymentDetails.ToListAsync());
        }
    }
}
