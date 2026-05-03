List<CuentaBancaria> cuentas = new List<CuentaBancaria>();
cuentas.Add(new CuentaCorriente("Pepe Argento"));
cuentas.Add(new CajaAhorros("Dardo Fuseneco"));
int opci;
do
{
    Console.WriteLine("Seleccione la acción a realizar\n1) Crear nueva cuenta\n2) Realizar movimientos\n3) Mostrar cuentas\n0) Salir");
    opci = (int)LeerNumero();
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
                opci2 = (int)LeerNumero(); 
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
             do
            {
                opci2 = (int)LeerNumero();
                int k;
                decimal Cant;
                switch (opci2)
                {
                    case 1:
                        k = SolicitarCuenta(true);
                        if (k > -1 && k < cuentas.Count)
                        {
                            Console.WriteLine("Ingrese la cantidad a depositar");
                            Cant = LeerNumero();
                            cuentas[k].Depositar(Cant);
                        }
                        else
                        {
                            Console.WriteLine("CBU no encontrado");
                        }
                        opci2 = 0;
                        break;
                    case 2:
                        k = SolicitarCuenta(false);
                        if (k > -1 && k < cuentas.Count)
                        {
                            Console.WriteLine("Ingrese la cantidad a retirar");
                            Cant = LeerNumero();
                            cuentas[k].Retirar(Cant);
                        }
                        else
                        {
                            Console.WriteLine("CBU no encontrado");
                        }
                        opci2 = 0;
                        break;
                    case 3:
                        k = SolicitarCuenta(false);
                        if (k > -1 && k < cuentas.Count)
                        {
                            int k2 = SolicitarCuenta(true);
                            if (k2 > -1 && k2 < cuentas.Count)
                            {
                                Console.WriteLine("Ingrese la cantidad a transferir");
                                Cant = LeerNumero();
                                if (cuentas[k].Transferir(Cant)){
                                cuentas[k].Retirar(Cant);
                                    cuentas[k2].Depositar(Cant);
                                }
                                else
                                {
                                    Console.WriteLine("La cuenta de origen no posee fondos suficientes para realizar esta acción");
                                }
                            }
                        }
                        opci2 = 0;
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opción no valida, intente nuevamente.");
                        break;
                }
            }while(opci2 != 0);
            break;
        case 3:
            ImplimirCuentas(cuentas);
            break;
        default:
            Console.WriteLine("Opción no valida, intente nuevamente.");
            break;
    }
}//Pepe Argento

int SolicitarCuenta(bool o)
{
    string oyd = (o) ? "destino" : "origen";
    Console.WriteLine($"Ingrese el CBU de la cuenta {oyd}");
    int CBUsol = (int)LeerNumero();
    return BuscarCuenta(cuentas,CBUsol);
}

void ImplimirCuentas(List<CuentaBancaria> lista)
{
    Console.WriteLine("Titular | Tipo Cuenta | CBU | Saldo");
            foreach (var n in lista)
            {
                Console.WriteLine($"{n.Titular} | {n.TipoCuenta} | {n.GetCBU()} | {n.GetSaldo()}");
            }
}

int BuscarCuenta (List<CuentaBancaria> lista, int ñ)
{
    int i = -1;
    foreach (var item in lista)
    {
        if (item.CBU == ñ)
        {
            i = lista.IndexOf(item);
            continue;
        }
    }
    return i;
}

decimal LeerNumero()
{
    string? auxiliar = Console.ReadLine();
    auxiliar ??= "-1";//para que no salte el cartel de warning
    return decimal.TryParse(auxiliar, out decimal e) ? e : -1;
}
//fin de main
public interface ITransferible
{
bool Transferir(decimal monto);
}
 
abstract class CuentaBancaria:ITransferible
{
    static int Cont = 1;

    public int CBU {get ; init;}
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
    public void Retirar(decimal monto)
    {
        if (Transferir(monto))
        {
         saldo-=monto;
         Console.WriteLine("Saldo restante: "+saldo);   
        
        }else
        {
            Console.WriteLine("Saldo insuficiente");
        }
    }
    public void Depositar(decimal deposito)
    {
        if (deposito >0)
        {
            saldo+=deposito;
            Console.WriteLine("Saldo actual: "+saldo);
        }
        else {Console.WriteLine("Monto invalido");}
    }

    public abstract bool Transferir(decimal monto);
    
    
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
   
    public override bool Transferir(decimal monto)
    {
    
        return (saldo - monto >= -10000) ? true : false;
    }
    
}
class CajaAhorros : CuentaBancaria{
    public CajaAhorros(string titular) : base("CA", titular)
    {
    }
    
    public override bool Transferir(decimal monto)
    {
    return (saldo - monto >= 0) ? true : false;
    }
}
//comentario de prueba