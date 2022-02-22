using API.Enums;
using API.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Cuota : ModelMetadata
    {
        public Decimal Monto { get; set; }
        public Decimal MontoFinal { get; set; }
        public DateTime FechaPagoConfirmado { get; set; }
        public DateTime FechaPendientePagar { get; set; }
        public int DiasMora { get; set; }
        public Decimal Recargo { get; set; }
        public Estado Estado { get; set; }
        public Prestamo Prestamo { get; set; }

        public int GetDiasMora()
        {
            var fechaPendiente = this.FechaPendientePagar;
            var fechaConfirmada = this.FechaPagoConfirmado;

            return (fechaPendiente.Day > fechaConfirmada.Day) ? 0 : (fechaConfirmada.Day - fechaPendiente.Day);
        }

        /* 
            TODO: se debe de revisar como se sumaran los intereses
            - multiplicar el monto a pagar por la tasa de interes y multiplicar dicha suma por la cantidad de (dias, quincenas, mes).
            - Se debe de variar los intereses dependiendo la modalidad de pago.
        */
        public decimal GetInteresesPorMora()
        {
            var modalidadPago = this.Prestamo.Modalidad;

            switch(modalidadPago)
            {
                case Modalidad.Semanal:
                    this.MontoFinal += (Decimal.Add(this.Monto, 9m)) * this.DiasMora;
                break;

                case Modalidad.Quincenal:
                    this.MontoFinal += (Decimal.Add(this.Monto, 9m)) * this.DiasMora;
                break;

                case Modalidad.Mensual:
                    this.MontoFinal += (Decimal.Add(this.Monto, 9m)) * this.DiasMora;
                break;
                
                default:
                    this.MontoFinal += 0;
                break;               
            }

             return this.MontoFinal;
        }

    }
}