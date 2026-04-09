
// fin main
public interface ITransferible
{
    void Retirar();
}
abstract class Cuenta(){}

class CuentaCorriente : Cuenta, ITransferible(){

}

class CajaAhorros : Cuenta, ITransferible (){

}

class Banco (){

}