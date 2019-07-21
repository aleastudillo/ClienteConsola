using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseConsola
{
    class Cliente
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
    }

    class Factura
    {
        public int ClienteId { get; set; }

        public string Observacion { get; set; }

        public DateTime Fecha { get; set; }

        public int TotalVentas { get; set; }
    }

    class Program
    {
        static bool EsMayor(int n)
        {
            return n > 10;
        }

        static void Main(string[] args)
        {
            List<Cliente> Clientes = new List<Cliente>()
            {
                new Cliente(){ Id=1, Nombre="Alexandra Astudillo"},
                new Cliente(){ Id=2, Nombre="Karla Sanchez"},
                new Cliente(){ Id=3, Nombre="Aracely Tama"},
                new Cliente(){ Id=4, Nombre="Melissa Sancan"},
                new Cliente(){ Id=5, Nombre="Celio Astudillo"},
                new Cliente(){ Id=6, Nombre="Maria Sanchez"},
                new Cliente(){ Id=7, Nombre="Clara Tama"},
                new Cliente(){ Id=8, Nombre="Jordy Lanchimba"}
            };

            List<Factura> Facturas = new List<Factura>()
            {
                new Factura(){ Fecha=new DateTime(2018,06,15,13,12,11), Observacion="Prop", TotalVentas= 12, ClienteId=1},
                new Factura(){ Fecha=new DateTime(2018,06,15,13,12,11), Observacion="En Espera", TotalVentas= 9, ClienteId=2},
                new Factura(){ Fecha=new DateTime(2017,06,13,11,10,09), Observacion="Prop", TotalVentas= 15, ClienteId=3},
                new Factura(){ Fecha=new DateTime(2014,06,14,13,12,11), Observacion="En Espera", TotalVentas= 18, ClienteId=4},
                new Factura(){ Fecha=new DateTime(2013,06,15,13,12,11), Observacion="Prop", TotalVentas= 12, ClienteId=5},
                new Factura(){ Fecha=new DateTime(2016,06,15,13,12,11), Observacion="En Espera", TotalVentas= 29, ClienteId=6},
                new Factura(){ Fecha=new DateTime(2015,06,13,11,10,09), Observacion="Prop", TotalVentas= 19, ClienteId=7},
                new Factura(){ Fecha=new DateTime(2019,07,14,20,12,11), Observacion="En Espera", TotalVentas= 22, ClienteId=8}

            };



            //•	Los clients ordenados por nombre
            Console.WriteLine("*********************************************************************************************");
            var union = from  Fac in Facturas join Clie in Clientes on Fac.ClienteId equals Clie.Id orderby Clie.Nombre select
                        new
                        {
                            NombreClie = Clie.Nombre,
                            FechaFac = Fac.Fecha,
                            ObservacionFac = Fac.Observacion,
                            TotalFac = Fac.TotalVentas
                        };
            Console.WriteLine("Cliente por Nombre: ");
            foreach (var item in union)
            {
                Console.WriteLine(item.NombreClie);
            }
            Console.WriteLine();


            //•	Las ventas ordenadas por fecha
            Console.WriteLine("*********************************************************************************************");
            Console.WriteLine("Ventas por Fechas: ");
            var union1 = from Fac in Facturas orderby Fac.Fecha select Fac;
            foreach (var item in union1)
            {
                Console.WriteLine(item.Fecha);
            }
            Console.WriteLine();



            //•	La venta más antigua.
            Console.WriteLine("*********************************************************************************************");
            Console.WriteLine("Los Clientes con mayor venta: ");
            var ventamas = from Fac in Facturas
                               join Cli in Clientes on Fac.ClienteId equals Cli.Id
                               where Fac.TotalVentas > 20
                               select new
                               {
                                   nombreCli = Cli.Nombre,
                                   totalFac = Fac.TotalVentas
                               };

            foreach (var items in ventamas)
            {
                Console.WriteLine("Cliente: {0}: \n FechaAntigua: {1}", items.nombreCli, items.totalFac);
            }



            //•	Los 3 clientes con mas monto en ventas.
            Console.WriteLine("*********************************************************************************************");
            Console.WriteLine("3 clientes con mas monto: ");
            var mas = from Fac in Facturas
                        join Cli in Clientes on Fac.ClienteId equals Cli.Id
                        where Fac.TotalVentas > 18
                        orderby Fac.TotalVentas
                        select new
                        {
                            nombreCli = Cli.Nombre,
                            totalventa = Fac.TotalVentas
                        };
            foreach (var item in mas)
            {
                Console.WriteLine("Cliente: {0}: \n Total Venta: {1}", item.nombreCli, item.totalventa);
            }
            Console.WriteLine();


            //•	Los 3 clientes con menos monto en ventas.
            Console.WriteLine("*********************************************************************************************");
            Console.WriteLine("3 clientes con menos monto: ");
            var menos = from Fac in Facturas
                            join Cli in Clientes on Fac.ClienteId equals Cli.Id
                        where Fac.TotalVentas <15
                        orderby Fac.TotalVentas
                            select new
                            {
                                nombreCli = Cli.Nombre,
                                totalventa = Fac.TotalVentas
                            };
            foreach (var item in menos)
            {
                Console.WriteLine("Cliente: {0}: \n Total Venta: {1}", item.nombreCli, item.totalventa);
            }
            Console.WriteLine();



            //•	El cliente y la cantidad de ventas realizadas.
            Console.WriteLine("*********************************************************************************************");
            Console.WriteLine("Ventas Realizadas: ");
            var realizado = from Fac in Facturas join Cli in Clientes on Fac.ClienteId equals Cli.Id
                            orderby Fac.TotalVentas select new
                            {
                                nombreCli = Cli.Nombre,
                                totalventa = Fac.TotalVentas
                            };
            foreach (var item in realizado)
            {
                Console.WriteLine("Cliente: {0}: \n Total Venta: {1}", item.nombreCli, item.totalventa);
            }
            Console.WriteLine();



            //•	Las ventas realizadas hace menos de 1 año.
            Console.WriteLine("*********************************************************************************************");
            Console.WriteLine("Los Clientes venta menos de 1 año: ");
            var fechamenos = from Fac in Facturas join Cli in Clientes on Fac.ClienteId  equals Cli.Id 
                             where Fac.Fecha > Convert.ToDateTime("2018-01-01")
                             orderby Fac.Fecha select new
                             {
                                 nombreCli = Cli.Nombre,
                                 fechaFac = Fac.Fecha
                             };
            DateTime fecha = DateTime.Today;
            foreach (var items in fechamenos)
                {
                    Console.WriteLine("Cliente: {0}: \n Fecha Menos: {1}", items.nombreCli, items.fechaFac);
                }
            Console.WriteLine();



            //•	La venta más antigua.
            Console.WriteLine("*********************************************************************************************");
            Console.WriteLine("Los Clientes fecha mas antigua: ");
            DateTime fecha1 = DateTime.Today;
            var fechaantigua = from Fac in Facturas
                             join Cli in Clientes on Fac.ClienteId equals Cli.Id
                               where Fac.Fecha < Convert.ToDateTime("2019-01-01")
                               select new
                             {
                                 nombreCli = Cli.Nombre,
                                 fechaFac = Fac.Fecha
                             };
           
            foreach (var items in fechaantigua)
            {
                Console.WriteLine("Cliente: {0}: \n FechaAntigua: {1}", items.nombreCli, items.fechaFac);
            }
            Console.WriteLine();




            //•	La última venta realizada.
            Console.WriteLine("*********************************************************************************************");
            Console.WriteLine("Los Clientes ultima venta: ");
            var ultima = from Fac in Facturas
                             join Cli in Clientes on Fac.ClienteId equals Cli.Id
                             where Fac.Fecha >= Convert.ToDateTime("2019-07-14")
                         orderby Fac.Fecha
                             select new
                             {
                                 nombreCli = Cli.Nombre,
                                 fechaFac = Fac.Fecha
                             };
            foreach (var items in ultima)
            {
                Console.WriteLine("Cliente: {0}: \n Fecha Menos: {1}", items.nombreCli, items.fechaFac);
            }
            Console.WriteLine();


                       

            //•	Los clientes que tengan una venta cuya observación comience con "Prob"
            Console.WriteLine("*********************************************************************************************");
            Console.WriteLine("Clientes que tengan una venta cuya observación comience con Prob ");
            var prop = from Fac in Facturas join Cli in Clientes on Fac.ClienteId equals Cli.Id
                               where Fac.Observacion.Contains("Prop") select new
                               {
                                   nombreCli = Cli.Nombre,
                                   obsFac = Fac.Observacion
                               };

            foreach (var items in prop)
            {
                Console.WriteLine("Cliente: {0}: \n Observacion: {1}", items.nombreCli, items.obsFac);
            }
            Console.ReadKey();
        }
    }    
}