List<CuentaBancaria> cuentas = new List<CuentaBancaria>();
int opci;
do
{
    Console.WriteLine("Seleccione la acción a realizar\n1) Crear nueva cuenta\n2) Realizar movimientos\n3) Mostrar cuentas\n0) Salir");
    string? auxiliar = Console.ReadLine();
    auxiliar ??= "-1";//para que no salte el cartel de warning
    opci = int.TryParse(auxiliar, out int e) ? e : -1;
    Opciones (opci);
}while(opci != 0);

void Opciones (int op)
{
    int opci2;
    string? tit;
    switch (op)
    {
        case 0:
            Console.WriteLine("Saliendo.");
            break;
        case 1:
            bool valido = false;
            do
            {
                Console.WriteLine("Ingrese el nombre del titular");
                tit = Console.ReadLine();
                valido = (tit == string.Empty) ? false : true;
                if (!valido){Console.WriteLine($"El titular no puede estar vacio");}
            }while(valido != true);
            Console.WriteLine("Indique el tipo de cuenta\n1) Cuenta Corriente\n2) Caja de Ahorros\n0) Volver");
            do
            {
                string? auxiliar = Console.ReadLine();
                auxiliar ??= "-1";//para que no salte el cartel de warning
                opci2 = int.TryParse(auxiliar, out int e) ? e : -1; 
                switch (opci2)
                {
                    case 1:
                        cuentas.Add(new CuentaCorriente(tit));
                        opci2 = 0;
                        break;
                    case 2:
                        cuentas.Add(new CajaAhorros(tit));
                        opci2 = 0;
                        break;
                    default:
                        Console.WriteLine("Opción no valida, intente nuevamente.");
                        break;
                }
            }while(opci2 != 0);
            break;
        case 2:
            Console.WriteLine("Indique movimiento a realizar\n1) Deposito\n2) Retiro\n3) Transferencia\n0) Volver");
            
            break;
        case 3:
            Console.WriteLine("Titular | Tipo Cuenta | CBU | Saldo");
            foreach (var n in cuentas)
            {
                Console.WriteLine($"{n.Titular} | {n.TipoCuenta} | {n.GetCBU()} | {n.GetSaldo()}");
            }
            break;
        default:
            Console.WriteLine("Opción no valida, intente nuevamente.");
            break;
    }
}//Pepe Argento

//fin de main
public interface ITransferible
{
    void Transferir(decimal monto, string cbuDestino);
}
 
abstract class CuentaBancaria:ITransferible
{
    static int Cont = 1;

    protected int CBU;
    public string TipoCuenta {get;}
    public string Titular {get;}
    protected decimal saldo {get; set;}
    // constructor
    public CuentaBancaria( string tipoCuenta, string titular)
    {
        CBU = Cont++;
        TipoCuenta = tipoCuenta;
        Titular = titular;
        saldo = 0;
    }
    public abstract void Retirar(decimal monto);
    public abstract void Depositar(decimal cantidad);

    public void Transferir(decimal monto, string cbuDestino)
    {
        
    }
    public int GetCBU()
    {
        return CBU;
    }
    public decimal GetSaldo()
    {
        return saldo;
    }
}

class CuentaCorriente : CuentaBancaria{
    public CuentaCorriente(string titular) : base("CC", titular)
    {
    }
    public override void Retirar(decimal retiro)
    {
        if ((saldo -retiro)< -10000)
        {
            saldo-=retiro;
            Console.WriteLine("Saldo restante: "+saldo);
        }
        else Console.WriteLine("Monto insuficiente");
    }
    public void Transferir()
    {
        Console.WriteLine("transferir");
    }
    public override void Depositar(decimal Deposito)
    {
        if (Deposito >0)
        {
            saldo+=Deposito;
            Console.WriteLine("Saldo restante: "+saldo);
        }
        else Console.WriteLine("Monto invalido");
    }
}
class CajaAhorros : CuentaBancaria{
    public CajaAhorros(string titular) : base("CA", titular)
    {
    }
    public override void Retirar(decimal retiro)
    {
        if (retiro <= saldo)
        {
            saldo-=retiro;
            Console.WriteLine("Saldo restante: "+saldo);
        }
        else Console.WriteLine("Monto insuficiente");
    }
    public void Transferir()
    {
        Console.WriteLine("transferir");
    }
    public override void Depositar(decimal Deposito)
    {
        if (Deposito >0)
        {
            saldo+=Deposito;
            Console.WriteLine("Saldo restante: "+saldo);
        }
        else Console.WriteLine("Monto invalido");
    }
}
//comentario de prueba